namespace Motivation.Models
{
	public class Product : EntityBase
	{
		public string Name { get; set; }

		public string Comment { get; set; }

		public string ImageUrl { get; set; }

		public int Price { get; set; }
	}
}