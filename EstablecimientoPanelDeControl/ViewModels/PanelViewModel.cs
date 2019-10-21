using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstablecimientoPanelDeControl.Models;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class PanelViewModel
    {
        //public Establecimientos establecimientos { get; set; }

        //[Key]
        //public Int32 establecimientoId { get; set; }
        //[Required]
        //[StringLength(50)]
        public String establecimientoNombre { get; set; }

        //public Medicos medicos { get; set; }

        public Int32 profesionalesTotales { get; set; }
        public Int32 profesionalesActivos { get; set; }
        public Int32 profesionalesInactivos { get; set; }

        //public Evoluciones atenciones { get; set; }

        public Int32 evolucionesTotales { get; set; }
        //public DateTime evolucionesFechaDesde { get; set; }
        //public DateTime evolucionesFechaHasta { get; set; }

        //public Practicas practicas { get; set; }

        public Int32 practicasTotales { get; set; }
        //public DateTime practicasFechaDesde { get; set; }
        //public DateTime practicasFechaHasta { get; set; }

        public List<SectorModel> sectoresListado { get; set; }

        public PanelViewModel(String nombreEstablecimiento, Int32 totalProfesionales, Int32 activosProfesionales, Int32 totalEvoluciones, Int32 totalPracticas, List<SectorModel> listadoSectores )
        {
            this.establecimientoNombre = nombreEstablecimiento;
            this.profesionalesTotales = totalProfesionales;
            this.profesionalesActivos = activosProfesionales;
            this.profesionalesInactivos = totalProfesionales - activosProfesionales;
            this.evolucionesTotales = totalEvoluciones;
            this.practicasTotales = totalPracticas;
            this.sectoresListado = listadoSectores;
        }

        public PanelViewModel()
        {
        }
    }
}