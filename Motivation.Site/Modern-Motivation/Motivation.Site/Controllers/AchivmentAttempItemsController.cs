using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using Motivation.Data;
using Motivation.Models;
using Motivation.Site.Models;

namespace Motivation.Site.Controllers
{
    public class AchivmentAttempItemsController : ODataController
    {
		MotivationDb _db = new MotivationDb();

	    protected override void Dispose(bool disposing)
	    {
		    base.Dispose(disposing);
			if(disposing)
				_db.Dispose();
	    }

	    IQueryable<AchivmentAttempDto> CreateQuery()
	    {
			return from aa in _db.Set<AchivmentAttemp>()
				   from au in _db.Set<User>().Where(i => i.Id == aa.AcceptUserId).DefaultIfEmpty()
				   from aug in _db.Set<UserGroup>().Where(i => i.Id == au.UserGroupId).DefaultIfEmpty()
				   from at in _db.Set<AchivmentType>().Where(i => i.Id == aa.AchivnedTypeId).DefaultIfEmpty()
				   select new AchivmentAttempDto
				   {
					   Id = aa.Id,
					   Comment = aa.Comment,
					   UserId = aa.UserId,
					   CreateDate = aa.CreateDate,
					   FileExt = aa.FileExt,
					   FileName = aa.FileName,
					   FileUrl = aa.FileUrl,
					   IsAccepted = aa.IsAccepted,
					   IsCompleted = aa.IsCompleted,
					   AcceptUserName = au.Name,
					   AcceptUserGroupName = aug.Name,
					   AchivmentTypeComment = at.Comment,
					   AchivmentTypeMaxCount = at.MaxCount,
					   AchivmentTypeExpCount = at.ExpCount,
					   AchivmentTypeCoinsCount = at.CoinsCount,
					   AchivmentTypeImageUrl = at.ImageUrl
				   };
		}

		[EnableQuery]
	    public IQueryable<AchivmentAttempDto> Get()
		{
			return CreateQuery();
		}

		[EnableQuery]
	    public SingleResult<AchivmentAttempDto> Get([FromODataUri] int id)
	    {
		    var item = CreateQuery().Where(i => i.Id == id);
			return SingleResult.Create(item);
	    }


	    
	}
}
