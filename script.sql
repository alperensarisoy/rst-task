USE [TaskProject]
GO
/****** Object:  Table [dbo].[t_Tasks]    Script Date: 8.12.2024 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Tasks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_User]    Script Date: 8.12.2024 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Username] [nchar](50) NOT NULL,
	[Password] [nchar](256) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_t_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[t_Tasks] ON 

INSERT [dbo].[t_Tasks] ([Id], [Title], [Description], [CreatedAt]) VALUES (1, N'string', N'et,su,sigara', CAST(N'2024-12-08T12:48:09.300' AS DateTime))
INSERT [dbo].[t_Tasks] ([Id], [Title], [Description], [CreatedAt]) VALUES (2, N'ahh', N'qweqwe , qwe, qweal', CAST(N'2024-12-08T12:48:23.463' AS DateTime))
SET IDENTITY_INSERT [dbo].[t_Tasks] OFF
GO
SET IDENTITY_INSERT [dbo].[t_User] ON 

INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (1, N'John Doe                                          ', N'johndoe                                           ', N'Password123!                                                                                                                                                                                                                                                    ', CAST(N'2024-12-08T01:29:59.967' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (2, N'Jane Smith                                        ', N'janesmith                                         ', N'SecurePass456!                                                                                                                                                                                                                                                  ', CAST(N'2024-12-08T01:29:59.967' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (3, N'Alice Johnson                                     ', N'alicej                                            ', N'Passw0rd!                                                                                                                                                                                                                                                       ', CAST(N'2024-12-08T01:29:59.967' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (4, N'Erdem                                             ', N'string                                            ', N'473287f8298dba7163a897908958f7c0eae733e25d2e027992ea2edc9bed2fa8                                                                                                                                                                                                ', CAST(N'2024-12-08T01:29:59.967' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (6, N'Alperen                                           ', N'SkyLegend                                         ', N'd07164a628596323ebcf8796dee0e5c164620e0922b52483bc805f54416ee73c                                                                                                                                                                                                ', CAST(N'2024-12-08T12:18:53.537' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (7, N'alp                                               ', N'sky                                               ', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3                                                                                                                                                                                                ', CAST(N'2024-12-08T13:29:39.850' AS DateTime))
INSERT [dbo].[t_User] ([Id], [Name], [Username], [Password], [CreatedAt]) VALUES (8, N'ali                                               ', N'alis                                              ', N'd7e69851a0c497628fb49b69624530f85aa25ad39ec1a780b81b3477f25eb195                                                                                                                                                                                                ', CAST(N'2024-12-08T13:46:09.147' AS DateTime))
SET IDENTITY_INSERT [dbo].[t_User] OFF
GO
