USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_TOTAL_PROFESIONALES]    Script Date: 23/10/2019 15:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_TOTAL_PROFESIONALES]
as
begin
	--Total de Profesionales en el Establecimiento
	SELECT count(*) 'Total Profesionales'
	FROM GeneralLocal.ProfesionalesDisponibles prof
	INNER JOIN Usuario.Usuarios usu on usu.idProfesional=prof.id
end