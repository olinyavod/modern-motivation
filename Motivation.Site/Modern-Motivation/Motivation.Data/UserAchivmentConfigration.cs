using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class UserAchivmentConfigration : EntityTypeConfiguration<UserAchivment>
	{
		public UserAchivmentConfigration()
		{
			ToTable("dbo.UserAchivments");

			HasKey(m => m.Id);

			HasRequired(m => m.AchivmentType)
				.WithMany()
				.HasForeignKey(m => m.AchivnedTypeId);

			HasRequired(m => m.User)
				.WithMany()
				.HasForeignKey(m => m.UserId);
		}
	}
}