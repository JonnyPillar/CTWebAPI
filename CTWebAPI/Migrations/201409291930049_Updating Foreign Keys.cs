namespace CTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "FoodGroup_FoodGroupID", "dbo.FoodGroups");
            DropIndex("dbo.Foods", new[] { "FoodGroup_FoodGroupID" });
            DropColumn("dbo.Foods", "GroupID");
            RenameColumn(table: "dbo.Foods", name: "FoodGroup_FoodGroupID", newName: "GroupID");
            AlterColumn("dbo.Foods", "GroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "GroupID");
            AddForeignKey("dbo.Foods", "GroupID", "dbo.FoodGroups", "FoodGroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "GroupID", "dbo.FoodGroups");
            DropIndex("dbo.Foods", new[] { "GroupID" });
            AlterColumn("dbo.Foods", "GroupID", c => c.Int());
            RenameColumn(table: "dbo.Foods", name: "GroupID", newName: "FoodGroup_FoodGroupID");
            AddColumn("dbo.Foods", "GroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "FoodGroup_FoodGroupID");
            AddForeignKey("dbo.Foods", "FoodGroup_FoodGroupID", "dbo.FoodGroups", "FoodGroupID");
        }
    }
}
