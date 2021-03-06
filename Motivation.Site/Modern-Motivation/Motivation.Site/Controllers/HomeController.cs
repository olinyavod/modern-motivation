﻿using Motivation.Data;
using Motivation.Models;
using Motivation.Site.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Motivation.Site.Controllers
{
	public class HomeController : Controller
	{
        MotivationDb baseContent = new MotivationDb();

        public ActionResult Index()
		{
            List<AchivmentModelView> achList;
            List<AchivmentModelView> newsList;

            achList = CreateQuery(2, 10).ToList();
            newsList = CreateQuery(0, 100).ToList();

            ViewBag.AchivmentModels = achList;
            ViewBag.NewsModels = newsList;

            baseContent.Dispose();

            return View();
		}

        public ActionResult GetDepartmentList()
        {
            List<UserGroup> groupsList;
            using (MotivationDb context = new MotivationDb())
            {
                groupsList = context.Set<UserGroup>().ToList();
            }
            return View(groupsList);
        }


        public ActionResult Login()
        {
            return Redirect("~/Pages/Users.aspx");
        }

        public ActionResult Anketa()
        {
            return Redirect("~/Anketa/Index");
        }

        public ActionResult GetCompetitions()
        {
            List<Compitition> competitionList;
            using (MotivationDb context = new MotivationDb())
            {
                competitionList = context.Set<Compitition>().ToList();
            }
            return View(competitionList);
        }

        public ActionResult GetRatingList()
        {
            List<User> userList;
            List<UserGroup> groupsList;
            List<User> userMoneyList;
            using (MotivationDb context = new MotivationDb())
            {
                userList = context.Set<User>().OrderBy(x => x.Exp).OrderByDescending(x=>x.Exp).Take(4).ToList();
                groupsList = context.Set<UserGroup>().Take(3).ToList();
                userMoneyList = context.Set<User>().Where(x=>x.CoinsCount > 0).OrderByDescending(x => x.CoinsCount).Take(4).ToList();
            }

            ViewBag.Groups = groupsList;
            ViewBag.MoneyList = userMoneyList;
            return View("GetRating", userList);
        }

        IQueryable<AchivmentModelView> CreateQuery(int _userId, int _count)
        {
            return from u in baseContent.Set<UserAchivment>()
                   from a in baseContent.Set<AchivmentType>().Where(a => a.Id == u.AchivnedTypeId)
                   from g in baseContent.Set<User>().Where(i => i.Id == u.UserId && (u.UserId == _userId || _userId == 0))
                   .OrderBy(x => u.Date)
                   .OrderByDescending(x => u.Date)
                   .Take(_count)
                   select new AchivmentModelView
                   {
                       Date = u.Date,
                       AchivmentComment = u.Comment,
                       AchivmentName = a.Comment,
                       UserName = g.Name
                   };
        }

        public ActionResult Shop()
		{


			return View();
		}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}