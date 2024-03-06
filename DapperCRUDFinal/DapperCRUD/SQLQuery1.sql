-- Drop existing tables if they exist
IF OBJECT_ID('[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees]

IF OBJECT_ID('[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies]

-- Create Companies Table
CREATE TABLE [dbo].[Companies](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Address] [nvarchar](60) NOT NULL,
    [Country] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    ) WITH (
        -- Specify table options
        PAD_INDEX = OFF,                   -- Do not pad data pages
        STATISTICS_NORECOMPUTE = OFF,      -- Automatically recompute statistics when necessary
        IGNORE_DUP_KEY = OFF,              -- Do not ignore duplicate key violations
        ALLOW_ROW_LOCKS = ON,              -- Allow row-level locks
        ALLOW_PAGE_LOCKS = ON              -- Allow page-level locks
    ) ON [PRIMARY]
)

-- Create Employees Table
CREATE TABLE [dbo].[Employees](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Age] [int] NOT NULL,
    [Position] [nvarchar](50) NOT NULL,
    [CompanyId] [int] NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    ) WITH (
        -- Specify table options
        PAD_INDEX = OFF,                   -- Do not pad data pages
        STATISTICS_NORECOMPUTE = OFF,      -- Automatically recompute statistics when necessary
        IGNORE_DUP_KEY = OFF,              -- Do not ignore duplicate key violations
        ALLOW_ROW_LOCKS = ON,              -- Allow row-level locks
        ALLOW_PAGE_LOCKS = ON              -- Allow page-level locks
    ) ON [PRIMARY]
)

-- Insert sample data into Companies table
SET IDENTITY_INSERT [dbo].[Companies] ON 
INSERT [dbo].[Companies] ([Id], [Name], [Address], [Country]) VALUES 
(1, N'IT_Solutions Ltd', N'583 Wall Dr. Gwynn Oak, MD 21207', N'USA'),
(2, N'Admin_Solutions Ltd', N'312 Forest Avenue, BF 923', N'USA')
SET IDENTITY_INSERT [dbo].[Companies] OFF

-- Insert sample data into Employees table
SET IDENTITY_INSERT [dbo].[Employees] ON 
INSERT [dbo].[Employees] ([Id], [Name], [Age], [Position], [CompanyId]) VALUES 
(1, N'Sam Raiden', 26, N'Software developer', 1),
(2, N'Kane Miller', 35, N'Administrator', 2),
(3, N'Jana McLeaf', 30, N'Software developer', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF


   DROP TABLE [dbo].[Employees]
    DROP TABLE [dbo].[Companies]