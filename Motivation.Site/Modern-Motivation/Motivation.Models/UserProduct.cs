namespace Motivation.Models
{
	public class UserProduct : EntityBase
	{
		public int ProductId { get; set; }

		public Products Products { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}