using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class TypicalAchivnedTypeConfiguration : EntityTypeConfiguration<TypicalAchivnedType>
	{
		public TypicalAchivnedTypeConfiguration()
		{
			ToTable("dbo.TypicalAchivnedTypes");

			HasKey(m => m.Id);
		}
	}
}