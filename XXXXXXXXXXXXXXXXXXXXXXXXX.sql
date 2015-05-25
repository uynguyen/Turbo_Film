USE [TURBO_PHIM]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaiNhanXet]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiNhanXet](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[MS_Phim] [int] NULL,
	[MS_ThanhVien] [int] NULL,
	[NoiDung] [ntext] NULL,
	[NgayDang] [datetime] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_BaiNhanXet] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BangThamSo]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangThamSo](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[TenThamSo] [nvarchar](50) NULL,
	[KieuDuLieu] [nchar](10) NULL,
	[GiaTri] [nchar](30) NULL,
 CONSTRAINT [PK_BangThamSo] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BinhChon]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhChon](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[MS_ThanhVien] [int] NOT NULL,
	[MS_BaiNhanXet] [int] NOT NULL,
	[BinhChon] [bit] NOT NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_BinhChon] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BinhLuan]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinhLuan](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[MS_ThanhVien] [int] NULL,
	[MS_BaiNhanXet] [int] NULL,
	[NoiDung] [ntext] NULL,
	[NgayDang] [date] NULL,
 CONSTRAINT [PK_BinhLuan] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[MS_ThanhVien] [int] NULL,
	[MS_Phim] [int] NULL,
	[DiemDanhGia] [float] NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucNuocSanXuat]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucNuocSanXuat](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[TenNuoc] [nvarchar](20) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NuocSX] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucTheLoai]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucTheLoai](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhSachPhimYeuThich]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachPhimYeuThich](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[MS_ThanhVien] [int] NULL,
	[MS_Phim] [int] NULL,
 CONSTRAINT [PK_DanhSachPhimYeuThich] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phim]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phim](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[TenPhim] [nvarchar](100) NULL,
	[NoiDung] [ntext] NULL,
	[URL_Trailer] [nvarchar](50) NULL,
	[DiemDanhGia] [float] NULL,
	[MS_TheLoai] [int] NULL,
	[ThoiLuong] [float] NULL,
	[DienVien] [ntext] NULL,
	[DaoDien] [ntext] NULL,
	[MS_NuocSX] [int] NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[NgayPhatHanh] [date] NULL,
	[TinhTrang] [bit] NULL,
	[AnhBanner] [nvarchar](100) NULL,
 CONSTRAINT [PK_Phim] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhVien]    Script Date: 25/05/2015 4:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhVien](
	[MaSo] [int] IDENTITY(0,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[MS_TaiKhoan] [nvarchar](128) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[TinhTrang] [bit] NULL,
	[GioiTinh] [bit] NULL,
	[Avatar] [nchar](100) NULL,
	[NgayDangKy] [datetime] NULL,
 CONSTRAINT [PK_ThanhVien] PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201505241512051_InitialCreate', N'TESTIDENTITY.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE3B6127E3FC0F90F829ECE3948AD5CBA8B6D60EF227592738C6E2E587B8B9EA7052DD18EB012A54A549AA0E82FEB437F52FF42871275E345175BB19D628145440EBF190E87E47038F49FBFFF31FEF0E47BC6238E62372013F364746C1A98D881E392F5C44CE8EA9B77E687F7FFFCC7F8CAF19F8C1F73BA3346072D493C311F280DCF2D2BB61FB08FE291EFDA5110072B3AB203DF424E609D1E1F7F679D9C5818204CC0328CF1A78450D7C7E9077C4E0362E39026C8BB091CECC5BC1C6AE629AA718B7C1C87C8C6137371355FCC2EAF6E17B3C5FF4719B9695C782E0251E6D85B99062224A08882A0E79F633CA75140D6F3100A90B7780E31D0AD901763DE81F392BC6B5F8E4F595FACB2610E6527310DFC9E8027675C3996D87C23159B85F2407D57A066FACC7A9DAA7062CE1C9C167D0A3C5080C8F07CEA458C7862DE142C2EE2F016D351DE7094415E4700F74B107D1D55118F8CCEED8E0A633A1D1DB37F47C634F16812E109C1098D907764DC274BCFB57FC0CF8BE02B2693B393E5EAECDD9BB7C8397BFB2D3E7B53ED29F415E86A0550741F05218E4036BC2AFA6F1A56BD9D25362C9A55DA645A015B8279611A37E8E923266BFA0033E6F49D695CBB4FD8C94BB8717D262E4C236844A3043E6F13CF434B0F17F556234FF67F03D7D3376F07E17A8B1EDD753AF4027F983811CCAB4FD84B6BE30737CCA6576DBCBF70B2EB28F0D977DDBEB2DA2FF320896CD699404BB240D11AD3BA7463AB34DE4E26CDA08637EB1CF5F04D9B492A9BB792947568939990B3D8F56CC8E57D59BE9D2DEE220C61F052D3621A693238C56E35129A1F1955A2D2784EBA1A0F814EFD9DD7C22B1FB9DE008B61072EE088ACDCC8C7452FBF0FC0F410E92DF33D8A63580B9CFFA1F8A14174F87300D1E7D84E2230D139457EF8E2DCEE1F02826F137FC92C7F77BC061B9AC52FC135B269105D11D66A6BBC8F81FD3548E815712E11C59FA99D03B2CF85EB770718449C0BDBC6717C0DC68C9D69007E760E3823F4ECB4371C5BA1F6ED8C4C3DE4FA6A6F44584BBFE4A4A547A2A690BC120D99CA336912F563B0764937517352BDA81945ABA89CACAFA80CAC9BA49C522F684AD02A67463598AF978ED0F0CE5E0A7BF8DEDE769BB76E2DA8A8710E2B24FE2F26388265CCB94794E2889423D065DDD887B3900E1F63FAE27B53CAE947E42543B3DA6836A48BC0F0B321853DFCD9908A09C58FAEC3BC920E47A09C18E03BD1AB4F57ED734E906CD7D3A1D6CD5D33DFCD1AA09B2E17711CD86E3A0B14C12F1EBAA8CB0F3E9CD11EC7C87A23C642A06360E82EDBF2A004FA668A4675472EB18729362EEC2C383845B18D1C598DD021A78760F98EAA10AC8C89D485FB8FC4132C1D47AC116287A01866AA4BA83C2D5C62BB21F25AB524B4ECB885B1BE173CC49A4B1C62C218B66AA20B737508840950F01106A54D4363AB6271CD86A8F15A7563DEE6C296E32E45267662932DBEB3C62EB9FFF62286D9ACB11D1867B34ABA08A00DE7EDC340F959A5AB01880797433350E1C4A43150EE52EDC440EB1ADB8381D655F2EA0C343BA2761D7FE1BC7A68E6593F28EF7E5B6F54D71E6CB3A68F0333CDCCF78436145AE04836CFCB25ABC44F5471380339F9F92CE6AEAE68220C7C8E693D6453FABB4A3FD46A06118DA809B034B416507E1128014913AA8770792CAF513AEE45F480CDE36E8DB07CED17602B362063572F442B84FA6B53D1383B9D3E8A9E15D6201979A7C34205476110E2E255EF7807A5E8E2B2B262BAF8C27DBCE14AC7F8603428A8C573D52829EFCCE05ACA4DB35D4B2A87AC8F4BB6959604F749A3A5BC33836B89DB68BB92144E410FB7602B15D5B7F081265B1EE928769BA26E6C658952BC606C6932AAC637280C5DB2AE6458F112639EA5574DBF99F74F3BF2330CCB8E15D94785B405271A44688D855A600D925EBB514C2F11454BC4E23C53C797C8947BAB66F9CF5956B74F7910F37D20A7667FF3BB42C5F57D6DB395BD110E720D5DF4994B93C6D11506A06E6EB09437E4A14811BA9F065EE213BD87A56F9D5DE055DB672532C2D812E4973C28495D929F5BD77DA7919167C550A35478309B8F941E42A7EFDCFFAC6A5CE793EA51F21055154517B6DADBC8E95C997EA325BA89FD07AB15E1656616CF4DA902F0A29E1895F40609AC52D71DB59E8152C5ACD7744714D24CAA9042550F29ABC9243521AB151BE16934AAA6E8CE414E1FA9A2CBB5DD91158924556845F506D80A99C5BAEEA88A5C932AB0A2BA3B76997822AEA207BC77690F2F9B6F5ED90177BBDD4B83F1324BE2309B5FE51EBF0A5429EE89C56FEA25305E7E90E6A43DE56D6E4E5960633B73D260E8D79EDA15787DE969BCB7D763D6EEB56BCB7BD3BDBE1EAF9FD1BEA86948A73C91A4E05E9CF68453DD989FB0DA1FD34847AE8CC4347235C2D6FE1C53EC8F18C168FEB337F55CCC16F29CE006117785639AE5729870227C273CC7399CA731561C3B9EE284AA7B1F531FB31DA465914714D90F28929324B6783E52824AF1E71971F0D3C4FC356D759E8632D85F69F191318B3F13F7E7042A1651828DDFE4A4CF61D2E99BCF5907FAF8A1BB56673F7DC99A1E197711CC9873E358D0E526235C7F12D14B9AACE916D26CFC50E2F54EA8DA1B0425AA3021367F72B074E920CF0D7229FFE5A3A77FF7154DF9A4602B44C5B381A1F00651A1EE59C02658DA27010E7CD2F44940BFCEAA9F086C229AF679804BFA83898F03BA2F4379CB3D6E358A43D12E96A454CFADC9D55B655AEE7B6F9272B0B79AE8729E750FB82D72A937B08C5796863CD8EEA8C8321E0C7B9FA6FDE2A9C587924D5CE679EC3789789779C30D37437FAB74E10348705324ECEC3F2978D7B6A60BE41E786665BFD4DF0333369EC6B5FF04DF5D1B9B2ECC7BE0C6D62B8DF7C06C6D5FFBE79E2DADF316BAF7A45C39BF487321A38A05B725DD66817338E12F033082CCA3CCDE4AAAB3BC9A32545B1896247AA6FAF43291B1347124BE124533DB7E7DE51B7E6367394D335B4D5266136FBEFE37F2E634CDBC35A98EFB481756261BAA52B85BD6B1A63CA8D7941E5CEB494B367A9BCFDA78BBFE9AB28107514A6DF668EE885F4FF2EF202A1972EAF448F695AF7B61EFACFCC222ECDFB1BB2E21D8EF2D126CD776CD8266465641BE790B12E5244284E60653E4C0967A115177856C0AD52CC69C3EF64EE376ECA663899D19B94B689850E832F6975E2DE0C59C8026FE6946735DE6F15D98FE6EC9105D00315D169BBF23DF27AEE714725F2B62421A08E65DF0882E1B4BCA22BBEBE702E936201D81B8FA0AA76881FDD003B0F88ECCD123DE443630BF8F788DECE73202A803691F88BADAC7972E5A47C88F3946D91E3EC1861DFFE9FD5F9F06928068540000, N'6.1.1-30610')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Member')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId], [Id]) VALUES (N'7605494e-96a0-442e-b6ac-ba2e24441182', N'1', NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'490d24b2-b547-4db9-8d70-41c7237c14a1', N'vinle@gmail.com', 0, N'APgbtu7JBul+yo6cRWVJRR/2zoY+YqHirD4qc8u297wxHmnYVyniScNaDXm7ahGhxQ==', N'09f23d18-40c4-4834-97e2-19f60d566735', NULL, 0, 0, NULL, 1, 0, N'vinle@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7605494e-96a0-442e-b6ac-ba2e24441182', N'vinledepchai@gmail.com', 0, N'ABqLfhksmd+tCu/mu5qfaSuElWI2RBnJ/aU/ltQX0vCYbyxj8HCZCco0iJP4UIilMA==', N'60ae04e7-ce71-44d0-8227-e8e4ec181d26', NULL, 0, 0, NULL, 1, 0, N'vinledepchai@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e0a0804e-aeb0-48b0-b3ed-91653c458b74', N'abcxyzc@gmail.com', 0, N'AP7qvlKar7GzrbJKy4FTczc4qOOJWFFb3cOnuEsttlclV0h/A+30n9CsSSz4cj+2PA==', N'413ed637-6933-4b54-b32a-d62b074027e4', NULL, 0, 0, NULL, 1, 0, N'abcxyzc@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f2a07c66-b798-43c9-9203-637f2df1e44e', N'uynguyen@gmail.com', 0, N'AFj7/IytzQDjR/vefBK7lVIcije8CW+xHyUkoXMYyJYSouY+jt4Yg6fxXAw3fdiNEw==', N'2d40674b-3fc0-4fac-927f-7370b29379e8', NULL, 0, 0, NULL, 1, 0, N'uynguyen@gmail.com')
SET IDENTITY_INSERT [dbo].[BaiNhanXet] ON 

INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (0, 0, 0, N'Bộ phim khá hay', CAST(0x0000A2C600000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (1, 1, 0, N'Phim diễn viên đẹp và không hay gì hết, coi diễn viên bù lại cũng được mấy bạn à.', CAST(0x0000A39E00000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (2, 0, 1, N'Phim này hay nhưng mà nếu diễn viên đẹp hơn tí chắc nhiều người xem hơn.', CAST(0x0000A2C700000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (3, 0, 2, N'Phim này cũng tạm được, diễn viên hơi xấu tí', CAST(0x0000A2E200000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (4, 1, 1, N'Xem xong phim đứng hình trước vẻ đẹp của diễn viên, nhưng mà chả hiểu phim nói gì hết', CAST(0x0000A3BC00000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (5, 1, 2, N'Phim này chỉ được cái diễn viên đẹp thôi', CAST(0x0000A3BC00000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (6, 2, 1, N'Nội dung phim hay và cảm động, qua phim này ta học được nhiều bài học', CAST(0x0000A30100000000 AS DateTime), 1)
INSERT [dbo].[BaiNhanXet] ([MaSo], [MS_Phim], [MS_ThanhVien], [NoiDung], [NgayDang], [TinhTrang]) VALUES (7, 2, 2, N'Phim hay quá, đầy tình cảm, cảm động và chan chứa nhiều cảm xúc', CAST(0x0000A2E200000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BaiNhanXet] OFF
SET IDENTITY_INSERT [dbo].[BangThamSo] ON 

INSERT [dbo].[BangThamSo] ([MaSo], [TenThamSo], [KieuDuLieu], [GiaTri]) VALUES (0, N'SoPhimTrenMotTrang', N'int       ', N'5                             ')
INSERT [dbo].[BangThamSo] ([MaSo], [TenThamSo], [KieuDuLieu], [GiaTri]) VALUES (9, N'GiaTriTrangLonNhatMoiLanPhanTrang', N'int       ', N'5                             ')
SET IDENTITY_INSERT [dbo].[BangThamSo] OFF
SET IDENTITY_INSERT [dbo].[BinhChon] ON 

INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (0, 0, 1, 1, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (1, 0, 0, 0, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (2, 0, 4, 1, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (3, 0, 5, 1, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (4, 1, 0, 1, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (6, 1, 3, 1, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (7, 1, 2, 0, 1)
INSERT [dbo].[BinhChon] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [BinhChon], [TinhTrang]) VALUES (8, 2, 6, 1, 1)
SET IDENTITY_INSERT [dbo].[BinhChon] OFF
SET IDENTITY_INSERT [dbo].[BinhLuan] ON 

INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (0, 0, 0, N'Đúng đó bạn à, mình cũng thấy dzị.', CAST(0x24380B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (1, 0, 1, N'Người đẹp là được rồi bạn, coi người thôi mà', CAST(0x17390B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (2, 0, 4, N'uh thì vậy đó', CAST(0xA6380B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (3, 1, 1, N'Mình chỉ coi diễn viên thôi, diễn viên đẹp', CAST(0xFC380B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (4, 2, 0, N'Phim hay, khỏi phải chê', CAST(0x5A390B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (5, 2, 7, N'Coi phim xong khóc sưng mắt luôn', CAST(0x1B390B00 AS Date))
INSERT [dbo].[BinhLuan] ([MaSo], [MS_ThanhVien], [MS_BaiNhanXet], [NoiDung], [NgayDang]) VALUES (6, 1, 7, N'Minh ngồi coi phim một mình, mà nước mắt cứ tuôn ra, phim cảm động quá', CAST(0xFC380B00 AS Date))
SET IDENTITY_INSERT [dbo].[BinhLuan] OFF
SET IDENTITY_INSERT [dbo].[DanhGia] ON 

INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (0, 1, 0, 8)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (1, 1, 0, 9)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (2, 1, 0, 8)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (3, 0, 0, 7)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (4, 0, 1, 9)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (5, 0, 2, 9)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (6, 2, 2, 7)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (7, 2, 4, 8)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (8, 2, 8, 9)
INSERT [dbo].[DanhGia] ([MaSo], [MS_ThanhVien], [MS_Phim], [DiemDanhGia]) VALUES (9, 2, 1, 5,6)
SET IDENTITY_INSERT [dbo].[DanhGia] OFF
SET IDENTITY_INSERT [dbo].[DanhMucNuocSanXuat] ON 

INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (0, N'Mỹ', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (1, N'Việt Nam', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (2, N'Pháp', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (3, N'Hàn Quốc', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (4, N'Nhật Bản', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (5, N'Anh', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (6, N'Trung Quốc', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (7, N'Hồng Kong', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (8, N'Thái Lan', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (9, N'Ấn Độ', 1)
INSERT [dbo].[DanhMucNuocSanXuat] ([MaSo], [TenNuoc], [TinhTrang]) VALUES (10, N'Khác', 1)
SET IDENTITY_INSERT [dbo].[DanhMucNuocSanXuat] OFF
SET IDENTITY_INSERT [dbo].[DanhMucTheLoai] ON 

INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (0, N'Hành động', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (1, N'Phiêu lưu', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (2, N'Viễn tưởng', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (3, N'Võ thuật', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (4, N'Kinh dị', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (5, N'Cổ trang', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (6, N'Tâm lý', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (7, N'Hình sự', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (8, N'Hài hước', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (9, N'Thần thoại', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (10, N'Hoạt hình', 1)
INSERT [dbo].[DanhMucTheLoai] ([MaSo], [TenTheLoai], [TinhTrang]) VALUES (11, N'Khác', 1)
SET IDENTITY_INSERT [dbo].[DanhMucTheLoai] OFF
SET IDENTITY_INSERT [dbo].[Phim] ON 

INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (0, N'Spider Man 2', N'Wizard Vitruvius, một nhà tiên tri phải cố gắng để bảo vệ "Kragle", một siêu vũ khí từ Trùm Kinh doanh. Ông đã không ngăn cản được hắn, nhưng ông đã cảnh báo Trùm kinh doanh về một lời tiên tri, nơi mà một người được gọi là "người đặc biệt" sẽ ngăn chặn được Kragle. Tám năm sau, Emmet Brickowski, một công nhân xây dựng bình thường, anh gặp một phụ nữ tên là Wyldstyle, cô đang tìm kiếm một cái gì đó sau giờ làm ở công trường xây dựng của Emmet. Khi đi tìm cô, Emmet rơi vào một cái lỗ và tìm thấy cái "cục gạch ngăn trở". Sau khi chạm vào nó, Emmet ngất đi. Anh tỉnh dậy dưới sự giám sát của Cảnh sát Xấu (người có hai mặt là tốt và xấu), tay sai của Trùm kinh doanh, lúc này Emmet phát hiện ra trên lưng anh vẫn còn "cục gạch ngăn trở". Emmet biết được kế hoạch của Trùm kinh doanh là đóng băng thế giới bằng Kragle (một loại keo dán). Wyldstyle cứu Emmet và đưa anh ta đến Vitruvius, cô cố giải thích cho Emmet và cô nói anh là Thợ xây Tài ba (Master Builders) có khả năng xây dựng bất cứ điều gì họ cần với tốc độ lớn và không cần hướng dẫn. Khi Trùm kinh doanh lên cầm quyền, hắn không tán thành về sự sáng tạo vô chính phủ như vậy hắn đến và bắt giữ nhiều người trong số họ. Là " người đặc biệt", Emmet có sứ mệnh phải đánh bại hắn ta nhưng Wyldstyle và Vitruvius rất thất vọng khi thấy Emmet không có gì sáng tạo.', N'https://www.youtube.com/embed/DlM2CWNTQ84', 8, 0, 120, N'Phil Lord , Chris Miller', N'Lý An', 1, N'/Images/01.JPG', CAST(0xF1390B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (1, N'Big Hero 6', N'Câu chuyện diễn ra tại một thành phố hư cấu có tên là San Fransokyo (tên viết tắt của 2 thành phố San Francisco của Mỹ và Tokyo của Nhật Bản). Đó là nơi ở của cậu bé thần đồng Hiro Hamada cùng với một người bạn hết sức đặc biệt là Baymax. Baymax trông giống như một người tuyết màu trắng, đây là phát minh của Tadashi – anh trai Hiro. Baymax được tạo ra nhằm mục đích phục vụ cho sức khỏe của con người. Với sự thông minh của Hiro, cậu nhóc đã chế tạo ra các công cụ chiến đấu cho biệt đội siêu anh hùng với sự đồng hành của 5 thành viên còn lại là Baymax, Wasabi, Go Go, Fred và Honey Lemon. Họ cùng điều tra về kẻ giấu mặt “kabuki” đã đánh cắp phát minh “bọ siêu nhỏ” của Hiro và ngăn chặn 1 thảm họa đối với thành phố.', N'https://www.youtube.com/embed/mZEZ35Fhvuc', 9, 0, 120, N'uyuyuyyu', N'Chris Williams, Don Hall, ', 2, N'/Images/02.jpg', CAST(0xEF390B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (2, N'The Lego Movie', N'Bộ Phim Lego là một bộ phim điện ảnh thuộc thể loại hoạt hình 3d hành động được 2 đạo diễn Phil Lord và Chris Miller phụ trách hợp tác ngoài ra còn có thêm những diễn viên lồng tiếng thú vị trong phim như là Phil Lord, Chris Miller....Nội dung bộ Phim The Lego Movie  xoay quanh một anh chàng thanh niên bình thường tên Emmet bị hiểu nhầm là một trong những siêu anh hùng đi giải cứu thế giới khỏi tay một tên độc tài sở hữu sức mạnh khủng khiếp nhất vũ trụ, với ý đĩnh sẽ chiếm lấy Trái Đất làm của riêng hắn. Emmet từ một chàng trai bình thường trở thành vị cứu tình bất đắc dĩ của cả nhân loại, đằng sau Emmet là sự hỗ trợ của những super heroes đến từ khắp nơi trên thế giới, điển hình như Superman, Batman, Superwoman và những siêu robot do quân đội điều phái đến. Nhận thấy Emmet là mối nguy hiểm cần diệt trừ cho nên President Business đã điều phái Bad Cop đi bắt cóc Emmet và điều tra thông tin về anh chàng thanh niên này. Bộ phim sử dụng đồ họa 3d về những bộ trò chơi lắp ráp lego nổi tiếng thế giới rất được ưa chuộng hàng thập kỉ qua và cho đến tận bây giờ.', N'https://www.youtube.com/embed/fZ_JOBCLF-I', 8, 0, 120, N'Phil Lord , Chris Miller', N'Xanh Hồ3', 1, N'/Images/03.jpg', CAST(0xF1390B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (3, N'Transcendence ', N'Transcendence xoay quanh tiến sĩ Will Caster (Johnny Depp), một nhà nghiên cứu dự báo trong lĩnh vực trí thông minh nhân tạo, công việc của anh đang làm nhằm chế tạo một cỗ máy có khả năng tự nhận thức, kết hợp từ toàn bộ những tri thức mà nhân loại từng biết đến với mọi biểu hiện cảm xúc đặc trưng của con người. Những thử nghiệm gây tranh cãi của Will khiến anh trở nên nổi tiếng nhưng cũng biến anh thành mục tiêu lớn nhất của những phần tử bài công nghệ và chúng sẽ không từ bất kỳ thủ đoạn nào để ngăn cản anh.', N'https://www.youtube.com/embed/CTen3-B8GU', 0, 1, 90, N'Johnny Depp, Rebecca Hall, Morgan ', N'Wally Pfister', 4, N'/Images/04.jpg', CAST(0xEF390B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (4, N'Life of Pi ', N'Nội dung phim Cuộc Phiêu Lưu Của Pi: Đã lâu rồi mình không cảm thấy tuyệt vời như vậy khi đến rạp xem phim, đạo diễn Lý An đã mang đến cho khán giả một thế giới tuyệt vời, đưa người xem chu du qua những cung bậc cảm xúc, thoả mãn những giác quan khó tính, làm người xem nổi da gà qua những khung hình tuyệt đẹp cùng âm thanh sống động đến không ngờ, Life of Pi quả thật là một trải niệm điện ảnh tuyệt vời, cùng với công nghệ 3D, bộ phim là một tác phẩm nghệ thuật đích thực. 1. Kịch bản: 8/10 Pi Patel là một cậu bé người Ấn Độ, cậu lớn lên một cách bình thường như bao đứa trẻ khác, cậu cũng yêu, cũng bất đồng với cha mẹ...đến một ngày, cha cậu quyết định chuyển nhà đến tận Canada vì chuyện kinh doanh hiện tại không được tốt, trong chuyến đi định mệnh, con tàu chở hàng cùng với cả nhà Pi gặp một trận bão lớn, và chỉ có mình Pi sống sót trên con thuyền cứu hộ nhỏ, chút ít lương thực cùng một vài con thú từ sở thú mà cha cậu định mang sang Mỹ để bán lấy tiền sinh sống, một con ngựa vằn, một con linh cẩu, một đười ươi và một con hổ, lênh đênh trên biển bao ngày, chống chọi với thiên nhiên cùng những con thú, cuối cùng cậu đã đến được đất liền Mexicô, kiệt sức và cô độc. Kịch bản của Life of Pi quả thực viết rất hay, những tình tiết, lời thoại trong phim có giá trị giáo dục rất cao mà không thể xem một lần đã hiểu hết được, phim cho ta thấy một cách toàn diện văn hoá, con người Ấn Độ, một cái nhìn về các tôn giáo, tuyên truyền bảo vệ động vật...hầu như trong phim, mọi thứ đều có một liên kết rất chặt chẽ với nhau một cách tuyệt vời, một kịch bản không có gì đáng chê trách. 2. Diễn xuất: 8/10 Câu chuyện trong Life of Pi là một câu chuyện được kể lại, có người kể Irrfan Khan [trong vai Pi Patel trưởng thành] và người nghe Rafe Spall [một tiểu thuyết gia đi tìm ý tưởng], hai nhân vật này chỉ xuất hiện rất ít trong phim, nhân vật chính chúng ta cần nói đến chính là Suraj Sharma [trong vai Pi Patel còn trẻ] và...con hổ Bengal có tên Richard Parker. Pi Patel, thường gọi là Pi, sau khi sống sót qua cơn bão thì số phận oái oăm ào đến với một con thú dữ cứ lỡn vỡn trong bán kính 10m xung quanh, anh cố gắn để sống sót, làm quen với con hổ, và gần như trở thành bạn nó. Đây là một vai diễn khá tốt của chàng diễn viên trẻ, những trường đoạn như lúc tàu chìm, lúc vờn với con hổ rất cảm xúc, làm người xem rất cảm động, tuy chỉ có hai nhân vật phần lớn thời gian của phim.', N'https://www.youtube.com/embed/mZEZ35Fhvuc', 9, 2, 45, N'Suraj Sharma, Irrfan Khan và Adil ', N'Lý An', 3, N'/Images/05.jpg', CAST(0xF1390B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (5, N'SherLock Holmes ', N'Sherlock Holmes và người bạn thân là bác sĩ Watson lần này phải đối mặt với kẻ thù mới vô cùng khôn ngoan là giáo sư Moriarty.', N'https://www.youtube.com/embed/I0hXhGt5XPg', 9, 3, 180, N'Joel Silver, Lionel Wigram, Susan Downey, Dan Lin, Robert Downey Jr, Rachel McAdams', N'Guy Ritchie', 7, N'/Images/06.jpg', CAST(0xB1340B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (6, N'The Avengers', N'The Avengers là một tập hợp những siêu anh hùng bao gồm: Captain America, Iron Man, Thor, Hulk,… Tuy nhiên, Captain America vẫn chưa công chiếu. Vì là tập hợp của một loạt siêu anh hùng trên nên việc đồng nhất về nhân vật cũng như cốt truyện, cách xây dựng là rất khó, điều đó nâng The Avengers trở thành một siêu phẩm hứa hẹn sẽ thu hút bất kỳ tín đồ nào của dòng phim này.', N'https://www.youtube.com/embed/tmeOjFno6Do', 7, 4, 45, N'Robert Downey, Jr., Chris Evans, Mark Ruffalo, Chris Hemsworth, Scarlett Johansson, Jeremy Renner, Tom Hiddleston, Samuel L. Jackson', N'Joss Whedon', 5, N'/Images/07.jpg', CAST(0x01360B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (7, N'Interstellar', N'“Interstellar” là biên niên ký về cuộc phiêu lưu vĩ đại của một nhóm các nhà thám hiểm sử dụng khám phá mới về lỗ đen vũ trụ để vượt qua các giới hạn thông thường trong du hành không gian, chinh phục khoảng không mênh mông trên một chuyến hành trình xuyên dải ngân hà...', N'https://www.youtube.com/embed/Lm8p5rlrSkY', 8, 2, 120, N'Matthew McConaughey, Anne Hathaway, Jessica Chastain', N'Christopher Nolan', 6, N'/Images/08.jpg', CAST(0x7D380B00 AS Date), 1, NULL)
INSERT [dbo].[Phim] ([MaSo], [TenPhim], [NoiDung], [URL_Trailer], [DiemDanhGia], [MS_TheLoai], [ThoiLuong], [DienVien], [DaoDien], [MS_NuocSX], [HinhAnh], [NgayPhatHanh], [TinhTrang], [AnhBanner]) VALUES (8, N'Dawn of the Planet of the Apes', N'Phần tiếp theo của siêu phẩm khoa học viễn tưởng Rise of the Planet of the Apes (Sự Nổi Dậy Của Loài Khỉ) - Dawn of the Planet of the Apes - đang gây sự chú ý cao độ của người xem khi nhận được hàng loạt lời nhận xét vô cùng tích cực từ giới truyền thông. Thậm chí, những dự đoán phim sẽ oanh tạc phòng vé vào thứ 6 tuần tới đã được nhiều trang báo khẳng định “chắc như đinh đóng cột”.', N'https://www.youtube.com/embed/eq1sTNGDXo0', 10, 1, 120, N'Gary Oldman, Keri Russell, Andy Serkis', N'Matt Reeves', 6, N'/Images/09.jpg', CAST(0xEF390B00 AS Date), 1, NULL)
SET IDENTITY_INSERT [dbo].[Phim] OFF
SET IDENTITY_INSERT [dbo].[ThanhVien] ON 

INSERT [dbo].[ThanhVien] ([MaSo], [HoTen], [MS_TaiKhoan], [DiaChi], [NgaySinh], [TinhTrang], [GioiTinh], [Avatar], [NgayDangKy]) VALUES (0, N'Nguyễn Long Uy', N'0', N'Đồ Sơn, Phú Nhuận', CAST(0x09380B00 AS Date), 1, 1, NULL, NULL)
INSERT [dbo].[ThanhVien] ([MaSo], [HoTen], [MS_TaiKhoan], [DiaChi], [NgaySinh], [TinhTrang], [GioiTinh], [Avatar], [NgayDangKy]) VALUES (1, N'Hồ Thị Xanh', N'1', N'Quận 1, TP.HCM', CAST(0x811B0B00 AS Date), 1, 1, NULL, NULL)
INSERT [dbo].[ThanhVien] ([MaSo], [HoTen], [MS_TaiKhoan], [DiaChi], [NgaySinh], [TinhTrang], [GioiTinh], [Avatar], [NgayDangKy]) VALUES (2, N'Lê Quốc Vin', N'2', N'Quận 5, TP.HCM', CAST(0xFE160B00 AS Date), 1, 0, NULL, NULL)
INSERT [dbo].[ThanhVien] ([MaSo], [HoTen], [MS_TaiKhoan], [DiaChi], [NgaySinh], [TinhTrang], [GioiTinh], [Avatar], [NgayDangKy]) VALUES (3, N'Lê Quốc Vin', N'490d24b2-b547-4db9-8d70-41c7237c14a1', N'tp Hồ Chí Minh', CAST(0x47380B00 AS Date), 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ThanhVien] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BaiNhanXet]  WITH CHECK ADD  CONSTRAINT [FK_BaiNhanXet_Phim] FOREIGN KEY([MS_Phim])
REFERENCES [dbo].[Phim] ([MaSo])
GO
ALTER TABLE [dbo].[BaiNhanXet] CHECK CONSTRAINT [FK_BaiNhanXet_Phim]
GO
ALTER TABLE [dbo].[BaiNhanXet]  WITH CHECK ADD  CONSTRAINT [FK_BaiNhanXet_ThanhVien] FOREIGN KEY([MS_ThanhVien])
REFERENCES [dbo].[ThanhVien] ([MaSo])
GO
ALTER TABLE [dbo].[BaiNhanXet] CHECK CONSTRAINT [FK_BaiNhanXet_ThanhVien]
GO
ALTER TABLE [dbo].[BinhChon]  WITH CHECK ADD  CONSTRAINT [FK_BinhChon_BaiNhanXet] FOREIGN KEY([MS_BaiNhanXet])
REFERENCES [dbo].[BaiNhanXet] ([MaSo])
GO
ALTER TABLE [dbo].[BinhChon] CHECK CONSTRAINT [FK_BinhChon_BaiNhanXet]
GO
ALTER TABLE [dbo].[BinhChon]  WITH CHECK ADD  CONSTRAINT [FK_BinhChon_ThanhVien] FOREIGN KEY([MS_ThanhVien])
REFERENCES [dbo].[ThanhVien] ([MaSo])
GO
ALTER TABLE [dbo].[BinhChon] CHECK CONSTRAINT [FK_BinhChon_ThanhVien]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_BaiNhanXet] FOREIGN KEY([MS_BaiNhanXet])
REFERENCES [dbo].[BaiNhanXet] ([MaSo])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_BaiNhanXet]
GO
ALTER TABLE [dbo].[BinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_BinhLuan_ThanhVien] FOREIGN KEY([MS_ThanhVien])
REFERENCES [dbo].[ThanhVien] ([MaSo])
GO
ALTER TABLE [dbo].[BinhLuan] CHECK CONSTRAINT [FK_BinhLuan_ThanhVien]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_Phim] FOREIGN KEY([MS_Phim])
REFERENCES [dbo].[Phim] ([MaSo])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_Phim]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_ThanhVien] FOREIGN KEY([MS_ThanhVien])
REFERENCES [dbo].[ThanhVien] ([MaSo])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_ThanhVien]
GO
ALTER TABLE [dbo].[DanhSachPhimYeuThich]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachPhimYeuThich_Phim] FOREIGN KEY([MS_Phim])
REFERENCES [dbo].[Phim] ([MaSo])
GO
ALTER TABLE [dbo].[DanhSachPhimYeuThich] CHECK CONSTRAINT [FK_DanhSachPhimYeuThich_Phim]
GO
ALTER TABLE [dbo].[DanhSachPhimYeuThich]  WITH CHECK ADD  CONSTRAINT [FK_DanhSachPhimYeuThich_ThanhVien] FOREIGN KEY([MS_ThanhVien])
REFERENCES [dbo].[ThanhVien] ([MaSo])
GO
ALTER TABLE [dbo].[DanhSachPhimYeuThich] CHECK CONSTRAINT [FK_DanhSachPhimYeuThich_ThanhVien]
GO
ALTER TABLE [dbo].[Phim]  WITH CHECK ADD  CONSTRAINT [FK_Phim_NuocSX] FOREIGN KEY([MS_NuocSX])
REFERENCES [dbo].[DanhMucNuocSanXuat] ([MaSo])
GO
ALTER TABLE [dbo].[Phim] CHECK CONSTRAINT [FK_Phim_NuocSX]
GO
ALTER TABLE [dbo].[Phim]  WITH CHECK ADD  CONSTRAINT [FK_Phim_TheLoai] FOREIGN KEY([MS_TheLoai])
REFERENCES [dbo].[DanhMucTheLoai] ([MaSo])
GO
ALTER TABLE [dbo].[Phim] CHECK CONSTRAINT [FK_Phim_TheLoai]
GO
ALTER TABLE [dbo].[ThanhVien]  WITH NOCHECK ADD  CONSTRAINT [FK_ThanhVien_AspUsers] FOREIGN KEY([MS_TaiKhoan])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ThanhVien] CHECK CONSTRAINT [FK_ThanhVien_AspUsers]
GO
