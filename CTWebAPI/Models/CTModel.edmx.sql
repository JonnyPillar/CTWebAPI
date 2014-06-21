
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2014 17:07:52
-- Generated from EDMX file: C:\Code\CTWebAPI\CTWebAPI\Models\CTModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CalorieTracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_activity_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_activity_logs] DROP CONSTRAINT [FK_activity_id];
GO
IF OBJECT_ID(N'[dbo].[FK_activity_user_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_activity_logs] DROP CONSTRAINT [FK_activity_user_id];
GO
IF OBJECT_ID(N'[dbo].[fk_food_group_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_foods] DROP CONSTRAINT [fk_food_group_id];
GO
IF OBJECT_ID(N'[dbo].[FK_food_log_food_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_food_logs] DROP CONSTRAINT [FK_food_log_food_id];
GO
IF OBJECT_ID(N'[dbo].[FK_food_log_user_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_food_logs] DROP CONSTRAINT [FK_food_log_user_id];
GO
IF OBJECT_ID(N'[dbo].[fk_food_nutrient_food_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_food_nutrition_logs] DROP CONSTRAINT [fk_food_nutrient_food_id];
GO
IF OBJECT_ID(N'[dbo].[fk_food_nutrient_nutrient_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_food_nutrition_logs] DROP CONSTRAINT [fk_food_nutrient_nutrient_id];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_metric_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_metric_logs] DROP CONSTRAINT [FK_tbl_metric_id];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_nutrient_rda_tbl_Nutrient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_nutrient_rda] DROP CONSTRAINT [FK_tbl_nutrient_rda_tbl_Nutrient];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_user_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_metric_logs] DROP CONSTRAINT [FK_tbl_user_id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Activity];
GO
IF OBJECT_ID(N'[dbo].[tbl_activity_logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_activity_logs];
GO
IF OBJECT_ID(N'[dbo].[tbl_food_groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_food_groups];
GO
IF OBJECT_ID(N'[dbo].[tbl_food_logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_food_logs];
GO
IF OBJECT_ID(N'[dbo].[tbl_food_nutrition_logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_food_nutrition_logs];
GO
IF OBJECT_ID(N'[dbo].[tbl_foods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_foods];
GO
IF OBJECT_ID(N'[dbo].[tbl_metric_logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_metric_logs];
GO
IF OBJECT_ID(N'[dbo].[tbl_Metric]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Metric];
GO
IF OBJECT_ID(N'[dbo].[tbl_nutrient_rda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_nutrient_rda];
GO
IF OBJECT_ID(N'[dbo].[tbl_Nutrient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Nutrient];
GO
IF OBJECT_ID(N'[dbo].[tbl_users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activity'
CREATE TABLE [dbo].[Activity] (
    [ActivityID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [CalorieBurnRate] decimal(18,0)  NOT NULL,
    [ImageUrl] varchar(256)  NULL
);
GO

-- Creating table 'ActivityLog1'
CREATE TABLE [dbo].[ActivityLog] (
    [ActivityLogID] int IDENTITY(1,1) NOT NULL,
    [ActivityID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Duration] time  NOT NULL,
    [Distance] decimal(18,0)  NOT NULL,
    [Title] varchar(256)  NOT NULL,
    [Accent] decimal(18,0)  NOT NULL,
    [HeartRate] int  NOT NULL,
    [Notes] varchar(max)  NOT NULL,
    [FileURL] varchar(256)  NOT NULL
);
GO

-- Creating table 'FoodGroup1'
CREATE TABLE [dbo].[FoodGroup] (
    [FoodGroupID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [SourceID] int  NOT NULL
);
GO

-- Creating table 'FoodLog1'
CREATE TABLE [dbo].[FoodLog] (
    [FoodLogID] int IDENTITY(1,1) NOT NULL,
    [FoodID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Quantity] decimal(18,0)  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- Creating table 'FoodNutrientLog1'
CREATE TABLE [dbo].[FoodNutrientLog] (
    [NurtientLogID] int IDENTITY(1,1) NOT NULL,
    [FoodID] int  NOT NULL,
    [NurtientID] int  NOT NULL,
    [Value] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Foods1'
CREATE TABLE [dbo].[Food] (
    [FoodID] int IDENTITY(1,1) NOT NULL,
    [SourceID] int  NOT NULL,
    [ParentID] int  NULL,
    [GroupID] int  NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [Description] varchar(256)  NOT NULL,
    [ManufactureName] varchar(256)  NOT NULL
);
GO

-- Creating table 'NutrientRDA'
CREATE TABLE [dbo].[NutrientRDA] (
    [NutrientRDAID] int IDENTITY(1,1) NOT NULL,
    [NutrientID] int  NOT NULL,
    [Gender] bit  NOT NULL,
    [AgeMin] int  NOT NULL,
    [AgeMax] int  NOT NULL,
    [Value] decimal(9,6)  NOT NULL,
    [UnitType] int  NOT NULL
);
GO

-- Creating table 'Nutrient1'
CREATE TABLE [dbo].[Nutrient] (
    [NutrientID] int IDENTITY(1,1) NOT NULL,
    [SourceID] int  NOT NULL,
    [UnitType] int  NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [DecimalRounding] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [DOB] datetime  NOT NULL,
    [Gender] bit  NOT NULL,
    [PasswordHash] varchar(128)  NOT NULL,
    [PasswordSalt] varchar(128)  NOT NULL,
    [Admin] bit  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ActivityID] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [PK_Activity]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [ActivityLogID] in table 'ActivityLog1'
ALTER TABLE [dbo].[ActivityLog]
ADD CONSTRAINT [PK_ActivityLog]
    PRIMARY KEY CLUSTERED ([ActivityLogID] ASC);
GO

-- Creating primary key on [FoodGroupID] in table 'FoodGroup1'
ALTER TABLE [dbo].[FoodGroup]
ADD CONSTRAINT [PK_FoodGroup]
    PRIMARY KEY CLUSTERED ([FoodGroupID] ASC);
GO

-- Creating primary key on [FoodLogID] in table 'FoodLog1'
ALTER TABLE [dbo].[FoodLog]
ADD CONSTRAINT [PK_FoodLog]
    PRIMARY KEY CLUSTERED ([FoodLogID] ASC);
GO

-- Creating primary key on [NurtientLogID] in table 'FoodNutrientLog1'
ALTER TABLE [dbo].[FoodNutrientLog]
ADD CONSTRAINT [PK_FoodNutrientLog]
    PRIMARY KEY CLUSTERED ([NurtientLogID] ASC);
GO

-- Creating primary key on [FoodID] in table 'Foods1'
ALTER TABLE [dbo].[Food]
ADD CONSTRAINT [PK_Food]
    PRIMARY KEY CLUSTERED ([FoodID] ASC);
GO

-- Creating primary key on [NutrientRDAID] in table 'NutrientRDA'
ALTER TABLE [dbo].[NutrientRDA]
ADD CONSTRAINT [PK_NutrientRDA]
    PRIMARY KEY CLUSTERED ([NutrientRDAID] ASC);
GO

-- Creating primary key on [NutrientID] in table 'Nutrient1'
ALTER TABLE [dbo].[Nutrient]
ADD CONSTRAINT [PK_Nutrient]
    PRIMARY KEY CLUSTERED ([NutrientID] ASC);
GO

-- Creating primary key on [UserID] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityID] in table 'ActivityLog1'
ALTER TABLE [dbo].[ActivityLog]
ADD CONSTRAINT [FK_activity_id]
    FOREIGN KEY ([ActivityID])
    REFERENCES [dbo].[Activity]
        ([ActivityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_id'
CREATE INDEX [IX_FK_activity_id]
ON [dbo].[ActivityLog]
    ([ActivityID]);
GO

-- Creating foreign key on [UserID] in table 'ActivityLog1'
ALTER TABLE [dbo].[ActivityLog]
ADD CONSTRAINT [FK_activity_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_user_id'
CREATE INDEX [IX_FK_activity_user_id]
ON [dbo].[ActivityLog]
    ([UserID]);
GO

-- Creating foreign key on [GroupID] in table 'Foods1'
ALTER TABLE [dbo].[Food]
ADD CONSTRAINT [fk_food_group_id]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[FoodGroup]
        ([FoodGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_group_id1'
CREATE INDEX [IX_fk_food_group_id]
ON [dbo].[Food]
    ([GroupID]);
GO

-- Creating foreign key on [FoodID] in table 'FoodLog1'
ALTER TABLE [dbo].[FoodLog]
ADD CONSTRAINT [FK_food_log_food_id]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Food]
        ([FoodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_food_id'
CREATE INDEX [IX_FK_food_log_food_id]
ON [dbo].[FoodLog]
    ([FoodID]);
GO

-- Creating foreign key on [UserID] in table 'FoodLog1'
ALTER TABLE [dbo].[FoodLog]
ADD CONSTRAINT [FK_food_log_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_user_id'
CREATE INDEX [IX_FK_food_log_user_id]
ON [dbo].[FoodLog]
    ([UserID]);
GO

-- Creating foreign key on [FoodID] in table 'FoodNutrientLog1'
ALTER TABLE [dbo].[FoodNutrientLog]
ADD CONSTRAINT [fk_food_nutrient_food_id]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Food]
        ([FoodID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_food_id'
CREATE INDEX [IX_fk_food_nutrient_food_id]
ON [dbo].[FoodNutrientLog]
    ([FoodID]);
GO

-- Creating foreign key on [NurtientID] in table 'FoodNutrientLog1'
ALTER TABLE [dbo].[FoodNutrientLog]
ADD CONSTRAINT [fk_food_nutrient_nutrient_id]
    FOREIGN KEY ([NurtientID])
    REFERENCES [dbo].[Nutrient]
        ([NutrientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_nutrient_id'
CREATE INDEX [IX_fk_food_nutrient_nutrient_id]
ON [dbo].[FoodNutrientLog]
    ([NurtientID]);
GO

-- Creating foreign key on [NutrientID] in table 'NutrientRDA'
ALTER TABLE [dbo].[NutrientRDA]
ADD CONSTRAINT [FK_tbl_nutrient_rda_tbl_Nutrient]
    FOREIGN KEY ([NutrientID])
    REFERENCES [dbo].[Nutrient]
        ([NutrientID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_nutrient_rda_tbl_Nutrient'
CREATE INDEX [IX_FK_tbl_nutrient_rda_tbl_Nutrient]
ON [dbo].[NutrientRDA]
    ([NutrientID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------