USE [duo]
GO
/****** Object:  Trigger [InsWorks]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[InsWorks]
GO
/****** Object:  Trigger [DelWorks]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[DelWorks]
GO
/****** Object:  Trigger [InsProducts]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[InsProducts]
GO
/****** Object:  Trigger [DelProducts]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[DelProducts]
GO
/****** Object:  Trigger [InsPerfilDUO]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[InsPerfilDUO]
GO
/****** Object:  Trigger [DelAnuncio]    Script Date: 05/03/2021 16:17:29 ******/
DROP TRIGGER IF EXISTS [dbo].[DelAnuncio]
GO
/****** Object:  Table [dbo].[worksTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[worksTNQ]
GO
/****** Object:  Table [dbo].[works_03022021]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[works_03022021]
GO
/****** Object:  Table [dbo].[works]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[works]
GO
/****** Object:  Table [dbo].[SessionDUOTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[SessionDUOTNQ]
GO
/****** Object:  Table [dbo].[SessionDUO]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[SessionDUO]
GO
/****** Object:  Table [dbo].[RegistradoTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[RegistradoTNQ]
GO
/****** Object:  Table [dbo].[Registrado]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[Registrado]
GO
/****** Object:  Table [dbo].[ProductsTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[ProductsTNQ]
GO
/****** Object:  Table [dbo].[products_03022021]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[products_03022021]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[Products]
GO
/****** Object:  Table [dbo].[PerfilDuoTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[PerfilDuoTNQ]
GO
/****** Object:  Table [dbo].[PerfilDUO_03022021]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[PerfilDUO_03022021]
GO
/****** Object:  Table [dbo].[PerfilDuo]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[PerfilDuo]
GO
/****** Object:  Table [dbo].[AnuncioTNQ]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[AnuncioTNQ]
GO
/****** Object:  Table [dbo].[AnuncioImages_03022021]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[AnuncioImages_03022021]
GO
/****** Object:  Table [dbo].[AnuncioImages]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[AnuncioImages]
GO
/****** Object:  Table [dbo].[Anuncio_03022021]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[Anuncio_03022021]
GO
/****** Object:  Table [dbo].[Anuncio]    Script Date: 05/03/2021 16:17:29 ******/
DROP TABLE IF EXISTS [dbo].[Anuncio]
GO
/****** Object:  Table [dbo].[Anuncio]    Script Date: 05/03/2021 16:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anuncio](
	[RegAnuncioId] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegAnuncioPalabraClave] [varchar](10) NULL,
	[RegAnuncioAcercaDe] [varchar](max) NULL,
	[RegAnuncioEstado] [varchar](20) NULL,
	[RegAnuncioFecha] [datetime] NULL,
	[AnioAnuncioReg] [int] NULL,
	[MesAnuncioReg] [int] NULL,
	[DiaAnuncioReg] [int] NULL,
	[AnioAnuncioHastaId] [int] NULL,
	[MesAnuncioHastaId] [int] NULL,
	[DiaAnuncioHastaId] [int] NULL,
	[RegRutaImagen1] [varchar](max) NULL,
	[RegRutaImagen2] [varchar](max) NULL,
	[RegRutaImagen3] [varchar](max) NULL,
	[Titulo] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegAnuncioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anuncio_03022021]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anuncio_03022021](
	[RegAnuncioId] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegAnuncioPalabraClave] [varchar](10) NULL,
	[RegAnuncioAcercaDe] [varchar](max) NULL,
	[RegAnuncioEstado] [varchar](20) NULL,
	[RegAnuncioFecha] [datetime] NULL,
	[AnioAnuncioReg] [int] NULL,
	[MesAnuncioReg] [int] NULL,
	[DiaAnuncioReg] [int] NULL,
	[AnioAnuncioHastaId] [int] NULL,
	[MesAnuncioHastaId] [int] NULL,
	[DiaAnuncioHastaId] [int] NULL,
	[RegRutaImagen1] [varchar](max) NULL,
	[RegRutaImagen2] [varchar](max) NULL,
	[RegRutaImagen3] [varchar](max) NULL,
	[Titulo] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnuncioImages]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnuncioImages](
	[RegAnuncioImagenId] [int] IDENTITY(1,1) NOT NULL,
	[RegAnuncioId] [int] NULL,
	[RegId] [int] NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegAnuncioEstado] [varchar](20) NULL,
	[RegAnuncioFecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegAnuncioImagenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnuncioImages_03022021]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnuncioImages_03022021](
	[RegAnuncioImagenId] [int] IDENTITY(1,1) NOT NULL,
	[RegAnuncioId] [int] NULL,
	[RegId] [int] NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegAnuncioEstado] [varchar](20) NULL,
	[RegAnuncioFecha] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnuncioTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnuncioTNQ](
	[RegAnuncioIdTnq] [int] IDENTITY(1,1) NOT NULL,
	[RegAnuncioId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegAnuncioPalabraClave] [varchar](max) NULL,
	[RegAnuncioAcercaDe] [varchar](max) NULL,
	[RegAnuncioEstado] [varchar](30) NULL,
	[RegAnuncioFecha] [datetime] NULL,
	[AnioAnuncioReg] [int] NULL,
	[MesAnuncioReg] [int] NULL,
	[DiaAnuncioReg] [int] NULL,
	[AnioAnuncioHastaId] [int] NULL,
	[MesAnuncioHastaId] [int] NULL,
	[DiaAnuncioHastaId] [int] NULL,
	[RegRutaImagen1] [varchar](max) NULL,
	[RegRutaImagen2] [varchar](max) NULL,
	[RegRutaImagen3] [varchar](max) NULL,
	[Titulo] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegAnuncioIdTnq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilDuo]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilDuo](
	[RegPerfilId] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegNombres] [varchar](max) NULL,
	[RegApellidos] [varchar](max) NULL,
	[RegNombresCompletos] [varchar](max) NULL,
	[RegProfesion] [varchar](max) NULL,
	[RegAcercaDe] [varchar](max) NULL,
	[RegEmail] [varchar](max) NULL,
	[RegNumeroCelular] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[Tecnologia] [bit] NULL,
	[Legales] [bit] NULL,
	[Comunicacion] [bit] NULL,
	[Comercio] [bit] NULL,
	[ArteDiseno] [bit] NULL,
	[ServiciosTecnicos] [bit] NULL,
	[Urbanismo] [bit] NULL,
	[Emprendimientos] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegPerfilId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilDUO_03022021]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilDUO_03022021](
	[RegPerfilId] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegNombres] [varchar](max) NULL,
	[RegApellidos] [varchar](max) NULL,
	[RegNombresCompletos] [varchar](max) NULL,
	[RegProfesion] [varchar](max) NULL,
	[RegAcercaDe] [varchar](max) NULL,
	[RegEmail] [varchar](max) NULL,
	[RegNumeroCelular] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[Tecnologia] [bit] NULL,
	[Legales] [bit] NULL,
	[Comunicacion] [bit] NULL,
	[Comercio] [bit] NULL,
	[ArteDiseno] [bit] NULL,
	[ServiciosTecnicos] [bit] NULL,
	[Urbanismo] [bit] NULL,
	[Emprendimientos] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilDuoTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilDuoTNQ](
	[RegPerfilIdTNQ] [int] IDENTITY(1,1) NOT NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegNombres] [varchar](max) NULL,
	[RegApellidos] [varchar](max) NULL,
	[RegNombresCompletos] [varchar](max) NULL,
	[RegProfesion] [varchar](max) NULL,
	[RegAcercaDe] [varchar](max) NULL,
	[RegEmail] [varchar](max) NULL,
	[RegNumeroCelular] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[Tecnologia] [bit] NULL,
	[Legales] [bit] NULL,
	[Comunicacion] [bit] NULL,
	[Comercio] [bit] NULL,
	[ArteDiseno] [bit] NULL,
	[ServiciosTecnicos] [bit] NULL,
	[Urbanismo] [bit] NULL,
	[Emprendimientos] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegPerfilIdTNQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[RegProductId] [int] IDENTITY(1,1) NOT NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegTituloProducto] [varchar](max) NULL,
	[RegDescripcionProducto] [varchar](max) NULL,
	[RegPreciProducto] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[IsNew] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products_03022021]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products_03022021](
	[RegProductId] [int] IDENTITY(1,1) NOT NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegTituloProducto] [varchar](max) NULL,
	[RegDescripcionProducto] [varchar](max) NULL,
	[RegPreciProducto] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsTNQ](
	[RegProductIdTNQ] [int] IDENTITY(1,1) NOT NULL,
	[RegProductId] [int] NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegTituloProducto] [varchar](max) NULL,
	[RegDescripcionProducto] [varchar](max) NULL,
	[RegPreciProducto] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegProductIdTNQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrado]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrado](
	[RegId] [int] IDENTITY(1,1) NOT NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegNombres] [varchar](max) NULL,
	[RegApellidos] [varchar](max) NULL,
	[RegNombreCompleto] [varchar](max) NULL,
	[RegContrasenia] [varchar](max) NULL,
	[RegEmail] [varchar](max) NULL,
	[RegNumeroCelular] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[Tecnologia] [bit] NULL,
	[Legales] [bit] NULL,
	[Comunicacion] [bit] NULL,
	[Comercio] [bit] NULL,
	[ArteDiseno] [bit] NULL,
	[ServiciosTecnicos] [bit] NULL,
	[Urbanismo] [bit] NULL,
	[Emprendimientos] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistradoTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistradoTNQ](
	[RegIdTNQ] [int] IDENTITY(1,1) NOT NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegNombres] [varchar](max) NULL,
	[RegApellidos] [varchar](max) NULL,
	[RegNombreCompleto] [varchar](max) NULL,
	[RegContrasenia] [varchar](max) NULL,
	[RegEmail] [varchar](max) NULL,
	[RegNumeroCelular] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[Tecnologia] [bit] NULL,
	[Legales] [bit] NULL,
	[Comunicacion] [bit] NULL,
	[Comercio] [bit] NULL,
	[ArteDiseno] [bit] NULL,
	[ServiciosTecnicos] [bit] NULL,
	[Urbanismo] [bit] NULL,
	[Emprendimientos] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegIdTNQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionDUO]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionDUO](
	[IdSessionDUO] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioDUO] [varchar](max) NULL,
	[FechaLog] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSessionDUO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionDUOTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionDUOTNQ](
	[IdSessionDUOTNQ] [int] IDENTITY(1,1) NOT NULL,
	[IdSessionDUO] [int] NULL,
	[UsuarioDUO] [varchar](max) NULL,
	[FechaLog] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSessionDUOTNQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[works]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[works](
	[RegWorksId] [int] IDENTITY(1,1) NOT NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegDescripcion] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[IsNew] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegWorksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[works_03022021]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[works_03022021](
	[RegWorksId] [int] IDENTITY(1,1) NOT NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegDescripcion] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[worksTNQ]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[worksTNQ](
	[RegWorksIdTNQ] [int] IDENTITY(1,1) NOT NULL,
	[RegWorksId] [int] NULL,
	[RegPerfilId] [int] NULL,
	[RegId] [int] NULL,
	[RegCodigoUnico] [varchar](max) NULL,
	[RegRutaImagen] [varchar](max) NULL,
	[RegStreamImagen] [image] NULL,
	[RegDescripcion] [varchar](max) NULL,
	[RegFecha] [datetime] NULL,
	[AnioReg] [int] NULL,
	[MesReg] [int] NULL,
	[DiaReg] [int] NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegWorksIdTNQ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Trigger [dbo].[DelAnuncio]    Script Date: 05/03/2021 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[DelAnuncio]
on [dbo].[AnuncioTNQ]
for insert 
as
BEGIN
        declare @IdAnuncioDel int
        
        select @IdAnuncioDel = RegAnuncioId from inserted

        update a
        set a.RegCodigoUnico = b.RegCodigoUnico,
            a.RegAnuncioPalabraClave = b.RegAnuncioPalabraClave,
            a.RegAnuncioAcercaDe = b.RegAnuncioAcercaDe,
            a.RegAnuncioEstado = b.RegAnuncioEstado,
            a.RegAnuncioFecha = b.RegAnuncioFecha,
            a.RegRutaImagen1 = b.RegRutaImagen1,
            a.RegRutaImagen2 = b.RegRutaImagen2,
            a.RegRutaImagen3 = b.RegRutaImagen3,
            a.Titulo = b.Titulo
        from duo..AnuncioTNQ a
        join duo..Anuncio b on b.RegAnuncioId = a.RegAnuncioId
        where a.RegAnuncioId = @IdAnuncioDel

        delete from duo..Anuncio where RegAnuncioId = @IdAnuncioDel

END
GO
ALTER TABLE [dbo].[AnuncioTNQ] ENABLE TRIGGER [DelAnuncio]
GO
/****** Object:  Trigger [dbo].[InsPerfilDUO]    Script Date: 05/03/2021 16:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create TRIGGER [dbo].[InsPerfilDUO]
on [dbo].[PerfilDuoTNQ]
for insert 
as
BEGIN

   declare @RegPerfilId int, @RegId int, @RegPerfilIdTNQ int

    select @RegPerfilIdTNQ = RegPerfilIdTNQ,  @RegPerfilId = RegPerfilId, @RegId = RegId from inserted

    if (@RegPerfilId = 0) 
    BEGIN
        insert into duo..PerfilDUO
        (
        RegId ,
        RegCodigoUnico ,
        RegRutaImagen ,
        RegStreamImagen ,
        RegNombres ,
        RegApellidos ,
        RegNombresCompletos ,
        RegProfesion ,
        RegAcercaDe ,
        RegEmail ,
        RegNumeroCelular ,
        RegFecha ,
        AnioReg ,
        MesReg ,
        DiaReg ,
        Tecnologia ,
        Legales ,
        Comunicacion ,
        Comercio ,
        ArteDiseno ,
        ServiciosTecnicos ,
        Urbanismo ,
        Emprendimientos 
        )
        select 
        a.RegId
        ,a.[RegCodigoUnico]
        ,'http://18.218.178.167/imagesemail/Profile.png' [RegRutaImagen]
        ,null [RegStreamImagen]
        ,a.[RegNombres]
        ,a.[RegApellidos]
        ,a.RegNombres
        ,a.RegProfesion [RegProfesion]
        ,a.RegAcercaDe [RegAcercaDe]
        ,a.[RegEmail]
        ,a.[RegNumeroCelular]
        ,a.[RegFecha]
        ,a.[AnioReg]
        ,a.[MesReg]
        ,a.[DiaReg]
        ,a.[Tecnologia]
        ,a.[Legales]
        ,a.[Comunicacion]
        ,a.[Comercio]
        ,a.[ArteDiseno]
        ,a.[ServiciosTecnicos]
        ,a.[Urbanismo]
        ,a.[Emprendimientos] 
        from duo..PerfilDuoTNQ a
        where a.RegId = @RegId and a.RegPerfilIdTNQ = @RegPerfilIdTNQ
    END
    ELSE
    BEGIN
        update a
        set a.RegNombres = b.RegNombres, a.RegApellidos = b.RegApellidos, a.RegNombresCompletos = b.RegNombresCompletos,
        a.RegProfesion = b.RegProfesion, a.RegAcercaDe = b.RegAcercaDe, a.RegEmail = b.RegEmail, a.RegNumeroCelular = b.RegNumeroCelular,
        a.RegFecha = b.RegFecha
        from duo..PerfilDUO a
        join duo..PerfilDuoTNQ b on a.RegPerfilId = b.RegPerfilId and a.RegId = b.RegId
        where b.RegId = @RegId and b.RegPerfilId = @RegPerfilId
        and b.RegPerfilIdTNQ = @RegPerfilIdTNQ
    END 

END
GO
ALTER TABLE [dbo].[PerfilDuoTNQ] ENABLE TRIGGER [InsPerfilDUO]
GO
/****** Object:  Trigger [dbo].[DelProducts]    Script Date: 05/03/2021 16:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DelProducts]
on [dbo].[ProductsTNQ]
for insert 
as
BEGIN
        declare @IdProductDel int, @IsDel int
        
        select @IdProductDel = RegProductId, @IsDel = IsDel  from inserted

        if(@IsDel = 1)
        BEGIN
            update a
            set a.RegCodigoUnico = b.RegCodigoUnico,
                a.RegTituloProducto = b.RegTituloProducto,
                a.RegDescripcionProducto = b.RegDescripcionProducto,
                a.RegPreciProducto = b.RegPreciProducto,
                a.RegFecha = b.RegFecha,
                a.AnioReg = b.AnioReg,
                a.MesReg = b.MesReg,
                a.DiaReg = b.DiaReg
            from duo..ProductsTNQ a
            join duo..Products b on b.RegProductId = a.RegProductId
            where a.RegProductId = @IdProductDel

            delete from duo..Products where RegProductId = @IdProductDel
        END
END
GO
ALTER TABLE [dbo].[ProductsTNQ] ENABLE TRIGGER [DelProducts]
GO
/****** Object:  Trigger [dbo].[InsProducts]    Script Date: 05/03/2021 16:17:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsProducts]
on [dbo].[ProductsTNQ]
for insert 
as
BEGIN
        declare @IdWorkDel int
        
        select @IdWorkDel = RegProductId from inserted

        update b
        set b.RegCodigoUnico = a.RegCodigoUnico,
            b.RegTituloProducto = a.RegTituloProducto,
            b.RegDescripcionProducto = a.RegDescripcionProducto,
            b.RegPreciProducto = a.RegPreciProducto,
            b.IsNew = 0
        from duo..productsTNQ a
        join duo..products b on b.RegProductId = a.RegProductId
        where b.RegProductId = @IdWorkDel
END
GO
ALTER TABLE [dbo].[ProductsTNQ] ENABLE TRIGGER [InsProducts]
GO
/****** Object:  Trigger [dbo].[DelWorks]    Script Date: 05/03/2021 16:17:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DelWorks]
on [dbo].[worksTNQ]
for insert 
as
BEGIN
        declare @IdWorkDel int, @IsDel int
        
        select @IdWorkDel = RegWorksId, @IsDel = IsDel from inserted

        if(@IsDel = 1)
        BEGIN
            update a
            set a.RegCodigoUnico = b.RegCodigoUnico,
                a.RegDescripcion = b.RegDescripcion,
                a.RegFecha = b.RegFecha,
                a.AnioReg = b.AnioReg,
                a.MesReg = b.MesReg,
                a.DiaReg = b.DiaReg
            from duo..worksTNQ a
            join duo..works b on b.RegWorksId = a.RegWorksId
            where a.RegWorksId = @IdWorkDel

            delete from duo..works where RegWorksId = @IdWorkDel
        END
END
GO
ALTER TABLE [dbo].[worksTNQ] ENABLE TRIGGER [DelWorks]
GO
/****** Object:  Trigger [dbo].[InsWorks]    Script Date: 05/03/2021 16:17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create TRIGGER [dbo].[InsWorks]
on [dbo].[worksTNQ]
for insert 
as
BEGIN
        declare @IdWorkDel int, @IsDel int
        
        select @IdWorkDel = RegWorksId from inserted

        update b
        set b.RegCodigoUnico = a.RegCodigoUnico,
            b.RegDescripcion = a.RegDescripcion,
            b.IsNew = 0
        from duo..worksTNQ a
        join duo..works b on b.RegWorksId = a.RegWorksId
        where b.RegWorksId = @IdWorkDel
END
GO
ALTER TABLE [dbo].[worksTNQ] ENABLE TRIGGER [InsWorks]
GO
