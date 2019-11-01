using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstablecimientoPanelDeControl.Models;

namespace EstablecimientoPanelDeControl.ViewModels
{
    public class ProblemaSaludViewModel
    {
        public List<ProblemasSaludModel> problemasSaludListado { get; set; }

        public ProblemaSaludViewModel()
        {

        }

        public ProblemaSaludViewModel(List<ProblemasSaludModel> listadoProblemasSalud)
        {
            this.problemasSaludListado = listadoProblemasSalud;
        }
    }
}