namespace Motivation.Models
{
	public class AchivnedType : EntityBase
	{
		public int TypicalTypeId { get; set; }

		public TypicalAchivnedType TypicalType { get; set; }

		public int MaxCount { get; set; }

		public int ExpCount { get; set; }

		public int CoinsCount { get; set; }


	}
}