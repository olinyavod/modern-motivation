namespace Motivation.Models
{
	public class UserGroup : EntityBase
	{
		public string Name { get; set; }

		public UserGroupType Type { get; set; }
	}

	public class Products : EntityBase
	{
		public string Name { get; set; }

		public string Comment { get; set; }

		public string ImageUrl { get; set; }

		public int Price { get; set; }
	}
}