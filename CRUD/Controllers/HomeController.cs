using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {

            using (var context = new TestEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
                String msg = "Created record succressfully !!";
                ViewBag.Message = msg;
                return RedirectToAction("Read");
            }
        }

        public ActionResult Edit(int ID)
        {
            using (var context = new TestEntities())
            {
                var data = context.Users.Where(x => x.ID == ID).SingleOrDefault();
                if (data != null)
                {
                    return View(data);
                }
                else {
                    return View("Error");
                }
            }
        }


        [HttpPost]
        public ActionResult Edit(int ID, User model)
        {
            using (var context = new TestEntities())
            {
                var data = context.Users.Where(x => x.ID == ID).SingleOrDefault();
                if (data != null)
                {
                    data.Name = model.Name;
                    data.password = model.password;
                    data.Desgn = model.Desgn;

                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public ActionResult Read(User model)
        {
            using (var context = new TestEntities())
            {
                var data = context.Users.ToList();
                return View(data);
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID, User model)
        {
            using (var context = new TestEntities())
            {
                var data = context.Users.Where(x => x.ID == ID).SingleOrDefault();
                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    return View("Error");
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            using (var context = new TestEntities())
            {
                var data = context.Users.Where(x => x.ID == ID).SingleOrDefault();
                if (data != null)
                {
                    context.Users.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}