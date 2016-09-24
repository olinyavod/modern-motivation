namespace Motivation.Models
{
	public class CompititionGroup : EntityBase
	{
		public int CompititionId { get; set; }

		public virtual Compitition Compitition { get; set; }

		public virtual UserGroup UserGroup { get; set; }

		public int UserGroupId { get; set; }
	}
}