using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class SemanalAtencionesViewModel
    {
        public Dia dia { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int iDProfesional { get; set; }
        public DateTime primeraAtencion { get; set; }
        public DateTime ultimaAtencion { get; set; }
        public int cantAtenciones { get; set; }


        public SemanalAtencionesViewModel()
        {

        }


        
    }

    public enum Dia { Lunes  = 0 , Martes , Miercoles ,Jueves, Viernes,Sabado,Domingo }
}
