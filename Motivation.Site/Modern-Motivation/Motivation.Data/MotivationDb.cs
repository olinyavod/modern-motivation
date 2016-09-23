using System.Data.Entity;

namespace Motivation.Data
{
	public class MotivationDb : DbContext
	{
		public MotivationDb()
		{
			
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.AddFromAssembly(typeof(MotivationDb).Assembly);
		}
	}
}
