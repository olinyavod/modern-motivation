using Motivation.Data;
using Motivation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Motivation.Site.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("ViewPage1");
        }

        [HttpPost]
        public ActionResult Logon(string txtUserName, string txtUserPass)
        {
            using (MotivationDb context = new MotivationDb())
            {
                User user = context.Set<User>().Where(x => x.Login == txtUserName && x.Password == txtUserPass).FirstOrDefault();
                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    return RedirectToAction("Home", "Index");
                }
            }
            return View("Login");
        }
    }
}