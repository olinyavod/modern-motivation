namespace Motivation.Models
{
	public class CompititionAchivmentType : EntityBase
	{
		public int CompititionId { get; set; }

		public virtual Compitition Compitition { get; set; }

		public virtual AchivmentType AchivmentType { get; set; }

		public int AchivnedTypeId { get; set; }
	}
}