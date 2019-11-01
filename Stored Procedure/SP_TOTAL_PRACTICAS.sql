USE [Klinicos_B]
GO
/****** Object:  StoredProcedure [dbo].[SP_TOTAL_PRACTICAS]    Script Date: 23/10/2019 15:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SP_TOTAL_PRACTICAS]
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

	--Total de Profesionales en el Establecimiento con Practicas
	SELECT COUNT(*) 'CantidadPracticas'
	FROM atencion.Observaciones atenObs
	LEFT JOIN Atencion.ObservacionesPracticaMedica atenObsPMed on atenObsPMed.id = atenObs.id
	LEFT JOIN Atencion.ObservacionesPracticaEnfermeria atenObsPEnf on atenObsPEnf.id = atenObs.id
	LEFT JOIN Atencion.ObservacionesPracticaImagen atenObsPImg on atenObsPImg.id = atenObs.id
	LEFT JOIN Atencion.ObservacionesPracticaBioquimica atenObsPBio on atenObsPBio.id = atenObs.id
	WHERE (atenObs.fechaCrea BETWEEN @fechaDesdeTxt AND @fechaHastaTxt )
	AND (atenObsPMed.idPractica IS NOT NULL OR 
	 atenObsPEnf.idPractica IS NOT NULL OR
	 atenObsPImg.id IS NOT NULL OR
	 atenObsPBio.id IS NOT NULL)
end
