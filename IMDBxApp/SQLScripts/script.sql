USE [IMDBx]
GO
/****** Object:  Table [dbo].[actor_master]    Script Date: 13-11-2018 01:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[actor_master](
	[actor_id] [bigint] IDENTITY(101,1) NOT NULL,
	[actor_name] [nvarchar](max) NOT NULL,
	[sex] [varchar](10) NULL,
	[DOB] [date] NULL,
	[Bio] [text] NULL,
 CONSTRAINT [PK_actor_master] PRIMARY KEY CLUSTERED 
(
	[actor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[movie_actor_db]    Script Date: 13-11-2018 01:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie_actor_db](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[movie_id] [bigint] NULL,
	[actor_id] [bigint] NULL,
 CONSTRAINT [PK_movie_actor_db] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movie_master]    Script Date: 13-11-2018 01:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie_master](
	[movie_id] [bigint] IDENTITY(1001,1) NOT NULL,
	[movie_name] [nvarchar](max) NOT NULL,
	[release_year] [date] NULL,
	[plot] [text] NULL,
	[thumbnail] [text] NULL,
	[prod_id] [bigint] NULL,
 CONSTRAINT [PK_movie_master] PRIMARY KEY CLUSTERED 
(
	[movie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producer_master]    Script Date: 13-11-2018 01:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producer_master](
	[prod_id] [bigint] IDENTITY(1,1) NOT NULL,
	[prod_name] [nvarchar](max) NOT NULL,
	[sex] [nvarchar](10) NULL,
	[dob] [date] NULL,
	[bio] [text] NULL,
 CONSTRAINT [PK_producer_master] PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
