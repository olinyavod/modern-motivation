using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Motivation.Models;
using Motivation.Site.Models;

namespace Motivation.Site.Controllers
{
    public class NewsController : Controller
    {
        private OperationDataContext context;
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

        [HttpPost]
        public ActionResult GetLastAch(User EmployeeId)
        {
            IList<AchivmentAttempDto> AchivmentList = new List<AchivmentAttempDto>();

            var query = 
                from book in context.BOOKs
                join publisher in context.Publishers
                on book.PublisherId equals publisher.Id
                select new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublisherName = publisher.Name,
                    Auther = book.Auther,
                    Year = book.Year,
                    Price = book.Price
                };

            return View();
        }
    }
}