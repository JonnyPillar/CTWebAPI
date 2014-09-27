namespace CTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMetaData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.ActivityLogs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "ManufactureName", c => c.String(nullable: false));
            AlterColumn("dbo.FoodGroups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Nutrients", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nutrients", "Name", c => c.String());
            AlterColumn("dbo.FoodGroups", "Name", c => c.String());
            AlterColumn("dbo.Foods", "ManufactureName", c => c.String());
            AlterColumn("dbo.Foods", "Description", c => c.String());
            AlterColumn("dbo.Foods", "Name", c => c.String());
            AlterColumn("dbo.Users", "EmailAddress", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.ActivityLogs", "Title", c => c.String());
            AlterColumn("dbo.Activities", "ImageUrl", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String());
        }
    }
}
