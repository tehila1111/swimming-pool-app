USE [master]
GO
/****** Object:  Database [Swimming_Pool]    Script Date: 16/07/2023 13:43:30 ******/
CREATE DATABASE [Swimming_Pool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Swimming_Pool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Swimming_Pool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Swimming_Pool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Swimming_Pool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Swimming_Pool] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Swimming_Pool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Swimming_Pool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Swimming_Pool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Swimming_Pool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Swimming_Pool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Swimming_Pool] SET ARITHABORT OFF 
GO
ALTER DATABASE [Swimming_Pool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Swimming_Pool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Swimming_Pool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Swimming_Pool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Swimming_Pool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Swimming_Pool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Swimming_Pool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Swimming_Pool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Swimming_Pool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Swimming_Pool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Swimming_Pool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Swimming_Pool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Swimming_Pool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Swimming_Pool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Swimming_Pool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Swimming_Pool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Swimming_Pool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Swimming_Pool] SET RECOVERY FULL 
GO
ALTER DATABASE [Swimming_Pool] SET  MULTI_USER 
GO
ALTER DATABASE [Swimming_Pool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Swimming_Pool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Swimming_Pool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Swimming_Pool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Swimming_Pool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Swimming_Pool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Swimming_Pool', N'ON'
GO
ALTER DATABASE [Swimming_Pool] SET QUERY_STORE = OFF
GO
USE [Swimming_Pool]
GO
/****** Object:  Table [dbo].[BusinessDetails]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessDetails](
	[BusinessName] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[rentDay] [nvarchar](50) NOT NULL,
	[rentPrice] [int] NOT NULL,
	[RentStartHour] [time](7) NOT NULL,
	[RentEndHour] [time](7) NOT NULL,
 CONSTRAINT [PK_BusinessDetails] PRIMARY KEY CLUSTERED 
(
	[BusinessName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customers]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customers](
	[cust_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[telephone] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[birthdate] [date] NOT NULL,
	[archive] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[cust_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers_enter]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers_enter](
	[enter_id] [int] IDENTITY(1,1) NOT NULL,
	[Subscription_id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[work_shift_id] [int] NOT NULL,
 CONSTRAINT [PK_Customers_enter] PRIMARY KEY CLUSTERED 
(
	[enter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[open_days]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[open_days](
	[open_id] [int] IDENTITY(1,1) NOT NULL,
	[shift_id] [int] NOT NULL,
	[day] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_open_days] PRIMARY KEY CLUSTERED 
(
	[open_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[otherEnter]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[otherEnter](
	[other_enter] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[work_shift_id] [int] NOT NULL,
 CONSTRAINT [PK_otherEnter] PRIMARY KEY CLUSTERED 
(
	[other_enter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[rent_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[price] [int] NOT NULL,
	[Payment_status] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[rent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rentals_details]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rentals_details](
	[RentalDetails_id] [int] IDENTITY(1,1) NOT NULL,
	[rent_id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rentals_details] PRIMARY KEY CLUSTERED 
(
	[RentalDetails_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscribed_customers]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribed_customers](
	[Subscription_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NOT NULL,
	[Subscription_type] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[sum_of_entries] [int] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Subscribed_customers] PRIMARY KEY CLUSTERED 
(
	[Subscription_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription_type]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription_type](
	[Subscription_type_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[Num_of_entrances] [int] NOT NULL,
	[price] [int] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Subscription_type] PRIMARY KEY CLUSTERED 
(
	[Subscription_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[position] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[work_shift_type]    Script Date: 16/07/2023 13:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_shift_type](
	[shift_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[start_hour] [time](7) NOT NULL,
	[end_hour] [time](7) NOT NULL,
 CONSTRAINT [PK_work_shift_type] PRIMARY KEY CLUSTERED 
(
	[shift_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BusinessDetails] ([BusinessName], [address], [rentDay], [rentPrice], [RentStartHour], [RentEndHour]) VALUES (N'swim on', N'רחוב השמיר 9 בני ברק', N'שני', 9000, CAST(N'10:00:00' AS Time), CAST(N'20:00:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[customers] ON 

INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5196, N'רחלי', N'תמרי', N'0506286160', N'racheli234@gmail.com', N'נקבה', N'מנוי', CAST(N'2002-12-15' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5198, N'נעמי', N'רווח', N'0509895685', N'nomi2345@outlook.com', N'נקבה', N'מנוי', CAST(N'2000-06-15' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5199, N'רחלי', N'כהן', N'0533112458', N'racheli053333@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-05-30' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5200, N'עדי', N'ברוורמן', N'052356896', N'adi1234@gmail.com', N'נקבה', N'מנוי', CAST(N'2010-06-09' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5205, N'נעמה', N'אביר', N'0503256589', N'nahama@gmail.com', N'נקבה', N'מנוי', CAST(N'2003-06-23' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5206, N'שמעון', N'פרנקל', N'0533110385', N'shimon1234@gmail.com', N'זכר', N'מנוי', CAST(N'2000-06-23' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5207, N'מירי', N'שמואלי', N'0526286160', N'miri43@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-06-07' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5208, N'רחל', N'בן דוד', N'0521447856', N'rachel4@gmail.com', N'נקבה', N'עסקי', CAST(N'1992-06-22' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5209, N'אבי', N'גרטלר', N'0536985412', N'avi14@gmail.com', N'זכר', N'עסקי', CAST(N'1980-06-16' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5210, N'חגית', N'לוי', N'0534570370', N'r23f4@gmail.com', N'נקבה', N'עסקי', CAST(N'1970-06-22' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5211, N'מירי', N'שחורי', N'0558966160', N'mirishchori@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-06-29' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5212, N'יעל', N'דמרי', N'0502325689', N'yael@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-06-27' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5213, N'שבי', N'סופר', N'0523256235', N'shevi@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-06-21' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5214, N'מירי', N'עוברני', N'0532115237', N'miri123@gmail.com', N'נקבה', N'עסקי', CAST(N'1996-06-13' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5215, N'דיתה', N'דיתה', N'0504124521', N'r23xcf4@gmail.com', N'נקבה', N'מנוי', CAST(N'2000-06-14' AS Date), N'פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5216, N'רחלי', N'כהן', N'0533110258', N'ruti3555@gmail.com', N'נקבה', N'עסקי', CAST(N'2001-06-21' AS Date), N'לא פעיל')
INSERT [dbo].[customers] ([cust_id], [first_name], [last_name], [telephone], [email], [gender], [status], [birthdate], [archive]) VALUES (5217, N' dkwl vw', N'l ckld', N'841641652', N'knkcnd@gmail.com', N'נקבה', N'עסקי', CAST(N'2000-08-01' AS Date), N'פעיל')
SET IDENTITY_INSERT [dbo].[customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers_enter] ON 

INSERT [dbo].[Customers_enter] ([enter_id], [Subscription_id], [date], [work_shift_id]) VALUES (7061, 2067, CAST(N'2023-06-02' AS Date), 4)
INSERT [dbo].[Customers_enter] ([enter_id], [Subscription_id], [date], [work_shift_id]) VALUES (7062, 2069, CAST(N'2023-06-02' AS Date), 4)
INSERT [dbo].[Customers_enter] ([enter_id], [Subscription_id], [date], [work_shift_id]) VALUES (7063, 2070, CAST(N'2023-06-02' AS Date), 4)
INSERT [dbo].[Customers_enter] ([enter_id], [Subscription_id], [date], [work_shift_id]) VALUES (7064, 2073, CAST(N'2023-06-02' AS Date), 4)
INSERT [dbo].[Customers_enter] ([enter_id], [Subscription_id], [date], [work_shift_id]) VALUES (7065, 2072, CAST(N'2023-06-04' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Customers_enter] OFF
GO
SET IDENTITY_INSERT [dbo].[open_days] ON 

INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (27, 1, N'חמישי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (28, 2, N'חמישי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (29, 3, N'חמישי', N'גברים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (30, 4, N'שישי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (1039, 3, N'שלישי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2041, 1, N'שלישי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2042, 2, N'שלישי', N'גברים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2048, 2, N'ראשון', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2049, 3, N'ראשון', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2050, 1, N'ראשון', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2051, 2, N'רביעי', N'נשים', N'פעיל')
INSERT [dbo].[open_days] ([open_id], [shift_id], [day], [gender], [status]) VALUES (2052, 1, N'רביעי', N'נשים', N'פעיל')
SET IDENTITY_INSERT [dbo].[open_days] OFF
GO
SET IDENTITY_INSERT [dbo].[otherEnter] ON 

INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (2, CAST(N'2022-10-01' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (3, CAST(N'2022-10-01' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (4, CAST(N'2022-10-01' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (5, CAST(N'2022-10-03' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6, CAST(N'2022-10-03' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7, CAST(N'2022-10-03' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (8, CAST(N'2022-10-03' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (9, CAST(N'2022-10-03' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (10, CAST(N'2022-10-03' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (11, CAST(N'2022-10-19' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (1011, CAST(N'2022-10-24' AS Date), 2)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (1012, CAST(N'2022-10-24' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (1013, CAST(N'2022-10-24' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (2011, CAST(N'2022-10-27' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (3011, CAST(N'2022-10-27' AS Date), 2)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (4011, CAST(N'2022-10-28' AS Date), 4)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (4012, CAST(N'2022-10-28' AS Date), 4)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (4013, CAST(N'2022-10-31' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (4014, CAST(N'2022-10-31' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (5013, CAST(N'2022-10-31' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6013, CAST(N'2022-11-03' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6014, CAST(N'2022-11-06' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6015, CAST(N'2022-11-07' AS Date), 2)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6016, CAST(N'2022-11-07' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (6017, CAST(N'2022-11-14' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7017, CAST(N'2022-11-15' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7018, CAST(N'2022-12-22' AS Date), 2)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7019, CAST(N'2023-03-27' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7021, CAST(N'2023-04-13' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7022, CAST(N'2023-04-16' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7024, CAST(N'2023-04-17' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7025, CAST(N'2023-04-17' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7028, CAST(N'2023-06-01' AS Date), 3)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7029, CAST(N'2023-06-02' AS Date), 4)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7030, CAST(N'2023-06-04' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7031, CAST(N'2023-06-04' AS Date), 1)
INSERT [dbo].[otherEnter] ([other_enter], [date], [work_shift_id]) VALUES (7032, CAST(N'2023-06-04' AS Date), 1)
SET IDENTITY_INSERT [dbo].[otherEnter] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2028, 5208, CAST(N'2023-06-05' AS Date), CAST(N'2023-10-02' AS Date), 27000, N'שולם', N'פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2029, 5209, CAST(N'2023-06-12' AS Date), CAST(N'2023-06-26' AS Date), 0, N'שולם', N'לא פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2030, 5210, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-24' AS Date), 27000, N'שולם', N'פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2031, 5211, CAST(N'2023-06-12' AS Date), CAST(N'2023-06-26' AS Date), 18000, N'שולם', N'פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2032, 5214, CAST(N'2023-07-03' AS Date), CAST(N'2023-07-31' AS Date), 18000, N'שולם', N'פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2033, 5216, CAST(N'2023-08-07' AS Date), CAST(N'2023-08-14' AS Date), 0, N'שולם', N'לא פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2034, 5216, CAST(N'2023-08-14' AS Date), CAST(N'2023-08-14' AS Date), 9000, N'שולם', N'פעיל')
INSERT [dbo].[Rentals] ([rent_id], [cust_id], [start_date], [end_date], [price], [Payment_status], [status]) VALUES (2035, 5217, CAST(N'2023-11-13' AS Date), CAST(N'2023-12-18' AS Date), 18000, N'שולם', N'פעיל')
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[rentals_details] ON 

INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1075, 2028, CAST(N'2023-06-05' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1076, 2028, CAST(N'2023-06-19' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1077, 2028, CAST(N'2023-10-02' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1078, 2029, CAST(N'2023-06-12' AS Date), N'לא פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1079, 2029, CAST(N'2023-06-26' AS Date), N'לא פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1080, 2030, CAST(N'2023-07-03' AS Date), N'לא פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1081, 2030, CAST(N'2023-07-10' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1082, 2030, CAST(N'2023-07-17' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1083, 2030, CAST(N'2023-07-24' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1084, 2031, CAST(N'2023-06-12' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1085, 2031, CAST(N'2023-06-26' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1086, 2032, CAST(N'2023-07-03' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1087, 2032, CAST(N'2023-07-31' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1088, 2033, CAST(N'2023-08-07' AS Date), N'לא פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1089, 2033, CAST(N'2023-08-14' AS Date), N'לא פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1090, 2034, CAST(N'2023-08-14' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1091, 2035, CAST(N'2023-11-13' AS Date), N'פעיל')
INSERT [dbo].[rentals_details] ([RentalDetails_id], [rent_id], [date], [status]) VALUES (1092, 2035, CAST(N'2023-12-18' AS Date), N'פעיל')
SET IDENTITY_INSERT [dbo].[rentals_details] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribed_customers] ON 

INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2065, 5196, 1, CAST(N'2023-06-01' AS Date), 15, N'לא פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2067, 5198, 4, CAST(N'2023-06-01' AS Date), 0, N'לא פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2068, 5199, 3, CAST(N'2023-06-01' AS Date), 8, N'לא פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2069, 5200, 2, CAST(N'2023-06-01' AS Date), 3, N'פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2070, 5205, 3, CAST(N'2023-06-02' AS Date), 7, N'פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2071, 5206, 1, CAST(N'2023-06-02' AS Date), 15, N'פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2072, 5207, 2, CAST(N'2023-06-02' AS Date), 19, N'לא פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2073, 5211, 3, CAST(N'2023-06-02' AS Date), 7, N'לא פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2074, 5212, 1, CAST(N'2023-06-03' AS Date), 15, N'פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2075, 5213, 2, CAST(N'2023-06-04' AS Date), 20, N'פעיל')
INSERT [dbo].[Subscribed_customers] ([Subscription_id], [cust_id], [Subscription_type], [start_date], [sum_of_entries], [status]) VALUES (2076, 5215, 3, CAST(N'2023-06-04' AS Date), 8, N'פעיל')
SET IDENTITY_INSERT [dbo].[Subscribed_customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscription_type] ON 

INSERT [dbo].[Subscription_type] ([Subscription_type_id], [type], [Num_of_entrances], [price], [status]) VALUES (1, N'פרימיום', 15, 800, N'פעיל')
INSERT [dbo].[Subscription_type] ([Subscription_type_id], [type], [Num_of_entrances], [price], [status]) VALUES (2, N'זהב', 20, 700, N'פעיל')
INSERT [dbo].[Subscription_type] ([Subscription_type_id], [type], [Num_of_entrances], [price], [status]) VALUES (3, N'סטנדרט', 8, 200, N'פעיל')
INSERT [dbo].[Subscription_type] ([Subscription_type_id], [type], [Num_of_entrances], [price], [status]) VALUES (4, N'בסיס', 3, 100, N'פעיל')
SET IDENTITY_INSERT [dbo].[Subscription_type] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [userName], [position], [password]) VALUES (1, N'אבי דדון', N'מנהל', N'123456')
INSERT [dbo].[users] ([userId], [userName], [position], [password]) VALUES (5, N'שירה כהן', N'מזכיר', N'1234')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[work_shift_type] ON 

INSERT [dbo].[work_shift_type] ([shift_id], [name], [start_hour], [end_hour]) VALUES (1, N'בוקר', CAST(N'07:00:00' AS Time), CAST(N'12:00:00' AS Time))
INSERT [dbo].[work_shift_type] ([shift_id], [name], [start_hour], [end_hour]) VALUES (2, N'צהריים', CAST(N'12:30:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[work_shift_type] ([shift_id], [name], [start_hour], [end_hour]) VALUES (3, N'ערב', CAST(N'17:10:00' AS Time), CAST(N'23:50:00' AS Time))
INSERT [dbo].[work_shift_type] ([shift_id], [name], [start_hour], [end_hour]) VALUES (4, N'שישי', CAST(N'07:00:00' AS Time), CAST(N'14:30:00' AS Time))
SET IDENTITY_INSERT [dbo].[work_shift_type] OFF
GO
ALTER TABLE [dbo].[Customers_enter]  WITH CHECK ADD  CONSTRAINT [FK_Customers_enter_Subscribed_customers] FOREIGN KEY([Subscription_id])
REFERENCES [dbo].[Subscribed_customers] ([Subscription_id])
GO
ALTER TABLE [dbo].[Customers_enter] CHECK CONSTRAINT [FK_Customers_enter_Subscribed_customers]
GO
ALTER TABLE [dbo].[Customers_enter]  WITH CHECK ADD  CONSTRAINT [FK_Customers_enter_work_shift_type] FOREIGN KEY([work_shift_id])
REFERENCES [dbo].[work_shift_type] ([shift_id])
GO
ALTER TABLE [dbo].[Customers_enter] CHECK CONSTRAINT [FK_Customers_enter_work_shift_type]
GO
ALTER TABLE [dbo].[open_days]  WITH CHECK ADD  CONSTRAINT [FK_open_days_work_shift_type] FOREIGN KEY([shift_id])
REFERENCES [dbo].[work_shift_type] ([shift_id])
GO
ALTER TABLE [dbo].[open_days] CHECK CONSTRAINT [FK_open_days_work_shift_type]
GO
ALTER TABLE [dbo].[otherEnter]  WITH CHECK ADD  CONSTRAINT [FK_otherEnter_work_shift_type] FOREIGN KEY([work_shift_id])
REFERENCES [dbo].[work_shift_type] ([shift_id])
GO
ALTER TABLE [dbo].[otherEnter] CHECK CONSTRAINT [FK_otherEnter_work_shift_type]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_customers] FOREIGN KEY([cust_id])
REFERENCES [dbo].[customers] ([cust_id])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_customers]
GO
ALTER TABLE [dbo].[rentals_details]  WITH CHECK ADD  CONSTRAINT [FK_rentals_details_Rentals] FOREIGN KEY([rent_id])
REFERENCES [dbo].[Rentals] ([rent_id])
GO
ALTER TABLE [dbo].[rentals_details] CHECK CONSTRAINT [FK_rentals_details_Rentals]
GO
ALTER TABLE [dbo].[Subscribed_customers]  WITH CHECK ADD  CONSTRAINT [FK_Subscribed_customers_customers] FOREIGN KEY([cust_id])
REFERENCES [dbo].[customers] ([cust_id])
GO
ALTER TABLE [dbo].[Subscribed_customers] CHECK CONSTRAINT [FK_Subscribed_customers_customers]
GO
ALTER TABLE [dbo].[Subscribed_customers]  WITH CHECK ADD  CONSTRAINT [FK_Subscribed_customers_Subscription_type] FOREIGN KEY([Subscription_type])
REFERENCES [dbo].[Subscription_type] ([Subscription_type_id])
GO
ALTER TABLE [dbo].[Subscribed_customers] CHECK CONSTRAINT [FK_Subscribed_customers_Subscription_type]
GO
USE [master]
GO
ALTER DATABASE [Swimming_Pool] SET  READ_WRITE 
GO
