
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2021 14:45:40
-- Generated from EDMX file: C:\Users\Tamara\source\repos\ProjekatBP2\ProjekatBP2\BeautySalon.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BeautySalon];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CollaborateProduct_Collaborate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollaborateProduct] DROP CONSTRAINT [FK_CollaborateProduct_Collaborate];
GO
IF OBJECT_ID(N'[dbo].[FK_CollaborateProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollaborateProduct] DROP CONSTRAINT [FK_CollaborateProduct_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerJob_Owner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OwnerJob] DROP CONSTRAINT [FK_OwnerJob_Owner];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerJob_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OwnerJob] DROP CONSTRAINT [FK_OwnerJob_Job];
GO
IF OBJECT_ID(N'[dbo].[FK_ShiftJob]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShiftSet] DROP CONSTRAINT [FK_ShiftJob];
GO
IF OBJECT_ID(N'[dbo].[FK_JobWorker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkerSet] DROP CONSTRAINT [FK_JobWorker];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerBill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillSet] DROP CONSTRAINT [FK_WorkerBill];
GO
IF OBJECT_ID(N'[dbo].[FK_BillService_Bill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillService] DROP CONSTRAINT [FK_BillService_Bill];
GO
IF OBJECT_ID(N'[dbo].[FK_BillService_Service]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillService] DROP CONSTRAINT [FK_BillService_Service];
GO
IF OBJECT_ID(N'[dbo].[FK_BossServiceCompany_Boss]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BossServiceCompany] DROP CONSTRAINT [FK_BossServiceCompany_Boss];
GO
IF OBJECT_ID(N'[dbo].[FK_BossServiceCompany_ServiceCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BossServiceCompany] DROP CONSTRAINT [FK_BossServiceCompany_ServiceCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCompanyWork_ServiceCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCompanyWork] DROP CONSTRAINT [FK_ServiceCompanyWork_ServiceCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceCompanyWork_Work]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceCompanyWork] DROP CONSTRAINT [FK_ServiceCompanyWork_Work];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerSector_Worker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkerSector] DROP CONSTRAINT [FK_WorkerSector_Worker];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerSector_Sector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkerSector] DROP CONSTRAINT [FK_WorkerSector_Sector];
GO
IF OBJECT_ID(N'[dbo].[FK_AppoitmentWorker_Appoitment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppoitmentWorker] DROP CONSTRAINT [FK_AppoitmentWorker_Appoitment];
GO
IF OBJECT_ID(N'[dbo].[FK_AppoitmentWorker_Worker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AppoitmentWorker] DROP CONSTRAINT [FK_AppoitmentWorker_Worker];
GO
IF OBJECT_ID(N'[dbo].[FK_ManufacturerCollaborate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollaborateSet] DROP CONSTRAINT [FK_ManufacturerCollaborate];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerCollaborate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollaborateSet] DROP CONSTRAINT [FK_OwnerCollaborate];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerBoss]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkerSet] DROP CONSTRAINT [FK_WorkerBoss];
GO
IF OBJECT_ID(N'[dbo].[FK_BossBoss]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BossSet] DROP CONSTRAINT [FK_BossBoss];
GO
IF OBJECT_ID(N'[dbo].[FK_HairStylist_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobSet_HairStylist] DROP CONSTRAINT [FK_HairStylist_inherits_Job];
GO
IF OBJECT_ID(N'[dbo].[FK_Beautican_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobSet_Beautican] DROP CONSTRAINT [FK_Beautican_inherits_Job];
GO
IF OBJECT_ID(N'[dbo].[FK_Barber_inherits_Job]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobSet_Barber] DROP CONSTRAINT [FK_Barber_inherits_Job];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ManufacturerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManufacturerSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[OwnerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OwnerSet];
GO
IF OBJECT_ID(N'[dbo].[ShiftSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShiftSet];
GO
IF OBJECT_ID(N'[dbo].[JobSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobSet];
GO
IF OBJECT_ID(N'[dbo].[WorkerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkerSet];
GO
IF OBJECT_ID(N'[dbo].[BillSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillSet];
GO
IF OBJECT_ID(N'[dbo].[ServiceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceSet];
GO
IF OBJECT_ID(N'[dbo].[BossSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BossSet];
GO
IF OBJECT_ID(N'[dbo].[ServiceCompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceCompanySet];
GO
IF OBJECT_ID(N'[dbo].[WorkSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkSet];
GO
IF OBJECT_ID(N'[dbo].[AppoitmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppoitmentSet];
GO
IF OBJECT_ID(N'[dbo].[SectorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SectorSet];
GO
IF OBJECT_ID(N'[dbo].[CollaborateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollaborateSet];
GO
IF OBJECT_ID(N'[dbo].[JobSet_HairStylist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobSet_HairStylist];
GO
IF OBJECT_ID(N'[dbo].[JobSet_Beautican]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobSet_Beautican];
GO
IF OBJECT_ID(N'[dbo].[JobSet_Barber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobSet_Barber];
GO
IF OBJECT_ID(N'[dbo].[CollaborateProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollaborateProduct];
GO
IF OBJECT_ID(N'[dbo].[OwnerJob]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OwnerJob];
GO
IF OBJECT_ID(N'[dbo].[BillService]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillService];
GO
IF OBJECT_ID(N'[dbo].[BossServiceCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BossServiceCompany];
GO
IF OBJECT_ID(N'[dbo].[ServiceCompanyWork]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceCompanyWork];
GO
IF OBJECT_ID(N'[dbo].[WorkerSector]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkerSector];
GO
IF OBJECT_ID(N'[dbo].[AppoitmentWorker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppoitmentWorker];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ManufacturerSet'
CREATE TABLE [dbo].[ManufacturerSet] (
    [ManufacturerId] int IDENTITY(1,1) NOT NULL,
    [ManufacturerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OwnerSet'
CREATE TABLE [dbo].[OwnerSet] (
    [OwnerId] int IDENTITY(1,1) NOT NULL,
    [OwnerName] nvarchar(max)  NOT NULL,
    [OwnerSurname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ShiftSet'
CREATE TABLE [dbo].[ShiftSet] (
    [ShiftId] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [JobJobId] int  NULL
);
GO

-- Creating table 'JobSet'
CREATE TABLE [dbo].[JobSet] (
    [JobId] int IDENTITY(1,1) NOT NULL,
    [JobName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WorkerSet'
CREATE TABLE [dbo].[WorkerSet] (
    [WorkerId] int IDENTITY(1,1) NOT NULL,
    [WorkerName] nvarchar(max)  NOT NULL,
    [WorkerSurname] nvarchar(max)  NOT NULL,
    [Salary] float  NOT NULL,
    [WorkerDOB] datetime  NULL,
    [UMCN] nvarchar(max)  NOT NULL,
    [JobJobId] int  NOT NULL,
    [BossBossId] int  NULL
);
GO

-- Creating table 'BillSet'
CREATE TABLE [dbo].[BillSet] (
    [BillId] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [WorkerWorkerId] int  NOT NULL
);
GO

-- Creating table 'ServiceSet'
CREATE TABLE [dbo].[ServiceSet] (
    [ServiceId] int IDENTITY(1,1) NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'BossSet'
CREATE TABLE [dbo].[BossSet] (
    [BossId] int IDENTITY(1,1) NOT NULL,
    [BossName] nvarchar(max)  NOT NULL,
    [BossSurname] nvarchar(max)  NOT NULL,
    [BossBossId] int  NOT NULL,
    [BossBossId1] int  NULL
);
GO

-- Creating table 'ServiceCompanySet'
CREATE TABLE [dbo].[ServiceCompanySet] (
    [CompanyId] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NULL
);
GO

-- Creating table 'WorkSet'
CREATE TABLE [dbo].[WorkSet] (
    [WorkId] int IDENTITY(1,1) NOT NULL,
    [WorkName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AppoitmentSet'
CREATE TABLE [dbo].[AppoitmentSet] (
    [AppoitmentId] int IDENTITY(1,1) NOT NULL,
    [NameOfClient] nvarchar(max)  NOT NULL,
    [SurnameOfClient] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SectorSet'
CREATE TABLE [dbo].[SectorSet] (
    [SectorId] int IDENTITY(1,1) NOT NULL,
    [SectorName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CollaborateSet'
CREATE TABLE [dbo].[CollaborateSet] (
    [CollaborateId] int IDENTITY(1,1) NOT NULL,
    [ManufacturerManufacturerId1] int  NOT NULL,
    [OwnerOwnerId] int  NOT NULL
);
GO

-- Creating table 'JobSet_HairStylist'
CREATE TABLE [dbo].[JobSet_HairStylist] (
    [Gender] int  NOT NULL,
    [JobId] int  NOT NULL
);
GO

-- Creating table 'JobSet_Beautican'
CREATE TABLE [dbo].[JobSet_Beautican] (
    [ProductType] int  NOT NULL,
    [JobId] int  NOT NULL
);
GO

-- Creating table 'JobSet_Barber'
CREATE TABLE [dbo].[JobSet_Barber] (
    [BarberType] int  NOT NULL,
    [JobId] int  NOT NULL
);
GO

-- Creating table 'CollaborateProduct'
CREATE TABLE [dbo].[CollaborateProduct] (
    [Collaborations_CollaborateId] int  NOT NULL,
    [Products_ProductId] int  NOT NULL
);
GO

-- Creating table 'OwnerJob'
CREATE TABLE [dbo].[OwnerJob] (
    [Owners_OwnerId] int  NOT NULL,
    [Jobs_JobId] int  NOT NULL
);
GO

-- Creating table 'BillService'
CREATE TABLE [dbo].[BillService] (
    [Bills_BillId] int  NOT NULL,
    [Services_ServiceId] int  NOT NULL
);
GO

-- Creating table 'BossServiceCompany'
CREATE TABLE [dbo].[BossServiceCompany] (
    [Bosses_BossId] int  NOT NULL,
    [ServiceCompanies_CompanyId] int  NOT NULL
);
GO

-- Creating table 'ServiceCompanyWork'
CREATE TABLE [dbo].[ServiceCompanyWork] (
    [ServiceCompany_CompanyId] int  NOT NULL,
    [Work_WorkId] int  NOT NULL
);
GO

-- Creating table 'WorkerSector'
CREATE TABLE [dbo].[WorkerSector] (
    [Workers_WorkerId] int  NOT NULL,
    [Sectors_SectorId] int  NOT NULL
);
GO

-- Creating table 'AppoitmentWorker'
CREATE TABLE [dbo].[AppoitmentWorker] (
    [Appoitments_AppoitmentId] int  NOT NULL,
    [Workers_WorkerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ManufacturerId] in table 'ManufacturerSet'
ALTER TABLE [dbo].[ManufacturerSet]
ADD CONSTRAINT [PK_ManufacturerSet]
    PRIMARY KEY CLUSTERED ([ManufacturerId] ASC);
GO

-- Creating primary key on [ProductId] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [OwnerId] in table 'OwnerSet'
ALTER TABLE [dbo].[OwnerSet]
ADD CONSTRAINT [PK_OwnerSet]
    PRIMARY KEY CLUSTERED ([OwnerId] ASC);
GO

-- Creating primary key on [ShiftId] in table 'ShiftSet'
ALTER TABLE [dbo].[ShiftSet]
ADD CONSTRAINT [PK_ShiftSet]
    PRIMARY KEY CLUSTERED ([ShiftId] ASC);
GO

-- Creating primary key on [JobId] in table 'JobSet'
ALTER TABLE [dbo].[JobSet]
ADD CONSTRAINT [PK_JobSet]
    PRIMARY KEY CLUSTERED ([JobId] ASC);
GO

-- Creating primary key on [WorkerId] in table 'WorkerSet'
ALTER TABLE [dbo].[WorkerSet]
ADD CONSTRAINT [PK_WorkerSet]
    PRIMARY KEY CLUSTERED ([WorkerId] ASC);
GO

-- Creating primary key on [BillId] in table 'BillSet'
ALTER TABLE [dbo].[BillSet]
ADD CONSTRAINT [PK_BillSet]
    PRIMARY KEY CLUSTERED ([BillId] ASC);
GO

-- Creating primary key on [ServiceId] in table 'ServiceSet'
ALTER TABLE [dbo].[ServiceSet]
ADD CONSTRAINT [PK_ServiceSet]
    PRIMARY KEY CLUSTERED ([ServiceId] ASC);
GO

-- Creating primary key on [BossId] in table 'BossSet'
ALTER TABLE [dbo].[BossSet]
ADD CONSTRAINT [PK_BossSet]
    PRIMARY KEY CLUSTERED ([BossId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'ServiceCompanySet'
ALTER TABLE [dbo].[ServiceCompanySet]
ADD CONSTRAINT [PK_ServiceCompanySet]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [WorkId] in table 'WorkSet'
ALTER TABLE [dbo].[WorkSet]
ADD CONSTRAINT [PK_WorkSet]
    PRIMARY KEY CLUSTERED ([WorkId] ASC);
GO

-- Creating primary key on [AppoitmentId] in table 'AppoitmentSet'
ALTER TABLE [dbo].[AppoitmentSet]
ADD CONSTRAINT [PK_AppoitmentSet]
    PRIMARY KEY CLUSTERED ([AppoitmentId] ASC);
GO

-- Creating primary key on [SectorId] in table 'SectorSet'
ALTER TABLE [dbo].[SectorSet]
ADD CONSTRAINT [PK_SectorSet]
    PRIMARY KEY CLUSTERED ([SectorId] ASC);
GO

-- Creating primary key on [CollaborateId] in table 'CollaborateSet'
ALTER TABLE [dbo].[CollaborateSet]
ADD CONSTRAINT [PK_CollaborateSet]
    PRIMARY KEY CLUSTERED ([CollaborateId] ASC);
GO

-- Creating primary key on [JobId] in table 'JobSet_HairStylist'
ALTER TABLE [dbo].[JobSet_HairStylist]
ADD CONSTRAINT [PK_JobSet_HairStylist]
    PRIMARY KEY CLUSTERED ([JobId] ASC);
GO

-- Creating primary key on [JobId] in table 'JobSet_Beautican'
ALTER TABLE [dbo].[JobSet_Beautican]
ADD CONSTRAINT [PK_JobSet_Beautican]
    PRIMARY KEY CLUSTERED ([JobId] ASC);
GO

-- Creating primary key on [JobId] in table 'JobSet_Barber'
ALTER TABLE [dbo].[JobSet_Barber]
ADD CONSTRAINT [PK_JobSet_Barber]
    PRIMARY KEY CLUSTERED ([JobId] ASC);
GO

-- Creating primary key on [Collaborations_CollaborateId], [Products_ProductId] in table 'CollaborateProduct'
ALTER TABLE [dbo].[CollaborateProduct]
ADD CONSTRAINT [PK_CollaborateProduct]
    PRIMARY KEY CLUSTERED ([Collaborations_CollaborateId], [Products_ProductId] ASC);
GO

-- Creating primary key on [Owners_OwnerId], [Jobs_JobId] in table 'OwnerJob'
ALTER TABLE [dbo].[OwnerJob]
ADD CONSTRAINT [PK_OwnerJob]
    PRIMARY KEY CLUSTERED ([Owners_OwnerId], [Jobs_JobId] ASC);
GO

-- Creating primary key on [Bills_BillId], [Services_ServiceId] in table 'BillService'
ALTER TABLE [dbo].[BillService]
ADD CONSTRAINT [PK_BillService]
    PRIMARY KEY CLUSTERED ([Bills_BillId], [Services_ServiceId] ASC);
GO

-- Creating primary key on [Bosses_BossId], [ServiceCompanies_CompanyId] in table 'BossServiceCompany'
ALTER TABLE [dbo].[BossServiceCompany]
ADD CONSTRAINT [PK_BossServiceCompany]
    PRIMARY KEY CLUSTERED ([Bosses_BossId], [ServiceCompanies_CompanyId] ASC);
GO

-- Creating primary key on [ServiceCompany_CompanyId], [Work_WorkId] in table 'ServiceCompanyWork'
ALTER TABLE [dbo].[ServiceCompanyWork]
ADD CONSTRAINT [PK_ServiceCompanyWork]
    PRIMARY KEY CLUSTERED ([ServiceCompany_CompanyId], [Work_WorkId] ASC);
GO

-- Creating primary key on [Workers_WorkerId], [Sectors_SectorId] in table 'WorkerSector'
ALTER TABLE [dbo].[WorkerSector]
ADD CONSTRAINT [PK_WorkerSector]
    PRIMARY KEY CLUSTERED ([Workers_WorkerId], [Sectors_SectorId] ASC);
GO

-- Creating primary key on [Appoitments_AppoitmentId], [Workers_WorkerId] in table 'AppoitmentWorker'
ALTER TABLE [dbo].[AppoitmentWorker]
ADD CONSTRAINT [PK_AppoitmentWorker]
    PRIMARY KEY CLUSTERED ([Appoitments_AppoitmentId], [Workers_WorkerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Collaborations_CollaborateId] in table 'CollaborateProduct'
ALTER TABLE [dbo].[CollaborateProduct]
ADD CONSTRAINT [FK_CollaborateProduct_Collaborate]
    FOREIGN KEY ([Collaborations_CollaborateId])
    REFERENCES [dbo].[CollaborateSet]
        ([CollaborateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_ProductId] in table 'CollaborateProduct'
ALTER TABLE [dbo].[CollaborateProduct]
ADD CONSTRAINT [FK_CollaborateProduct_Product]
    FOREIGN KEY ([Products_ProductId])
    REFERENCES [dbo].[ProductSet]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollaborateProduct_Product'
CREATE INDEX [IX_FK_CollaborateProduct_Product]
ON [dbo].[CollaborateProduct]
    ([Products_ProductId]);
GO

-- Creating foreign key on [Owners_OwnerId] in table 'OwnerJob'
ALTER TABLE [dbo].[OwnerJob]
ADD CONSTRAINT [FK_OwnerJob_Owner]
    FOREIGN KEY ([Owners_OwnerId])
    REFERENCES [dbo].[OwnerSet]
        ([OwnerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jobs_JobId] in table 'OwnerJob'
ALTER TABLE [dbo].[OwnerJob]
ADD CONSTRAINT [FK_OwnerJob_Job]
    FOREIGN KEY ([Jobs_JobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerJob_Job'
CREATE INDEX [IX_FK_OwnerJob_Job]
ON [dbo].[OwnerJob]
    ([Jobs_JobId]);
GO

-- Creating foreign key on [JobJobId] in table 'ShiftSet'
ALTER TABLE [dbo].[ShiftSet]
ADD CONSTRAINT [FK_ShiftJob]
    FOREIGN KEY ([JobJobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShiftJob'
CREATE INDEX [IX_FK_ShiftJob]
ON [dbo].[ShiftSet]
    ([JobJobId]);
GO

-- Creating foreign key on [JobJobId] in table 'WorkerSet'
ALTER TABLE [dbo].[WorkerSet]
ADD CONSTRAINT [FK_JobWorker]
    FOREIGN KEY ([JobJobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobWorker'
CREATE INDEX [IX_FK_JobWorker]
ON [dbo].[WorkerSet]
    ([JobJobId]);
GO

-- Creating foreign key on [WorkerWorkerId] in table 'BillSet'
ALTER TABLE [dbo].[BillSet]
ADD CONSTRAINT [FK_WorkerBill]
    FOREIGN KEY ([WorkerWorkerId])
    REFERENCES [dbo].[WorkerSet]
        ([WorkerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerBill'
CREATE INDEX [IX_FK_WorkerBill]
ON [dbo].[BillSet]
    ([WorkerWorkerId]);
GO

-- Creating foreign key on [Bills_BillId] in table 'BillService'
ALTER TABLE [dbo].[BillService]
ADD CONSTRAINT [FK_BillService_Bill]
    FOREIGN KEY ([Bills_BillId])
    REFERENCES [dbo].[BillSet]
        ([BillId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Services_ServiceId] in table 'BillService'
ALTER TABLE [dbo].[BillService]
ADD CONSTRAINT [FK_BillService_Service]
    FOREIGN KEY ([Services_ServiceId])
    REFERENCES [dbo].[ServiceSet]
        ([ServiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillService_Service'
CREATE INDEX [IX_FK_BillService_Service]
ON [dbo].[BillService]
    ([Services_ServiceId]);
GO

-- Creating foreign key on [Bosses_BossId] in table 'BossServiceCompany'
ALTER TABLE [dbo].[BossServiceCompany]
ADD CONSTRAINT [FK_BossServiceCompany_Boss]
    FOREIGN KEY ([Bosses_BossId])
    REFERENCES [dbo].[BossSet]
        ([BossId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ServiceCompanies_CompanyId] in table 'BossServiceCompany'
ALTER TABLE [dbo].[BossServiceCompany]
ADD CONSTRAINT [FK_BossServiceCompany_ServiceCompany]
    FOREIGN KEY ([ServiceCompanies_CompanyId])
    REFERENCES [dbo].[ServiceCompanySet]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BossServiceCompany_ServiceCompany'
CREATE INDEX [IX_FK_BossServiceCompany_ServiceCompany]
ON [dbo].[BossServiceCompany]
    ([ServiceCompanies_CompanyId]);
GO

-- Creating foreign key on [ServiceCompany_CompanyId] in table 'ServiceCompanyWork'
ALTER TABLE [dbo].[ServiceCompanyWork]
ADD CONSTRAINT [FK_ServiceCompanyWork_ServiceCompany]
    FOREIGN KEY ([ServiceCompany_CompanyId])
    REFERENCES [dbo].[ServiceCompanySet]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Work_WorkId] in table 'ServiceCompanyWork'
ALTER TABLE [dbo].[ServiceCompanyWork]
ADD CONSTRAINT [FK_ServiceCompanyWork_Work]
    FOREIGN KEY ([Work_WorkId])
    REFERENCES [dbo].[WorkSet]
        ([WorkId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceCompanyWork_Work'
CREATE INDEX [IX_FK_ServiceCompanyWork_Work]
ON [dbo].[ServiceCompanyWork]
    ([Work_WorkId]);
GO

-- Creating foreign key on [Workers_WorkerId] in table 'WorkerSector'
ALTER TABLE [dbo].[WorkerSector]
ADD CONSTRAINT [FK_WorkerSector_Worker]
    FOREIGN KEY ([Workers_WorkerId])
    REFERENCES [dbo].[WorkerSet]
        ([WorkerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sectors_SectorId] in table 'WorkerSector'
ALTER TABLE [dbo].[WorkerSector]
ADD CONSTRAINT [FK_WorkerSector_Sector]
    FOREIGN KEY ([Sectors_SectorId])
    REFERENCES [dbo].[SectorSet]
        ([SectorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerSector_Sector'
CREATE INDEX [IX_FK_WorkerSector_Sector]
ON [dbo].[WorkerSector]
    ([Sectors_SectorId]);
GO

-- Creating foreign key on [Appoitments_AppoitmentId] in table 'AppoitmentWorker'
ALTER TABLE [dbo].[AppoitmentWorker]
ADD CONSTRAINT [FK_AppoitmentWorker_Appoitment]
    FOREIGN KEY ([Appoitments_AppoitmentId])
    REFERENCES [dbo].[AppoitmentSet]
        ([AppoitmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Workers_WorkerId] in table 'AppoitmentWorker'
ALTER TABLE [dbo].[AppoitmentWorker]
ADD CONSTRAINT [FK_AppoitmentWorker_Worker]
    FOREIGN KEY ([Workers_WorkerId])
    REFERENCES [dbo].[WorkerSet]
        ([WorkerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppoitmentWorker_Worker'
CREATE INDEX [IX_FK_AppoitmentWorker_Worker]
ON [dbo].[AppoitmentWorker]
    ([Workers_WorkerId]);
GO

-- Creating foreign key on [ManufacturerManufacturerId1] in table 'CollaborateSet'
ALTER TABLE [dbo].[CollaborateSet]
ADD CONSTRAINT [FK_ManufacturerCollaborate]
    FOREIGN KEY ([ManufacturerManufacturerId1])
    REFERENCES [dbo].[ManufacturerSet]
        ([ManufacturerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManufacturerCollaborate'
CREATE INDEX [IX_FK_ManufacturerCollaborate]
ON [dbo].[CollaborateSet]
    ([ManufacturerManufacturerId1]);
GO

-- Creating foreign key on [OwnerOwnerId] in table 'CollaborateSet'
ALTER TABLE [dbo].[CollaborateSet]
ADD CONSTRAINT [FK_OwnerCollaborate]
    FOREIGN KEY ([OwnerOwnerId])
    REFERENCES [dbo].[OwnerSet]
        ([OwnerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerCollaborate'
CREATE INDEX [IX_FK_OwnerCollaborate]
ON [dbo].[CollaborateSet]
    ([OwnerOwnerId]);
GO

-- Creating foreign key on [BossBossId] in table 'WorkerSet'
ALTER TABLE [dbo].[WorkerSet]
ADD CONSTRAINT [FK_WorkerBoss]
    FOREIGN KEY ([BossBossId])
    REFERENCES [dbo].[BossSet]
        ([BossId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerBoss'
CREATE INDEX [IX_FK_WorkerBoss]
ON [dbo].[WorkerSet]
    ([BossBossId]);
GO

-- Creating foreign key on [BossBossId1] in table 'BossSet'
ALTER TABLE [dbo].[BossSet]
ADD CONSTRAINT [FK_BossBoss]
    FOREIGN KEY ([BossBossId1])
    REFERENCES [dbo].[BossSet]
        ([BossId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BossBoss'
CREATE INDEX [IX_FK_BossBoss]
ON [dbo].[BossSet]
    ([BossBossId1]);
GO

-- Creating foreign key on [JobId] in table 'JobSet_HairStylist'
ALTER TABLE [dbo].[JobSet_HairStylist]
ADD CONSTRAINT [FK_HairStylist_inherits_Job]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JobId] in table 'JobSet_Beautican'
ALTER TABLE [dbo].[JobSet_Beautican]
ADD CONSTRAINT [FK_Beautican_inherits_Job]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JobId] in table 'JobSet_Barber'
ALTER TABLE [dbo].[JobSet_Barber]
ADD CONSTRAINT [FK_Barber_inherits_Job]
    FOREIGN KEY ([JobId])
    REFERENCES [dbo].[JobSet]
        ([JobId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------