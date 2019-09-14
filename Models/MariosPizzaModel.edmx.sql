
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/14/2019 21:47:59
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pizzas'
CREATE TABLE [dbo].[Pizzas] (
    [PizzaId] int IDENTITY(1,1) NOT NULL,
    [PizzaName] nvarchar(max)  NOT NULL,
    [PizzaDescription] nvarchar(max)  NOT NULL,
    [PizzaPrice] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Toppings'
CREATE TABLE [dbo].[Toppings] (
    [ToppingId] int IDENTITY(1,1) NOT NULL,
    [ToppingName] nvarchar(max)  NOT NULL,
    [PizzaPizzaId] int  NOT NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PizzaPizzaId] in table 'Toppings'
ALTER TABLE [dbo].[Toppings]
ADD CONSTRAINT [FK_PizzaTopping]
    FOREIGN KEY ([PizzaPizzaId])
    REFERENCES [dbo].[Pizzas]
        ([PizzaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PizzaTopping'
CREATE INDEX [IX_FK_PizzaTopping]
ON [dbo].[Toppings]
    ([PizzaPizzaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------