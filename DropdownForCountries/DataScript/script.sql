USE [master]
GO
/****** Object:  Database [GlobalData]    Script Date: 2/17/2023 10:42:24 AM ******/
CREATE DATABASE [GlobalData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GlobalData', FILENAME = N'C:\Users\paynek\GlobalData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GlobalData_log', FILENAME = N'C:\Users\paynek\GlobalData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GlobalData] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GlobalData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GlobalData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GlobalData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GlobalData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GlobalData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GlobalData] SET ARITHABORT OFF 
GO
ALTER DATABASE [GlobalData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GlobalData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GlobalData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GlobalData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GlobalData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GlobalData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GlobalData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GlobalData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GlobalData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GlobalData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GlobalData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GlobalData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GlobalData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GlobalData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GlobalData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GlobalData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GlobalData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GlobalData] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GlobalData] SET  MULTI_USER 
GO
ALTER DATABASE [GlobalData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GlobalData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GlobalData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GlobalData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GlobalData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GlobalData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GlobalData] SET QUERY_STORE = OFF
GO
USE [GlobalData]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 2/17/2023 10:42:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](2) NOT NULL,
	[Name] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (1, N'AF', N'Afghanistan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (2, N'AL', N'Albania')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (3, N'DZ', N'Algeria')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (4, N'AS', N'American Samoa')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (5, N'AD', N'Andorra')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (6, N'AO', N'Angola')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (7, N'AI', N'Anguilla')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (8, N'AQ', N'Antarctica')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (9, N'AG', N'Antigua and Barbuda')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (10, N'AR', N'Argentina')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (11, N'AM', N'Armenia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (12, N'AW', N'Aruba')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (13, N'AU', N'Australia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (14, N'AT', N'Austria')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (15, N'AZ', N'Azerbaijan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (16, N'BS', N'Bahamas')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (17, N'BH', N'Bahrain')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (18, N'BD', N'Bangladesh')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (19, N'BB', N'Barbados')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (20, N'BY', N'Belarus')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (21, N'BE', N'Belgium')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (22, N'BZ', N'Belize')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (23, N'BJ', N'Benin')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (24, N'BM', N'Bermuda')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (25, N'BT', N'Bhutan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (26, N'BO', N'Bolivia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (27, N'BA', N'Bosnia and Herzegovina')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (28, N'BW', N'Botswana')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (29, N'BV', N'Bouvet Island')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (30, N'BR', N'Brazil')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (31, N'IO', N'British Indian Ocean Territory')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (32, N'BN', N'Brunei Darussalam')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (33, N'BG', N'Bulgaria')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (34, N'BF', N'Burkina Faso')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (35, N'BI', N'Burundi')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (36, N'KH', N'Cambodia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (37, N'CM', N'Cameroon')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (38, N'CA', N'Canada')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (39, N'CV', N'Cape Verde')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (40, N'KY', N'Cayman Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (41, N'CF', N'Central African Republic')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (42, N'TD', N'Chad')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (43, N'CL', N'Chile')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (44, N'CN', N'China')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (45, N'CX', N'Christmas Island')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (46, N'CC', N'Cocos (Keeling) Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (47, N'CO', N'Colombia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (48, N'KM', N'Comoros')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (49, N'CG', N'Congo')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (50, N'CD', N'Congo, the Democratic Republic of the')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (51, N'CK', N'Cook Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (52, N'CR', N'Costa Rica')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (53, N'CI', N'Cote D''Ivoire')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (54, N'HR', N'Croatia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (55, N'CU', N'Cuba')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (56, N'CY', N'Cyprus')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (57, N'CZ', N'Czech Republic')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (58, N'DK', N'Denmark')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (59, N'DJ', N'Djibouti')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (60, N'DM', N'Dominica')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (61, N'DO', N'Dominican Republic')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (62, N'EC', N'Ecuador')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (63, N'EG', N'Egypt')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (64, N'SV', N'El Salvador')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (65, N'GQ', N'Equatorial Guinea')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (66, N'ER', N'Eritrea')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (67, N'EE', N'Estonia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (68, N'ET', N'Ethiopia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (69, N'FK', N'Falkland Islands (Malvinas)')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (70, N'FO', N'Faroe Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (71, N'FJ', N'Fiji')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (72, N'FI', N'Finland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (73, N'FR', N'France')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (74, N'GF', N'French Guiana')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (75, N'PF', N'French Polynesia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (76, N'TF', N'French Southern Territories')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (77, N'GA', N'Gabon')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (78, N'GM', N'Gambia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (79, N'GE', N'Georgia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (80, N'DE', N'Germany')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (81, N'GH', N'Ghana')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (82, N'GI', N'Gibraltar')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (83, N'GR', N'Greece')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (84, N'GL', N'Greenland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (85, N'GD', N'Grenada')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (86, N'GP', N'Guadeloupe')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (87, N'GU', N'Guam')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (88, N'GT', N'Guatemala')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (89, N'GN', N'Guinea')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (90, N'GW', N'Guinea-Bissau')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (91, N'GY', N'Guyana')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (92, N'HT', N'Haiti')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (93, N'HM', N'Heard Island and Mcdonald Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (94, N'VA', N'Holy See (Vatican City State)')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (95, N'HN', N'Honduras')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (96, N'HK', N'Hong Kong')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (97, N'HU', N'Hungary')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (98, N'IS', N'Iceland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (99, N'IN', N'India')
GO
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (100, N'ID', N'Indonesia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (101, N'IR', N'Iran, Islamic Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (102, N'IQ', N'Iraq')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (103, N'IE', N'Ireland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (104, N'IL', N'Israel')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (105, N'IT', N'Italy')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (106, N'JM', N'Jamaica')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (107, N'JP', N'Japan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (108, N'JO', N'Jordan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (109, N'KZ', N'Kazakhstan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (110, N'KE', N'Kenya')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (111, N'KI', N'Kiribati')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (112, N'KP', N'Korea, Democratic People''s Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (113, N'KR', N'Korea, Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (114, N'KW', N'Kuwait')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (115, N'KG', N'Kyrgyzstan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (116, N'LA', N'Lao People''s Democratic Republic')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (117, N'LV', N'Latvia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (118, N'LB', N'Lebanon')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (119, N'LS', N'Lesotho')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (120, N'LR', N'Liberia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (121, N'LY', N'Libyan Arab Jamahiriya')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (122, N'LI', N'Liechtenstein')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (123, N'LT', N'Lithuania')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (124, N'LU', N'Luxembourg')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (125, N'MO', N'Macao')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (126, N'MK', N'Macedonia, the Former Yugoslav Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (127, N'MG', N'Madagascar')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (128, N'MW', N'Malawi')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (129, N'MY', N'Malaysia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (130, N'MV', N'Maldives')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (131, N'ML', N'Mali')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (132, N'MT', N'Malta')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (133, N'MH', N'Marshall Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (134, N'MQ', N'Martinique')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (135, N'MR', N'Mauritania')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (136, N'MU', N'Mauritius')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (137, N'YT', N'Mayotte')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (138, N'MX', N'Mexico')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (139, N'FM', N'Micronesia, Federated States of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (140, N'MD', N'Moldova, Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (141, N'MC', N'Monaco')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (142, N'MN', N'Mongolia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (143, N'MS', N'Montserrat')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (144, N'MA', N'Morocco')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (145, N'MZ', N'Mozambique')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (146, N'MM', N'Myanmar')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (147, N'NA', N'Namibia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (148, N'NR', N'Nauru')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (149, N'NP', N'Nepal')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (150, N'NL', N'Netherlands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (151, N'AN', N'Netherlands Antilles')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (152, N'NC', N'New Caledonia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (153, N'NZ', N'New Zealand')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (154, N'NI', N'Nicaragua')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (155, N'NE', N'Niger')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (156, N'NG', N'Nigeria')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (157, N'NU', N'Niue')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (158, N'NF', N'Norfolk Island')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (159, N'MP', N'Northern Mariana Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (160, N'NO', N'Norway')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (161, N'OM', N'Oman')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (162, N'PK', N'Pakistan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (163, N'PW', N'Palau')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (164, N'PS', N'Palestinian Territory, Occupied')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (165, N'PA', N'Panama')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (166, N'PG', N'Papua New Guinea')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (167, N'PY', N'Paraguay')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (168, N'PE', N'Peru')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (169, N'PH', N'Philippines')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (170, N'PN', N'Pitcairn')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (171, N'PL', N'Poland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (172, N'PT', N'Portugal')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (173, N'PR', N'Puerto Rico')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (174, N'QA', N'Qatar')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (175, N'RE', N'Reunion')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (176, N'RO', N'Romania')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (177, N'RU', N'Russian Federation')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (178, N'RW', N'Rwanda')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (179, N'SH', N'Saint Helena')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (180, N'KN', N'Saint Kitts and Nevis')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (181, N'LC', N'Saint Lucia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (182, N'PM', N'Saint Pierre and Miquelon')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (183, N'VC', N'Saint Vincent and the Grenadines')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (184, N'WS', N'Samoa')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (185, N'SM', N'San Marino')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (186, N'ST', N'Sao Tome and Principe')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (187, N'SA', N'Saudi Arabia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (188, N'SN', N'Senegal')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (189, N'CS', N'Serbia and Montenegro')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (190, N'SC', N'Seychelles')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (191, N'SL', N'Sierra Leone')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (192, N'SG', N'Singapore')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (193, N'SK', N'Slovakia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (194, N'SI', N'Slovenia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (195, N'SB', N'Solomon Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (196, N'SO', N'Somalia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (197, N'ZA', N'South Africa')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (198, N'GS', N'South Georgia and the South Sandwich Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (199, N'ES', N'Spain')
GO
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (200, N'LK', N'Sri Lanka')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (201, N'SD', N'Sudan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (202, N'SR', N'Suriname')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (203, N'SJ', N'Svalbard and Jan Mayen')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (204, N'SZ', N'Swaziland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (205, N'SE', N'Sweden')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (206, N'CH', N'Switzerland')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (207, N'SY', N'Syrian Arab Republic')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (208, N'TW', N'Taiwan, Province of China')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (209, N'TJ', N'Tajikistan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (210, N'TZ', N'Tanzania, United Republic of')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (211, N'TH', N'Thailand')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (212, N'TL', N'Timor-Leste')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (213, N'TG', N'Togo')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (214, N'TK', N'Tokelau')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (215, N'TO', N'Tonga')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (216, N'TT', N'Trinidad and Tobago')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (217, N'TN', N'Tunisia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (218, N'TR', N'Turkey')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (219, N'TM', N'Turkmenistan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (220, N'TC', N'Turks and Caicos Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (221, N'TV', N'Tuvalu')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (222, N'UG', N'Uganda')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (223, N'UA', N'Ukraine')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (224, N'AE', N'United Arab Emirates')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (225, N'GB', N'United Kingdom')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (226, N'US', N'United States')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (227, N'UM', N'United States Minor Outlying Islands')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (228, N'UY', N'Uruguay')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (229, N'UZ', N'Uzbekistan')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (230, N'VU', N'Vanuatu')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (231, N'VE', N'Venezuela')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (232, N'VN', N'Viet Nam')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (233, N'VG', N'Virgin Islands, British')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (234, N'VI', N'Virgin Islands, U.s.')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (235, N'WF', N'Wallis and Futuna')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (236, N'EH', N'Western Sahara')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (237, N'YE', N'Yemen')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (238, N'ZM', N'Zambia')
INSERT [dbo].[Countries] ([Id], [Code], [Name]) VALUES (239, N'ZW', N'Zimbabwe')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uc_Countries_Iso]    Script Date: 2/17/2023 10:42:24 AM ******/
ALTER TABLE [dbo].[Countries] ADD  CONSTRAINT [uc_Countries_Iso] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [GlobalData] SET  READ_WRITE 
GO
