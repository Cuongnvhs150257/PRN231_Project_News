USE [PRN_Project]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 8/24/2023 11:44:47 AM ******/
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
	[img] [varchar](max) NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[article_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles_Categories]    Script Date: 8/24/2023 11:44:47 AM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 8/24/2023 11:44:47 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 8/24/2023 11:44:47 AM ******/
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
	[img] [varchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [img], [user_id]) VALUES (8, N'Lính Ukraine tiết lộ trận chiến khốc liệt với Nga trên tiền tuyến', N'Trả lời phỏng vấn báo Kyiv Post, các binh sĩ tiền tuyến của Ukraine nói rằng, tinh thần của các đơn vị đang giảm sút vì hứng tổn thất liên tục và không nhận được sự hỗ trợ đủ, kịp thời, cũng như việc ít khi giành được lợi thế trong cuộc phản công mùa hè trước một đối thủ cứng rắn và phòng thủ chặt chẽ như Nga.', CAST(N'2023-07-21T09:27:53.360' AS DateTime), CAST(N'2023-07-21T16:29:42.057' AS DateTime), 10, N'Các binh sĩ Ukraine ở tiền tuyến đã kể về những trận chiến khốc liệt với Nga khiến lực lượng của họ tử trận và bị thương, tinh thần giảm sút nhưng cho biết sẽ vẫn tiếp tục chiến đấu.', N'https://icdn.dantri.com.vn/thumb_w/680/2023/07/23/bstientuyen-1690103830860.jpg', 2)
INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [img], [user_id]) VALUES (9, N'Miền Bắc nắng nóng 4 ngày rồi chuyển mưa dông', N'Trung tâm Dự báo Khí tượng Thủy văn Quốc gia cho biết ngày 24/7, nắng nóng tiếp diễn ở khu vực Bắc Bộ và Bắc Trung Bộ. Nhiệt độ cao nhất phổ biến 35-36 độ C, có nơi trên 36 độ C. Độ ẩm tương đối thấp nhất 55-60%.', CAST(N'2023-07-21T01:03:22.397' AS DateTime), CAST(N'2023-07-21T01:03:22.397' AS DateTime), 5, N'Nắng nóng quay trở lại miền Bắc trong các ngày 24-27/7, sau đó khu vực chuyển mưa dông cuối tuần. Ngược lại, mưa dông ở Tây Nguyên và Nam Bộ khả năng giảm dần từ giữa tuần tới.', N'https://suckhoedoisong.qltns.mediacdn.vn/324455921873985536/2023/7/20/nang-nong-xe-may-1689820058776366953017-0-192-1080-1920-crop-16898200737741251834261.jpg', 2)
INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [img], [user_id]) VALUES (11, N'iPhone nào sẽ bị "khai tử" khi iPhone 15 ra mắt?', N'Một phần của động thái này là do những sản phẩm đời cũ đã không còn phù hợp với nhu cầu của thị trường. Bên cạnh đó, đây cũng được xem là chiến lược kinh doanh của Apple nhằm kích cầu doanh số đối với các thiết bị đời mới.', CAST(N'2023-07-21T08:58:36.757' AS DateTime), CAST(N'2023-07-21T08:58:36.757' AS DateTime), 6, N'Việc "khai tử" các mẫu iPhone đời cũ được xem là một chiến lược kinh doanh phù hợp được Apple thường xuyên áp dụng trong vài năm trở lại đây.', N'https://icdn.dantri.com.vn/thumb_w/680/2022/09/16/tren-tay-iphone-14-pro-max-3-1663297795621.jpg', 2)
INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [img], [user_id]) VALUES (14, N'Loài cá được Trung Quốc đưa lên Trạm Vũ trụ Thiên Cung có gì đặc biệt?', N'Space đưa tin, cho biết các loài cá nhỏ sẽ được đưa vào quỹ đạo trên Trạm Vũ trụ Thiên Cung (Tiangong) của Trung Quốc như một phần của nghiên cứu về sự tương tác giữa cá và vi sinh vật trong một hệ sinh thái quy mô nhỏ và khép kín.', CAST(N'2023-07-21T08:58:36.757' AS DateTime), CAST(N'2023-07-21T08:58:36.757' AS DateTime), 9, N'Trung Quốc đang có kế hoạch gửi cá ngựa vằn lên trạm vũ trụ của mình để phục vụ cho nghiên cứu.', N'https://icdn.dantri.com.vn/thumb_w/680/2023/07/24/ca-ngua-van-crop-1690156201442.jpeg', 2)
INSERT [dbo].[Articles] ([article_id], [title], [content], [create_date], [edit_date], [view], [summary], [img], [user_id]) VALUES (20, N'Cận cảnh con đường mang tên Đại tướng Võ Nguyên Giáp ở TPHCM', N'Xa lộ Hà Nội dài hơn 31km bắt đầu từ cầu Sài Gòn đến ngã ba Chợ Sặt (TP Biên Hòa). Trong đó đoạn xa lộ Hà Nội từ cầu Sài Gòn đến ngã tư Thủ Đức đã được đổi tên thành đường Võ Nguyên Giáp, có chiều dài gần 7,8km. OK', CAST(N'2023-08-24T10:22:00.000' AS DateTime), CAST(N'2023-08-24T10:23:59.630' AS DateTime), NULL, N'Một đoạn xa lộ Hà Nội được đổi tên thành đường Võ Nguyên Giáp nhằm tri ân công lao to lớn của Đại tướng trong sự nghiệp đấu tranh, giải phóng dân tộc, thống nhất đất nước.', N'https://cdnphoto.dantri.com.vn/OQ55FwFwDlUnUT8B98uU0USDIpg=/thumb_w/1920/2023/08/24/duongvonguyengiapnamanhdji0851-1692814227300.jpg?watermark=true', 2)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (8, 2)
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (9, 1)
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (11, 1)
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (14, 1)
INSERT [dbo].[Articles_Categories] ([article_id], [category_id]) VALUES (20, 3)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (1, N'thể thao')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (2, N'công nghệ')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (3, N'đời sống')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (4, N'thế giới')
INSERT [dbo].[Categories] ([category_id], [category_name]) VALUES (5, N'khoa học d')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [username], [password], [email], [role], [description], [img]) VALUES (2, N'Admin', N'1234', N'admin@gmail.com', N'User', N'Da sua', N'https://i0.wp.com/thatnhucuocsong.com.vn/wp-content/uploads/2022/04/Anh-avatar-dep-anh-dai-dien-FB-Tiktok-Zalo.jpg?ssl\u003d1')
INSERT [dbo].[User] ([user_id], [username], [password], [email], [role], [description], [img]) VALUES (1003, N'cuong', N'1234', N'cuong@gmail.com', N'User', N'đã test', N'https://i.9mobi.vn/cf/Images/di/2023/4/24/avatar-facebook-6.jpg')
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
