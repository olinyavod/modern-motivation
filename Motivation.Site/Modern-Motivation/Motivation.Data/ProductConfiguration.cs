using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class ProductConfiguration : EntityTypeConfiguration<Product>
	{
		public ProductConfiguration()
		{
			ToTable("dbo.Products");

			HasKey(m => m.Id);
		}
	}
}