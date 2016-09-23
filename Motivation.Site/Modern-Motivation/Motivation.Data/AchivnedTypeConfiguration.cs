using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class AchivnedTypeConfiguration : EntityTypeConfiguration<AchivnedType>
	{
		public AchivnedTypeConfiguration()
		{
			ToTable("dbo.AchivnedType");

			HasKey(m => m.Id);

			HasRequired(m => m.TypicalType)
				.WithMany()
				.HasForeignKey(m => m.TypicalTypeId);
		}
	}
}