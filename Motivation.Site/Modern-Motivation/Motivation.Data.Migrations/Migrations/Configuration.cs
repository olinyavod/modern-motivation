using System.Data.Entity.Migrations;

namespace Motivation.Data.Migrations.Migrations
{
	public class Configuration:DbMigrationsConfiguration<MotivationDb>
	{
		public Configuration()
		{
			AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(MotivationDb context)
		{
			base.Seed(context);


		}
	}
}
