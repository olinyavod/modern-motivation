using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class AchivmentAttempConfiguration : EntityTypeConfiguration<AchivmentAttemp>
	{
		public AchivmentAttempConfiguration()
		{
			ToTable("dbo.AchivmentAttemps");

			HasKey(m => m.Id);

			HasRequired(m => m.User)
				.WithMany()
				.HasForeignKey(m => m.UserId);

			HasOptional(m => m.AcceptUser)
				.WithMany()
				.HasForeignKey(m => m.AcceptUserId);

			HasOptional(m => m.AchivmentType)
				.WithMany()
				.HasForeignKey(m => m.AchivnedTypeId);
		}
	}
}