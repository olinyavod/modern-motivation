using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class UserProductConfiguration : EntityTypeConfiguration<UserProduct>
	{
		public UserProductConfiguration()
		{
			ToTable("dbo.UserProducts");

			HasRequired(m => m.User)
				.WithMany()
				.HasForeignKey(m => m.UserId);

			HasRequired(m => m.Product)
				.WithMany()
				.HasForeignKey(m => m.ProductId);
		}
	}
}