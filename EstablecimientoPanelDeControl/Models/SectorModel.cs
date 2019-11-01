﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstablecimientoPanelDeControl.Models
{
    public class SectorModel
    {
        [Key]
        public Int32 id { get; set; }

        [Required]
        [StringLength(50)]
        public String nombre { get; set; }

        [Required]
        [StringLength(20)]
        public String tipo { get; set; }

        public Boolean vigente { get; set; }
    }
}