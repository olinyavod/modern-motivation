using System.IO;

namespace Motivation.Models
{
	public class AchivnedType : EntityBase
	{
		public string Comment { get; set; }

		public int MaxCount { get; set; }

		public int ExpCount { get; set; }

		public int CoinsCount { get; set; }

		public string ImageUrl { get; set; }


	}
}