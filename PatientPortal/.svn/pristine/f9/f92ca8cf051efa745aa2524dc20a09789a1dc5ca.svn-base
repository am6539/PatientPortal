-- Table sync from  eHos
CREATE TABLE [dbo].[PatientProfile]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY,
	[PatientKey] [int] NOT NULL, --eHos Id
	[BloodGroup_Id] [int] NULL, --  Nhóm máu
	[PersonalId] [varchar](25) NULL,
	[MedicalHistory] [nvarchar](500) NULL, -- Tiền sử bệnh án
	[SmokingHistory] [nvarchar](500) NULL,-- Tiền sử thuốc lá
	[History] [nvarchar](500) NULL, -- Tiền căn
	[Chronic] [nvarchar](500) NULL, -- Mãn tính
	[InheritedDiseases] [nvarchar](500) NULL, --Bệnh di truyền
	[Appointed] [nvarchar](500) NULL, -- Chỉ định đặc biệt
	[Tobacco] [nvarchar](500) NULL, -- Thuốc lá
	[Activities] [nvarchar](500) NULL, -- Hoạt động
	[Alcohol] [nvarchar](500) NULL, -- Chất cồn (Ruou)
	[Cocaine] [nvarchar](500) NULL, -- Chất gây nghiện (Coffee)
	[Tea] [nvarchar](500) NULL -- Trà
)
