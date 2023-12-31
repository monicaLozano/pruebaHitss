USE [master]
GO
/****** Object:  Database [PruebaHits]    Script Date: 18/11/2023 22:52:40 ******/
CREATE DATABASE [PruebaHits]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaHits', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PruebaHits.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaHits_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PruebaHits_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaHits] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaHits].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaHits] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaHits] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaHits] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaHits] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaHits] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaHits] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaHits] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaHits] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaHits] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaHits] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaHits] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaHits] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaHits] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaHits] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaHits] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaHits] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaHits] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaHits] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaHits] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaHits] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaHits] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaHits] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaHits] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PruebaHits] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaHits] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaHits] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaHits] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaHits] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaHits] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaHits] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PruebaHits] SET QUERY_STORE = OFF
GO
USE [PruebaHits]
GO
/****** Object:  Table [dbo].[TbClient]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbClient](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[address] [nvarchar](200) NULL,
	[phone] [bigint] NULL,
 CONSTRAINT [PK_TbClient] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbProduct]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbProduct](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[quantity] [bigint] NOT NULL,
	[price] [bigint] NOT NULL,
 CONSTRAINT [PK_TbProduct] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[del_Client]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[del_Client]
	@idClient as int
AS
BEGIN
	DELETE FROM dbo.TbClient WHERE idClient = @idClient
END
GO
/****** Object:  StoredProcedure [dbo].[del_Product]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[del_Product]
	@idProduct as int
AS
BEGIN
	DELETE FROM dbo.TbProduct WHERE idProduct = @idProduct
END
GO
/****** Object:  StoredProcedure [dbo].[ins_Client]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ins_Client]
	@fullName as NVARCHAR(100),
	@Email as NVARCHAR(150),
	@address as NVARCHAR(200),
	@phone as BIGINT
AS
BEGIN
	INSERT dbo.TbClient
	(	
		fullName, 
		Email,
		[address],
		phone
	)
	VALUES
	(
		@fullName,
		@Email,
		@address,
		@phone
	)
END
GO
/****** Object:  StoredProcedure [dbo].[ins_Product]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ins_Product]
	@productName as NVARCHAR(100),
	@description as NVARCHAR(150),
	@quantity as NVARCHAR(200),
	@price as BIGINT
AS
BEGIN
	INSERT dbo.TbProduct
	(	
		productName, 
		[description],
		quantity,
		price
	)
	VALUES
	(
		@productName,
		@description,
		@quantity,
		@price
	)
END
GO
/****** Object:  StoredProcedure [dbo].[sel_Clients]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sel_Clients]

AS
BEGIN
	SELECT * FROM dbo.TbClient
END
GO
/****** Object:  StoredProcedure [dbo].[sel_OnlyClient]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sel_OnlyClient]
	@idClient as int
AS
BEGIN
	SELECT * FROM dbo.TbClient where idClient = @idClient
END
GO
/****** Object:  StoredProcedure [dbo].[sel_OnlyProduct]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sel_OnlyProduct]
	@idProduct as int
AS
BEGIN
	SELECT * FROM dbo.TbProduct where idProduct = @idProduct
END
GO
/****** Object:  StoredProcedure [dbo].[sel_Products]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sel_Products]

AS
BEGIN
	SELECT * FROM dbo.TbProduct
END
GO
/****** Object:  StoredProcedure [dbo].[upd_Client]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[upd_Client]
	@idClient as int,
	@fullname as NVARCHAR(100),
	@Email as NVARCHAR(150),
	@address as NVARCHAR(200),
	@phone as BIGINT
AS
BEGIN
	UPDATE dbo.TbClient SET fullName = @fullname, Email = @Email, [address] = @address, phone = @phone WHERE idClient = @idClient
END
GO
/****** Object:  StoredProcedure [dbo].[upd_Product]    Script Date: 18/11/2023 22:52:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[upd_Product]
	@idProduct as int,
	@productName as NVARCHAR(100),
	@description as NVARCHAR(150),
	@quantity as NVARCHAR(200),
	@price as BIGINT
AS
BEGIN
	UPDATE dbo.TbProduct SET productName = @productName, [description] = @description, [quantity] = @quantity, price = @price WHERE idProduct = @idProduct
END
GO
USE [master]
GO
ALTER DATABASE [PruebaHits] SET  READ_WRITE 
GO
