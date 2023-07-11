using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DynamicFields;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Services;

namespace SviyajskMonitorSystem.Controllers
{
    public class TreeElementController : Controller
    {

        ApplicationDbContext context;

        public TreeElementController(ApplicationDbContext _context)
        {
            context = _context;
        }


        public IActionResult Index()
        {
            ViewData["TreeTypes"] = context.Treetypes.ToList<IChoosable>();
            return View();
        }

        //public IActionResult CreateTree()
        //{
        //    int treetypeid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "treetypes").Value);
        //    int elid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "elid").Value);

        //    TreeType type = context.Treetypes.Include(t => t.keys).ThenInclude(k=>k.entitytype).FirstOrDefault(t => t.id == treetypeid);
        //    Element el = context.Element.FirstOrDefault(e => e.Id == elid);
        //    TreeRoot root = context.Roots.Include(r => r.treetype).Include(r => r.element).FirstOrDefault(r => r.element.Id == elid && r.treetype.id == treetypeid);
        //    if (root == null)
        //    {
        //        //TreeType
        //        root = new TreeRoot();
        //        root.treetype = type;
        //        root.root = new TreeElement()
        //        {
        //            identifier = el.Name,
        //            materialobject = el,
        //            type = type
        //        };
        //        root.element = el;
        //        context.Roots.Add(root);
        //        context.SaveChanges();
        //    }
        //    ViewData["EValues"] = context.Values.Include(v => v.type).ToList();
        //    foreach (var item in root.treetype.keys)
        //    {
        //        if (item.type == AttributeTypes.Choosable)
        //        {
        //            ViewData[item.entitytype.Name] = context.Values.Include(v => v.type).Where(v => v.type.Id == item.entitytype.Id).ToList();
        //        }
        //    }
        //    return View("CreateTree",root);
        //}


        //public JsonResult GetTree(int id,int rootid)
        //{
        //    List<TreeElement> els = null;
        //    if (id > 0)
        //    {
        //       els = getchildlist(id);
        //    }
        //    else
        //    {
        //        TreeElement el = context.Roots.Include(r => r.root).FirstOrDefault(r => r.id == rootid).root;
        //        els = getchildlist(el.id);
        //        els.Add(el);
        //    }
        //    List<TreeViewModel> treeels = new List<TreeViewModel>();
        //    foreach(var item in els)
        //    {
        //        treeels.Add(new TreeViewModel(item));
        //    }
        //    return Json(treeels);
        //}

        List<TreeElement> getchildlist(long pid)
        {
            List<TreeElement> ellist = null;
            TreeElement el = context.Treeelements.Include(e => e.children).Include(e=>e.parent).FirstOrDefault(e => e.id == pid);
            ellist = el.children;
            List<TreeElement> childnodes = new List<TreeElement>();
            foreach (var element in ellist)
            {
                childnodes.AddRange(getchildlist(element.id));
            }
            ellist.AddRange(childnodes);
            return ellist;
        }



        public IActionResult CreateEl()
        {
            int rootid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "Treeid").Value);
            string identifier = Request.Form.FirstOrDefault(f => f.Key == "indentifier").Value;
            int parentid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "elementid").Value);
            TreeType type = context.Roots.Include(r => r.treetype).ThenInclude(tt => tt.keys).FirstOrDefault(r => r.id == rootid).treetype;
            TreeElement el = new TreeElement()
            {
                identifier = identifier,
                type = type,
                parent = context.Treeelements.FirstOrDefault(te => te.id == parentid),
                values=new List<AbstractAttributeValue>()

            };
            context.Treeelements.Add(el);
            context.SaveChanges();
            foreach(var key in type.keys)
            {
                AbstractAttributeValue val = null;
                switch (key.type)
                {
                    case AttributeTypes.Choosable: val = buildchoosablevalue(key); break;
                    case AttributeTypes.stringval: val = buildstringvalue(key);break;
                    case AttributeTypes.intval: val = buildintvalue(key);break;
                    case AttributeTypes.floatval:val = buildfloatvalue(key);break;
                    case AttributeTypes.photo:val = buildPhotoValue(key);break;
                }
                if (val != null)
                {
                    el.values.Add(val);
                }
            }
            context.SaveChanges();
            return Ok();
        }



        AbstractAttributeValue buildchoosablevalue(AttributeKey key)
        {
            ChooseAttributeValue value = new ChooseAttributeValue();
            int valid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == key.name).Value);
            value.attributekey = key;
            value.value = context.Values.FirstOrDefault(v => v.id == valid);
            context.Chooseattribute.Add(value);
            context.SaveChanges();
            
            return value;
        }



        AbstractAttributeValue buildstringvalue(AttributeKey key)
        {
            StringAttributeValue value = new StringAttributeValue
            {
                attributekey = key,
                stringvalue = Request.Form.FirstOrDefault(f => f.Key == key.name).Value
            };
            context.Stringvalues.Add(value);
            context.SaveChanges();
            return value;

        }


        AbstractAttributeValue buildintvalue(AttributeKey key)
        {
            IntAttributeValue value = new IntAttributeValue();
            value.attributekey = key;
            value.intvalue =int.Parse(Request.Form.FirstOrDefault(f => f.Key == key.name).Value);
            context.Intvalues.Add(value);
            context.SaveChanges();
            return value;
        }


        AbstractAttributeValue buildfloatvalue(AttributeKey key)
        {
            FloatAttributeValue value = new FloatAttributeValue
            {
                attributekey = key,
                floatvalue = float.Parse(Request.Form.FirstOrDefault(f => f.Key == key.name).Value)
            };
            context.Floatvalues.Add(value);
            context.SaveChanges();
            return value;
        }

        AbstractAttributeValue buildPhotoValue(AttributeKey key)
        {
            PhotoAttributeValue value = new PhotoAttributeValue();
            value.photos = new List<Photo>();
            value.attributekey = key;
            var files= Request.Form.Files.GetFiles(key.name);
            FileUpload fupl = new FileUpload("/photos/");
            foreach(var photo in files)
            {
                Photo ph = new Photo();
                context.Photos.Add(ph);
                context.SaveChanges();
                fupl.SaveFile(photo, ph.Id.ToString());
                value.photos.Add(ph);
            }
            return value;

        }

        public IActionResult GetElementInfo()
        {
            try
            {
                int id = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "elemid").Value);
                TreeElement el = context.Treeelements.Include(e => e.values).ThenInclude(e => e.attributekey).FirstOrDefault(t => t.id == id);

                foreach (var item in el.values)
                {
                    if (item.attributekey.type == AttributeTypes.Choosable)
                    {
                        ((ChooseAttributeValue)item).value = context.Chooseattribute.Include(i => i.value).FirstOrDefault(val => val.id == item.id).value;
                    }
                    if (item.attributekey.type == AttributeTypes.photo)
                    {
                        ((PhotoAttributeValue)item).photos = context.Photosattribute.Include(p => p.photos).FirstOrDefault(pat => pat.id == item.id).photos;
                    }
                }

                return PartialView("ElDataView", el.values);
            }
            catch
            {
                return Ok();
            }
        }


        public IActionResult CreateTreeType()
        {
            return View();
        }











    }
}