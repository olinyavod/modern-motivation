using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class CompititionAchivmentTypeConfiguration : EntityTypeConfiguration<CompititionAchivmentType>
	{
		public CompititionAchivmentTypeConfiguration()
		{
			ToTable("dbo.CompititionAchivmentypes");

			HasKey(m => m.Id);

			HasRequired(m => m.AchivmentType)
				.WithMany()
				.HasForeignKey(m => m.AchivnedTypeId);

			HasRequired(m => m.Compitition)
				.WithMany()
				.HasForeignKey(m => m.CompititionId);

		}
	}


}