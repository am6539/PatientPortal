CREATE TABLE [dbo].[MedicationDrug]
(
	[Id] INT NOT NULL PRIMARY KEY, --Mã đơn thuốc
    [MedicalExaminationId] INT NOT NULL, --Mã khám bệnh
    [Name] NVARCHAR(150) NOT NULL, --Tên thuốc
    [MolarMass] NVARCHAR(150) NOT NULL, -- Hàm lượng, Tỷ lệ
	[TradeName] NVARCHAR(150) NOT NULL,  -- Nhà cung cấp
    [Usage] NVARCHAR(300) NOT NULL,  -- Cách dùng
    [Unit] NVARCHAR(10) NOT NULL,  -- Đơn vị tính
    [Morning] VARCHAR(5) NOT NULL, --Số lượng sáng
    [Midday] VARCHAR(5) NOT NULL,  --Số lượng trưa
    [Afternoon] VARCHAR(5) NOT NULL, --Số lượng chiều
    [Evening] VARCHAR(5) NOT NULL, --Số lượng tối
    [Days] VARCHAR(3) NOT NULL, -- Số ngày
    [Quantity] VARCHAR(8) NOT NULL,  --Số lượng
    [Note] NVARCHAR(300) NOT NULL, --Ghi chú

)
