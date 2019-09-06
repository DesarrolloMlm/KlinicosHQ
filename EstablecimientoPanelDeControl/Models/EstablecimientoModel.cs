using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstablecimientoPanelDeControl.Models
{
    public class EstablecimientoModel
    {
        //public string nombreEstablecimiento { get { return this.Establecimiento.Select(x => x.nombre).Aggregate((x, y) => string.Format("{0}, {1}", x, y)); } }

        public Int32 totalMedicosActivos { get; set; }

        public Int32 totalMedicosInactivos { get; set; }

        public Int32 totalAtenciones { get; set; }

        public Int32 totalPracticas { get; set; }

        public DateTime atencionFechaDesde { get; set; }

        public DateTime atencionFechaHasta { get; set; }

        public DateTime practicaFechaDesde { get; set; }

        public DateTime practicaFechaHasta { get; set; }

        //[NotMapped]
        public string nombreSector { get { return this.sectores.Select(x => x.nombre).Aggregate((x, y) => string.Format("{0}, {1}", x, y)); } }

        public virtual List<Sector> sectores { get; set; }

        internal void Mokear()
        {
            this.totalMedicosActivos = 100;
            this.totalMedicosInactivos = 50;
            this.totalAtenciones = 80;
            this.totalPracticas = 40;
            //this.atencionFechaDesde = DateTime.Now;
            this.atencionFechaDesde = new DateTime(2019, 8, 22, 10, 4, 0);
            this.atencionFechaHasta = DateTime.Now;
            this.practicaFechaDesde = new DateTime(2019, 8, 22, 10, 4, 0);
            this.practicaFechaHasta = DateTime.Now;
        }
    }
}