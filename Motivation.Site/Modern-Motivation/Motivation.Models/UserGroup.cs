namespace Motivation.Models
{
	public class UserGroup : EntityBase
	{
		public string Name { get; set; }

		public virtual UserGroupType Type { get; set; }
	}
}