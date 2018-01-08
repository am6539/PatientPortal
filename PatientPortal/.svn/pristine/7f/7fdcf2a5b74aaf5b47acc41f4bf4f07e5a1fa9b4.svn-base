/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM [dbo].[Group]
GO
INSERT INTO [dbo].[Group] VALUES(N'Content Management System (CMS)', 1)
GO
INSERT INTO [dbo].[Group] VALUES(N'Patient Services', 1)
GO
INSERT INTO [dbo].[Group] VALUES(N'Internal Services', 1)
GO
-- DELETE MODULE
GO
DELETE FROM [dbo].[Module]
GO
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (1, N'Main', N'', 1, 0, N'3', NULL)
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (2, N'Dashboard', N'Home', 1, 1, N'3', N'overview')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (3, N'Lịch làm việc', N'Schedule', 1, 1, N'3', N'schedule')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (4, N'Chuyên khoa', N'Department', 1, 1, N'3', N'department')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (5, N'Chức năng', N'Module', 1, 1, N'3', N'category')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (6, N'Communication', N'', 1, 0, N'3', NULL)
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (7, N'Hộp thư', N'', 1, 6, N'3', N'message-box')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (8, N'System', N'', 1, 0, N'3', NULL)
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (9, N'Tài khoản', N'Account', 1, 8, N'3', N'users')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (10, N'Cài đặt', N'Setting', 1, 8, N'3', N'configuration')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (11, N'Email Marketing', N'EmailMarketing', 1, 6, N'3', N'email-marketing')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (12, N'Quản lý đặt kịch hẹn', N'Appointment', 1, 1, N'3', N'prescription')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (13, N'Hỏi đáp y tế', N'Article', 1, 6, N'3', N'question')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (14, N'Góp ý xây dựng', N'OfferAdvise', 0, 6, N'3', N'offder-advise')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (15, N'Khảo sát', N'Survey', 1, 6, N'3', N'survey')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (16, N'Hỏi đáp y tế cộng đồng', N'QA', 1, 6, N'3', N'question')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (17, N'Chi tiết quyền', N'Permission', 1, 8, N'3', N'permission')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (18, N'Nhóm tài khoản', N'Role', 1, 8, N'3', N'role')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (19, N'Main', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (20, N'Dashboard', N'Home', 1, 19, N'1', N'dashboard')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (21, N'Post Management', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (22, N'Ngôn ngữ', N'Language', 1, 21, N'1', N'language')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (23, N'Chuyên mục', N'Category', 1, 21, N'1', N'category')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (24, N'Bản tin', N'Post', 1, 21, N'1', N'posts')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (25, N'Duyệt tin', N'ApprovePost', 1, 21, N'1', N'approved-posts')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (26, N'Xuất bản', N'PublishPost', 1, 21, N'1', N'publish-post')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (27, N'Services', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (28, N'Liên kết Website', N'LinkBuilding', 1, 27, N'1', N'link-building')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (29, N'Dịch vụ nổi bật', N'Feature', 1, 27, N'1', N'feature')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (30, N'Trình chiếu', N'Slider', 1, 27, N'1', N'slider')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (31, N'Quảng cáo', N'Advertise', 1, 27, N'1', N'advertise')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (32, N'Library', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (33, N'Thư viện', N'Gallery', 1, 32, N'1', N'gallery')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (34, N'Resources', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (35, N'Hình ảnh', N'ImageLibrary', 1, 34, N'1', N'image-lib')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (36, N'Video', N'VideoLibrary', 0, 34, N'1', N'video-lib')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (37, N'Workflow', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (38, N'Quy trình', N'Workflow', 1, 37, N'1', N'workflow')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (39, N'Bước xử lý quy trình', N'WorkflowState', 1, 37, N'1', N'workflow')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (40, N'System', N'#', 1, 0, N'1', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (41, N'Cài đặt', N'Configuration', 1, 40, N'1', N'configuration')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (42, N'Main', N'#', 1, 0, N'2', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (43, N'Dashboard', N'Home', 1, 42, N'2', N'overview')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (44, N'Bảo hiểm', N'#', 1, 42, N'2', N'insurance')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (45, N'Hồ sơ y tế', N'PHR', 1, 42, N'2', N'health-result')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (46, N'Thanh toán', N'#', 1, 42, N'2', N'payment')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (47, N'Communication', N'#', 1, 0, N'2', N'')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (48, N'Hỏi đáp y tế', N'Article', 1, 47, N'2', N'question')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (49, N'Góp ý xây dựng', N'OfferAdvise', 1, 47, N'2', N'offder-advise')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (50, N'Hộp thư', N'#', 1, 47, N'2', N'message-box')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (51, N'Truy cập bản tin', N'AccessPost', 1, 21, N'1', N'posts')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (52, N'Redis Manager', N'Redis', 1, 19, N'1', N'databases')
INSERT [dbo].[Module] ([Id], [Title], [Handler], [Sort], [ParentId], [Group], [ClassName]) VALUES (53, N'Thông báo nội bộ', N'Notification', 1, 6, N'3', N'notification')