using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegForm.Models;

namespace UserRegForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            using (DBModels db = new DBModels())
            {
                if (db.Users.Any(x => x.Username == user.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("Index", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Saved Successfully";
                return View("Index", new User());
            }
        }
    }
}