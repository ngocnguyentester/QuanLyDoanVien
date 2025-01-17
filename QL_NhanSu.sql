CREATE DATABASE [QL_NhanSu]
GO
USE [QL_NhanSu]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE TaiKhoan
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	TenDN NVARCHAR(100) UNIQUE NOT NULL,
	MatKhau NVARCHAR(100) NOT NULL,
	Loai NVARCHAR(20) NOT NULL -- Quản lý | Nhân viên
)
go
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [char](6) NOT NULL,
	[TenChucVu] [nvarchar](70) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenMon]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenMon](
	[MaChuyenMon] [char](6) NOT NULL,
	[MaNV] [char](6) NOT NULL,
	[TenChuyenNganh] [nvarchar](50) NOT NULL,
	[TrinhDoChuyenMon] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChuyenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanToc]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanToc](
	[MaDanToc] [char](4) NOT NULL,
	[TenDanToc] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanToc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[NgayBD] [date] NOT NULL,
	[MaNV] [char](6) NOT NULL,
	[LuongCB] [varchar](max) NULL,
	[XepLoai] [char](100) NOT NULL,

PRIMARY KEY CLUSTERED 
(
	[NgayBD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](6) NOT NULL,
	[TenNV] [nvarchar](70) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[MaDanToc] [char](4) NOT NULL,
	[DienThoai] [char](10) NULL,
	[CCCD] [char](12) NOT NULL,
	[DiaChi] [nvarchar](150) NOT NULL,
	[QueQuan] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[HonNhan] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[MaPhong] [char](6) NULL,
	[MaChucVu] [char](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 11/12/2022 3:02:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhong] [char](6) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV0001', N'Phó bí thư')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV0002', N'Liên chi hội trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV0003', N'Đoàn viên')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV0004', N'Chi hội trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (N'CV0005', N'Bí thư chi đoàn')
GO
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong]) VALUES (N'CD0001', N'DH21TH2')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong]) VALUES (N'CD0002', N'GT21TH2')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong]) VALUES (N'CD0003', N'VN20TH2')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong]) VALUES (N'CD0004', N'DH21TH1')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong]) VALUES (N'CD0005', N'DH21PM2')
GO
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT01', N'Kinh')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT02', N'Thái')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT03', N'Mường')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT04', N'Tày')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT05', N'Nùng')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT06', N'Dao')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT07', N'Hoa')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT08', N'Khmer')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT09', N'Chăm')
INSERT [dbo].[DanToc] ([MaDanToc], [TenDanToc]) VALUES (N'DT10', N'Gia Rai')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0001', N'Nguyễn Thị A', CAST(N'1952-12-10' AS Date), N'Nữ', N'DT01', N'1111111111', N'111111111111', N'A1', N'B1', N'nta@gmail.com', N'Độc thân', N'Đang học tại trường', N'CD0001', N'CV0001')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0002', N'Lê Văn B', CAST(N'1986-12-15' AS Date), N'Nam', N'DT01', N'2222222222', N'222222222222', N'A2', N'B2', N'lvb@gmail.com', N'Độc thân', N'Đã ra trường', N'CD0002', N'CV0002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0003', N'Trần Thị C', CAST(N'1995-09-08' AS Date), N'Nữ', N'DT01', N'3333333333', N'333333333333', N'A3', N'B3', N'ttc@gmail.com', N'Độc thân', N'Đang học tại trường', N'CD0003', N'CV0003')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0004', N'Phạm Văn D', CAST(N'1995-03-20' AS Date), N'Nam', N'DT01', N'4444444444', N'444444444444', N'A4', N'B4', N'pvd@gmail.com', N'Độc thân', N'Đang học tại trường', N'CD0003', N'CV0004')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0005', N'Trần Văn E', CAST(N'1995-03-20' AS Date), N'Nam', N'DT01', N'5555555555', N'555555555555', N'A5', N'B5', N'tve@gmail.com', N'Độc thân', N'Đã ra trường', N'CD0004', N'CV0004')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [MaDanToc], [DienThoai], [CCCD], [DiaChi], [QueQuan], [Email], [HonNhan], [TrangThai], [MaPhong], [MaChucVu]) VALUES (N'DV0006', N'Lê Thị F', CAST(N'1993-12-11' AS Date), N'Nữ', N'DT01', N'6666666666', N'666666666666', N'A6', N'B6', N'ltf@gmail.com', N'Đã kết hôn', N'Đang học tại trường', N'CD0005', N'CV0004')
GO
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'TH0001', N'DV0005', N'Khoa công nghệ thông tin', N'Công nghệ thông tin')
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'SP0001', N'DV0003', N'Khoa ngoại ngữ', N'Sư phạm tiếng anh')
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'CN0002', N'DV0001', N'Khoa công nghệ - kỹ thuật - môi trường', N'Công nghệ thực phẩm')
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'KT0001', N'DV0001', N'Khoa kinh tế', N'Quản trị kinh doanh')
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'NN0002', N'DV0002', N'Khoa nông nghiệp ', N'Chăn nuôi')
INSERT [dbo].[ChuyenMon] ([MaChuyenMon], [MaNV], [TenChuyenNganh], [TrinhDoChuyenMon]) VALUES (N'KT0003', N'DV0004', N'Khoa kinh tế', N'Kế toán')
GO
INSERT [dbo].[Luong] ([NgayBD], [MaNV], [LuongCB], [XepLoai]) VALUES (CAST(N'2010-09-08' AS Date), N'DV0001', N'89',  N'Xuất sắc')
INSERT [dbo].[Luong] ([NgayBD], [MaNV], [LuongCB], [XepLoai]) VALUES (CAST(N'2019-09-04' AS Date), N'DV0002', N'75', N'Khá')
INSERT [dbo].[Luong] ([NgayBD], [MaNV], [LuongCB], [XepLoai]) VALUES (CAST(N'2021-09-04' AS Date), N'DV0003', N'44',N'Trung bình')
INSERT [dbo].[Luong] ([NgayBD], [MaNV], [LuongCB], [XepLoai]) VALUES (CAST(N'2022-06-28' AS Date), N'DV0004', N'80', N'Giỏi')
INSERT [dbo].[Luong] ([NgayBD], [MaNV], [LuongCB], [XepLoai]) VALUES (CAST(N'2022-12-10' AS Date), N'DV0005', N'20', N'Yếu')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__1F03187631C10B1E]    Script Date: 11/12/2022 3:02:28 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[DienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__2725D70BECC7A4D9]    Script Date: 11/12/2022 3:02:28 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A955A0AA9F7B2DEF]    Script Date: 11/12/2022 3:02:28 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D1053420B69DED]    Script Date: 11/12/2022 3:02:28 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChuyenMon]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenMon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChuyenMon] CHECK CONSTRAINT [FK_ChuyenMon_NhanVien]
GO
ALTER TABLE [dbo].[Luong]  WITH CHECK ADD  CONSTRAINT [FK_Luong_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Luong] CHECK CONSTRAINT [FK_Luong_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_DanToc] FOREIGN KEY([MaDanToc])
REFERENCES [dbo].[DanToc] ([MaDanToc])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_DanToc]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongBan] ([MaPhong])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[DanToc]  WITH CHECK ADD CHECK  (([MaDanToc] like 'DT[0-9][0-9]'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([CCCD] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([Email] like '%@%' AND NOT [Email] like '% %'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([GioiTinh] like 'Nam' OR [GioiTinh] like N'Nữ'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([HonNhan] like N'Độc thân' OR [HonNhan] like N'Đã kết hôn'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([MaDanToc] like 'DT[0-9][0-9]'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([MaNV] like 'DV[0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD CHECK  (([TrangThai] like N'Đang học tại trường' OR [TrangThai] like N'đã ra trường'))
GO

INSERT INTO TaiKhoan(TenDN,MatKhau,Loai) VALUES('admin', '111', N'Quản lý');
SELECT * FROM dbo.TaiKhoan;
use QL_NhanSu
insert TaiKhoan values('user', '698D51A19D8A121CE581499D7B701668', 'user')
update TaiKhoan set MatKhau = '698D51A19D8A121CE581499D7B701668'

use QL_NhanSu
delete TaiKhoan
insert TaiKhoan values('admin', '698D51A19D8A121CE581499D7B701668', 'admin')
insert TaiKhoan values('user', '698D51A19D8A121CE581499D7B701668', 'user')
