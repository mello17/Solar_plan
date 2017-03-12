
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2017 00:54:43
-- Generated from EDMX file: C:\Users\--\Documents\Visual Studio 2015\Projects\solar_plan_2\solar_plan_2\Event.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-plan_solar-20170309094817];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name_Event] nvarchar(max)  NULL,
    [Subscr_Event] nvarchar(max)  NULL,
    [Start_Date] datetime  NOT NULL,
    [End_Date] datetime  NOT NULL,
    [IsDeffered] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------