namespace Motivation.Models
{
	public class CompititionAchivmentType : EntityBase
	{
		public int CompititionId { get; set; }

		public Compitition Compitition { get; set; }

		public AchivmentType AchivmentType { get; set; }

		public int AchivnedTypeId { get; set; }
	}
}