USE [TopDown]
GO

/****** Object:  Table [dbo].[Arquivo]    Script Date: 07/04/2019 05:42:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Arquivo](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[NomeArquivo] [varchar](50) NOT NULL,
	[Caminho] [varchar](50) NOT NULL,
	[ArquivoBytes] [varbinary](max) NOT NULL,
	[DataUpload] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


