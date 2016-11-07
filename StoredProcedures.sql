USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerCategoriaPorId]    Script Date: 11/6/2016 11:01:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ObtenerCategoriaPorId]
@IdCategoria int
AS
BEGIN
	SELECT c.descripcion AS 'Categoría', p.cargo AS 'Cargo', e.nombre AS '	', e.localidad AS 'Localidad'
	FROM PuestoTrabajo p 
	INNER JOIN Categoria c ON c.id = p.id_Categoria
	INNER JOIN Empresa e ON e.id = p.id_Empresa
	WHERE id_Categoria = @IdCategoria
END






USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerCategoriaPorEstado]    Script Date: 11/6/2016 11:01:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_ObtenerPuestosPorCategoria]
@Categoria INT
AS
BEGIN
	SELECT * FROM PuestoTrabajo
	WHERE id_Categoria = @Categoria 
END









USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListadoCategoria_Paginacion_Count]    Script Date: 11/6/2016 11:01:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListadoCategoria_Paginacion_Count]
@NroRegistros INT -- Registros por Pagina
AS
BEGIN
	DECLARE @residuo INT
	DECLARE @nroPaginas INT
	DECLARE @cantidad INT = (SELECT COUNT(1) FROM PuestoTrabajo)
	
	SET @nroPaginas = @cantidad / @NroRegistros
	SET @residuo = @Cantidad % @NroRegistros

	IF @residuo > 0
	BEGIN
		SET @nroPaginas = @nroPaginas + 1
	END

	SELECT @nroPaginas AS 'NroPaginas'
END











USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListadoCategoria_Paginacion]    Script Date: 11/6/2016 11:01:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ListadoCategoria_Paginacion]
@Pagina INT, -- # de pagina 
@NroRegistros INT -- # de elementos por pagina
AS
BEGIN
	DECLARE @inicio INT
	DECLARE @fin INT

	SET @inicio = @NroRegistros * @Pagina - @NroRegistros + 1
	SET @fin = @inicio + @NroRegistros - 1

	SELECT * FROM
		(SELECT ROW_NUMBER()OVER (ORDER BY id_Categoria) AS Row, 
		c.descripcion AS 'Categoría', p.cargo AS 'Cargo', e.nombre AS 'Compañía', e.localidad AS 'Localidad'
		FROM PuestoTrabajo p 
		INNER JOIN Categoria c ON c.id = p.id_Categoria
		INNER JOIN Empresa e ON e.id = p.id_Empresa) resultado
	WHERE Row BETWEEN @inicio AND @fin;
END




















USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 11/6/2016 11:00:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_InsertarCategoria]
@Codigo varchar(5),
@Descripcion varchar(20)
AS
BEGIN
	INSERT INTO Categoria(Codigo, Descripcion, Estado)
	Values(@Codigo, @Descripcion, 1)
END











USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 11/6/2016 11:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sp_EliminarCategoria]
@IdCategoria int
AS
BEGIN
	DELETE FROM Categoria
	WHERE IdCategoria = @IdCategoria;
END













USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_CantidadRegistros]    Script Date: 11/6/2016 11:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CantidadRegistros]
AS
BEGIN
	SELECT COUNT(1) FROM PuestoTrabajo
END













USE [Puestos]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCategoria]    Script Date: 11/6/2016 11:02:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ActualizarCategoria]
@IdCategoria int,
@Codigo varchar(5),
@Descripcion varchar(20),
@Estado bit
AS
BEGIN
	UPDATE Categoria
	SET Codigo = @Codigo,
		Descripcion = @Descripcion,
		Estado = @Estado
	WHERE IdCategoria = @IdCategoria
END