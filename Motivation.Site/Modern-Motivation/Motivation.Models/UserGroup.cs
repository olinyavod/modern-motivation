namespace Motivation.Models
{
	public class UserGroup : EntityBase
	{
		public string Name { get; set; }

		public UserGroupType Type { get; set; }
	}
}