namespace CTWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CalorieBurnRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityID);
            
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        ActivityLogID = c.Int(nullable: false, identity: true),
                        ActivityID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(),
                        Accent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeartRate = c.Int(nullable: false),
                        Notes = c.String(),
                        FileURL = c.String(),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityLogID)
                .ForeignKey("dbo.Activities", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ActivityID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                        Admin = c.Boolean(nullable: false),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.FoodLogs",
                c => new
                    {
                        FoodLogID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoodLogID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.FoodID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ManufactureName = c.String(),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                        FoodGroup_FoodGroupID = c.Int(),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.FoodGroups", t => t.FoodGroup_FoodGroupID)
                .Index(t => t.FoodGroup_FoodGroupID);
            
            CreateTable(
                "dbo.FoodGroups",
                c => new
                    {
                        FoodGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoodGroupID);
            
            CreateTable(
                "dbo.FoodNutrientRecords",
                c => new
                    {
                        FoodNutrientRecordID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        NurtientID = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                        Nutrient_NutrientID = c.Int(),
                    })
                .PrimaryKey(t => t.FoodNutrientRecordID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Nutrients", t => t.Nutrient_NutrientID)
                .Index(t => t.FoodID)
                .Index(t => t.Nutrient_NutrientID);
            
            CreateTable(
                "dbo.Nutrients",
                c => new
                    {
                        NutrientID = c.Int(nullable: false, identity: true),
                        UnitType = c.Int(nullable: false),
                        Name = c.String(),
                        DecimalRounding = c.Int(nullable: false),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NutrientID);
            
            CreateTable(
                "dbo.NutrientRDAs",
                c => new
                    {
                        NutrientRDAID = c.Int(nullable: false, identity: true),
                        NutrientID = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        AgeMin = c.Int(nullable: false),
                        AgeMax = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitType = c.Int(nullable: false),
                        CreationTimestamp = c.DateTime(nullable: false),
                        LastUpdatedTimestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NutrientRDAID)
                .ForeignKey("dbo.Nutrients", t => t.NutrientID, cascadeDelete: true)
                .Index(t => t.NutrientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodLogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.NutrientRDAs", "NutrientID", "dbo.Nutrients");
            DropForeignKey("dbo.FoodNutrientRecords", "Nutrient_NutrientID", "dbo.Nutrients");
            DropForeignKey("dbo.FoodNutrientRecords", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.FoodLogs", "FoodID", "dbo.Foods");
            DropForeignKey("dbo.Foods", "FoodGroup_FoodGroupID", "dbo.FoodGroups");
            DropForeignKey("dbo.ActivityLogs", "UserID", "dbo.Users");
            DropForeignKey("dbo.ActivityLogs", "ActivityID", "dbo.Activities");
            DropIndex("dbo.NutrientRDAs", new[] { "NutrientID" });
            DropIndex("dbo.FoodNutrientRecords", new[] { "Nutrient_NutrientID" });
            DropIndex("dbo.FoodNutrientRecords", new[] { "FoodID" });
            DropIndex("dbo.Foods", new[] { "FoodGroup_FoodGroupID" });
            DropIndex("dbo.FoodLogs", new[] { "UserID" });
            DropIndex("dbo.FoodLogs", new[] { "FoodID" });
            DropIndex("dbo.ActivityLogs", new[] { "UserID" });
            DropIndex("dbo.ActivityLogs", new[] { "ActivityID" });
            DropTable("dbo.NutrientRDAs");
            DropTable("dbo.Nutrients");
            DropTable("dbo.FoodNutrientRecords");
            DropTable("dbo.FoodGroups");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodLogs");
            DropTable("dbo.Users");
            DropTable("dbo.ActivityLogs");
            DropTable("dbo.Activities");
        }
    }
}
