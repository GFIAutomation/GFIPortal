
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/24/2018 15:07:56
-- Generated from EDMX file: C:\Portal\GFIPortal\gfi-test-landing\API.GFI.TestLanding\TestLandingEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [testLanding];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActionObject_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionObject] DROP CONSTRAINT [FK_ActionObject_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionObject_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionObject] DROP CONSTRAINT [FK_ActionObject_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserLogins_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Battery_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Battery] DROP CONSTRAINT [FK_Battery_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryTest_Battery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryTest] DROP CONSTRAINT [FK_BatteryTest_Battery];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryTest_Environment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryTest] DROP CONSTRAINT [FK_BatteryTest_Environment];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryTest_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryTest] DROP CONSTRAINT [FK_BatteryTest_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryTest_Schedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryTest] DROP CONSTRAINT [FK_BatteryTest_Schedule];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryTest_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryTest] DROP CONSTRAINT [FK_BatteryTest_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryUser_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryUser] DROP CONSTRAINT [FK_BatteryUser_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_BatteryUser_Battery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BatteryUser] DROP CONSTRAINT [FK_BatteryUser_Battery];
GO
IF OBJECT_ID(N'[dbo].[FK_Build_BatteryTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Build] DROP CONSTRAINT [FK_Build_BatteryTest];
GO
IF OBJECT_ID(N'[dbo].[FK_Build_Machine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Build] DROP CONSTRAINT [FK_Build_Machine];
GO
IF OBJECT_ID(N'[dbo].[FK_Build_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Build] DROP CONSTRAINT [FK_Build_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_DisplayComponent_Component]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisplayComponent] DROP CONSTRAINT [FK_DisplayComponent_Component];
GO
IF OBJECT_ID(N'[dbo].[FK_DisplayComponent_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DisplayComponent] DROP CONSTRAINT [FK_DisplayComponent_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Object_Attribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_Object_Attribute];
GO
IF OBJECT_ID(N'[dbo].[FK_Object_Data]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_Object_Data];
GO
IF OBJECT_ID(N'[dbo].[FK_Object_Method]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Object] DROP CONSTRAINT [FK_Object_Method];
GO
IF OBJECT_ID(N'[dbo].[FK_Request_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_Request_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Request_BatteryTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_Request_BatteryTest];
GO
IF OBJECT_ID(N'[dbo].[FK_Request_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_Request_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleWeekDays_Schedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleWeekDays] DROP CONSTRAINT [FK_ScheduleWeekDays_Schedule];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduleWeekDays_WeekDays]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduleWeekDays] DROP CONSTRAINT [FK_ScheduleWeekDays_WeekDays];
GO
IF OBJECT_ID(N'[dbo].[FK_Step_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Step] DROP CONSTRAINT [FK_Step_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_Step_Object]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Step] DROP CONSTRAINT [FK_Step_Object];
GO
IF OBJECT_ID(N'[dbo].[FK_Test_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test] DROP CONSTRAINT [FK_Test_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_TestAction_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestAction] DROP CONSTRAINT [FK_TestAction_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_TestAction_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestAction] DROP CONSTRAINT [FK_TestAction_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_TestUser_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestUser] DROP CONSTRAINT [FK_TestUser_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_TestUser_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestUser] DROP CONSTRAINT [FK_TestUser_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_Tools_Step_Tools_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tools_Step] DROP CONSTRAINT [FK_Tools_Step_Tools_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_Tools_Test_Build]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tools_Test] DROP CONSTRAINT [FK_Tools_Test_Build];
GO
IF OBJECT_ID(N'[dbo].[FK_Tools_Test_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tools_Test] DROP CONSTRAINT [FK_Tools_Test_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Project];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action];
GO
IF OBJECT_ID(N'[dbo].[ActionObject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionObject];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Attribute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attribute];
GO
IF OBJECT_ID(N'[dbo].[Battery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Battery];
GO
IF OBJECT_ID(N'[dbo].[BatteryTest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BatteryTest];
GO
IF OBJECT_ID(N'[dbo].[BatteryUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BatteryUser];
GO
IF OBJECT_ID(N'[dbo].[Bug_reporting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bug_reporting];
GO
IF OBJECT_ID(N'[dbo].[Bug_reporting_collection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bug_reporting_collection];
GO
IF OBJECT_ID(N'[dbo].[Bug_reporting_step]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bug_reporting_step];
GO
IF OBJECT_ID(N'[dbo].[Build]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Build];
GO
IF OBJECT_ID(N'[dbo].[Component]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Component];
GO
IF OBJECT_ID(N'[dbo].[Data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Data];
GO
IF OBJECT_ID(N'[dbo].[DisplayComponent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DisplayComponent];
GO
IF OBJECT_ID(N'[dbo].[Environment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Environment];
GO
IF OBJECT_ID(N'[dbo].[Machine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Machine];
GO
IF OBJECT_ID(N'[dbo].[Method]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Method];
GO
IF OBJECT_ID(N'[dbo].[Object]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Object];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Report_test_collection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Report_test_collection];
GO
IF OBJECT_ID(N'[dbo].[ReportCollection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReportCollection];
GO
IF OBJECT_ID(N'[dbo].[Request]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Request];
GO
IF OBJECT_ID(N'[dbo].[Schedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schedule];
GO
IF OBJECT_ID(N'[dbo].[ScheduleWeekDays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleWeekDays];
GO
IF OBJECT_ID(N'[dbo].[Step]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Step];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Test]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Test];
GO
IF OBJECT_ID(N'[dbo].[TestAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestAction];
GO
IF OBJECT_ID(N'[dbo].[TestUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestUser];
GO
IF OBJECT_ID(N'[dbo].[Tools_Step]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tools_Step];
GO
IF OBJECT_ID(N'[dbo].[Tools_Test]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tools_Test];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[WeekDays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WeekDays];
GO
IF OBJECT_ID(N'[testLandingModelStoreContainer].[TestBackoffice]', 'U') IS NOT NULL
    DROP TABLE [testLandingModelStoreContainer].[TestBackoffice];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL
);
GO

-- Creating table 'ActionObject'
CREATE TABLE [dbo].[ActionObject] (
    [id_action] int  NOT NULL,
    [id_object] int  NOT NULL,
    [last_update] datetime  NULL,
    [status] nvarchar(100)  NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [id_project] int  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] nvarchar(128)  NOT NULL,
    [RoleId] nvarchar(128)  NOT NULL,
    [id_project] int  NOT NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [ImageUrl] nvarchar(256)  NULL,
    [FirstName] nvarchar(100)  NULL,
    [LastName] nvarchar(100)  NULL
);
GO

-- Creating table 'Attribute'
CREATE TABLE [dbo].[Attribute] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(200)  NULL
);
GO

-- Creating table 'Battery'
CREATE TABLE [dbo].[Battery] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL,
    [id_project] int  NULL
);
GO

-- Creating table 'BatteryTest'
CREATE TABLE [dbo].[BatteryTest] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(100)  NULL,
    [created_date] datetime  NULL,
    [update_date] datetime  NULL,
    [id_environment] int  NULL,
    [id_schedule] int  NULL,
    [id_project] int  NULL,
    [id_test] int  NULL,
    [id_battery] int  NULL
);
GO

-- Creating table 'BatteryUser'
CREATE TABLE [dbo].[BatteryUser] (
    [id_user] nvarchar(128)  NOT NULL,
    [id_battery] int  NOT NULL,
    [creation_date] datetime  NULL
);
GO

-- Creating table 'Bug_reporting'
CREATE TABLE [dbo].[Bug_reporting] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Description] varchar(max)  NULL,
    [Current_behaviour] varchar(max)  NULL,
    [Expected_behaviour] varchar(max)  NULL,
    [Bug_reporting_collection_id] int  NULL,
    [Browser] varchar(50)  NULL,
    [Operating_system] varchar(50)  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'Bug_reporting_collection'
CREATE TABLE [dbo].[Bug_reporting_collection] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Step_id] int  NULL,
    [Bug_report_id] int  NULL
);
GO

-- Creating table 'Bug_reporting_step'
CREATE TABLE [dbo].[Bug_reporting_step] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(max)  NULL
);
GO

-- Creating table 'Component'
CREATE TABLE [dbo].[Component] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL
);
GO

-- Creating table 'Credentials'
CREATE TABLE [dbo].[Credentials] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(100)  NULL,
    [password] nvarchar(100)  NULL,
    [img] nvarchar(200)  NULL,
    [name] nvarchar(200)  NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'Data'
CREATE TABLE [dbo].[Data] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(200)  NULL
);
GO

-- Creating table 'DisplayComponent'
CREATE TABLE [dbo].[DisplayComponent] (
    [id_component] int  NOT NULL,
    [id_project] int  NOT NULL,
    [visible] bit  NOT NULL
);
GO

-- Creating table 'Environment'
CREATE TABLE [dbo].[Environment] (
    [id] int IDENTITY(1,1) NOT NULL,
    [link] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL,
    [name] nvarchar(100)  NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [id_role] int  NULL,
    [id_project] int  NULL,
    [id_credentials] int  NULL
);
GO

-- Creating table 'Machine'
CREATE TABLE [dbo].[Machine] (
    [id] int IDENTITY(1,1) NOT NULL,
    [cpu] nvarchar(100)  NULL,
    [ram] nvarchar(100)  NULL,
    [storage] nvarchar(100)  NULL,
    [date_created] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL
);
GO

-- Creating table 'Method'
CREATE TABLE [dbo].[Method] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL
);
GO

-- Creating table 'Object'
CREATE TABLE [dbo].[Object] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [descritpion] nvarchar(200)  NULL,
    [status] nvarchar(100)  NULL,
    [id_method] int  NULL,
    [id_attribute] int  NULL,
    [id_data] int  NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL,
    [logo_url] nvarchar(200)  NULL,
    [projectImage] varbinary(max)  NULL
);
GO

-- Creating table 'Report'
CREATE TABLE [dbo].[Report] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date_start] datetime  NULL,
    [date_end] datetime  NULL,
    [status] nvarchar(100)  NULL,
    [general_message] nvarchar(100)  NULL,
    [error_message] nvarchar(100)  NULL,
    [warning_message] nvarchar(100)  NULL,
    [error_type] nvarchar(100)  NULL,
    [logs] nvarchar(100)  NULL,
    [id_batteryTest] int  NULL,
    [id_machine] int  NULL,
    [pass_tests] int  NULL,
    [duration] nvarchar(100)  NULL,
    [total_tests] int  NULL,
    [failed_tests] int  NULL,
    [skipped_tests] int  NULL
);
GO

-- Creating table 'Report_test_collection'
CREATE TABLE [dbo].[Report_test_collection] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date_start] datetime  NULL,
    [Date_end] datetime  NULL,
    [Status] varchar(50)  NULL,
    [General_message] varchar(max)  NULL,
    [Report_test_id] int  NULL,
    [Report_id] int  NULL
);
GO

-- Creating table 'ReportCollection'
CREATE TABLE [dbo].[ReportCollection] (
    [id] int IDENTITY(1,1) NOT NULL,
    [project_id] int  NULL,
    [report_id] int  NULL,
    [date_start] datetime  NULL,
    [date_end] datetime  NULL,
    [status] nvarchar(50)  NULL,
    [general_message] nvarchar(200)  NULL,
    [error_message] nvarchar(200)  NULL,
    [error_type] nvarchar(200)  NULL,
    [logs] varchar(max)  NULL,
    [test_name] nvarchar(200)  NULL,
    [author] nvarchar(200)  NULL,
    [duration] nvarchar(100)  NULL,
    [area] nvarchar(200)  NULL,
    [screenshot] varbinary(max)  NULL
);
GO

-- Creating table 'Request'
CREATE TABLE [dbo].[Request] (
    [id] int  NOT NULL,
    [date] datetime  NULL,
    [status] nvarchar(100)  NULL,
    [id_user] nvarchar(128)  NULL,
    [id_project] int  NULL,
    [id_batteryTest] int  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL
);
GO

-- Creating table 'Schedule'
CREATE TABLE [dbo].[Schedule] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [date_end] datetime  NULL,
    [date_start] datetime  NULL,
    [hour] time  NULL
);
GO

-- Creating table 'ScheduleWeekDays'
CREATE TABLE [dbo].[ScheduleWeekDays] (
    [id_schedule] int  NOT NULL,
    [id_weekDays] int  NOT NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'Step'
CREATE TABLE [dbo].[Step] (
    [id_action] int  NOT NULL,
    [id_object] int  NOT NULL,
    [last_update] datetime  NULL,
    [status] nvarchar(100)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Test'
CREATE TABLE [dbo].[Test] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [description] nvarchar(200)  NULL,
    [creation_date] nvarchar(100)  NULL,
    [id_project] int  NULL,
    [broswer] nvarchar(200)  NULL
);
GO

-- Creating table 'TestAction'
CREATE TABLE [dbo].[TestAction] (
    [id_test] int  NOT NULL,
    [id_action] int  NOT NULL,
    [date] datetime  NULL,
    [printscreen] varbinary(max)  NULL
);
GO

-- Creating table 'TestUser'
CREATE TABLE [dbo].[TestUser] (
    [id_user] nvarchar(128)  NOT NULL,
    [id_test] int  NOT NULL,
    [update_date] datetime  NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [UserId] nvarchar(128)  NOT NULL,
    [RoleId] nvarchar(128)  NOT NULL,
    [id_project] int  NOT NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'WeekDays'
CREATE TABLE [dbo].[WeekDays] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL
);
GO

-- Creating table 'TestBackoffice'
CREATE TABLE [dbo].[TestBackoffice] (
    [id] int IDENTITY(1,1) NOT NULL,
    [image] varbinary(max)  NULL,
    [color] nvarchar(10)  NULL,
    [id_user] nvarchar(100)  NULL
);
GO

-- Creating table 'Build'
CREATE TABLE [dbo].[Build] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_project] int  NOT NULL,
    [tool_name] nvarchar(100)  NULL,
    [date_start] datetime  NULL,
    [date_end] datetime  NULL,
    [status] nvarchar(100)  NULL,
    [general_message] nvarchar(100)  NULL,
    [id_batteryTest] int  NULL,
    [id_machine] int  NULL,
    [pass_tests] int  NULL,
    [duration] nvarchar(100)  NULL,
    [total_tests] int  NULL,
    [failed_tests] int  NULL,
    [skipped_tests] int  NULL,
    [username] nvarchar(100)  NULL
);
GO

-- Creating table 'Tools_Step'
CREATE TABLE [dbo].[Tools_Step] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_tools_test] int  NULL,
    [name] nvarchar(100)  NULL,
    [description] nvarchar(max)  NULL,
    [error_message] nvarchar(500)  NULL,
    [screenshot] nvarchar(100)  NULL,
    [duration] nvarchar(100)  NULL,
    [status] nvarchar(50)  NULL,
    [data_start] datetime  NULL,
    [data_end] datetime  NULL
);
GO

-- Creating table 'Tools_Test'
CREATE TABLE [dbo].[Tools_Test] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_build] int  NOT NULL,
    [id_project] int  NOT NULL,
    [name] nvarchar(100)  NULL,
    [status] nvarchar(100)  NULL,
    [date_start] datetime  NULL,
    [date_end] datetime  NULL,
    [duration] nvarchar(100)  NULL,
    [browser] nvarchar(100)  NULL,
    [site] nvarchar(100)  NULL,
    [general_message] nchar(100)  NULL,
    [description] nvarchar(max)  NULL,
    [error_message] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_action], [id_object] in table 'ActionObject'
ALTER TABLE [dbo].[ActionObject]
ADD CONSTRAINT [PK_ActionObject]
    PRIMARY KEY CLUSTERED ([id_action], [id_object] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [UserId], [RoleId], [id_project] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId], [id_project] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Attribute'
ALTER TABLE [dbo].[Attribute]
ADD CONSTRAINT [PK_Attribute]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Battery'
ALTER TABLE [dbo].[Battery]
ADD CONSTRAINT [PK_Battery]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [PK_BatteryTest]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_user], [id_battery] in table 'BatteryUser'
ALTER TABLE [dbo].[BatteryUser]
ADD CONSTRAINT [PK_BatteryUser]
    PRIMARY KEY CLUSTERED ([id_user], [id_battery] ASC);
GO

-- Creating primary key on [Id] in table 'Bug_reporting'
ALTER TABLE [dbo].[Bug_reporting]
ADD CONSTRAINT [PK_Bug_reporting]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bug_reporting_collection'
ALTER TABLE [dbo].[Bug_reporting_collection]
ADD CONSTRAINT [PK_Bug_reporting_collection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bug_reporting_step'
ALTER TABLE [dbo].[Bug_reporting_step]
ADD CONSTRAINT [PK_Bug_reporting_step]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Component'
ALTER TABLE [dbo].[Component]
ADD CONSTRAINT [PK_Component]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Credentials'
ALTER TABLE [dbo].[Credentials]
ADD CONSTRAINT [PK_Credentials]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Data'
ALTER TABLE [dbo].[Data]
ADD CONSTRAINT [PK_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_component], [id_project] in table 'DisplayComponent'
ALTER TABLE [dbo].[DisplayComponent]
ADD CONSTRAINT [PK_DisplayComponent]
    PRIMARY KEY CLUSTERED ([id_component], [id_project] ASC);
GO

-- Creating primary key on [id] in table 'Environment'
ALTER TABLE [dbo].[Environment]
ADD CONSTRAINT [PK_Environment]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Machine'
ALTER TABLE [dbo].[Machine]
ADD CONSTRAINT [PK_Machine]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Method'
ALTER TABLE [dbo].[Method]
ADD CONSTRAINT [PK_Method]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [PK_Object]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Report'
ALTER TABLE [dbo].[Report]
ADD CONSTRAINT [PK_Report]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Report_test_collection'
ALTER TABLE [dbo].[Report_test_collection]
ADD CONSTRAINT [PK_Report_test_collection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'ReportCollection'
ALTER TABLE [dbo].[ReportCollection]
ADD CONSTRAINT [PK_ReportCollection]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [PK_Request]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Schedule'
ALTER TABLE [dbo].[Schedule]
ADD CONSTRAINT [PK_Schedule]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_schedule], [id_weekDays] in table 'ScheduleWeekDays'
ALTER TABLE [dbo].[ScheduleWeekDays]
ADD CONSTRAINT [PK_ScheduleWeekDays]
    PRIMARY KEY CLUSTERED ([id_schedule], [id_weekDays] ASC);
GO

-- Creating primary key on [id_action], [id_object] in table 'Step'
ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [PK_Step]
    PRIMARY KEY CLUSTERED ([id_action], [id_object] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Test'
ALTER TABLE [dbo].[Test]
ADD CONSTRAINT [PK_Test]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_test], [id_action] in table 'TestAction'
ALTER TABLE [dbo].[TestAction]
ADD CONSTRAINT [PK_TestAction]
    PRIMARY KEY CLUSTERED ([id_test], [id_action] ASC);
GO

-- Creating primary key on [id_user], [id_test] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [PK_TestUser]
    PRIMARY KEY CLUSTERED ([id_user], [id_test] ASC);
GO

-- Creating primary key on [UserId], [RoleId], [id_project] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId], [id_project] ASC);
GO

-- Creating primary key on [id] in table 'WeekDays'
ALTER TABLE [dbo].[WeekDays]
ADD CONSTRAINT [PK_WeekDays]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TestBackoffice'
ALTER TABLE [dbo].[TestBackoffice]
ADD CONSTRAINT [PK_TestBackoffice]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Build'
ALTER TABLE [dbo].[Build]
ADD CONSTRAINT [PK_Build]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tools_Step'
ALTER TABLE [dbo].[Tools_Step]
ADD CONSTRAINT [PK_Tools_Step]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tools_Test'
ALTER TABLE [dbo].[Tools_Test]
ADD CONSTRAINT [PK_Tools_Test]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_action] in table 'ActionObject'
ALTER TABLE [dbo].[ActionObject]
ADD CONSTRAINT [FK_ActionObject_Action]
    FOREIGN KEY ([id_action])
    REFERENCES [dbo].[Action]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_action] in table 'Step'
ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [FK_Step_Action]
    FOREIGN KEY ([id_action])
    REFERENCES [dbo].[Action]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_action] in table 'TestAction'
ALTER TABLE [dbo].[TestAction]
ADD CONSTRAINT [FK_TestAction_Action]
    FOREIGN KEY ([id_action])
    REFERENCES [dbo].[Action]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestAction_Action'
CREATE INDEX [IX_FK_TestAction_Action]
ON [dbo].[TestAction]
    ([id_action]);
GO

-- Creating foreign key on [id_object] in table 'ActionObject'
ALTER TABLE [dbo].[ActionObject]
ADD CONSTRAINT [FK_ActionObject_Object]
    FOREIGN KEY ([id_object])
    REFERENCES [dbo].[Object]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionObject_Object'
CREATE INDEX [IX_FK_ActionObject_Object]
ON [dbo].[ActionObject]
    ([id_object]);
GO

-- Creating foreign key on [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetRoles'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetRoles]
ON [dbo].[AspNetUserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [RoleId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_AspNetRoles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_AspNetRoles'
CREATE INDEX [IX_FK_UserRole_AspNetRoles]
ON [dbo].[UserRole]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [id_project] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_AspNetUserLogins_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserLogins_Project'
CREATE INDEX [IX_FK_AspNetUserLogins_Project]
ON [dbo].[AspNetUserLogins]
    ([id_project]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_project] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_Project'
CREATE INDEX [IX_FK_AspNetUserRoles_Project]
ON [dbo].[AspNetUserRoles]
    ([id_project]);
GO

-- Creating foreign key on [id_user] in table 'BatteryUser'
ALTER TABLE [dbo].[BatteryUser]
ADD CONSTRAINT [FK_BatteryUser_AspNetUsers]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_user] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_Request_AspNetUsers]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Request_AspNetUsers'
CREATE INDEX [IX_FK_Request_AspNetUsers]
ON [dbo].[Request]
    ([id_user]);
GO

-- Creating foreign key on [id_user] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [FK_TestUser_AspNetUsers]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_attribute] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [FK_Object_Attribute]
    FOREIGN KEY ([id_attribute])
    REFERENCES [dbo].[Attribute]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Object_Attribute'
CREATE INDEX [IX_FK_Object_Attribute]
ON [dbo].[Object]
    ([id_attribute]);
GO

-- Creating foreign key on [id_project] in table 'Battery'
ALTER TABLE [dbo].[Battery]
ADD CONSTRAINT [FK_Battery_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Battery_Project'
CREATE INDEX [IX_FK_Battery_Project]
ON [dbo].[Battery]
    ([id_project]);
GO

-- Creating foreign key on [id_battery] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [FK_BatteryTest_Battery]
    FOREIGN KEY ([id_battery])
    REFERENCES [dbo].[Battery]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryTest_Battery'
CREATE INDEX [IX_FK_BatteryTest_Battery]
ON [dbo].[BatteryTest]
    ([id_battery]);
GO

-- Creating foreign key on [id_battery] in table 'BatteryUser'
ALTER TABLE [dbo].[BatteryUser]
ADD CONSTRAINT [FK_BatteryUser_Battery]
    FOREIGN KEY ([id_battery])
    REFERENCES [dbo].[Battery]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryUser_Battery'
CREATE INDEX [IX_FK_BatteryUser_Battery]
ON [dbo].[BatteryUser]
    ([id_battery]);
GO

-- Creating foreign key on [id_environment] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [FK_BatteryTest_Environment]
    FOREIGN KEY ([id_environment])
    REFERENCES [dbo].[Environment]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryTest_Environment'
CREATE INDEX [IX_FK_BatteryTest_Environment]
ON [dbo].[BatteryTest]
    ([id_environment]);
GO

-- Creating foreign key on [id_project] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [FK_BatteryTest_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryTest_Project'
CREATE INDEX [IX_FK_BatteryTest_Project]
ON [dbo].[BatteryTest]
    ([id_project]);
GO

-- Creating foreign key on [id_schedule] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [FK_BatteryTest_Schedule]
    FOREIGN KEY ([id_schedule])
    REFERENCES [dbo].[Schedule]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryTest_Schedule'
CREATE INDEX [IX_FK_BatteryTest_Schedule]
ON [dbo].[BatteryTest]
    ([id_schedule]);
GO

-- Creating foreign key on [id_test] in table 'BatteryTest'
ALTER TABLE [dbo].[BatteryTest]
ADD CONSTRAINT [FK_BatteryTest_Test]
    FOREIGN KEY ([id_test])
    REFERENCES [dbo].[Test]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BatteryTest_Test'
CREATE INDEX [IX_FK_BatteryTest_Test]
ON [dbo].[BatteryTest]
    ([id_test]);
GO

-- Creating foreign key on [id_batteryTest] in table 'Report'
ALTER TABLE [dbo].[Report]
ADD CONSTRAINT [FK_Report_BatteryTest]
    FOREIGN KEY ([id_batteryTest])
    REFERENCES [dbo].[BatteryTest]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Report_BatteryTest'
CREATE INDEX [IX_FK_Report_BatteryTest]
ON [dbo].[Report]
    ([id_batteryTest]);
GO

-- Creating foreign key on [id_batteryTest] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_Request_BatteryTest]
    FOREIGN KEY ([id_batteryTest])
    REFERENCES [dbo].[BatteryTest]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Request_BatteryTest'
CREATE INDEX [IX_FK_Request_BatteryTest]
ON [dbo].[Request]
    ([id_batteryTest]);
GO

-- Creating foreign key on [id_component] in table 'DisplayComponent'
ALTER TABLE [dbo].[DisplayComponent]
ADD CONSTRAINT [FK_DisplayComponent_Component]
    FOREIGN KEY ([id_component])
    REFERENCES [dbo].[Component]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_data] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [FK_Object_Data]
    FOREIGN KEY ([id_data])
    REFERENCES [dbo].[Data]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Object_Data'
CREATE INDEX [IX_FK_Object_Data]
ON [dbo].[Object]
    ([id_data]);
GO

-- Creating foreign key on [id_project] in table 'DisplayComponent'
ALTER TABLE [dbo].[DisplayComponent]
ADD CONSTRAINT [FK_DisplayComponent_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisplayComponent_Project'
CREATE INDEX [IX_FK_DisplayComponent_Project]
ON [dbo].[DisplayComponent]
    ([id_project]);
GO

-- Creating foreign key on [id_machine] in table 'Report'
ALTER TABLE [dbo].[Report]
ADD CONSTRAINT [FK_Report_Machine]
    FOREIGN KEY ([id_machine])
    REFERENCES [dbo].[Machine]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Report_Machine'
CREATE INDEX [IX_FK_Report_Machine]
ON [dbo].[Report]
    ([id_machine]);
GO

-- Creating foreign key on [id_method] in table 'Object'
ALTER TABLE [dbo].[Object]
ADD CONSTRAINT [FK_Object_Method]
    FOREIGN KEY ([id_method])
    REFERENCES [dbo].[Method]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Object_Method'
CREATE INDEX [IX_FK_Object_Method]
ON [dbo].[Object]
    ([id_method]);
GO

-- Creating foreign key on [id_object] in table 'Step'
ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [FK_Step_Object]
    FOREIGN KEY ([id_object])
    REFERENCES [dbo].[Object]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Step_Object'
CREATE INDEX [IX_FK_Step_Object]
ON [dbo].[Step]
    ([id_object]);
GO

-- Creating foreign key on [id_project] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_Request_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Request_Project'
CREATE INDEX [IX_FK_Request_Project]
ON [dbo].[Request]
    ([id_project]);
GO

-- Creating foreign key on [id_project] in table 'Test'
ALTER TABLE [dbo].[Test]
ADD CONSTRAINT [FK_Test_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Test_Project'
CREATE INDEX [IX_FK_Test_Project]
ON [dbo].[Test]
    ([id_project]);
GO

-- Creating foreign key on [id_project] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Project'
CREATE INDEX [IX_FK_UserRole_Project]
ON [dbo].[UserRole]
    ([id_project]);
GO

-- Creating foreign key on [id_schedule] in table 'ScheduleWeekDays'
ALTER TABLE [dbo].[ScheduleWeekDays]
ADD CONSTRAINT [FK_ScheduleWeekDays_Schedule]
    FOREIGN KEY ([id_schedule])
    REFERENCES [dbo].[Schedule]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_weekDays] in table 'ScheduleWeekDays'
ALTER TABLE [dbo].[ScheduleWeekDays]
ADD CONSTRAINT [FK_ScheduleWeekDays_WeekDays]
    FOREIGN KEY ([id_weekDays])
    REFERENCES [dbo].[WeekDays]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleWeekDays_WeekDays'
CREATE INDEX [IX_FK_ScheduleWeekDays_WeekDays]
ON [dbo].[ScheduleWeekDays]
    ([id_weekDays]);
GO

-- Creating foreign key on [id_test] in table 'TestAction'
ALTER TABLE [dbo].[TestAction]
ADD CONSTRAINT [FK_TestAction_Test]
    FOREIGN KEY ([id_test])
    REFERENCES [dbo].[Test]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_test] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [FK_TestUser_Test]
    FOREIGN KEY ([id_test])
    REFERENCES [dbo].[Test]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestUser_Test'
CREATE INDEX [IX_FK_TestUser_Test]
ON [dbo].[TestUser]
    ([id_test]);
GO

-- Creating foreign key on [id_batteryTest] in table 'Build'
ALTER TABLE [dbo].[Build]
ADD CONSTRAINT [FK_Build_BatteryTest]
    FOREIGN KEY ([id_batteryTest])
    REFERENCES [dbo].[BatteryTest]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Build_BatteryTest'
CREATE INDEX [IX_FK_Build_BatteryTest]
ON [dbo].[Build]
    ([id_batteryTest]);
GO

-- Creating foreign key on [id_machine] in table 'Build'
ALTER TABLE [dbo].[Build]
ADD CONSTRAINT [FK_Build_Machine]
    FOREIGN KEY ([id_machine])
    REFERENCES [dbo].[Machine]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Build_Machine'
CREATE INDEX [IX_FK_Build_Machine]
ON [dbo].[Build]
    ([id_machine]);
GO

-- Creating foreign key on [id_project] in table 'Build'
ALTER TABLE [dbo].[Build]
ADD CONSTRAINT [FK_Build_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Build_Project'
CREATE INDEX [IX_FK_Build_Project]
ON [dbo].[Build]
    ([id_project]);
GO

-- Creating foreign key on [id_build] in table 'Tools_Test'
ALTER TABLE [dbo].[Tools_Test]
ADD CONSTRAINT [FK_Tools_Test_Build]
    FOREIGN KEY ([id_build])
    REFERENCES [dbo].[Build]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tools_Test_Build'
CREATE INDEX [IX_FK_Tools_Test_Build]
ON [dbo].[Tools_Test]
    ([id_build]);
GO

-- Creating foreign key on [id_project] in table 'Tools_Test'
ALTER TABLE [dbo].[Tools_Test]
ADD CONSTRAINT [FK_Tools_Test_Project]
    FOREIGN KEY ([id_project])
    REFERENCES [dbo].[Project]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tools_Test_Project'
CREATE INDEX [IX_FK_Tools_Test_Project]
ON [dbo].[Tools_Test]
    ([id_project]);
GO

-- Creating foreign key on [id_tools_test] in table 'Tools_Step'
ALTER TABLE [dbo].[Tools_Step]
ADD CONSTRAINT [FK_Tools_Step_Tools_Test]
    FOREIGN KEY ([id_tools_test])
    REFERENCES [dbo].[Tools_Test]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tools_Step_Tools_Test'
CREATE INDEX [IX_FK_Tools_Step_Tools_Test]
ON [dbo].[Tools_Step]
    ([id_tools_test]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------