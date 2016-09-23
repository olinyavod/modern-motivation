using System.Data.Entity.ModelConfiguration;
using Motivation.Models;

namespace Motivation.Data
{
	public class FileInfoConfiguration : EntityTypeConfiguration<FileInfo>
	{
		public FileInfoConfiguration()
		{
			ToTable("dbo.FIleInfos");

			HasKey(m => m.Id);

			HasRequired(m => m.Owner)
				.WithMany()
				.HasForeignKey(m => m.OwnerId);
		}
	}
}