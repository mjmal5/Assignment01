
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/27/2019 18:05:11
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

IF OBJECT_ID(N'[dbo].[FK_PizzaPizza_Topping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pizza_Topping] DROP CONSTRAINT [FK_PizzaPizza_Topping];
GO
IF OBJECT_ID(N'[dbo].[FK_ToppingPizza_Topping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pizza_Topping] DROP CONSTRAINT [FK_ToppingPizza_Topping];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderPizza]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pizzas] DROP CONSTRAINT [FK_OrderPizza];
GO
IF OBJECT_ID(N'[dbo].[FK_RestarauntBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_RestarauntBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_CustomerBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pizzas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pizzas];
GO
IF OBJECT_ID(N'[dbo].[Toppings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Toppings];
GO
IF OBJECT_ID(N'[dbo].[Pizza_Topping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pizza_Topping];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Restaraunts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaraunts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pizzas'
CREATE TABLE [dbo].[Pizzas] (
    [PizzaId] int IDENTITY(1,1) NOT NULL,
    [PizzaName] nvarchar(max)  NOT NULL,
    [PizzaDescription] nvarchar(max)  NOT NULL,
    [PizzaPrice] nvarchar(max)  NOT NULL,
    [OrderId] int  NOT NULL
);
GO

-- Creating table 'Toppings'
CREATE TABLE [dbo].[Toppings] (
    [ToppingId] int IDENTITY(1,1) NOT NULL,
    [ToppingName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pizza_Topping'
CREATE TABLE [dbo].[Pizza_Topping] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PizzaPizzaId] int  NOT NULL,
    [ToppingToppingId] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderTime] nvarchar(max)  NOT NULL,
    [OrderCurrency] nvarchar(max)  NOT NULL,
    [OrderTotal] nvarchar(max)  NOT NULL
);
GO

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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PizzaId] in table 'Pizzas'
ALTER TABLE [dbo].[Pizzas]
ADD CONSTRAINT [PK_Pizzas]
    PRIMARY KEY CLUSTERED ([PizzaId] ASC);
GO

-- Creating primary key on [ToppingId] in table 'Toppings'
ALTER TABLE [dbo].[Toppings]
ADD CONSTRAINT [PK_Toppings]
    PRIMARY KEY CLUSTERED ([ToppingId] ASC);
GO

-- Creating primary key on [Id] in table 'Pizza_Topping'
ALTER TABLE [dbo].[Pizza_Topping]
ADD CONSTRAINT [PK_Pizza_Topping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PizzaPizzaId] in table 'Pizza_Topping'
ALTER TABLE [dbo].[Pizza_Topping]
ADD CONSTRAINT [FK_PizzaPizza_Topping]
    FOREIGN KEY ([PizzaPizzaId])
    REFERENCES [dbo].[Pizzas]
        ([PizzaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PizzaPizza_Topping'
CREATE INDEX [IX_FK_PizzaPizza_Topping]
ON [dbo].[Pizza_Topping]
    ([PizzaPizzaId]);
GO

-- Creating foreign key on [ToppingToppingId] in table 'Pizza_Topping'
ALTER TABLE [dbo].[Pizza_Topping]
ADD CONSTRAINT [FK_ToppingPizza_Topping]
    FOREIGN KEY ([ToppingToppingId])
    REFERENCES [dbo].[Toppings]
        ([ToppingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ToppingPizza_Topping'
CREATE INDEX [IX_FK_ToppingPizza_Topping]
ON [dbo].[Pizza_Topping]
    ([ToppingToppingId]);
GO

-- Creating foreign key on [OrderId] in table 'Pizzas'
ALTER TABLE [dbo].[Pizzas]
ADD CONSTRAINT [FK_OrderPizza]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderPizza'
CREATE INDEX [IX_FK_OrderPizza]
ON [dbo].[Pizzas]
    ([OrderId]);
GO

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