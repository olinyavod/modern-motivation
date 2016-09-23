namespace Motivation.Data.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNameCompititionAchivmentTypeTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.dbo/CompititionAchivmentypes", newName: "CompititionAchivmentypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CompititionAchivmentypes", newName: "dbo/CompititionAchivmentypes");
        }
    }
}
