using Crud_Application_DB_first_Approach.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Application_DB_first_Approach.Controllers
{
    public class RegistrationController : Controller
    {
        CRUDPracticeEntitiy db = new CRUDPracticeEntitiy();
        public ActionResult Index()
        {
            var data = db.Users.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            db.Users.Add(user);
            var Name = user.Name;
            db.SaveChanges();
            TempData["Msg"] = $"{Name} has been created";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var exists = db.Users.Find(user.Id);
            if(exists!=null)
            {
                exists.Name = user.Name;
                exists.Password = user.Password;
                exists.Email = user.Email;
                exists.Dob = user.Dob;

                db.SaveChanges();
                TempData["Msg"] = $"{exists.Name} has been updated";
                return RedirectToAction("Index");
            } 
            else
            {
                return HttpNotFound();
            }
        }
    }
}
