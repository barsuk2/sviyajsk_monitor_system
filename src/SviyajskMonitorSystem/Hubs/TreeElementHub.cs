using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DataViewModels;
using SviyajskMonitorSystem.Models.DynamicFields;
using SviyajskMonitorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Hubs
{
    public class TreeElementHub : Hub
    {
        ApplicationDbContext _context;
        FileUpload _upload;
        public TreeElementHub(IServiceProvider sp)
        {
            var services = sp.CreateScope();
            _context = services.ServiceProvider.GetService<ApplicationDbContext>();
            _upload = services.ServiceProvider.GetService<FileUpload>();
        }


        public List<ElementViewModel> GetElements()
        {
            List<Element> elements = _context.Element.Include(el => el.Parent).ToList();
            List<ElementViewModel> elementvm = new List<ElementViewModel>();
            foreach (var el in elements)
            {
                elementvm.Add(new ElementViewModel(el));
            }
            // string els = JsonConvert.SerializeObject(elements);
            return elementvm;
        }


        public List<ElementViewModel> GetTreeEls(int elid, int typeid)
        {
            TreeRoot root = _context.Roots.Include(r => r.elements).ThenInclude(els => els.parent).Include(r => r.element).FirstOrDefault(r => r.element.Id == elid && r.treetype.id == typeid);
            List<ElementViewModel> elementvm = new List<ElementViewModel>();
            foreach (var item in root.elements)
            {
                elementvm.Add(new ElementViewModel(item));
            }
            return elementvm;
        }


        public List<string> GetTypeNames()
        {
            List<TreeType> types = _context.Treetypes.ToList();
            List<string> names = new List<string>();
            foreach (var t in types) { names.Add(t.name); }
            return names;
        }


        public void InitTreeRedactor(int element, string typename)
        {
            TreeType ttype = _context.Treetypes.Include(tt => tt.keys).ThenInclude(k => k.entitytype).FirstOrDefault(tt => tt.name == typename);
            TreeRoot root = _context.Roots.Include(r => r.element).FirstOrDefault(r => r.element.Id == element && r.treetype.name == typename);
            if (root == null)
            {
                root = new TreeRoot();
                root.element = _context.Element.FirstOrDefault(el => el.Id == element);
                root.treetype = ttype;
                _context.Roots.Add(root);
                TreeElement treeel = new TreeElement()
                {
                    materialobject = root.element,
                    parent = null,
                    root = root,
                    identifier = root.element.Name
                };
                _context.Treeelements.Add(treeel);
                _context.SaveChanges();
            }
            InitTreeViewModel tvm = new InitTreeViewModel()
            {
                elid = root.element.Id,
                elname = root.element.Name,
                treeType = ttype
            };
            Clients.Caller.SetTreeType(tvm);

        }


        public List<EntityValue> GetValues(int typeid)
        {

            List<EntityValue> values = _context.Values.Include(v => v.type).Where(v => v.type.Id == typeid).ToList();

            return values;
        }


        public long CreateEl(int parent,string name, List<AttributeValueViewModel> values)
        {
            TreeElement parentel = _context.Treeelements.Include(tel=>tel.root).FirstOrDefault(tel => tel.id == parent);
            TreeElement treeel = new TreeElement
            {
                parent = parentel,
                identifier = name,
                values = new List<AbstractAttributeValue>(),
                root=parentel.root
            };
            _context.Treeelements.Add(treeel);
            _context.SaveChanges();
            foreach (var value in values)
            {
                treeel.values.Add(BuildValue(value));
            }
            _context.SaveChanges();
            return treeel.id;
        }



        public void RemoveElement(int id)
        {
            TreeElement treeel = _context.Treeelements.FirstOrDefault(tel => tel.id == id);
            RemoveElement(treeel);
        }

        void RemoveElement(TreeElement element)
        {
            element = _context.Treeelements.Include(el => el.children).FirstOrDefault(el => el.id == element.id);
            foreach (var el in element.children)
            {
                RemoveElement(el);
            }
            element = _context.Treeelements.Include(el => el.values).ThenInclude(v => v.attributekey).FirstOrDefault(el => el.id == element.id);
            foreach(var value in element.values)
            {
                RemoveValue(value);
            }
            _context.Treeelements.Remove(element);
            _context.SaveChanges();
        }


        #region ValueBuilders
        AbstractAttributeValue BuildValue(AttributeValueViewModel model)
        {
            switch (model.type)
            {
                case AttributeTypes.intval: return BuildIntVal(model);
                case AttributeTypes.floatval: return BuildFloatVal(model);
                case AttributeTypes.stringval: return BuildStringVal(model);
                case AttributeTypes.Choosable: return BuildChoosablevalue(model);
                case AttributeTypes.photo: return BuildPhotoValue(model);
                case AttributeTypes.elements: return BuildElementsValue(model);
                default: return null;
            }
        }

        IntAttributeValue BuildIntVal(AttributeValueViewModel model)
        {
            IntAttributeValue intval = new IntAttributeValue();
            intval.intvalue = int.Parse(model.value);
            intval.attributekey = _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.Intvalues.Add(intval);
            return intval;
        }

        FloatAttributeValue BuildFloatVal(AttributeValueViewModel model)
        {
            FloatAttributeValue floatval = new FloatAttributeValue();
            floatval.floatvalue = float.Parse(model.value);
            floatval.attributekey= _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.Floatvalues.Add(floatval);
            return floatval;
        }

        StringAttributeValue BuildStringVal(AttributeValueViewModel model)
        {
            StringAttributeValue stringval = new StringAttributeValue();
            stringval.stringvalue = model.value;
            stringval.attributekey= _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.Stringvalues.Add(stringval);
            return stringval;
        }

        ChooseAttributeValue BuildChoosablevalue(AttributeValueViewModel model)
        {
            ChooseAttributeValue chooseval = new ChooseAttributeValue();
            chooseval.value = _context.Values.FirstOrDefault(ev => ev.id == int.Parse(model.value));
            chooseval.attributekey= _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.Chooseattribute.Add(chooseval);
            return chooseval;
        }

        PhotoAttributeValue BuildPhotoValue(AttributeValueViewModel model)
        {
            PhotoAttributeValue photoval = new PhotoAttributeValue();
            string[] phids = model.value.Split(';');
            foreach (var phid in phids)
            {
                photoval.photos.Add(_context.Photos.FirstOrDefault(p => p.Id == int.Parse(phid)));
            }
            photoval.attributekey= _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.Photosattribute.Add(photoval);
            return photoval;
        }

        ElementsAttributeValue BuildElementsValue(AttributeValueViewModel model)
        {
            ElementsAttributeValue elsvalue = new ElementsAttributeValue();
            elsvalue.MatObjects = model.value;
            elsvalue.attributekey= _context.Attributekeys.FirstOrDefault(k => k.id == model.keyid);
            _context.ElementsAttribute.Add(elsvalue);
            return elsvalue;
        }
        #endregion


        #region ValueRemovers
         void RemoveValue(AbstractAttributeValue value)
        {
            switch (value.attributekey.type)
            {
                case AttributeTypes.intval: RemoveInt((IntAttributeValue)value);
                    break;
                case AttributeTypes.floatval:RemoveFloat((FloatAttributeValue)value);
                    break;
                case AttributeTypes.stringval:Removestring((StringAttributeValue)value);
                    break;
                case AttributeTypes.Choosable:RemoveChoose((ChooseAttributeValue)value);
                    break;
                case AttributeTypes.photo:RemovePhoto((PhotoAttributeValue)value);
                    break;
                case AttributeTypes.elements:RemoveElements((ElementsAttributeValue)value);
                    break;
              
            }

        }


         void RemoveInt(IntAttributeValue value)
        {
            _context.Intvalues.Remove(value);
        }

        void RemoveFloat(FloatAttributeValue value)
        {
            _context.Floatvalues.Remove(value);
        }

        void Removestring(StringAttributeValue value)
        {
            _context.Stringvalues.Remove(value);
        }

        void RemoveChoose(ChooseAttributeValue value)
        {
            _context.Chooseattribute.Remove(value);
        }

        void RemovePhoto(PhotoAttributeValue value)
        {
            value = _context.Photosattribute.Include(v => v.attributekey).Include(v => v.photos).FirstOrDefault(v => v.id == value.id);
            foreach(var photo in value.photos)
            {
                _upload.RemovePhoto(photo.Id);
                _context.Photos.Remove(photo);
            }
            _context.Photosattribute.Remove(value);
        }

        void RemoveElements(ElementsAttributeValue value)
        {
            _context.ElementsAttribute.Remove(value);
        }
        #endregion
    }
}
