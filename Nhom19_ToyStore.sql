USE [master]
GO
/****** Object:  Database [Nhom19_ToysStore]    Script Date: 22/11/2022 10:08:07 PM ******/
CREATE DATABASE [Nhom19_ToysStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nhom19_ToysStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Nhom19_ToysStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nhom19_ToysStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Nhom19_ToysStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Nhom19_ToysStore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nhom19_ToysStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nhom19_ToysStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nhom19_ToysStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nhom19_ToysStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Nhom19_ToysStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nhom19_ToysStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET RECOVERY FULL 
GO
ALTER DATABASE [Nhom19_ToysStore] SET  MULTI_USER 
GO
ALTER DATABASE [Nhom19_ToysStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nhom19_ToysStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nhom19_ToysStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nhom19_ToysStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nhom19_ToysStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Nhom19_ToysStore', N'ON'
GO
ALTER DATABASE [Nhom19_ToysStore] SET QUERY_STORE = OFF
GO
USE [Nhom19_ToysStore]
GO
/****** Object:  User [bo]    Script Date: 22/11/2022 10:08:07 PM ******/
CREATE USER [bo] FOR LOGIN [bo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ben]    Script Date: 22/11/2022 10:08:07 PM ******/
CREATE USER [ben] FOR LOGIN [ben] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [role_for_customer]    Script Date: 22/11/2022 10:08:07 PM ******/
CREATE ROLE [role_for_customer]
GO
ALTER ROLE [role_for_customer] ADD MEMBER [ben]
GO
/****** Object:  Schema [role_for_customer]    Script Date: 22/11/2022 10:08:07 PM ******/
CREATE SCHEMA [role_for_customer]
GO
/****** Object:  UserDefinedFunction [dbo].[AddOrderNumber]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[AddOrderNumber]()
returns varchar(10)
as
begin
 declare @string varchar(10)
 set @string = 'ord'+'-'+CONVERT(varchar(4), (select count(order_number)+1000 from [Order])) 
 return @string
end
GO
/****** Object:  UserDefinedFunction [dbo].[AddPaymentID]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[AddPaymentID]()
returns varchar(10)
as
begin
 declare @string varchar(10)
 set @string = 'pay'+'-'+CONVERT(varchar(4), (select count(payment_id)+1000 from Payment)) 
 return @string
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetProductPrice]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetProductPrice](@product int)
returns float
as
begin
 declare @price float
 select @price = price from Toys where toy_id = @product
 return @price
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetQuantity]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetQuantity](@variation varchar(10))
returns int
as
begin
 declare @quantity int

 select @quantity = sum(quantity) 
 from Cart_Items
 where is_active = 0 and [user] = CURRENT_USER
 group by variation
 having variation = @variation

 return @quantity
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetStock]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetStock](@variation_id varchar(10))
returns int
as
begin
 return (select variation_stock from Variation where variation_id = @variation_id)
end
GO
/****** Object:  UserDefinedFunction [dbo].[IsSoldOut]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[IsSoldOut](@variation_id varchar(10))
returns bit
as
begin
 DECLARE @result bit
 if(exists (select * from Variation where variation_id = @variation_id and variation_stock > 0  and is_active = 1))
   SET @result = 0
 else
   SET @result = 1
 return @result
end
GO
/****** Object:  UserDefinedFunction [dbo].[LastCart]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[LastCart]()
returns datetime
as
begin
 declare @last_cart_id datetime
 SELECT TOP 1 @last_cart_id = card_id FROM Cart ORDER BY card_id DESC
 return @last_cart_id
end
GO
/****** Object:  UserDefinedFunction [dbo].[OrderTotal]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[OrderTotal](@user varchar(100))
returns float
as
begin
 declare @sum float
 select @sum = sum(quantity * price)
 from Cart_Items join Variation
 on Cart_Items.variation = Variation.variation_id
 join Toys
 on Variation.product = Toys.toy_id
 where Cart_Items.is_active = 0
 group by [user]
 having [user] = @user

 return @sum
end
GO
/****** Object:  UserDefinedFunction [dbo].[setTax]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[setTax]()
returns float
as
begin
  declare @settax float
  set @settax = 0.02
  return @settax
end
GO
/****** Object:  UserDefinedFunction [dbo].[Tax]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Tax](@user varchar(100))
returns float
as
begin
  declare @tax float
  set @tax = dbo.setTax() * dbo.OrderTotal(@user)
  return @tax
end
GO
/****** Object:  UserDefinedFunction [dbo].[WhatToy]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[WhatToy](@variation varchar(10))
returns int
as
begin
 declare @toy_id int
 select @toy_id = product from Variation where variation_id = @variation
 return @toy_id
end
GO
/****** Object:  Table [dbo].[Toys]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toys](
	[toy_id] [int] NOT NULL,
	[toy_name] [varchar](200) NOT NULL,
	[category] [varchar](50) NULL,
	[description] [varchar](500) NULL,
	[price] [float] NOT NULL,
	[image] [varchar](20) NULL,
	[stock] [int] NULL,
	[is_available] [varchar](11) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[modified_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Toys] PRIMARY KEY CLUSTERED 
(
	[toy_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Random6Toys]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Random6Toys]
as
select top 3 toy_id,toy_name,price,[image] from Toys
order by newid()
GO
/****** Object:  View [dbo].[UserPermission]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[UserPermission]
as
SELECT  pri.name As Username
,       pri.type_desc AS [User Type]
,       permit.permission_name AS [Permission]
,       permit.state_desc AS [Permission State]
,       permit.class_desc Class
,       object_name(permit.major_id) AS [Object Name]
FROM    sys.database_principals pri
LEFT JOIN
        sys.database_permissions permit
ON      permit.grantee_principal_id = pri.principal_id
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[card_id] [datetime] NOT NULL,
	[is_available] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[card_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart_Items]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_Items](
	[user] [varchar](100) NULL,
	[product] [int] NOT NULL,
	[variation] [varchar](10) NOT NULL,
	[cart_items_id] [datetime] NOT NULL,
	[quantity] [int] NOT NULL,
	[is_active] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_slug] [varchar](50) NOT NULL,
	[category_fullname] [varchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[category_slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[order_number] [varchar](10) NOT NULL,
	[user] [varchar](100) NOT NULL,
	[payment] [varchar](10) NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NULL,
	[phone] [varchar](10) NOT NULL,
	[email] [varchar](50) NULL,
	[address] [varchar](100) NOT NULL,
	[order_note] [varchar](500) NULL,
	[order_total] [float] NULL,
	[tax] [float] NULL,
	[status] [varchar](10) NOT NULL,
	[is_payment] [bit] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[update_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[order] [varchar](10) NOT NULL,
	[payment] [varchar](10) NULL,
	[user] [varchar](100) NOT NULL,
	[product] [int] NOT NULL,
	[variations] [varchar](10) NOT NULL,
	[quantity] [int] NOT NULL,
	[product_price] [float] NOT NULL,
	[ordered] [bit] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[update_at] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[payment_id] [varchar](10) NOT NULL,
	[user] [varchar](100) NOT NULL,
	[payment_method] [varchar](100) NOT NULL,
	[amount_paid] [float] NULL,
	[status] [varchar](100) NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [varchar](100) NOT NULL,
	[pass] [varchar](255) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[email] [varchar](100) NULL,
	[phone_number] [varchar](10) NULL,
	[avatar] [varchar](20) NULL,
	[is_admin] [bit] NOT NULL,
	[date_joined] [datetime] NOT NULL,
	[last_login] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Variation]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Variation](
	[variation_id] [varchar](10) NOT NULL,
	[product] [int] NOT NULL,
	[color] [varchar](20) NOT NULL,
	[size] [varchar](20) NOT NULL,
	[variation_stock] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[variation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T12:42:33.980' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T16:48:37.377' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T16:49:55.940' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T16:50:12.777' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T16:50:26.730' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T17:25:00.070' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T17:43:30.090' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T17:43:41.030' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T21:47:15.647' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T21:47:41.090' AS DateTime), 1)
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-11-22T21:48:00.800' AS DateTime), 1)
GO
INSERT [dbo].[Cart_Items] ([user], [product], [variation], [cart_items_id], [quantity], [is_active]) VALUES (N'dbo', 102, N'vari-102-1', CAST(N'2022-11-22T21:47:41.090' AS DateTime), 2, 1)
INSERT [dbo].[Cart_Items] ([user], [product], [variation], [cart_items_id], [quantity], [is_active]) VALUES (N'dbo', 103, N'vari-103-1', CAST(N'2022-11-22T21:48:00.800' AS DateTime), 5, 1)
GO
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'action-figures', N'Action Figures')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'collectible-figures', N'Collectible Figures')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'dan-gian', N'Tro Choi Dan Gian')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'nerf', N'Neft and Toy Blasters')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'vehicles', N'Phuong Tien Giao Thon')
GO
INSERT [dbo].[Order] ([order_number], [user], [payment], [first_name], [last_name], [phone], [email], [address], [order_note], [order_total], [tax], [status], [is_payment], [created_date], [update_at]) VALUES (N'ord-1000', N'dbo', N'pay-1000', N'ben', N'ben', N'123', N'ben@ben', N'hue', N'goi hang can than', 87.5, 1.75, N'New', 1, CAST(N'2022-11-22T21:49:10.120' AS DateTime), CAST(N'2022-11-22T21:49:10.120' AS DateTime))
GO
INSERT [dbo].[OrderProduct] ([order], [payment], [user], [product], [variations], [quantity], [product_price], [ordered], [created_date], [update_at]) VALUES (N'ord-1000', NULL, N'dbo', 102, N'vari-102-1', 2, 5, 1, CAST(N'2022-11-22T21:49:10.150' AS DateTime), CAST(N'2022-11-22T21:49:10.150' AS DateTime))
INSERT [dbo].[OrderProduct] ([order], [payment], [user], [product], [variations], [quantity], [product_price], [ordered], [created_date], [update_at]) VALUES (N'ord-1000', NULL, N'dbo', 103, N'vari-103-1', 5, 15.5, 1, CAST(N'2022-11-22T21:49:10.153' AS DateTime), CAST(N'2022-11-22T21:49:10.153' AS DateTime))
GO
INSERT [dbo].[Payment] ([payment_id], [user], [payment_method], [amount_paid], [status], [created_at]) VALUES (N'pay-1000', N'dbo', N'bidv', 89, N'New', CAST(N'2022-11-22T21:53:13.500' AS DateTime))
GO
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (100, N'Transformers Studio', N'action-figures', N'Studio Series has always allowed fans to reach past the big screen and build the ultimate Transformers collection inspired by iconic movie scenes from the Transformers movie universe. Now, the Studio Series line is expanding to include the epic moments and characters from the classic The Transformers: The Movie, bringing fans a whole new series of screen-inspired figures to collect! (Each sold separately. Subject to availability.)This Studio Series 86-07 Leader Class The Transformers: The Movie-', 10, N'100.jpg', NULL, N'already', CAST(N'2022-11-22T12:17:47.110' AS DateTime), CAST(N'2022-11-22T12:17:47.110' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (101, N'Marvel Spider-Man', N'action-figures', N'Twist Turn Flex your power Kids can bend, flex, pose, and play with their favorite Marvel Super Heroes and Villains with these super agile Spider-Man Bend and Flex Figures Collect characters inspired by Marvel Universe with a twist (each sold separately). These stylized Super Hero action figures have bendable arms and legs that can bend and hold in place for the perfect pose There''s plenty of heroic daring and dramatic action when kids shape their Bend and Flex figures into plenty of playful', 50, N'101.jpg', NULL, N'already', CAST(N'2022-11-22T12:18:12.923' AS DateTime), CAST(N'2022-11-22T12:18:12.923' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (102, N'Con Lan', N'dan-gian', N'dam chat Viet Nam', 5, N'102.jpg', NULL, N'already', CAST(N'2022-11-22T12:17:23.810' AS DateTime), CAST(N'2022-11-22T12:17:23.810' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (103, N'Den Ong Sao', N'dan-gian', N'dam chat trung thu', 15.5, N'103.jpg', NULL, N'already', CAST(N'2022-11-22T12:18:33.693' AS DateTime), CAST(N'2022-11-22T12:18:33.693' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (104, N'To He', N'dan-gian', N'tro ve tuoi tho', 2.2, N'104.jpg', NULL, N'already', CAST(N'2022-11-22T12:18:40.473' AS DateTime), CAST(N'2022-11-22T12:18:40.473' AS DateTime))
GO
INSERT [dbo].[User] ([user_id], [pass], [firstname], [lastname], [email], [phone_number], [avatar], [is_admin], [date_joined], [last_login]) VALUES (N'ben', N'123', N'ben', N'quang', N'ben1905@gmail.com', N'0123456', NULL, 0, CAST(N'2022-11-22T12:28:39.403' AS DateTime), NULL)
INSERT [dbo].[User] ([user_id], [pass], [firstname], [lastname], [email], [phone_number], [avatar], [is_admin], [date_joined], [last_login]) VALUES (N'bo', N'123', N'bao', N'thy', N'baothy2906@gmail.com', N'0123465', NULL, 1, CAST(N'2022-11-22T12:29:22.333' AS DateTime), NULL)
INSERT [dbo].[User] ([user_id], [pass], [firstname], [lastname], [email], [phone_number], [avatar], [is_admin], [date_joined], [last_login]) VALUES (N'dbo', N'123', N'bao', N'thy', N'thy2906@gmail.com', N'0123456', NULL, 1, CAST(N'2022-11-22T16:49:37.740' AS DateTime), NULL)
GO
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-102-1', 102, N'white', N'small', 3, 1, CAST(N'2022-11-22T12:19:34.547' AS DateTime))
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-102-2', 102, N'white', N'medium', 5, 1, CAST(N'2022-11-22T12:20:00.950' AS DateTime))
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-102-3', 102, N'black', N'medium', 10, 1, CAST(N'2022-11-22T12:20:16.347' AS DateTime))
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-103-1', 103, N'white', N'large', 15, 1, CAST(N'2022-11-22T12:20:30.080' AS DateTime))
GO
ALTER TABLE [dbo].[Cart] ADD  CONSTRAINT [DF_Cart_card_id]  DEFAULT (getdate()) FOR [card_id]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((1)) FOR [is_available]
GO
ALTER TABLE [dbo].[Cart_Items] ADD  CONSTRAINT [DF__Cart_Item__is_ac__73BA3083]  DEFAULT ((0)) FOR [is_active]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('New') FOR [status]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [is_payment]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF__OrderProd__order__70DDC3D8]  DEFAULT ((1)) FOR [ordered]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF__OrderProd__creat__71D1E811]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  CONSTRAINT [DF__OrderProd__updat__72C60C4A]  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[Payment] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Toys] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Toys] ADD  DEFAULT ('already') FOR [is_available]
GO
ALTER TABLE [dbo].[Toys] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[Toys] ADD  DEFAULT (getdate()) FOR [modified_date]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [date_joined]
GO
ALTER TABLE [dbo].[Variation] ADD  DEFAULT ((0)) FOR [variation_stock]
GO
ALTER TABLE [dbo].[Variation] ADD  DEFAULT ((1)) FOR [is_active]
GO
ALTER TABLE [dbo].[Variation] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD FOREIGN KEY([cart_items_id])
REFERENCES [dbo].[Cart] ([card_id])
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD FOREIGN KEY([product])
REFERENCES [dbo].[Toys] ([toy_id])
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD FOREIGN KEY([variation])
REFERENCES [dbo].[Variation] ([variation_id])
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([payment])
REFERENCES [dbo].[Payment] ([payment_id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__order__73BA3083] FOREIGN KEY([order])
REFERENCES [dbo].[Order] ([order_number])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__order__73BA3083]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__payme__74AE54BC] FOREIGN KEY([payment])
REFERENCES [dbo].[Payment] ([payment_id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__payme__74AE54BC]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__produ__75A278F5] FOREIGN KEY([product])
REFERENCES [dbo].[Toys] ([toy_id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__produ__75A278F5]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__varia__76969D2E] FOREIGN KEY([variations])
REFERENCES [dbo].[Variation] ([variation_id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__varia__76969D2E]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProdu__user__778AC167] FOREIGN KEY([user])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProdu__user__778AC167]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD FOREIGN KEY([category])
REFERENCES [dbo].[Category] ([category_slug])
GO
ALTER TABLE [dbo].[Variation]  WITH CHECK ADD FOREIGN KEY([product])
REFERENCES [dbo].[Toys] ([toy_id])
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD  CONSTRAINT [check_quantity_behon_stock] CHECK  (([quantity]<=[dbo].[GetStock]([variation])))
GO
ALTER TABLE [dbo].[Cart_Items] CHECK CONSTRAINT [check_quantity_behon_stock]
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD  CONSTRAINT [check_quantity_not_negative] CHECK  (([quantity]>(0)))
GO
ALTER TABLE [dbo].[Cart_Items] CHECK CONSTRAINT [check_quantity_not_negative]
GO
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD CHECK  (([price]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[AddCartItems]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddCartItems] @variation_id varchar(10), @quantity int
as
begin
 insert into Cart(is_available) values (1)
 insert into Cart_Items([user],product,variation,cart_items_id,quantity) values (CURRENT_USER,dbo.WhatToy(@variation_id),@variation_id,dbo.LastCart(),@quantity)
end
GO
/****** Object:  StoredProcedure [dbo].[AddOrder]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddOrder] @first_name varchar(50), @last_name varchar(50), @phone varchar(10), @email varchar(50), @address varchar(100),@order_note varchar(500)  
as
begin
 insert into [Order](order_number,[user],first_name,last_name,phone,email,[address],order_note,order_total,tax) 
 values (dbo.AddOrderNumber(),CURRENT_USER,@first_name,@last_name,@phone,@email,@address,@order_note,dbo.OrderTotal(CURRENT_USER),dbo.Tax(CURRENT_USER))
end
GO
/****** Object:  StoredProcedure [dbo].[AddOrderProduct]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddOrderProduct] @order_number varchar(10), @variation varchar(10)
as
begin
 declare @product int, @quantity varchar(10), @price float
 set @product = dbo.WhatToy(@variation)
 set @quantity = dbo.GetQuantity(@variation)
 set @price = dbo.GetProductPrice(dbo.WhatToy(@variation))
 insert into OrderProduct([order],[user],product,variations,quantity,product_price)
 values (@order_number,CURRENT_USER,@product,@variation,@quantity,@price)
end
GO
/****** Object:  StoredProcedure [dbo].[AddPayment]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[AddPayment] @order_number varchar(10),@payment_method varchar(100), @amount_paid float
as
begin
 declare @payment varchar(10)
 set @payment = dbo.AddPaymentID()
 insert into Payment(payment_id,[user],payment_method,amount_paid,[status]) values (@payment,CURRENT_USER,@payment_method,@amount_paid,'New')
 update [Order]
 set payment = @payment, is_payment = 1
 where order_number = @order_number
end
GO
/****** Object:  StoredProcedure [dbo].[GetCurrentUser]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCurrentUser]
as
begin
select CURRENT_USER
end
GO
/****** Object:  StoredProcedure [dbo].[GetToy]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetToy] (@toy_id int)
as
begin 
select toy_id,toy_name,category,[description],price,[image] from Toys where toy_id = @toy_id
end
GO
/****** Object:  StoredProcedure [dbo].[GetVariation]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetVariation] @variation_id varchar(10)
as
begin
select * from Variation where variation_id = @variation_id
end
GO
/****** Object:  StoredProcedure [dbo].[GetVariations]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetVariations] @toy_id int
as
begin
select variation_id,product,color,size from Variation where product = @toy_id
end
GO
/****** Object:  StoredProcedure [dbo].[IsSoldOut_Proc]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IsSoldOut_Proc] @variation_id varchar(10)
as
begin
select dbo.IsSoldOut(@variation_id)
end
GO
/****** Object:  StoredProcedure [dbo].[Random6Toys_Proc]    Script Date: 22/11/2022 10:08:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Random6Toys_Proc]
as
begin
select * from Random6Toys
end
GO
USE [master]
GO
ALTER DATABASE [Nhom19_ToysStore] SET  READ_WRITE 
GO
