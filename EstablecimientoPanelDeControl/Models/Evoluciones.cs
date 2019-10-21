using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Models
{
    public class Evoluciones
    {
        public Int32 totales { get; set; }

        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public Evoluciones(Int32 totalEvoluciones)
        {
            this.fechaDesde = DateTime.Now.AddDays(-30);
            this.fechaHasta = DateTime.Now;
            this.totales = totalEvoluciones;
        }
    }
}