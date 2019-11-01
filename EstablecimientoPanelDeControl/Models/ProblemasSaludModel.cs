using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstablecimientoPanelDeControl.Models
{
    public class ProblemasSaludModel
    {
        [Required]
        [StringLength(30)]
        public String problemaSalud { get; set; }

        public Int32 cantidad{ get; set; }
    }
}