using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motivation.Models;
using Motivation.Site.Models;
using Motivation.Data;

namespace Motivation.Site.Controllers
{
    public class NewsController : Controller
    {
        List<AchivmentAttempDto> list;

        public NewsController() {
            list = new List<AchivmentAttempDto>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetNews()
        {
            return View();
        }


    }
}