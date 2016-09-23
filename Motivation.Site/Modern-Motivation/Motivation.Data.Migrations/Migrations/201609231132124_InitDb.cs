namespace Motivation.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.Products",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Name = c.String(),
					Comment = c.String(),
					ImageUrl = c.String(),
					Price = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.AchivmentType",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Comment = c.String(),
					MaxCount = c.Int(nullable: false),
					ExpCount = c.Int(nullable: false),
					CoinsCount = c.Int(nullable: false),
					ImageUrl = c.String(),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
		        "dbo.UserGroups",
		        c => new
		        {
			        Id = c.Int(nullable: false, identity: true),
			        Name = c.String(),
			        Type = c.Int(nullable: false),
		        })
		        .PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Users",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Login = c.String(),
					Name = c.String(),
					Password = c.String(),
					UserGroupId = c.Int(nullable: false),
					IsGeneral = c.Boolean(nullable: false),
					Birthday = c.DateTime(),
					Exp = c.Int(nullable: false),
					CoinsCount = c.Int(nullable: false),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.UserGroups", t => t.UserGroupId, cascadeDelete: false)
				.Index(t => t.UserGroupId);

			CreateTable(
                "dbo.AchivmentAttemps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileExt = c.String(),
                        FileUrl = c.String(),
                        UserId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        AcceptUserId = c.Int(),
                        Comment = c.String(),
                        AchivnedTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AcceptUserId)
                .ForeignKey("dbo.AchivmentType", t => t.AchivnedTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.AcceptUserId)
                .Index(t => t.AchivnedTypeId);
            
            CreateTable(
                "dbo.dbo/CompititionAchivmentypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompititionId = c.Int(nullable: false),
                        AchivnedTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AchivmentType", t => t.AchivnedTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Compititions", t => t.CompititionId, cascadeDelete: false)
                .Index(t => t.CompititionId)
                .Index(t => t.AchivnedTypeId);
            
            CreateTable(
                "dbo.Compititions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ImageUrl = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CompititionGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompititionId = c.Int(nullable: false),
                        UserGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compititions", t => t.CompititionId, cascadeDelete: false)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupId, cascadeDelete: false)
                .Index(t => t.CompititionId)
                .Index(t => t.UserGroupId);
            
            
            
            CreateTable(
                "dbo.UserAchivments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AchivnedTypeId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AchivmentType", t => t.AchivnedTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.AchivnedTypeId);
            
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserAchivments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAchivments", "AchivnedTypeId", "dbo.AchivmentType");
            DropForeignKey("dbo.CompititionGroup", "UserGroupId", "dbo.UserGroups");
            DropForeignKey("dbo.CompititionGroup", "CompititionId", "dbo.Compititions");
            DropForeignKey("dbo.dbo/CompititionAchivmentypes", "CompititionId", "dbo.Compititions");
            DropForeignKey("dbo.Compititions", "UserId", "dbo.Users");
            DropForeignKey("dbo.dbo/CompititionAchivmentypes", "AchivnedTypeId", "dbo.AchivmentType");
            DropForeignKey("dbo.AchivmentAttemps", "UserId", "dbo.Users");
            DropForeignKey("dbo.AchivmentAttemps", "AchivnedTypeId", "dbo.AchivmentType");
            DropForeignKey("dbo.AchivmentAttemps", "AcceptUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserGroupId", "dbo.UserGroups");
            DropIndex("dbo.UserProducts", new[] { "UserId" });
            DropIndex("dbo.UserProducts", new[] { "ProductId" });
            DropIndex("dbo.UserAchivments", new[] { "AchivnedTypeId" });
            DropIndex("dbo.UserAchivments", new[] { "UserId" });
            DropIndex("dbo.CompititionGroup", new[] { "UserGroupId" });
            DropIndex("dbo.CompititionGroup", new[] { "CompititionId" });
            DropIndex("dbo.Compititions", new[] { "UserId" });
            DropIndex("dbo.dbo/CompititionAchivmentypes", new[] { "AchivnedTypeId" });
            DropIndex("dbo.dbo/CompititionAchivmentypes", new[] { "CompititionId" });
            DropIndex("dbo.Users", new[] { "UserGroupId" });
            DropIndex("dbo.AchivmentAttemps", new[] { "AchivnedTypeId" });
            DropIndex("dbo.AchivmentAttemps", new[] { "AcceptUserId" });
            DropIndex("dbo.AchivmentAttemps", new[] { "UserId" });
            DropTable("dbo.UserProducts");
            DropTable("dbo.UserAchivments");
            DropTable("dbo.Products");
            DropTable("dbo.CompititionGroup");
            DropTable("dbo.Compititions");
            DropTable("dbo.dbo/CompititionAchivmentypes");
            DropTable("dbo.AchivmentType");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.AchivmentAttemps");
        }
    }
}
