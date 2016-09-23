namespace Motivation.Models
{
	public class UserProduct : EntityBase
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public int Count { get; set; }
	}
}