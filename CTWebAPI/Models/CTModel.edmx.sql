
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2014 17:07:52
-- Generated from EDMX file: C:\Code\CTWebAPI\CTWebAPI\Models\CTModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CALTRACK];
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
IF OBJECT_ID(N'[dbo].[fk_food_group_id1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_foods] DROP CONSTRAINT [fk_food_group_id1];
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
IF OBJECT_ID(N'[dbo].[FK_tbl_nutrient_rda_tbl_nutrients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_nutrient_rda] DROP CONSTRAINT [FK_tbl_nutrient_rda_tbl_nutrients];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_user_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_metric_logs] DROP CONSTRAINT [FK_tbl_user_id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_activities];
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
IF OBJECT_ID(N'[dbo].[tbl_metrics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_metrics];
GO
IF OBJECT_ID(N'[dbo].[tbl_nutrient_rda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_nutrient_rda];
GO
IF OBJECT_ID(N'[dbo].[tbl_nutrients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_nutrients];
GO
IF OBJECT_ID(N'[dbo].[tbl_users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [ActivityID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [CalorieBurnRate] decimal(18,0)  NOT NULL,
    [ImageUrl] varchar(256)  NULL
);
GO

-- Creating table 'ActivityLogs1'
CREATE TABLE [dbo].[ActivityLogs1] (
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

-- Creating table 'FoodGroups1'
CREATE TABLE [dbo].[FoodGroups1] (
    [FoodGroupID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [SourceID] int  NOT NULL
);
GO

-- Creating table 'FoodLogs1'
CREATE TABLE [dbo].[FoodLogs1] (
    [FoodLogID] int IDENTITY(1,1) NOT NULL,
    [FoodID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Quantity] decimal(18,0)  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- Creating table 'FoodNutrientLogs1'
CREATE TABLE [dbo].[FoodNutrientLogs1] (
    [NurtientLogID] int IDENTITY(1,1) NOT NULL,
    [FoodID] int  NOT NULL,
    [NurtientID] int  NOT NULL,
    [Value] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Foods1'
CREATE TABLE [dbo].[Foods1] (
    [FoodID] int IDENTITY(1,1) NOT NULL,
    [SourceID] int  NOT NULL,
    [ParentID] int  NULL,
    [GroupID] int  NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [Description] varchar(256)  NOT NULL,
    [ManufactureName] varchar(256)  NOT NULL
);
GO

-- Creating table 'MetricLogs'
CREATE TABLE [dbo].[MetricLogs] (
    [MetricLogID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [MetricID] int  NULL,
    [Value] decimal(18,0)  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- Creating table 'Metrics1'
CREATE TABLE [dbo].[Metrics1] (
    [MetricID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [Type] int  NOT NULL
);
GO

-- Creating table 'NutrientRDAs'
CREATE TABLE [dbo].[NutrientRDAs] (
    [NutrientRDAID] int IDENTITY(1,1) NOT NULL,
    [NutrientID] int  NOT NULL,
    [Gender] bit  NOT NULL,
    [AgeMin] int  NOT NULL,
    [AgeMax] int  NOT NULL,
    [Value] decimal(9,6)  NOT NULL,
    [UnitType] int  NOT NULL
);
GO

-- Creating table 'Nutrients1'
CREATE TABLE [dbo].[Nutrients1] (
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
    [CreationTimestamp] datetime  NOT NULL,
    [ActivityLevelType] int  NOT NULL,
    [Personality] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ActivityID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [ActivityLogID] in table 'ActivityLogs1'
ALTER TABLE [dbo].[ActivityLogs1]
ADD CONSTRAINT [PK_ActivityLogs1]
    PRIMARY KEY CLUSTERED ([ActivityLogID] ASC);
GO

-- Creating primary key on [FoodGroupID] in table 'FoodGroups1'
ALTER TABLE [dbo].[FoodGroups1]
ADD CONSTRAINT [PK_FoodGroups1]
    PRIMARY KEY CLUSTERED ([FoodGroupID] ASC);
GO

-- Creating primary key on [FoodLogID] in table 'FoodLogs1'
ALTER TABLE [dbo].[FoodLogs1]
ADD CONSTRAINT [PK_FoodLogs1]
    PRIMARY KEY CLUSTERED ([FoodLogID] ASC);
GO

-- Creating primary key on [NurtientLogID] in table 'FoodNutrientLogs1'
ALTER TABLE [dbo].[FoodNutrientLogs1]
ADD CONSTRAINT [PK_FoodNutrientLogs1]
    PRIMARY KEY CLUSTERED ([NurtientLogID] ASC);
GO

-- Creating primary key on [FoodID] in table 'Foods1'
ALTER TABLE [dbo].[Foods1]
ADD CONSTRAINT [PK_Foods1]
    PRIMARY KEY CLUSTERED ([FoodID] ASC);
GO

-- Creating primary key on [MetricLogID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [PK_MetricLogs]
    PRIMARY KEY CLUSTERED ([MetricLogID] ASC);
GO

-- Creating primary key on [MetricID] in table 'Metrics1'
ALTER TABLE [dbo].[Metrics1]
ADD CONSTRAINT [PK_Metrics1]
    PRIMARY KEY CLUSTERED ([MetricID] ASC);
GO

-- Creating primary key on [NutrientRDAID] in table 'NutrientRDAs'
ALTER TABLE [dbo].[NutrientRDAs]
ADD CONSTRAINT [PK_NutrientRDAs]
    PRIMARY KEY CLUSTERED ([NutrientRDAID] ASC);
GO

-- Creating primary key on [NutrientID] in table 'Nutrients1'
ALTER TABLE [dbo].[Nutrients1]
ADD CONSTRAINT [PK_Nutrients1]
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

-- Creating foreign key on [ActivityID] in table 'ActivityLogs1'
ALTER TABLE [dbo].[ActivityLogs1]
ADD CONSTRAINT [FK_activity_id]
    FOREIGN KEY ([ActivityID])
    REFERENCES [dbo].[Activities]
        ([ActivityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_id'
CREATE INDEX [IX_FK_activity_id]
ON [dbo].[ActivityLogs1]
    ([ActivityID]);
GO

-- Creating foreign key on [UserID] in table 'ActivityLogs1'
ALTER TABLE [dbo].[ActivityLogs1]
ADD CONSTRAINT [FK_activity_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_user_id'
CREATE INDEX [IX_FK_activity_user_id]
ON [dbo].[ActivityLogs1]
    ([UserID]);
GO

-- Creating foreign key on [GroupID] in table 'Foods1'
ALTER TABLE [dbo].[Foods1]
ADD CONSTRAINT [fk_food_group_id1]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[FoodGroups1]
        ([FoodGroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_group_id1'
CREATE INDEX [IX_fk_food_group_id1]
ON [dbo].[Foods1]
    ([GroupID]);
GO

-- Creating foreign key on [FoodID] in table 'FoodLogs1'
ALTER TABLE [dbo].[FoodLogs1]
ADD CONSTRAINT [FK_food_log_food_id]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Foods1]
        ([FoodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_food_id'
CREATE INDEX [IX_FK_food_log_food_id]
ON [dbo].[FoodLogs1]
    ([FoodID]);
GO

-- Creating foreign key on [UserID] in table 'FoodLogs1'
ALTER TABLE [dbo].[FoodLogs1]
ADD CONSTRAINT [FK_food_log_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_user_id'
CREATE INDEX [IX_FK_food_log_user_id]
ON [dbo].[FoodLogs1]
    ([UserID]);
GO

-- Creating foreign key on [FoodID] in table 'FoodNutrientLogs1'
ALTER TABLE [dbo].[FoodNutrientLogs1]
ADD CONSTRAINT [fk_food_nutrient_food_id]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Foods1]
        ([FoodID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_food_id'
CREATE INDEX [IX_fk_food_nutrient_food_id]
ON [dbo].[FoodNutrientLogs1]
    ([FoodID]);
GO

-- Creating foreign key on [NurtientID] in table 'FoodNutrientLogs1'
ALTER TABLE [dbo].[FoodNutrientLogs1]
ADD CONSTRAINT [fk_food_nutrient_nutrient_id]
    FOREIGN KEY ([NurtientID])
    REFERENCES [dbo].[Nutrients1]
        ([NutrientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_nutrient_id'
CREATE INDEX [IX_fk_food_nutrient_nutrient_id]
ON [dbo].[FoodNutrientLogs1]
    ([NurtientID]);
GO

-- Creating foreign key on [MetricID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [FK_tbl_metric_id]
    FOREIGN KEY ([MetricID])
    REFERENCES [dbo].[Metrics1]
        ([MetricID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_metric_id'
CREATE INDEX [IX_FK_tbl_metric_id]
ON [dbo].[MetricLogs]
    ([MetricID]);
GO

-- Creating foreign key on [UserID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [FK_tbl_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[User]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_user_id'
CREATE INDEX [IX_FK_tbl_user_id]
ON [dbo].[MetricLogs]
    ([UserID]);
GO

-- Creating foreign key on [NutrientID] in table 'NutrientRDAs'
ALTER TABLE [dbo].[NutrientRDAs]
ADD CONSTRAINT [FK_tbl_nutrient_rda_tbl_nutrients]
    FOREIGN KEY ([NutrientID])
    REFERENCES [dbo].[Nutrients1]
        ([NutrientID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_nutrient_rda_tbl_nutrients'
CREATE INDEX [IX_FK_tbl_nutrient_rda_tbl_nutrients]
ON [dbo].[NutrientRDAs]
    ([NutrientID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------