using Motivation.Data;
using Motivation.Models;
using Motivation.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Motivation.Site.Controllers
{
    public class AnketaController : Controller
    {
        MotivationDb contextDb;

        public AnketaController() {
            contextDb = new MotivationDb();
        }
        
        // GET: Anketa
        public ActionResult Index()
        {
            List<UserDto> usr = CreateQuery(1).ToList();

            return View(usr);
        }

        IQueryable<UserDto> CreateQuery(int _userId)
        {
            return from u in contextDb.Set<User>()
                   from g in contextDb.Set<UserGroup>().Where(g => g.Id == u.UserGroupId)
                   .Where(x => u.Id == _userId)
                   select new UserDto
                   {
                       Login = u.Login,
                       Name = u.Name,
                       UserGroupTitle = g.Name,
                       AvatarUrl = u.AvatarUrl
                   };
        }
    }
}