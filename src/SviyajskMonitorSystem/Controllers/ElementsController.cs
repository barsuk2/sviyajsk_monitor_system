using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SviyajskMonitorSystem.Controllers
{
    [Authorize]
    public class ElementsController : Controller
    {

        public ApplicationDbContext context;

        public ElementsController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [Authorize(Roles = "Researcher")]
        public IActionResult CreateEl()
        {
            string name = Request.Form.FirstOrDefault(f => f.Key == "elname").Value;
            int parentid;
            try
            {
                 parentid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "parentid").Value);
            }
            catch
            {
                parentid = -1;
            }
            Element el = new Element();
            if (parentid > 0)
            {
              //  el.culcherobject = context.element.Include(e => e.culcherobject).FirstOrDefault(e => e.id == parentid).culcherobject;
            }
            if (name != "")
            {
                el.Name = name;
                //  el.OnCreate(context.Users.FirstOrDefault(us => us.UserName == User.Identity.Name.ToString()));
                context.Element.Add(el);
                el.Parent = context.Element.FirstOrDefault(e => e.Id == parentid);
                context.SaveChanges();
            }
            return Ok();
        }
        [Authorize(Roles = "Researcher")]
        public void DelEl(int elid)
        {
            Element el = context.Element.Include(e=>e.Childs).FirstOrDefault(e => e.Id == elid);
            List<Element> childs = el.Childs;
            foreach(var item in childs)
            {
                DelEl(item.Id);
                
            }
            context.Element.RemoveRange(childs);
            context.Element.Remove(el);
        }
        [Authorize(Roles = "Researcher")]
        public IActionResult DelelteEl()
        {
            int elid = int.Parse(Request.Form.FirstOrDefault(f => f.Key == "elid").Value);
            DelEl(elid);
            try
            {
                context.SaveChanges();
            }
            catch { }
            return Ok();
        }



        List<Element> Getchildlist(int pid)
        {
            List<Element> ellist = null;
            Element el = context.Element.Include(e => e.Childs).FirstOrDefault(e => e.Id == pid);
            ellist = el.Childs;
            List<Element> childnodes = new List<Element>();
            foreach(var element in ellist)
            {
               childnodes.AddRange(Getchildlist(element.Id));
            }
            ellist.AddRange(childnodes);
            return ellist;
        }


        [AllowAnonymous]
        public IActionResult GetAllElements()
        {
            List<TreeViewModel> treeelements = new List<TreeViewModel>();
            foreach (var item in context.Element.Include(el => el.Childs).Include(el => el.Parent))
            {
                treeelements.Add(new TreeViewModel(item));
            }
            return new JsonResult(treeelements);
        }

        public IActionResult GetJson(int pid)
        {
            List<Element> ellist = null;
            if (pid > 0)
            {
                ellist = Getchildlist(pid);
               // ViewBag.PID = el.id;
            }
            else
            {
                ViewBag.PID = -1;
                ellist = context.Element.Include(e => e.Parent).ToList();
            }
            List<TreeViewModel> elobjs = new List<TreeViewModel>();
            foreach (var item in ellist)
            {
                elobjs.Add(new TreeViewModel(item));
                
            }
           // string s = JsonConvert.SerializeObject(elobjs);

            return new JsonResult(elobjs);
        }


        public IActionResult GetJsonByOKN(string id)
        {
            List<Element> ellist =new List<Element>();

            int pid = int.Parse(id);
            if (pid > 0)
            {
                ellist = Getchildlist(pid);
                // ViewBag.PID = el.id;
            }
            else
            {
                ViewBag.PID = -1;
                ellist = context.Element.Include(e => e.Parent).ToList();
            }
            ellist.Add(context.Element.FirstOrDefault(el => el.Id.ToString() == id));

            List<TreeViewModel> elobjs = new List<TreeViewModel>();
            foreach (var item in ellist)
            {
                elobjs.Add(new TreeViewModel(item));

            }
            // string s = JsonConvert.SerializeObject(elobjs);

            return new JsonResult(elobjs);
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.CulObj = context.CulcherObject;
            return View();
        }
    }
}
