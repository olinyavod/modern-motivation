using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motivation.Data.Migrations
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
