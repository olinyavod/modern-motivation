using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

		[EnableQuery]
		public IQueryable<AchivmentAttemp> Get()
		{
			return _db.Set<AchivmentAttemp>();
		}

		[EnableQuery]
		public SingleResult<AchivmentAttemp> Get([FromODataUri] int id)
		{
			var item = _db.Set<AchivmentAttemp>().Where(i => i.Id == id);
			return SingleResult.Create(item);
		}

		public IHttpActionResult Post(AchivmentAttemp model)
		{
			try
			{
				var result = _db.Set<AchivmentAttemp>()
					.Add(model);
				_db.SaveChanges();
				model.Id = result.Id;
				return Created(model);
			}
			catch
			{
				return BadRequest();
			}
		}

		public IHttpActionResult Put([FromODataUri]int key, AchivmentAttemp model)
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
				return Updated(model);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

	    public IHttpActionResult Patch([FromODataUri]int id, Delta<AchivmentAttemp> delta)
	    {
		    try
		    {
				var set = _db.Set<AchivmentAttemp>();
				var oldModel = set.Find(id);
				if (oldModel == null)
					return NotFound();
				delta.Patch(oldModel);
				_db.SaveChanges();
				return Updated(oldModel);
			}
		    catch (Exception)
		    {
			    return BadRequest();
			    throw;
		    }
	    }

		public virtual IHttpActionResult Delete(int id)
		{
			var dbSet = _db.Set<AchivmentAttemp>();
			var entity = dbSet.Find(id);
			if (entity == null)
				return NotFound();
			dbSet.Remove(entity);
			_db.SaveChanges();
			return Ok();
		}
	}
}
