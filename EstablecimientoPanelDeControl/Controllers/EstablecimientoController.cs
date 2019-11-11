using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstablecimientoPanelDeControl.Repositorio;
using EstablecimientoPanelDeControl.ViewModels;
using EstablecimientoPanelDeControl.Models;

namespace EstablecimientoPanelDeControl.Controllers
{
    public class EstablecimientoController : Controller
    {
        EstablecimientoRepositorio EstablecimientoRepo = new EstablecimientoRepositorio();

        [HttpGet]
        public ActionResult Panel()
        {
            PanelViewModel miVista = new PanelViewModel();
            miVista = EstablecimientoRepo.CargaDeDatosPanel();

            return View(miVista);
        }

        [HttpPost]
        public JsonResult TotalEvolucionesRefresh(DateTime fechaDesdeEvolucioness, DateTime fechaHastaEvolucioness)
        {
            var resultado = new BaseRespuesta();
            Int32 tempValue;

            PanelViewModel miVista = new PanelViewModel();
            miVista = EstablecimientoRepo.CargaDeDatosPanel(fechaDesdeEvolucioness, fechaHastaEvolucioness, null, null);

            tempValue = miVista.evolucionesTotales;
            try
            {
                if (miVista.evolucionesTotales == 0)
                    throw new ApplicationException("La cantidad de Evoluciones es igual a 0");

                resultado.Mensaje = "creado correctamente";
                resultado.Ok = true;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
            }

            return Json(tempValue);
        }

        [HttpPost]
        public JsonResult TotalPracticasRefresh(DateTime fechaDesdePracticass, DateTime fechaHastaPracticass)
        {
            var resultado = new BaseRespuesta();
            Int32 tempValue;

            PanelViewModel miVista = new PanelViewModel();
            miVista = EstablecimientoRepo.CargaDeDatosPanel(null, null, fechaDesdePracticass, fechaHastaPracticass);

            tempValue = miVista.practicasTotales;
            try
            {
                if (miVista.practicasTotales == 0)
                    throw new ApplicationException("La cantidad de Practicas es igual a 0");

                resultado.Mensaje = "creado correctamente";
                resultado.Ok = true;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
            }

            return Json(tempValue);
        }

        [HttpGet]
        public ActionResult AccederSector(string idSector)
        {
            var url = Url.Action("Sector", "Establecimiento", new { iddSector = idSector });
            return Redirect(url);
        }

        [HttpGet]
        public ActionResult Sector(string iddSector)
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarPaciente(string dni)
        {
            var url = Url.Action("Paciente", "Establecimiento", new { ddni = dni });
            return Redirect(url);
        }

        [HttpGet]
        public ActionResult Paciente(string ddni)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProblemaSalud()
        {
            ProblemaSaludViewModel miVista = new ProblemaSaludViewModel();
            DateTime date1 = new DateTime(2019, 2, 1, 12, 0, 0, 0, 0);
            DateTime date2 = new DateTime(2019, 10, 1, 12, 0, 0, 0, 0);

            miVista = EstablecimientoRepo.CargaDeDatosProblemaSalud(date1, date2, 388);

            return View(miVista);
        }

        [HttpPost]
        public ActionResult ProblemaSalud(String FechaDesdePs, String FechaHastaPs, String CantidadPs)
        {
            CantidadPs = (CantidadPs == "" ? "0" : CantidadPs);

            TempData["t_FechaDesdePs"] = FechaDesdePs;
            TempData["t_FechaHastaPs"] = FechaHastaPs;
            TempData["t_CantidadPs"] = CantidadPs;
            return View();
        }

        public ActionResult ControladorPartialView()
        {
            DateTime FechaDesdePss=DateTime.Now.AddDays(-30);
            DateTime FechaHastaPss=DateTime.Now;
            Int32 CantidadPss=0;

            if (TempData.Keys.Contains("t_FechaDesdePs"))
            {
                FechaDesdePss= DateTime.Parse(TempData["t_FechaDesdePs"].ToString());
                FechaHastaPss= DateTime.Parse(TempData["t_FechaHastaPs"].ToString());
                CantidadPss = Int32.Parse(TempData["t_CantidadPs"].ToString());
            }
            
            ModelState.Clear();

            List<ProblemasSaludModel> lista1 = EstablecimientoRepo.ListarProblemasSalud(FechaDesdePss,FechaHastaPss,CantidadPss);

            ProblemaSaludViewModel lista = new ProblemaSaludViewModel(lista1);

            return PartialView("_ProblemaSalud",lista);
        }



        public ActionResult ListadoProfesionales()
        {
            EstablecimientoRepo.ObtenerSemanalAtenciones();
            return RedirectToAction("Listado", "Profesional");
        }

        public ActionResult SemanalAtenciones()
        {

            return View();
        }

    }
}

public class BaseRespuesta
{
    public bool Ok { get; set; }
    public string Mensaje { get; set; }
}