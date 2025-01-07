USE [dbVentas]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Idventa] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[IdVentaDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdVenta] [bigint] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_VentaDetalle] PRIMARY KEY CLUSTERED 
(
	[IdVentaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (1, N'Memorias', 1)
GO
INSERT [dbo].[Categoria] ([IdCategoria], [Nombre], [Activo]) VALUES (2, N'CPU', 1)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombres], [Apellidos], [Direccion], [Ciudad], [FechaNacimiento], [Activo]) VALUES (1, N'Pedro', N'Diaz', N'Los alamos', N'Lima', CAST(N'1978-08-05' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombres], [Apellidos], [Direccion], [Ciudad], [FechaNacimiento], [Activo]) VALUES (2, N'Juan', N'Perz', N'Los alamos', N'Lima', CAST(N'1978-08-05' AS Date), 1)
GO
INSERT [dbo].[Cliente] ([IdCliente], [Nombres], [Apellidos], [Direccion], [Ciudad], [FechaNacimiento], [Activo]) VALUES (3, N'Isabl', N'Ramos', N'Los alamos', N'Lima', CAST(N'1978-08-05' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([IdProducto], [IdCategoria], [Nombre], [Stock], [Precio], [Activo]) VALUES (1, 1, N'Teclado LG', 100, CAST(30.00 AS Decimal(18, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Producto]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Venta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Idventa])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Venta]
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteCategoria]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_deleteCategoria]
@idCategoria INT
as
BEGIN
	DELETE FROM Categoria
	WHERE IdCategoria =  @idCategoria
END

GO
/****** Object:  StoredProcedure [dbo].[usp_deleteCliente]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[usp_deleteCliente]
@idCliente int
as
begin
	delete from Cliente
	where idCliente=@idCliente
end



GO
/****** Object:  StoredProcedure [dbo].[usp_getCategoriaById]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCategoriaById]
@idCategoria INT
AS
BEGIN
	SELECT * 
	FROM  Categoria(nolock)
	WHERE IdCategoria=@idCategoria

END
GO
/****** Object:  StoredProcedure [dbo].[usp_getCategorias]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getCategorias]
AS
BEGIN
	SELECT * 
	FROM  Categoria(nolock)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_getClienteById]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_getClienteById]
@idCliente int
as
begin
	select * from Cliente(nolock)
	where IdCliente=@idCliente

end
GO
/****** Object:  StoredProcedure [dbo].[usp_getClientes]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_getClientes]
AS
BEGIN
	SELECT * 
	FROM  Cliente(nolock)
END

GO
/****** Object:  StoredProcedure [dbo].[usp_insertCategoria]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_insertCategoria]
@nombre varchar(50)
AS

BEGIN 
	INSERT INTO Categoria (Nombre, Activo)
	VALUES (@nombre,1)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_insertCliente]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_insertCliente]
@nombres varchar(50),
@apellidos varchar(100),
@direccion varchar(100),
@ciudad varchar(50),
@fechaNacimiento date
AS
BEGIN 
	INSERT INTO Cliente (Nombres, Apellidos, Direccion, Ciudad, FechaNacimiento,Activo)
	VALUES (@nombres,@apellidos,@direccion,@ciudad,@fechaNacimiento,1)
END

GO
/****** Object:  StoredProcedure [dbo].[usp_updateCategoria]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_updateCategoria]
@idCategoria INT,
@nombre varchar(50)

AS

BEGIN 
	UPDATE Categoria
	SET nombre = @nombre
	WHERE IdCategoria = @idCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[usp_updateCliente]    Script Date: 26/12/2024 19:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_updateCliente]
@idCliente INT,
@nombres varchar(50),
@Apellidos varchar(100),
@Direccion varchar(100),
@Ciudad varchar(50),
@FechaNacimiento date
AS

BEGIN 
	UPDATE Cliente
	SET nombres = @nombres,apellidos=@Apellidos,
		Direccion=@Direccion,Ciudad=@Ciudad,FechaNacimiento=@FechaNacimiento
	WHERE IdCliente = @idCliente
END

GO
