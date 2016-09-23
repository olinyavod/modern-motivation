using System;

namespace Motivation.Models
{
	public class UserAchivment : EntityBase
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public DateTime Date { get; set; }

		public AchivmentType AchivmentType { get; set; }

		public int AchivnedTypeId { get; set; }

		public string Comment { get; set; }
	}
}