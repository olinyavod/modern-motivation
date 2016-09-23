using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Motivation.Models;

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

			context.Set<UserGroup>()
				.AddOrUpdate(m => m.Type, new UserGroup
				{
					Name = "Активные продажи", Type = UserGroupType.ActiveSales
				}, new UserGroup
				{
					Name = "Продажи и обслуживание", Type = UserGroupType.SalesSupport
				}, 
				new UserGroup
				{
					Name = "Отдел по работе с крупными закупками B2B", Type = UserGroupType.B2B
				},
				new UserGroup
				{
					Name = "Отдел по работе с крупными закупками B2B", Type = UserGroupType.B2G
				},
				new UserGroup
				{
					Name = "Администратор", Type = UserGroupType.Admin
				});

			

		}
	}
}
