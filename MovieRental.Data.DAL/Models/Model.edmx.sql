
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2019 08:17:56
-- Generated from EDMX file: C:\Praktyki\MovieRental\MovieRental.Data.DAL\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieRental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Films]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Films];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Films'
CREATE TABLE [dbo].[Films] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] varchar(50)  NOT NULL,
    [Year] int  NOT NULL,
    [Director] varchar(50)  NOT NULL,
    [Language] varchar(50)  NOT NULL,
    [Category] varchar(50)  NOT NULL,
    [Notes] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Films'
ALTER TABLE [dbo].[Films]
ADD CONSTRAINT [PK_Films]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------