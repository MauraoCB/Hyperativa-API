CREATE DATABASE HyperCartoes
GO

USE [HyperCartoes]
GO

/****** Object:  Table [dbo].[CartaoInfo]    Script Date: 28/02/2023 14:16:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CartaoInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeTitular] [varchar](250) NOT NULL,
	[NumeroCartao] [varchar](250) NOT NULL,
	[NumeroLote] [char](8) NULL,
	[DataInclusao] [date] NOT NULL,
 CONSTRAINT [PK_CartaoInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [HyperCartoes]
GO

/****** Object:  Table [dbo].[LogApi]    Script Date: 28/02/2023 14:17:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LogApi](
	[DataLog] [datetime] NOT NULL,
	[EntradaSaida] [char](1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Acao] [varbinary](30) NOT NULL,
	[Detalhes] [varchar](250) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


