USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PROBLEMAS_SALUD]    Script Date: 1/11/2019 14:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_LISTAR_PROBLEMAS_SALUD]
(
	@fechaDesde datetime,
	@fechaHasta datetime,
	@cantidad int
)
as
begin
	
	DECLARE @fechaDesdeTxt NVARCHAR(20)
	SET @fechaDesdeTxt = CONVERT(varchar(10), @fechaDesde, 102) + ' ' + '00:00:00'

	DECLARE @fechaHastaTxt NVARCHAR(20)
	SET @fechaHastaTxt = CONVERT(varchar(10), @fechaHasta, 102) + ' ' + '23:59:59'

	SELECT snomed.term 'Problema de Salud',count(*) 'cantidad'
	FROM Atencion.ProblemasSalud ps
	INNER JOIN General.SNOMed snomed on snomed.id=ps.idSNOMed_problema
	WHERE EXISTS(
			   SELECT		1
			   FROM		Atencion.ProblemasSalud AtenProbSalud
			   WHERE fechaCrea BETWEEN @fechaDesdeTxt AND @fechaHastaTxt
			   AND AtenProbSalud.id = ps.id
		)
	GROUP BY ps.idSNOMed_problema,snomed.term HAVING count(*) >= @cantidad
	order by cantidad,[Problema de Salud] asc
end




