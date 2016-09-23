namespace Motivation.Models
{
	public class CompititionAchivnedType : EntityBase
	{
		public int CompititionId { get; set; }

		public Compitition Compitition { get; set; }

		public AchivnedType AchivnedTypeId { get; set; }

		public int AchivnedType { get; set; }
	}
}