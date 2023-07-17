USE [master]
GO
/****** Object:  Database [PRN_Project]    Script Date: 7/17/2023 11:30:00 AM ******/
CREATE DATABASE [PRN_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN_Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TVG\MSSQL\DATA\PRN_Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN_Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TVG\MSSQL\DATA\PRN_Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN_Project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN_Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN_Project] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN_Project] SET  MULTI_USER 
GO
ALTER DATABASE [PRN_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN_Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN_Project', N'ON'
GO
ALTER DATABASE [PRN_Project] SET QUERY_STORE = OFF
GO
USE [PRN_Project]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 7/17/2023 11:30:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[article_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[edit_date] [datetime] NULL,
	[view] [int] NULL,
	[summary] [nvarchar](255) NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[article_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles_Categories]    Script Date: 7/17/2023 11:30:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles_Categories](
	[article_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_Articles_Categories] PRIMARY KEY CLUSTERED 
(
	[article_id] ASC,
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/17/2023 11:30:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/17/2023 11:30:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[description] [nvarchar](255) NULL,
	[img] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [user_id]) VALUES (5, N'Bão mạnh cấp 12 hướng vào ven biển Quảng Ninh - Hải Phòng', N'Rạng sáng 17/7, tâm bão số 1 nằm cách bán đảo Lôi Châu (Trung Quốc) khoảng 340km về phía đông đông nam. Lúc 4h, sức gió mạnh nhất vùng gần tâm bão là 11-12 (103-133km/h), giật cấp 15. Bão tiếp tục tăng gần một cấp chỉ trong vòng 3 giờ.', CAST(N'2023-07-17T00:00:00.000' AS DateTime), CAST(N'2023-07-17T00:00:00.000' AS DateTime), 1, N' Bão Talim có thể đạt sức gió mạnh nhất cấp 12, giật cấp 15, trước thời điểm đi vào ven biển Quảng Ninh - Hải Phòng chiều 18/7. Ảnh hưởng của bão khiến miền Bắc bắt đầu mưa rất lớn từ đêm 17/7.', 2)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (5, 3)
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (5, 4)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (1, N'thể thao')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (2, N'công nghệ')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (3, N'đời sống')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (4, N'thế giới')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [username], [password], [email], [role], [description], [img]) VALUES (2, N'Admin', N'1234', N'admin@gmail.com', N'Admin', N'Chua', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_User]
GO
ALTER TABLE [dbo].[Articles_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categories_Articles] FOREIGN KEY([article_id])
REFERENCES [dbo].[Articles] ([article_id])
GO
ALTER TABLE [dbo].[Articles_Categories] CHECK CONSTRAINT [FK_Articles_Categories_Articles]
GO
ALTER TABLE [dbo].[Articles_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categories_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Articles_Categories] CHECK CONSTRAINT [FK_Articles_Categories_Categories]
GO
USE [master]
GO
ALTER DATABASE [PRN_Project] SET  READ_WRITE 
GO
