-- Bảng dữ liệu được đồng bộ từ eHos, chứa các thông tin chi tiết của bệnh nhân
CREATE TABLE [dbo].[Patient](
	[PatientKey] [int] NOT NULL, --eHos Id
	[PatientId] [varchar](20) NOT NULL, --Mã bệnh nhân
	[Name] [nvarchar](40) NOT NULL,
	[Gender] [char](1) NULL,
	[Birthday] [smalldatetime] NULL,
	[Address] [nvarchar](150) NULL,
	[BloodGroup_Id] [int] NULL, --  Nhóm máu
	[PersonalId] [varchar](9) NULL,
	[Passport] [varchar](15) NULL,
	[MedicalHistory] [nvarchar](500) NULL, -- Tiền sử bệnh án
	[SmokingHistory] [nvarchar](500) NULL,-- Tiền sử thuốc lá
	[PhoneNumber] [varchar](30) NULL,
	[Email] [nvarchar](50) NULL,
	[History] [nvarchar](500) NULL, -- Tiền căn
	[Chronic] [nvarchar](500) NULL, -- Mãn tính
	[InheritedDiseases] [nvarchar](500) NULL, --Bệnh di truyền
	[Appointed] [nvarchar](500) NULL, -- Chỉ định đặc biệt
	[SmokingStatus] [nvarchar](500) NULL, -- Thuốc lá
	[Activities] [nvarchar](500) NULL, -- Hoạt động
	[Alcohol] [nvarchar](500) NULL, -- Chất cồn (Ruou)
	[Cocaine] [nvarchar](500) NULL, -- Chất gây nghiện (Coffee)
	[Tea] [nvarchar](500) NULL, -- Trà
 )