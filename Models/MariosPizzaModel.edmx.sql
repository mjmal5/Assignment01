
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/13/2019 04:00:14
-- Generated from EDMX file: C:\Users\Malcolm\source\repos\FIT5032_Assignment\Models\MariosPizzaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Marios_Pizza];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RestarauntBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_RestarauntBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_CustomerBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Restaraunts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaraunts];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustId] int IDENTITY(1,1) NOT NULL,
    [CustFirstName] nvarchar(max)  NOT NULL,
    [CustLastName] nvarchar(max)  NOT NULL,
    [CustPhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [BookingId] int IDENTITY(1,1) NOT NULL,
    [BookingGuestNum] int  NOT NULL,
    [BookingDate] datetime  NOT NULL,
    [BookingTime] time  NOT NULL,
    [RestarauntRestId] int  NOT NULL,
    [CustomerCustId] int  NOT NULL
);
GO

-- Creating table 'Restaraunts'
CREATE TABLE [dbo].[Restaraunts] (
    [RestId] int IDENTITY(1,1) NOT NULL,
    [RestAddress] nvarchar(max)  NOT NULL,
    [RestPhone] nvarchar(max)  NOT NULL,
    [RestOpenTime] nvarchar(max)  NOT NULL,
    [RestCloseTime] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Start] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustId] ASC);
GO

-- Creating primary key on [BookingId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingId] ASC);
GO

-- Creating primary key on [RestId] in table 'Restaraunts'
ALTER TABLE [dbo].[Restaraunts]
ADD CONSTRAINT [PK_Restaraunts]
    PRIMARY KEY CLUSTERED ([RestId] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RestarauntRestId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_RestarauntBooking]
    FOREIGN KEY ([RestarauntRestId])
    REFERENCES [dbo].[Restaraunts]
        ([RestId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestarauntBooking'
CREATE INDEX [IX_FK_RestarauntBooking]
ON [dbo].[Bookings]
    ([RestarauntRestId]);
GO

-- Creating foreign key on [CustomerCustId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_CustomerBooking]
    FOREIGN KEY ([CustomerCustId])
    REFERENCES [dbo].[Customers]
        ([CustId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerBooking'
CREATE INDEX [IX_FK_CustomerBooking]
ON [dbo].[Bookings]
    ([CustomerCustId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------