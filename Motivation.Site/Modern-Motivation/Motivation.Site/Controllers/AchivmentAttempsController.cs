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
    public class AchivmentAttempsController : ODataController
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
				   from at in _db.Set<AchivmentType>().Where(i => i.Id == aa.AchivnedTypeId)
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

	    public AchivmentAttempDto Get([FromODataUri] int id)
	    {
		    var item = CreateQuery().FirstOrDefault(i => i.Id == id);
			if(item == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
		    return item;
	    }

	    public IHttpActionResult Post(AchivmentAttempDto model)
	    {
		    try
		    {
			    var result = _db.Set<AchivmentAttemp>().Add(new AchivmentAttemp
			    {
				    UserId = model.UserId,
				    Comment = model.Comment,
				    FileName = model.FileName,
				    FileUrl = model.FileUrl,
				    FileExt = model.FileExt,
				    CreateDate = DateTime.Now
			    });
			    _db.SaveChanges();
			    model.Id = result.Id;
			    return Ok(model);
		    }
		    catch
		    {
			    return BadRequest();
		    }
	    }

	    public IHttpActionResult Update(int key, AchivmentAttempDto model)
	    {
		    try
		    {
			    var set = _db.Set<AchivmentAttemp>();
			    var oldModel = set.Find(key);
			    if (oldModel == null)
				    return NotFound();
			    oldModel.FileExt = model.FileExt;
			    oldModel.FileName = model.FileName;
			    oldModel.FileUrl = model.FileUrl;
			    oldModel.Comment = model.Comment;
			    _db.SaveChanges();
			    return Ok(model);
		    }
		    catch (Exception)
		    {
			    return BadRequest();
		    }
	    }

		public virtual IHttpActionResult Delete(int id)
		{
			var dbSet = _db.Set<AchivmentAttemp>();
			var entity = dbSet.Find(id);
			if (entity == null)
				return NotFound();
			dbSet.Remove(entity);
			return Ok();
		}
	}
}
