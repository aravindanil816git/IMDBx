USE [IMDBx_2]
GO
/****** Object:  Table [dbo].[actor_master]    Script Date: 09-05-2019 01:30:55 ******/
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
/****** Object:  Table [dbo].[movie_actor_db]    Script Date: 09-05-2019 01:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[casting_details](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[movie_id] [bigint] NULL,
	[actor_id] [bigint] NULL,
 CONSTRAINT [PK_casting_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[movie_master]    Script Date: 09-05-2019 01:30:58 ******/
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
/****** Object:  Table [dbo].[producer_master]    Script Date: 09-05-2019 01:30:58 ******/
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

insert into [dbo].[actor_master] values
(  'Leonardo','Male','1970-12-12','First movie titanic'),
(	'Kate Winslet',	'Female','1969-11-10',	'First Movie Titanic'),
(	'vf',	'Female','2018-11-11',	'kig'),
(	'Will Smith',	'Male',	'1970-06-08',	'Cool Guy'),
(	'Jim Carrey',	'Male',	'2018-11-12',	'Comedian'),
(	'Jack Reacher',	'Male',	'1970-01-02',	'Theatre Artist'),
(	'Harison Ford',	'Male',	'1965-01-02',	'Theatre Artist'),
(	'Judy Frost',	'Female',	'1997-02-12',	'Child Artist'),
(	'Julia Roberts',	'Female','1980-02-12',	'Child Artist'),
(	'Ryan Gosling',	'Male',	'1976-11-09',	'Ryan Thomas Gosling is a Canadian actor and musician. He began his career as a child star on the Disney Channel''s The Mickey Mouse Club and went on to appear in other family entertainment programs including Are You Afraid of the Dark? and Goosebumps. His first starring film role was as a Jewish neo-Nazi in The Believer, and he went on to star in several independent films, including Murder by Numbers, The Slaughter Rule, and The United States of Leland.'), 
(	'Samuel JAckson',	'Male',	'1963-11-13',	'Captain'),
(	'Jason Sthathom',	'Male',	'1976-08-13',	'Transpoter guy'),
(	'Ann Hathaway''s',	'Female',	'1990-01-18',	'Versitale Spanish')


insert into [dbo].[producer_master] values
('James Cameroon'	,'Male',	'1954-10-24',	'Terminator Director'),
('Sandra Bullock','Female'	,'1970-07-10',	'Classic ScreenWriter')

insert into [dbo].[movie_master] values
('Titanic',	'1998-12-12',	'Based on real life boat accident that happened on 1930s',	'https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_SX300.jpg',1),
('Revolutionary Road',	'2008-01-11',	'A  struggling couple from country side',	'https://m.media-amazon.com/images/M/MV5BMTczNDgzMjczOV5BMl5BanBnXkFtZTcwOTU3MzMwMg@@._V1_SX300.jpg',1),
('Blade Runner 2049',	'2017-09-12',	'A young blade runner''s discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who''s been missing for thirty years.','https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_SX300.jpg',2)