using System;

namespace Motivation.Models
{
	public class AchivmentAttemp : EntityBase
	{
		public string FileName { get; set; }

		public string FileExt { get; set; }

		public string FileUrl { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }

		public bool IsCompleted { get; set; }

		public bool IsAccepted { get; set; }

		public User AcceptUser { get; set; }

		public int? AcceptUserId { get; set; }

		public string Comment { get; set; }

		public AchivmentType AchivmentType { get; set; }

		public int? AchivnedTypeId { get; set; }

		public DateTime CreateDate { get; set; }
	}
}