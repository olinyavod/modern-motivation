using System;
using System.ComponentModel.DataAnnotations;
using Motivation.DataContract;

namespace Motivation.Site.Models
{
	public class CompititionDto : ICompititionContract
	{
		[Key]
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Comment { get; set; }
		public string ImageUrl { get; set; }
	}
}