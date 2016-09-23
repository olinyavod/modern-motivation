namespace Motivation.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOptionalAchivmentTypeToAchivmentAttemp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AchivmentAttemps", "AchivnedTypeId", "dbo.AchivmentType");
            DropIndex("dbo.AchivmentAttemps", new[] { "AchivnedTypeId" });
            AlterColumn("dbo.AchivmentAttemps", "AchivnedTypeId", c => c.Int());
            CreateIndex("dbo.AchivmentAttemps", "AchivnedTypeId");
            AddForeignKey("dbo.AchivmentAttemps", "AchivnedTypeId", "dbo.AchivmentType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AchivmentAttemps", "AchivnedTypeId", "dbo.AchivmentType");
            DropIndex("dbo.AchivmentAttemps", new[] { "AchivnedTypeId" });
            AlterColumn("dbo.AchivmentAttemps", "AchivnedTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AchivmentAttemps", "AchivnedTypeId");
            AddForeignKey("dbo.AchivmentAttemps", "AchivnedTypeId", "dbo.AchivmentType", "Id", cascadeDelete: true);
        }
    }
}
