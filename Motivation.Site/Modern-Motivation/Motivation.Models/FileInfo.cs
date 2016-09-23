using System;

namespace Motivation.Models
{
	public class FileInfo : EntityBase
	{
		public string Name { get; set; }

		public string Ext { get; set; }

		public int OwnerId { get; set; }

		public User Owner { get; set; }

		public DateTime CreatedDate { get; set; }

		public string SourceUrl { get; set; }
	}
}