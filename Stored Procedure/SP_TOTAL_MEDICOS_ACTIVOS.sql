USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_TOTAL_MEDICOS_ACTIVOS]    Script Date: 23/10/2019 15:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_TOTAL_MEDICOS_ACTIVOS]
(
	@fechaDesde datetime
)
as
begin
	DECLARE @fechaDesdeTxt NVARCHAR(20)
	SET @fechaDesdeTxt = CONVERT(varchar(10), @fechaDesde, 102) + ' ' + '00:00:00'

	DECLARE @fechaHastaTxt NVARCHAR(20)
	SET @fechaHastaTxt = CONVERT(varchar(10), GETDATE(), 102) + ' ' + '23:59:59'

	--Total de Profesionales en el Establecimiento con Evoluciones
	SELECT COUNT(*) 'Medicos con Evoluciones'
	FROM
	(
		SELECT count(*) 'Evoluciones por Profesional'
		FROM general.Profesionales prof
		INNER JOIN Atencion.Evoluciones evo on evo.idProfesional = prof.id
		WHERE (evo.fechaCrea BETWEEN @fechaDesdeTxt AND @fechaHastaTxt )
		GROUP BY evo.idProfesional
	) Profesionales
end