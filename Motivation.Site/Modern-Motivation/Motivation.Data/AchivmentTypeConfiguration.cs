using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class AchivmentTypeConfiguration : EntityTypeConfiguration<AchivmentType>
	{
		public AchivmentTypeConfiguration()
		{
			ToTable("dbo.AchivmentType");

			HasKey(m => m.Id);

			
		}
	}
}