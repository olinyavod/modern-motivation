namespace Motivation.Models
{
	public class AchivmentAttemp : EntityBase
	{
		public FileInfo File { get; set; }

		public int FileId { get; set; }

		public User User { get; set; }

		public int UserId { get; set; }

		public bool IsCompleted { get; set; }

		public bool IsAccepted { get; set; }

		public User AcceptUser { get; set; }

		public int? AcceptUserId { get; set; }

		public string Comment { get; set; }

		public AchivnedType AchivnedType { get; set; }

		public int AchivnedTypeId { get; set; }
	}
}