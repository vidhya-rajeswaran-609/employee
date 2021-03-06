CREATE DATABASE CompanyEmployee;
GO
/****** Object:  Table [CompanyEmployee].[dbo].[Employee]    Script Date: 28/08/2017 13:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CompanyEmployee].[dbo].[Employee](
	[EmployeeID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateJoined] [smalldatetime] NOT NULL,
	[Extension] [smallint] NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [CompanyEmployee].[dbo].[Role]    Script Date: 28/08/2017 13:32:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CompanyEmployee].[dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [CompanyEmployee].[dbo].[Employee] ON 

GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (1, 1597, N'Russell', N'Crowe', CAST(N'2014-01-01 00:00:00' AS SmallDateTime), 9597, 1)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (2, 1598, N'Nicole', N'Kidman', CAST(N'2014-01-07 00:00:00' AS SmallDateTime), 9598, 2)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (3, 1599, N'Christian', N'Bale', CAST(N'2014-02-28 00:00:00' AS SmallDateTime), 9599, 3)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (4, 1600, N'Daniel', N'Craig', CAST(N'2014-07-31 00:00:00' AS SmallDateTime), NULL, 4)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (5, 1601, N'Gary', N'Oldman', CAST(N'2014-09-11 00:00:00' AS SmallDateTime), 9601, 5)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (6, 1602, N'Brad', N'Pitt', CAST(N'2014-09-13 00:00:00' AS SmallDateTime), 9602, 6)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (7, 1603, N'Charlize', N'Théron', CAST(N'2015-02-15 00:00:00' AS SmallDateTime), 9603, 7)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (8, 1604, N'Jamie', N'Fox', CAST(N'2015-04-01 00:00:00' AS SmallDateTime), 9604, 8)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (9, 1605, N'Kate', N'Beckinsale', CAST(N'2015-12-31 00:00:00' AS SmallDateTime), 9605, 9)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (10, 1606, N'Dev', N'Patel', CAST(N'2016-02-29 00:00:00' AS SmallDateTime), 9606, 10)
GO
INSERT [CompanyEmployee].[dbo].[Employee] ([EmployeeID], [EmployeeNumber], [FirstName], [LastName], [DateJoined], [Extension], [RoleID]) VALUES (11, 1607, N'Jackie', N'Chan', CAST(N'2017-03-24 00:00:00' AS SmallDateTime), 9607, NULL)
GO
SET IDENTITY_INSERT [CompanyEmployee].[dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [CompanyEmployee].[dbo].[Role] ON 

GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Junior Developer')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Senior Developer')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Project Manager')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (4, N'Senior Architect')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (5, N'Product Manager')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (6, N'Intern')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (7, N'Managing Director')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (8, N'UX Designer')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (9, N'Receptionist')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (10, N'QA Team Lead')
GO
INSERT [CompanyEmployee].[dbo].[Role] ([RoleID], [RoleName]) VALUES (11, N'Scrummaster')
GO
SET IDENTITY_INSERT [CompanyEmployee].[dbo].[Role] OFF
GO
ALTER TABLE [CompanyEmployee].[dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleID])
REFERENCES [CompanyEmployee].[dbo].[Role] ([RoleID])
GO
ALTER TABLE [CompanyEmployee].[dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
