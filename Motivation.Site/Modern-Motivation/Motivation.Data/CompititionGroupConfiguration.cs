using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class CompititionGroupConfiguration : EntityTypeConfiguration<CompititionGroup>
	{
		public CompititionGroupConfiguration()
		{
			ToTable("dbo.CompititionGroup");

			HasKey(m => m.Id);

			HasRequired(m => m.UserGroup)
				.WithMany()
				.HasForeignKey(m => m.UserGroupId);

			HasRequired(m => m.Compitition)
				.WithMany()
				.HasForeignKey(m => m.CompititionId);
		}
	}
}