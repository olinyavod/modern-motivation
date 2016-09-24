using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using Motivation.Data;
using Motivation.Models;
using Motivation.Site.Models;

namespace Motivation.Site.Controllers
{
    public class UsersController : ODataController
    {
		MotivationDb _context = new MotivationDb();

	    protected override void Dispose(bool disposing)
	    {
		    base.Dispose(disposing);
			if(disposing)
				_context.Dispose();
	    }

	    [EnableQuery]
	    public IQueryable<UserDto> Get()
	    {
		    return CreateQuery();
	    }

	    IQueryable<UserDto> CreateQuery()
	    {
			return from u in _context.Set<User>()
				   from g in _context.Set<UserGroup>().Where(i => i.Id == u.UserGroupId)
				   select new UserDto
				   {
					   Id = u.Id,
					   Name = u.Name,
					   Password = u.Password,
					   Login = u.Login,
					   IsGeneral = u.IsGeneral,
					   UserGroupTitle = g.Name
				   };
		}

	    public UserDto Get([FromODataUri] int id)
	    {
		    var item = CreateQuery().FirstOrDefault(i => i.Id == id);
		    if (item == null)
			    throw new HttpResponseException(HttpStatusCode.NotFound);
		    return item;
	    }
    }
}
