using EstablecimientoPanelDeControl.Models;
using EstablecimientoPanelDeControl.Repositorio;
using EstablecimientoPanelDeControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstablecimientoPanelDeControl.Controllers
{
    public class ProfesionalController : Controller
    {
        // GET: Profesional
        public ActionResult Listado()
        {
            EstablecimientoRepositorio repositorio = new EstablecimientoRepositorio();
            List<ProfesionalModel> listaProfesionales = repositorio.obtenerProfesionales();
            List<ProfesionalViewModel> lista = MapearProfesionaleViewModel(listaProfesionales);
            return View("ListaProfesionales", lista);
        }

        private List<ProfesionalViewModel> MapearProfesionaleViewModel(List<ProfesionalModel> listaProfesionales)
        {
            List<ProfesionalViewModel> retornador = new List<ProfesionalViewModel>();
            foreach (ProfesionalModel model in listaProfesionales)
            {
                retornador.Add(new ProfesionalViewModel(model));
            }
            return retornador;
        }
    }
}