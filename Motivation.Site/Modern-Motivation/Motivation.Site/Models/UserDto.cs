using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Mapping;
using System.Web.UI;
using Motivation.DataContract;
using Motivation.Models;

namespace Motivation.Site.Models
{
	public class UserDto : IUserContract
    {
		[Key]
		public int Id { get; set; }
		public string Login { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string UserGroupTitle { get; set; }
		public string AvatarUrl { get; set; }
		public bool IsGeneral { get; set; }
    }
}
