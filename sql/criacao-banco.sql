USE [master]
GO
/****** Object:  Database [TrincaChurrasco]    Script Date: 14/07/2021 13:07:23 ******/
CREATE DATABASE [TrincaChurrasco]
GO

USE [TrincaChurrasco]
GO

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/07/2021 13:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Churrasco]    Script Date: 14/07/2021 13:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Churrasco](
	[Id] [uniqueidentifier] NOT NULL,
	[DataHora] [datetime2](7) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Observacao] [varchar](300) NULL,
	[ValorComBebida] [decimal](5, 2) NOT NULL,
	[ValorSemBebida] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Churrasco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participante]    Script Date: 14/07/2021 13:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participante](
	[Id] [uniqueidentifier] NOT NULL,
	[ChurrascoId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Valor] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Participante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Participante_ChurrascoId]    Script Date: 14/07/2021 13:07:24 ******/
CREATE NONCLUSTERED INDEX [IX_Participante_ChurrascoId] ON [dbo].[Participante]
(
	[ChurrascoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participante]  WITH CHECK ADD  CONSTRAINT [FK_Participante_Churrasco_ChurrascoId] FOREIGN KEY([ChurrascoId])
REFERENCES [dbo].[Churrasco] ([Id])
GO
ALTER TABLE [dbo].[Participante] CHECK CONSTRAINT [FK_Participante_Churrasco_ChurrascoId]
GO
USE [master]
GO
ALTER DATABASE [TrincaChurrasco] SET  READ_WRITE 
GO
