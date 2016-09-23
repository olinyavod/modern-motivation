using System;

namespace Motivation.Models
{
	public class Compitition : EntityBase
	{
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Comment { get; set; }

		public string ImageUrl { get; set; }
	}
}