USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_TOTAL_EVOLUCIONES]    Script Date: 23/10/2019 15:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_TOTAL_EVOLUCIONES]
(
	@fechaDesde datetime,
	@fechaHasta datetime
)
as
begin
	
	DECLARE @fechaDesdeTxt NVARCHAR(20)
	SET @fechaDesdeTxt = CONVERT(varchar(10), @fechaDesde, 102) + ' ' + '00:00:00'

	DECLARE @fechaHastaTxt NVARCHAR(20)
	SET @fechaHastaTxt = CONVERT(varchar(10), @fechaHasta, 102) + ' ' + '23:59:59'

	--Total de Evoluciones en el Establecimiento
	SELECT COALESCE(SUM(Profesionales.[Evoluciones por Profesional]),0) 'Cantidad de Evoluciones'
	FROM
	(
		SELECT count(*) 'Evoluciones por Profesional'
		FROM general.Profesionales prof
		INNER JOIN Atencion.Evoluciones evo on   evo.idProfesional = prof.id
		WHERE (evo.fechaCrea BETWEEN @fechaDesdeTxt AND @fechaHastaTxt )
		GROUP BY evo.idProfesional
	) Profesionales
end