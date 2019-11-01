using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstablecimientoPanelDeControl.Models;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class PanelViewModel
    {
        public String establecimientoNombre { get; set; }

        public Int32 profesionalesTotales { get; set; }
        public Int32 profesionalesActivos { get; set; }
        public Int32 profesionalesInactivos { get; set; }

        public Int32 evolucionesTotales { get; set; }
        //public DateTime evolucionesFechaDesde { get; set; }
        //public DateTime evolucionesFechaHasta { get; set; }

        public Int32 practicasTotales { get; set; }
        //public DateTime practicasFechaDesde { get; set; }
        //public DateTime practicasFechaHasta { get; set; }

        public List<SectorModel> sectoresListado { get; set; }

        internal void Mokear()
        {
            this.establecimientoNombre = "Rebasa";

            this.profesionalesTotales = 50;
            this.profesionalesActivos = 80;
            this.profesionalesInactivos = 40;

            //this.evolucionesFechaDesde = DateTime.Now.AddDays(-30);
            //this.evolucionesFechaHasta = DateTime.Now;
            //this.practicasFechaDesde = DateTime.Now.AddDays(-30);
            //this.practicasFechaHasta = DateTime.Now;
        }

        public PanelViewModel()
        {

        }

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

    }
}