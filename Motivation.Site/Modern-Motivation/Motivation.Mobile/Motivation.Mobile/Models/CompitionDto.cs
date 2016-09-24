using System;
using Motivation.DataContract;

namespace Motivation.Mobile.Models
{
	public class CompitionDto : ICompititionContract
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Comment { get; set; }
		public string ImageUrl { get; set; }
	}
}