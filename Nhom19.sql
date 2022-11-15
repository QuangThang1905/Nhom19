USE [master]
GO
/****** Object:  Database [Hai]    Script Date: 15/11/2022 11:24:42 AM ******/
CREATE DATABASE [Hai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Hai] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hai] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hai] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Hai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hai] SET RECOVERY FULL 
GO
ALTER DATABASE [Hai] SET  MULTI_USER 
GO
ALTER DATABASE [Hai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hai] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hai] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Hai', N'ON'
GO
ALTER DATABASE [Hai] SET QUERY_STORE = OFF
GO
USE [Hai]
GO
/****** Object:  User [customer]    Script Date: 15/11/2022 11:24:42 AM ******/
CREATE USER [customer] FOR LOGIN [customer] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [bo]    Script Date: 15/11/2022 11:24:42 AM ******/
CREATE USER [bo] FOR LOGIN [bo] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [role_for_customer]    Script Date: 15/11/2022 11:24:42 AM ******/
CREATE ROLE [role_for_customer]
GO
ALTER ROLE [role_for_customer] ADD MEMBER [customer]
GO
/****** Object:  Schema [role_for_customer]    Script Date: 15/11/2022 11:24:43 AM ******/
CREATE SCHEMA [role_for_customer]
GO
/****** Object:  UserDefinedFunction [dbo].[IsAdmin]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[IsAdmin] (@user_id varchar(100))
returns bit
as
begin
 DECLARE @result bit
 if(exists (select * from [User] where user_id = @user_id and is_admin = 1))
   SET @result = 1
 else
   SET @result = 0
 return @result
end
GO
/****** Object:  UserDefinedFunction [dbo].[IsExistUser]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[IsExistUser] (@user_id varchar(100))
returns bit
as
begin
 DECLARE @result bit
 if(exists (select * from [User] where user_id = @user_id))
   SET @result = 1
 else
   SET @result = 0
 return @result
end
GO
/****** Object:  UserDefinedFunction [dbo].[IsValidPassword]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[IsValidPassword] (@user_id varchar(100), @pass varchar(255))
returns bit
as
begin
 DECLARE @result bit
 if(exists (select * from [User] where user_id = @user_id and pass = @pass))
   SET @result = 1
 else
   SET @result = 0
 return @result
end
GO
/****** Object:  Table [dbo].[Toys]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  View [dbo].[MostExpensiveToys]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[MostExpensiveToys] as
SELECT        toy_name, price
FROM            dbo.Toys
WHERE        (price > 100)
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  View [dbo].[ListAdmins]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ListAdmins] as
SELECT        [user_id], firstname, lastname
FROM            dbo.[User]
WHERE        (is_admin = 1)
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  Table [dbo].[Cart_Items]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 15/11/2022 11:24:43 AM ******/
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
	[is_ordered] [bit] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[update_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[order] [varchar](10) NOT NULL,
	[payment] [varchar](10) NOT NULL,
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
/****** Object:  Table [dbo].[Payment]    Script Date: 15/11/2022 11:24:43 AM ******/
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
/****** Object:  Table [dbo].[Variation]    Script Date: 15/11/2022 11:24:43 AM ******/
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
INSERT [dbo].[Cart] ([card_id], [is_available]) VALUES (CAST(N'2022-10-06T14:09:34.757' AS DateTime), 1)
GO
INSERT [dbo].[Cart_Items] ([user], [product], [variation], [cart_items_id], [quantity], [is_active]) VALUES (N'ben1905', 102, N'vari-102-1', CAST(N'2022-10-06T14:09:34.757' AS DateTime), 2, 1)
INSERT [dbo].[Cart_Items] ([user], [product], [variation], [cart_items_id], [quantity], [is_active]) VALUES (N'ben1905', 102, N'vari-102-2', CAST(N'2022-10-06T14:09:34.757' AS DateTime), 2, 1)
GO
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'action-figures', N'Action Figures')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'collectible-figures', N'Collectible Figures')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'dan-gian', N'Tro Choi Dan Gian')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'nerf', N'Neft and Toy Blasters')
INSERT [dbo].[Category] ([category_slug], [category_fullname]) VALUES (N'vehicles', N'Phuong Tien Giao Thon')
GO
INSERT [dbo].[Order] ([order_number], [user], [payment], [first_name], [last_name], [phone], [email], [address], [order_note], [order_total], [tax], [status], [is_ordered], [created_date], [update_at]) VALUES (N'ord-1000', N'ben1905', N'pay-1000', N'quang', N'thang', N'0123456', N'ben1905@gmail.com', N'hue', N'goi hang can than', 24, 4, N'New', 0, CAST(N'2022-10-06T14:18:53.563' AS DateTime), CAST(N'2022-10-06T14:18:53.563' AS DateTime))
GO
INSERT [dbo].[OrderProduct] ([order], [payment], [user], [product], [variations], [quantity], [product_price], [ordered], [created_date], [update_at]) VALUES (N'ord-1000', N'pay-1000', N'ben1905', 102, N'vari-102-1', 2, 5, 1, CAST(N'2022-10-06T21:58:16.303' AS DateTime), CAST(N'2022-10-06T21:58:16.303' AS DateTime))
INSERT [dbo].[OrderProduct] ([order], [payment], [user], [product], [variations], [quantity], [product_price], [ordered], [created_date], [update_at]) VALUES (N'ord-1000', N'pay-1000', N'ben1905', 102, N'vari-102-2', 2, 5, 1, CAST(N'2022-10-06T21:58:37.860' AS DateTime), CAST(N'2022-10-06T21:58:37.860' AS DateTime))
GO
INSERT [dbo].[Payment] ([payment_id], [user], [payment_method], [amount_paid], [status], [created_at]) VALUES (N'pay-1000', N'ben1905', N'techcom', 24, N'New', CAST(N'2022-10-06T14:27:00.670' AS DateTime))
INSERT [dbo].[Payment] ([payment_id], [user], [payment_method], [amount_paid], [status], [created_at]) VALUES (N'pay-1001', N'bo2906', N'bidv', 20, N'New', CAST(N'2022-11-14T13:50:28.407' AS DateTime))
GO
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (100, N'Transformers Studio', N'action-figures', N'Studio Series has always allowed fans to reach past the big screen and build the ultimate Transformers collection inspired by iconic movie scenes from the Transformers movie universe. Now, the Studio Series line is expanding to include the epic moments and characters from the classic The Transformers: The Movie, bringing fans a whole new series of screen-inspired figures to collect! (Each sold separately. Subject to availability.)This Studio Series 86-07 Leader Class The Transformers: The Movie-', 10, NULL, NULL, N'already', CAST(N'2022-10-06T13:50:18.223' AS DateTime), CAST(N'2022-10-06T13:50:18.223' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (101, N'Marvel Spider-Man', N'action-figures', N'Twist Turn Flex your power Kids can bend, flex, pose, and play with their favorite Marvel Super Heroes and Villains with these super agile Spider-Man Bend and Flex Figures Collect characters inspired by Marvel Universe with a twist (each sold separately). These stylized Super Hero action figures have bendable arms and legs that can bend and hold in place for the perfect pose There''s plenty of heroic daring and dramatic action when kids shape their Bend and Flex figures into plenty of playful', 50, NULL, NULL, N'already', CAST(N'2022-10-06T13:57:45.657' AS DateTime), CAST(N'2022-10-06T13:57:45.657' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (102, N'Con Lan', N'dan-gian', N'dam chat Viet Nam', 5, NULL, NULL, N'already', CAST(N'2022-10-06T13:59:59.960' AS DateTime), CAST(N'2022-10-06T13:59:59.960' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (103, N'Den Ong Sao', N'dan-gian', N'dam chat trung thu', 15.5, NULL, NULL, N'already', CAST(N'2022-10-06T14:00:24.877' AS DateTime), CAST(N'2022-10-06T14:00:24.877' AS DateTime))
INSERT [dbo].[Toys] ([toy_id], [toy_name], [category], [description], [price], [image], [stock], [is_available], [created_date], [modified_date]) VALUES (104, N'To He', N'dan-gian', N'tro ve tuoi tho', 2.2, NULL, NULL, N'already', CAST(N'2022-10-06T14:01:51.017' AS DateTime), CAST(N'2022-10-06T14:01:51.017' AS DateTime))
GO
INSERT [dbo].[User] ([user_id], [pass], [firstname], [lastname], [email], [phone_number], [avatar], [is_admin], [date_joined], [last_login]) VALUES (N'ben1905', N'123', N'ben', N'quang', N'ben1905@gmail.com', N'0123456', NULL, 0, CAST(N'2022-10-06T14:11:37.067' AS DateTime), NULL)
INSERT [dbo].[User] ([user_id], [pass], [firstname], [lastname], [email], [phone_number], [avatar], [is_admin], [date_joined], [last_login]) VALUES (N'bo2906', N'123', N'bao', N'thy', N'baothy2906@gmail.com', N'0999888', NULL, 1, CAST(N'2022-10-06T14:11:19.050' AS DateTime), NULL)
GO
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-102-1', 102, N'white', N'small', 5, 1, CAST(N'2022-10-06T14:02:31.840' AS DateTime))
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-102-2', 102, N'white', N'medium', 5, 1, CAST(N'2022-10-06T14:02:51.940' AS DateTime))
INSERT [dbo].[Variation] ([variation_id], [product], [color], [size], [variation_stock], [is_active], [created_date]) VALUES (N'vari-103-1', 103, N'white', N'large', 10, 1, CAST(N'2022-10-06T14:03:11.740' AS DateTime))
GO
ALTER TABLE [dbo].[Cart] ADD  CONSTRAINT [DF_Cart_card_id]  DEFAULT (getdate()) FOR [card_id]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((1)) FOR [is_available]
GO
ALTER TABLE [dbo].[Cart_Items] ADD  CONSTRAINT [DF__Cart_Item__is_ac__73BA3083]  DEFAULT ((0)) FOR [is_active]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('New') FOR [status]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ((0)) FOR [is_ordered]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  DEFAULT ((1)) FOR [ordered]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[OrderProduct] ADD  DEFAULT (getdate()) FOR [update_at]
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
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([order])
REFERENCES [dbo].[Order] ([order_number])
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([payment])
REFERENCES [dbo].[Payment] ([payment_id])
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([product])
REFERENCES [dbo].[Toys] ([toy_id])
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([variations])
REFERENCES [dbo].[Variation] ([variation_id])
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD FOREIGN KEY([user])
REFERENCES [dbo].[User] ([user_id])
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
ALTER TABLE [dbo].[Toys]  WITH CHECK ADD CHECK  (([price]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[CheckPassword]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CheckPassword](@user_id varchar(100),@pass varchar(255))
as
begin
SELECT * from [User] where user_id = @user_id and pass = @pass
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[DeleteCategory] (@category_slug varchar(50))  
AS  
BEGIN  
  delete from Category where category_slug=@category_slug
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteToy]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[DeleteToy] (@toy_id int)  
AS  
BEGIN  
  delete from Toys where toy_id=@toy_id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUser](@user_id varchar(100))
as
begin
SELECT * from [User] where user_id = @user_id
end
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[InsertCategory] (@category_slug varchar(50), @category_fullname varchar(500))  
AS  
BEGIN  
  Insert into Category(category_slug,category_fullname) values (@category_slug,@category_fullname)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertToy]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[InsertToy] (@toy_name varchar(200), @category varchar(50), @description varchar(500), @price float)  
AS  
BEGIN  
  Insert into Toys(toy_id,toy_name,category,[description],price) values ((select count(toy_id) + 100 from Toys),@toy_name,@category,@description,@price)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertVariation]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[InsertVariation] (@product int, @color varchar(20), @size varchar(20), @variation_stock int)  
AS  
BEGIN  
  insert into Variation(variation_id,product,color,size,variation_stock) values ((select 'vari'+'-'+CONVERT(varchar(3), (select toy_id from Toys where toy_id=@product))+'-'+CONVERT(varchar(1), (select count(variation_id)+1 from Variation where product=@product))), @product, @color, @size, @variation_stock)
END

GO
/****** Object:  StoredProcedure [dbo].[IsAdmin_Proc]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IsAdmin_Proc] (@user_id varchar(100))
as
begin
select dbo.IsAdmin(@user_id)
end
GO
/****** Object:  StoredProcedure [dbo].[IsExistUser_Proc]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IsExistUser_Proc] (@user_id varchar(100))
as
begin
select dbo.IsExistUser(@user_id)
end
GO
/****** Object:  StoredProcedure [dbo].[IsValidPassword_Proc]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IsValidPassword_Proc] (@user_id varchar(100), @pass varchar(255))
as
begin
select dbo.IsValidPassword(@user_id,@pass)
end
GO
/****** Object:  StoredProcedure [dbo].[Topp]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Topp](@top int)
as
begin
SELECT TOP(@top) * FROM Toys
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory_FullName]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateCategory_FullName] (@category_slug varchar(50), @category_fullname varchar(500))  
AS  
BEGIN  
  UPDATE Category
  SET category_fullname = @category_fullname
  WHERE category_slug = @category_slug
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateToy]    Script Date: 15/11/2022 11:24:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateToy] (@toy_id int, @toy_name varchar(200), @category varchar(50), @description varchar(500), @price float, @is_available varchar(11))  
AS  
BEGIN  
  UPDATE Toys
  SET toy_name = @toy_name, category = @category, [description] = @description, price = @price, is_available = @is_available
  WHERE toy_id = @toy_id
END
GO
USE [master]
GO
ALTER DATABASE [Hai] SET  READ_WRITE 
GO
