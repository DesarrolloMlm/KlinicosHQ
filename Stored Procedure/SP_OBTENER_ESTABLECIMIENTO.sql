USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ESTABLECIMIENTO]    Script Date: 23/10/2019 15:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_OBTENER_ESTABLECIMIENTO]
(
	@id int
)
as
begin
	--Trae el nombre de el Establecimiento segun id que ingresemos
	select nombre from General.Establecimientos where id=@id
end