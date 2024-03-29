USE [eproject]
GO
/****** Object:  Table [dbo].[CompanyVehicle]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyVehicle](
	[CompanyVehicleId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyVehicleName] [varchar](500) NULL,
	[CompanyVehicleBrand] [varchar](500) NULL,
	[CompanyVehicleModelNum] [varchar](500) NULL,
	[CompanyVehiclePrice] [int] NULL,
	[CompanyVehicleImage] [varchar](500) NULL,
	[CompanyVehicleColour] [varchar](500) NULL,
	[CompanyVehicleDescription] [varchar](500) NULL,
	[Status] [varchar](800) NULL,
 CONSTRAINT [PK_CompanyVehicle] PRIMARY KEY CLUSTERED 
(
	[CompanyVehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_order_items]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_order_items](
	[Order_item_ID] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[order_id] [int] NULL,
	[vehicle_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_item_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealer_Customer_Purchase]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealer_Customer_Purchase](
	[DCP_ID] [int] IDENTITY(1,1) NOT NULL,
	[date_of_purchase] [date] NULL,
	[Totale_Order_Price] [int] NULL,
	[U_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DCP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[New_Vehicle]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[New_Vehicle](
	[vehicle_Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyVehicleName] [varchar](50) NULL,
	[CompanyVehicleBrand] [varchar](50) NULL,
	[CompanyVehicleModelNum] [varchar](50) NULL,
	[CompanyVehiclePrice] [int] NULL,
	[CompanyVehicleImage] [varchar](500) NULL,
	[CompanyVehicleColour] [varchar](50) NULL,
	[CompanyVehicleDescription] [varchar](500) NULL,
 CONSTRAINT [PK_New_Vehicle] PRIMARY KEY CLUSTERED 
(
	[vehicle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Rid] [int] IDENTITY(1,1) NOT NULL,
	[Rname] [varchar](500) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_checkout]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_checkout](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[v_no] [varchar](max) NULL,
	[order_date] [varchar](max) NULL,
	[user_id] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_checkout] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/27/2024 6:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](500) NULL,
	[UserEmail] [varchar](500) NULL,
	[UserPhoneNumber] [varchar](500) NULL,
	[UserCity] [varchar](500) NULL,
	[UserPassword] [varchar](500) NULL,
	[Roles] [int] NULL,
	[UserImage] [varchar](500) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CompanyVehicle] ON 

INSERT [dbo].[CompanyVehicle] ([CompanyVehicleId], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription], [Status]) VALUES (1, N'456', N'463', N'3646', 5346, N'images\Golf1.jpg', N'36', N'436666', N'436')
INSERT [dbo].[CompanyVehicle] ([CompanyVehicleId], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription], [Status]) VALUES (2, N'Tesla Model S', N'Tesla ', N'Plaid', 80000, N'images\download.jpeg', N'Black', N'The Tesla Model S is an electric luxury sedan with cutting-edge technology, impressive acceleration, and a long electric range.', N'Available')
INSERT [dbo].[CompanyVehicle] ([CompanyVehicleId], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription], [Status]) VALUES (3, N'Chevrolet Silverado', N'Chevrolet ', N'2022', 40000, N'images\images (1).jpeg', N'White', N'The Chevrolet Silverado is a rugged and versatile pickup truck, known for its towing capacity, spacious interior, and off-road capabilities.', N'Sold')
SET IDENTITY_INSERT [dbo].[CompanyVehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[New_Vehicle] ON 

INSERT [dbo].[New_Vehicle] ([vehicle_Id], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription]) VALUES (4, N'Honda Civic', N'Honda', N'2021', 22000, N'images\images964d5fe6-ead0-4866-8a58-ce7d469a2bed817d0f76-0d2e-4885-ab21-64ff3ee5cb40.jpeg', N'Blue', N'The Honda Civic is a compact car known for its fuel efficiency, practicality, and modern design. It''s a popular choice for daily commuting.')
INSERT [dbo].[New_Vehicle] ([vehicle_Id], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription]) VALUES (11, N'Toyota Camry', N'Toyota', N'2022', 25000, N'images\2022toc020151_1280_01.webp', N'Silver', N' The Toyota Camry is a reliable and fuel-efficient midsize sedan known for its comfortable ride and advanced safety features.')
INSERT [dbo].[New_Vehicle] ([vehicle_Id], [CompanyVehicleName], [CompanyVehicleBrand], [CompanyVehicleModelNum], [CompanyVehiclePrice], [CompanyVehicleImage], [CompanyVehicleColour], [CompanyVehicleDescription]) VALUES (12, N' Ford Mustang', N'Ford', N'2023', 35000, N'images\car-2.png', N'Red', N'The Ford Mustang is an iconic American muscle car with a powerful V8 engine, offering a thrilling driving experience and classic design.')
SET IDENTITY_INSERT [dbo].[New_Vehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Rid], [Rname]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Rid], [Rname]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_checkout] ON 

INSERT [dbo].[tbl_checkout] ([order_id], [v_no], [order_date], [user_id]) VALUES (3, N'5', N'25-Jan-2024', N'5')
INSERT [dbo].[tbl_checkout] ([order_id], [v_no], [order_date], [user_id]) VALUES (4, N'4', N'27-Jan-2024', N'5')
INSERT [dbo].[tbl_checkout] ([order_id], [v_no], [order_date], [user_id]) VALUES (5, N'4', N'27-Jan-2024', N'5')
INSERT [dbo].[tbl_checkout] ([order_id], [v_no], [order_date], [user_id]) VALUES (6, N'4', N'27-Jan-2024', N'5')
SET IDENTITY_INSERT [dbo].[tbl_checkout] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [UserEmail], [UserPhoneNumber], [UserCity], [UserPassword], [Roles], [UserImage]) VALUES (5, N'abc', N'abc@gmail.com', N'123', N'karachi', N'123', 2, N'images\images 3.jfif')
INSERT [dbo].[Users] ([UserId], [UserName], [UserEmail], [UserPhoneNumber], [UserCity], [UserPassword], [Roles], [UserImage]) VALUES (6, N'Mahnorr', N'Mahnoor@gmail.com', N'3322', N'Karachi', N'M123', 1, N'images\images 3.jfif')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[customer_order_items]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Dealer_Customer_Purchase] ([DCP_ID])
GO
ALTER TABLE [dbo].[customer_order_items]  WITH CHECK ADD FOREIGN KEY([vehicle_id])
REFERENCES [dbo].[New_Vehicle] ([vehicle_Id])
GO
ALTER TABLE [dbo].[Dealer_Customer_Purchase]  WITH CHECK ADD FOREIGN KEY([U_ID])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Roles])
REFERENCES [dbo].[Role] ([Rid])
GO
