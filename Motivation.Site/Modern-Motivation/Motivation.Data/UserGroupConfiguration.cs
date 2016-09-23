using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>
	{
		public UserGroupConfiguration()
		{
			ToTable("dbo.UserGroups");

			HasKey(m => m.Id);
		}
	}
}