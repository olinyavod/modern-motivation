using Motivation.Data;
using Motivation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Motivation.Site.Controllers
{
    public class AchivementController : Controller
    {
        MotivationDb _context;
        public AchivementController() {
            _context = new MotivationDb();
        }

        // GET: Achivement
        public ActionResult Index(int? UserId)
        {
            if (Request.QueryString["UserId"] == null)
            {
                UserId = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            }

            List<UserAchivment> achivement;

            ///achivement = _context.UserAchivments.Where(x=>x.UserId == UserId).ToList();
            achivement = _context.UserAchivments.ToList();

            ViewBag.Achivements = achivement;
            //ViewBag.Name = _context.Users.Where(x => x.Id == UserId).FirstOrDefault().Name;

            return View();

        }
    }
}