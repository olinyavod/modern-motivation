namespace Motivation.Models
{
	public class UserProduct : EntityBase
	{
		public int ProductId { get; set; }

		public virtual Product Product { get; set; }

		public int UserId { get; set; }

		public virtual User User { get; set; }

		public int Count { get; set; }
	}
}