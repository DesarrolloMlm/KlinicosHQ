using EstablecimientoPanelDeControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class ProfesionalViewModel
    {
        [Display(Name = "Documento")]
        public String documento { get; set; }

        [Display(Name = "Apellido y nombre")]
        public String apeYNom { get; set; }

        [Display(Name = "Teléfono")]
        public String telefono { get; set; }

        [Display(Name = "Observ. del contacto")]
        public String contactoObservaciones { get; set; }

        [Display(Name = "Email")]
        public String email { get; set; }

        [Display(Name = "Matrícula")]
        public String matricula { get; set; }

        [Display(Name = "Especialidades")]
        public String especialidades { get; set; }



        public ProfesionalViewModel(ProfesionalModel modelo)
        {
            this.apeYNom = modelo.primerApellido + " " + modelo.primerNombre;
            this.contactoObservaciones = modelo.contactoObservaciones;
            this.documento = modelo.numeroDocumento;
            this.email = modelo.email;
            this.matricula = modelo.matricula;
            this.telefono = modelo.telefono;
        }
    }
}