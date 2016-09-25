using Motivation.DataContract;

namespace Motivation.Mobile.Models
{
	public class UserDto : IUserContract
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public string UserGroupTitle { get; set; }
		public string AvatarUrl { get; set; }

		public bool IsGeneral { get; set; }
	}
}