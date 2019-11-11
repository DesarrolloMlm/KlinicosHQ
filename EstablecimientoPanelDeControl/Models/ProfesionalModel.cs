using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Models
{
    public class ProfesionalModel
    {
        [Key]
        public Int32 id { get; set; }

        [Required]
        public Int32 idTipoDocumento { get; set; }

        [Required]
        [StringLength(8)]
        public String numeroDocumento { get; set; }

        [Required]
        public Int32 idSexo { get; set; }

        [Required]
        [StringLength(100)]
        public String primerApellido { get; set; }

        [Required]
        [StringLength(100)]
        public String primerNombre { get; set; }

        [StringLength(100)]
        public String otrosNombres { get; set; }

        [StringLength(3)]
        public String tipoTelefono { get; set; }

        [StringLength(50)]
        public String telefono { get; set; }

        public String contactoObservaciones { get; set; }

        public String email { get; set; }

        [StringLength(30)]
        public string matricula { get; set; }

        public Boolean vigente { get; set; }

        public string sexo { get; set; }

           

        
    }
}