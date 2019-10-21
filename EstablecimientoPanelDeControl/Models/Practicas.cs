using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Models
{
    public class Practicas
    {

        public Int32 totales { get; set; }

        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public Practicas(Int32 totalPracticas)
        {
            this.fechaDesde = DateTime.Now.AddDays(-30);
            this.fechaHasta = DateTime.Now;
            this.totales = totalPracticas;
        }

    }
}