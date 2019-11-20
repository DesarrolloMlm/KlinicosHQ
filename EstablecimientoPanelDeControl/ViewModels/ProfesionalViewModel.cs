using EstablecimientoPanelDeControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class ProfesionalViewModel
    {
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        public int IdProfesional { get; set; }

        private List<Especialidad> especialidades;

        public void SetEsepecialidades(List<Especialidad> lista)
        {
            this.especialidades = lista;
        }

        public string GetEspecialidades()
        {
            string retornador=string.Empty;
            int contador = this.especialidades.Count;
            foreach (Especialidad especialidad in this.especialidades)
            {
                contador--;
                if (contador != 0)
                    retornador += especialidad.Nombre + " ,";
                else
                    retornador += especialidad.Nombre + ".";
            }



            return retornador;
        }




    }
}