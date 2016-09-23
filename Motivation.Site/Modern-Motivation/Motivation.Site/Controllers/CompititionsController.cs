using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using Motivation.Data;
using Motivation.Models;
using Motivation.Site.Models;

namespace Motivation.Site.Controllers
{
	public class CompititionsController : ODataController
	{
		MotivationDb _context = new MotivationDb();

		[EnableQuery]
		public IQueryable<CompititionDto> GetByUserId(int userId)
		{
			var query = from u in _context.Set<User>()
				from g in _context.Set<UserGroup>().Where(i => i.Id == u.UserGroupId)
				from cross in _context.Set<CompititionGroup>().Where(i => i.UserGroupId == g.Id)
				where u.Id == userId
				select cross.CompititionId;
			var ids = query.ToList();
			return from c in _context.Set<Compitition>()
				   where ids.Contains(c.Id)
				   select new CompititionDto
				   {
						Id = c.Id,
					   Comment = c.Comment,
					   EndDate = c.EndDate,
					   ImageUrl = c.ImageUrl,
					   StartDate = c.StartDate
				   };
		}

		public CompititionDto Get([FromODataUri]int id)
		{
			var item = _context.Set<Compitition>()
				.Select(i => new CompititionDto
				{
					Id = i.Id,
					Comment = i.Comment,
					StartDate = i.StartDate,
					ImageUrl = i.ImageUrl,
					EndDate = i.EndDate
				}).FirstOrDefault();
			if(item == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			return item;
		}
	}
}