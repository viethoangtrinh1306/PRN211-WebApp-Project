USE [master]
GO
/****** Object:  Database [HotelWebsite]    Script Date: 13-Nov-21 3:54:40 PM ******/
CREATE DATABASE [HotelWebsite]
GO
ALTER DATABASE [HotelWebsite] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelWebsite] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelWebsite] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelWebsite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelWebsite] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [HotelWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelWebsite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelWebsite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelWebsite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelWebsite] SET QUERY_STORE = OFF
GO
USE [HotelWebsite]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 13-Nov-21 3:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[author_id] [int] NOT NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 13-Nov-21 3:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[room_id] [int] NOT NULL,
	[booking_date] [date] NOT NULL,
	[date_from] [date] NOT NULL,
	[date_to] [date] NOT NULL,
	[people] [int] NOT NULL,
	[total] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 13-Nov-21 3:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[position] [varchar](max) NOT NULL,
	[type_id] [int] NOT NULL,
	[image] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 13-Nov-21 3:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[acreage] [int] NOT NULL,
	[beds] [int] NOT NULL,
	[bathrooms] [int] NOT NULL,
	[capacity] [int] NOT NULL,
	[price] [float] NOT NULL,
	[description] [varchar](max) NOT NULL,
	[image] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13-Nov-21 3:54:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[gender] [bit] NULL,
	[dob] [date] NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](max) NULL,
	[account_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (1, N'guest1', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (2, N'guest2', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (3, N'guest3', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (4, N'guest4', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (5, N'guest5', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (6, N'guest6', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (7, N'guest7', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (8, N'guest8', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (9, N'guest9', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (10, N'guest10', N'12345', 1, 1)
GO
INSERT [dbo].[Accounts] ([account_id], [username], [password], [author_id], [status]) VALUES (11, N'admin', N'admin', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (1, N'Room 101', N'Floor 1', 1, N'https://maashaktitours.com/wp-content/uploads/2019/02/Standard-Room.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (2, N'Room 102', N'Floor 1', 1, N'https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/2880x2160/nest-hotel-standard-room-R-r.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (3, N'Room 103', N'Floor 1', 2, N'https://th.bing.com/th/id/R.2594bb6a18ee3d35e5a865257f52bc40?rik=81nvOh0VKzSCbA&riu=http%3a%2f%2fd1a896ec7cb361b0d54d-1dc878dead8ec78a84e429cdf4c9df00.r52.cf1.rackcdn.com%2fu%2fpark-hotel-alexandra%2frooms%2fPHAL---Superior-Room--Day-.jpg&ehk=XezWZOcWj6js7HlisORjPB4wrXBqCyVukKLVEVhGeEs%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (4, N'Room 104', N'Floor 1', 1, N'https://www.strandhotelswakopmund.com/media/img/mw/talitha_burmeister_-__hab4073_-_standard_room.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (5, N'Room 105', N'Floor 1', 2, N'https://th.bing.com/th/id/R.8699128fe7c257611d25016f144351d2?rik=11PoyeOzrw2ZNg&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (6, N'Room 106', N'Floor 1', 1, N'https://th.bing.com/th/id/R.8bb3555e446c27e29db3f24cb16bdc9d?rik=SLandVykSs7uhQ&riu=http%3a%2f%2f4.bp.blogspot.com%2f_eH8gmvphldg%2fTTkmXgUHwYI%2fAAAAAAAAACM%2fiAG4SLS1axk%2fs1600%2fstandard%2broom2.jpg&ehk=zREaS4KT%2fUMXPYjYY61xGp4MzxNibKp5DDhWI%2falTnM%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (7, N'Room 107', N'Floor 1', 2, N'https://th.bing.com/th/id/R.9589846d43f18479c549dec2a3a4e7c7?rik=vQy5VhICmvyVFQ&riu=http%3a%2f%2fpix10.agoda.net%2fhotelImages%2f644%2f6441%2f6441_15010809250024344501.jpg&ehk=Xsx%2flKdSmgPD9mPA%2ftaJmd69HjVYUVU6amgMlnofiUk%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (8, N'Room 108', N'Floor 1', 1, N'https://www.serendibleisure.com/avanibentota/wp-content/uploads/sites/7/2019/06/Standard-room-b1.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (9, N'Room 201', N'Floor 2', 3, N'https://th.bing.com/th/id/R.4ee3ba4e556cfa6b9ab9e57a1940f524?rik=6e1uVb00QVwkQg&riu=http%3a%2f%2fwebbox.imgix.net%2fimages%2fglsakmgqfksboglw%2f8bd9d720-2afc-49e8-8ef5-b6940b5d2e8e.jpg%3fauto%3denhance%2ccompress%26fit%3dcrop&ehk=IgBKfTdu6D%2f4rusbvyI1C8XM5Hu4%2bAdnx03VdX9Rkog%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (10, N'Room 202', N'Floor 2', 2, N'https://www.shorelinehotel.ie/wp-content/uploads/2020/07/Superior-Room-1.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (11, N'Room 203', N'Floor 2', 1, N'https://cdn-image.travelandleisure.com/sites/default/files/styles/1600x1000/public/standard0415-interior.jpg?itok=Cm116-Ws')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (12, N'Room 204', N'Floor 2', 1, N'https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/u/Anya%20Hotel/anya-hotel-standard-room-R-2.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (13, N'Room 205', N'Floor 2', 3, N'https://th.bing.com/th/id/R.96362eb31343286fa5eedce45485fc86?rik=7ATmps7yjiUgTg&riu=http%3a%2f%2fd2e5ushqwiltxm.cloudfront.net%2fwp-content%2fuploads%2fsites%2f12%2f2018%2f03%2f08140819%2fPullman-Deluxe-Room-Twin-Bed-1.jpg&ehk=zm8YRVN%2bZhF4MoVVhjDRl8M%2fvXA44rIs4eHlctjbfv0%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (14, N'Room 206', N'Floor 2', 1, N'https://www.waterfronthotels.com.ph/wp-content/uploads/2020/07/Standard-Room-king-bed-1-1024x682.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (15, N'Room 207', N'Floor 2', 4, N'https://i.dailymail.co.uk/i/pix/2017/12/05/09/4700561D00000578-5146823-image-a-47_1512466988155.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (16, N'Room 208', N'Floor 2', 1, N'https://th.bing.com/th/id/R.9d4e7d668fadb6086f43aa9c5b8327c2?rik=7TLjtVc9Mt1jDA&riu=http%3a%2f%2fwww.nobletonhotel.com%2fwp-content%2fuploads%2f2013%2f11%2fphoto-13.jpg&ehk=8fZu1PeLKhehPfGx9QrKXQD7EfLiw%2ffyd2slo4s6lZI%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (17, N'Room 301', N'Floor 3', 1, N'https://www.stirrupshotel.co.uk/uploads/rooms/3-room-112-edited-minpng.png')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (18, N'Room 302', N'Floor 3', 3, N'https://media.iceportal.com/126671/photos/67268926_XXL.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (19, N'Room 303', N'Floor 3', 1, N'https://www.lottehotel.com/content/dam/lotte-hotel/lotte/hanoi/accommodation/standard/deluxeroom/180921-2-2000-roo-LTHA.jpg.thumb.1920.1920.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (20, N'Room 304', N'Floor 3', 4, N'https://th.bing.com/th/id/R.e71d0e59f7b7b2785728665e91905aea?rik=tTZD0%2fXwoconlw&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (21, N'Room 305', N'Floor 3', 1, N'https://www.lottehotel.com/content/dam/lotte-hotel/lotte/seoul/accommodation/executive-tower/standard/grand-deluxe-room/181026-1-2000-roo-LTSE.jpg.thumb.1440.1440.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (22, N'Room 306', N'Floor 3', 2, N'https://th.bing.com/th/id/R.21abaca46cb96f8787cb098a9b139c4c?rik=Sq8l%2b2Lc2kE8sg&riu=http%3a%2f%2fd2e5ushqwiltxm.cloudfront.net%2fwp-content%2fuploads%2fsites%2f122%2f2017%2f04%2f29025339%2fPrestige-Suite-1.jpg&ehk=0dQWPrJUgHXRtJVxd0Vs0H3F1Gwhm5%2bNJoQpeSFxN%2bo%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (23, N'Room 307', N'Floor 3', 1, N'https://th.bing.com/th/id/R.54aeb0a3cdf7bcd7f0c3b389f01669b6?rik=kfBPGVFZCFkOqw&riu=http%3a%2f%2fwww.ncevents.com.au%2fwp-content%2fuploads%2f2016%2f11%2fKing-Standard-Room.jpg&ehk=nKKJCEZ4xGw%2fFTZz2ZZm%2fscfs3LZdV4X9GjDCwG4AQQ%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (24, N'Room 308', N'Floor 3', 4, N'https://www.lottehotel.com/content/dam/lotte-hotel/lotte/seoul/accommodation/executive-tower/suite/royal-suite-room/181026-53-2000-roo-LTSE.jpg.thumb.1920.1920.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (25, N'Room 401', N'Floor 4', 1, N'https://media.iceportal.com/107023/photos/67981835_XXL.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (26, N'Room 402', N'Floor 4', 1, N'https://th.bing.com/th/id/R.f5f1f663ef6be79596606433fd9d7388?rik=kUTLIjienOKlgw&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (27, N'Room 403', N'Floor 4', 3, N'https://rrsg.s3.amazonaws.com/wp-content/uploads/2020/11/09125130/hotel-the-mitsui-kyoto-suite.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (28, N'Room 404', N'Floor 4', 1, N'https://images.trvl-media.com/hotels/1000000/920000/916700/916618/27f94dcc_z.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (29, N'Room 405', N'Floor 4', 4, N'https://th.bing.com/th/id/R.b5603d2b974f2d2593baa7dfc031819d?rik=adAjobwFubZBpw&riu=http%3a%2f%2f4.bp.blogspot.com%2f-sUwyTYEWygs%2fTzQguI036LI%2fAAAAAAAABbA%2f82mnNz4mPxA%2fs1600%2fRoyal%2bSuite%2b-%2bLiving%2bRoom.jpg&ehk=thq4nJaf6ByWTZNn24sWl4chd62fk5%2bXTe3EeeXeic0%3d&risl=&pid=ImgRaw&r=0')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (30, N'Room 406', N'Floor 4', 1, N'https://images.trvl-media.com/hotels/1000000/920000/916700/916618/d56d7287_z.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (31, N'Room 407', N'Floor 4', 2, N'https://r-cf.bstatic.com/images/hotel/max1024x768/229/229638597.jpg')
GO
INSERT [dbo].[Rooms] ([room_id], [name], [position], [type_id], [image]) VALUES (32, N'Room 408', N'Floor 4', 3, N'https://2iptu93zu1vy2s4and11m26v-wpengine.netdna-ssl.com/wp-content/uploads/sites/53/2019/11/deluxe-twin.jpg')
GO
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 
GO
INSERT [dbo].[RoomType] ([type_id], [name], [acreage], [beds], [bathrooms], [capacity], [price], [description], [image]) VALUES (1, N'Standard Room', 20, 1, 1, 2, 50, N'This is a standard room in a hotel, with a small area, usually located on a low floor, without a view or a bad view. The STD room is equipped with basic items - equipment and has the lowest price.', N'https://newsneednews.com/wp-content/uploads/2018/05/nintchdbpict0004027832311.jpg')
GO
INSERT [dbo].[RoomType] ([type_id], [name], [acreage], [beds], [bathrooms], [capacity], [price], [description], [image]) VALUES (2, N'Superior Room', 40, 2, 1, 4, 70, N'This is a better quality room - large area - comfortable equipment - nice view. Because of that, the SUP room rental rate will be higher.', N'https://cache.marriott.com/marriottassets/marriott/KULDT/kuldt-guestroom-0017-hor-clsc.jpg?interpolation=progressive-bilinear&')
GO
INSERT [dbo].[RoomType] ([type_id], [name], [acreage], [beds], [bathrooms], [capacity], [price], [description], [image]) VALUES (3, N'Deluxe Room', 60, 2, 1, 4, 100, N'This is a high-class room in hotels, mainly located on a high floor with large space, many comfortable equipment - beautiful view.', N'https://www.manila-hotel.com.ph/wp-content/uploads/2020/06/Superior-DeLuxe-Room_TB.jpg')
GO
INSERT [dbo].[RoomType] ([type_id], [name], [acreage], [beds], [bathrooms], [capacity], [price], [description], [image]) VALUES (4, N'Suite Room', 100, 3, 2, 6, 120, N'This is the most luxurious room class of each hotel. A noticeable feature is that the Suite room is usually located in the position for the best view and in each such room can have many different function rooms: living room, bedroom, meeting room, dining room...', N'https://th.bing.com/th/id/R.d88334f31643ba8d014eb13d8a6141ff?rik=cNq4UDHlhRWe2A&pid=ImgRaw&r=0')
GO
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (1, N'Le Thanh Trung', 1, CAST(N'1999-04-19' AS Date), N'123456789', N'lethanhtrung@gmail.com', 1)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (2, N'Le Van Dat', 1, CAST(N'1995-08-09' AS Date), N'123456789', N'levandat@gmail.com', 2)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (3, N'Nguyen Thi Thao', 0, CAST(N'1998-11-27' AS Date), N'123456789', N'nguyenthithao@gmail.com', 3)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (4, N'Hoang Anh Minh', 0, CAST(N'2005-01-14' AS Date), N'123456789', N'hoanganhminh@gmail.com', 4)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (5, N'Nguyen The Kien', 1, CAST(N'1999-04-29' AS Date), N'123456789', N'nguyenthekien@gmail.com', 5)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (6, N'Trinh Viet Hoang', 1, CAST(N'1996-02-13' AS Date), N'123456789', N'trinhviethoang@gmail.com', 6)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (7, N'Ngo Van Chien', 1, CAST(N'2000-07-19' AS Date), N'123456789', N'ngovanchien@gmail.com', 7)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (8, N'Nguyen Quynh Trang', 0, CAST(N'2001-11-03' AS Date), N'123456789', N'nguyenquynhtrang@gmail.com', 8)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (9, N'Bui Anh Thu', 0, CAST(N'1991-06-16' AS Date), N'123456789', N'buianhthu@gmail.com', 9)
GO
INSERT [dbo].[Users] ([user_id], [name], [gender], [dob], [phone], [email], [account_id]) VALUES (10, N'Nguyen Thi Huong', 0, CAST(N'1992-05-23' AS Date), N'123456789', N'nguyenthihuong@gmail.com', 10)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Accounts__F3DBC572F03EE497]    Script Date: 13-Nov-21 3:54:40 PM ******/
ALTER TABLE [dbo].[Accounts] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([room_id])
REFERENCES [dbo].[Rooms] ([room_id])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD FOREIGN KEY([type_id])
REFERENCES [dbo].[RoomType] ([type_id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[Accounts] ([account_id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  ((NOT [Phone] like '%[^0-9]%' AND len([Phone])>=(8) AND len([Phone])<=(10)))
GO
USE [master]
GO
ALTER DATABASE [HotelWebsite] SET  READ_WRITE 
GO
