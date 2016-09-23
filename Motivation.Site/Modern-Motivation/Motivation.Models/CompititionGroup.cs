namespace Motivation.Models
{
	public class CompititionGroup : EntityBase
	{
		public int CompititionId { get; set; }

		public Compitition Compitition { get; set; }

		public UserGroup UserGroup { get; set; }

		public int UserGroupId { get; set; }
	}
}