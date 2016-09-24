using System;

namespace Motivation.Models
{
	public class AchivmentAttemp : EntityBase
	{
		public string FileName { get; set; }

		public string FileExt { get; set; }

		public string FileUrl { get; set; }

		public virtual User User { get; set; }

		public int UserId { get; set; }

		public bool IsCompleted { get; set; }

		public bool IsAccepted { get; set; }

		public virtual User AcceptUser { get; set; }

		public int? AcceptUserId { get; set; }

		public string Comment { get; set; }

		public virtual AchivmentType AchivmentType { get; set; }

		public int? AchivnedTypeId { get; set; }

		public DateTime CreateDate { get; set; }
	}
}