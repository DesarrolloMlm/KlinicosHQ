USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_SECTORES]    Script Date: 23/10/2019 15:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_LISTAR_SECTORES]
as
begin
	--Listado de Sectores
	SELECT id,nombre,tipo,vigente FROM GeneralLocal.Sectores
end
