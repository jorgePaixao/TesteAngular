USE [Confitec]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 04/11/2019 19:24:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Sobrenome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[Escolaridade] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


