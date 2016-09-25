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
        public ActionResult Index()
        {
            int UserId;
            if (Session["UserId"] == null)
            {
                UserId = 1;
            }
            else
            {
                UserId = Convert.ToInt32(Session["UserId"]);
            }

            List<UserAchivment> achivement;

            achivement = _context.UserAchivments.Where(x=>x.UserId == UserId).ToList();
            achivement = _context.UserAchivments.ToList();

            ViewBag.Achivements = achivement;

            return View();

        }
    }
}