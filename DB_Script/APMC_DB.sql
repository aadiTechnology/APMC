
/****** Object:  Database [APMC]    Script Date: 28/10/2020 12:22:41 PM ******/
CREATE DATABASE [APMC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APMC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\APMC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'APMC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\APMC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [APMC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APMC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APMC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APMC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APMC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APMC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APMC] SET ARITHABORT OFF 
GO
ALTER DATABASE [APMC] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [APMC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APMC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APMC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APMC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APMC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APMC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APMC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APMC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APMC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [APMC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APMC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APMC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APMC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APMC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APMC] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [APMC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APMC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [APMC] SET  MULTI_USER 
GO
ALTER DATABASE [APMC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APMC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APMC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APMC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [APMC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [APMC] SET QUERY_STORE = OFF
GO
USE [APMC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndentDetails]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [nvarchar](max) NULL,
	[ProductWeight] [real] NOT NULL,
	[OrderNo] [int] NOT NULL,
	[ETATime] [nvarchar](max) NULL,
	[VehicleNo] [nvarchar](max) NULL,
	[SupplierNo] [nvarchar](max) NULL,
	[SupplierName] [nvarchar](max) NULL,
	[DriverName] [nvarchar](max) NULL,
	[DriverNo] [nvarchar](max) NULL,
	[RollId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[AppovedBy] [int] NOT NULL,
	[IsApprove] [bit] NOT NULL,
	[IsRejected] [bit] NOT NULL,
	[RejectReason] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_IndentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StallDetails]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StallDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StallNo] [nvarchar](max) NULL,
	[StallName] [nvarchar](max) NULL,
	[StallRegNo] [nvarchar](max) NULL,
	[Area] [nvarchar](max) NULL,
	[IsAssigned] [bit] NOT NULL,
 CONSTRAINT [PK_StallDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StallProductCategories]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StallProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StallRegistrationId] [int] NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_StallProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StallRegistration]    Script Date: 28/10/2020 12:22:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StallRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StallId] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsRejected] [bit] NOT NULL,
	[ApproveBy] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ApprovedDate] [datetime2](7) NOT NULL,
	[RejectReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_StallRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201027103106_InitialCreate', N'3.1.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201028064224_UpdateDatabase', N'3.1.8')
GO
SET IDENTITY_INSERT [dbo].[AppUserRoles] ON 
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (2, N'Merchant')
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (3, N'Driver')
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (4, N'Gate Operator')
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (5, N'Agent')
GO
INSERT [dbo].[AppUserRoles] ([Id], [RoleName]) VALUES (6, N'Transporter')
GO
SET IDENTITY_INSERT [dbo].[AppUserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (1, N'Fruits')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (2, N'Vegetables')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (3, N'Flowers')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (4, N'Dry Fruits ')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (5, N'Spices')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (6, N'Fertilizers & Manures')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (7, N'Dairy')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (8, N'Packaging Material')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (9, N'Farm Equipments')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (10, N'Grains')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (11, N'Fishery')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (12, N'Pulses')
GO
INSERT [dbo].[ProductCategory] ([Id], [Category]) VALUES (13, N'Cereals')
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
ALTER TABLE [dbo].[AppUsers] ADD  DEFAULT ((0)) FOR [RoleId]
GO
USE [master]
GO
ALTER DATABASE [APMC] SET  READ_WRITE 
GO
