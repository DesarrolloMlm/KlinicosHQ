using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Models
{
    public class Medicos
    {
        public Medicos()
        {

        }

        public Medicos(Int32 totalProfesionales, Int32 totalActivos)
        {
            this.totales = totalProfesionales;
            this.activos = totalActivos;
            this.inactivos = totalProfesionales - totalActivos;
        }

        public Int32 totales { get; set; }
        public Int32 activos { get; set; }
        public Int32 inactivos { get; set; }

    }
}