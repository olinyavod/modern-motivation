namespace Motivation.Mobile.Models
{
	public class UserStore
	{
		public const string Key = "UserStore";

		public int UserId { get; set; }

		public bool HasUser { get; set; }
	}
}
