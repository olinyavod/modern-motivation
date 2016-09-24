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

        public System.Data.Entity.DbSet<Motivation.Models.UserAchivment> UserAchivments { get; set; }

        public System.Data.Entity.DbSet<Motivation.Models.AchivmentType> AchivmentTypes { get; set; }

        public System.Data.Entity.DbSet<Motivation.Models.User> Users { get; set; }
    }
}
