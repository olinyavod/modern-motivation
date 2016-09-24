using System;
using System.ComponentModel.DataAnnotations;
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
		public string UserGroupTitle { get; set; }
		public bool IsGeneral { get; set; }
        public string AvatarUrl { get; set; }
        public string Information { get; set; }
    }
}
