using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("dbo.Users");

			HasKey(m => m.Id);

			HasRequired(m => m.UserGroup)
				.WithMany()
				.HasForeignKey(m => m.UserGroupId);
		}
	}
}
