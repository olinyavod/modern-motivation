using Motivation.Data;
using Motivation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Motivation.Site.Controllers
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
                userList = context.Set<User>().OrderBy(x => x.Exp).OrderByDescending(x=>x.Exp).ToList();
                groupsList = context.Set<UserGroup>().ToList();
                userMoneyList = context.Set<User>().Where(x=>x.CoinsCount > 0).OrderByDescending(x => x.CoinsCount).ToList();
            }

            ViewBag.Groups = groupsList;
            ViewBag.MoneyList = userMoneyList;
            return View("GetRating", userList);
        }

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

	}
}