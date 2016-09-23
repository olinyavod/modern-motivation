using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class CompititionConfiguration : EntityTypeConfiguration<Compitition>
	{
		public CompititionConfiguration()
		{
			ToTable("dbo.Compititions");

			HasKey(m => m.Id);

			HasRequired(m => m.User)
				.WithMany()
				.HasForeignKey(m => m.UserId);
		}
	}
}