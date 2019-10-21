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
        // GET: Establecimiento

        EstablecimientoRepositorio EstablecimientoRepo = new EstablecimientoRepositorio();
        public ActionResult Panel()
        {
            PanelViewModel miVista = new PanelViewModel();
            miVista = EstablecimientoRepo.CargaDeDatos();

            return View(miVista);
        }

        [HttpPost]
        public JsonResult TotalEvolucionesRefresh(DateTime fechaDesdeEvolucioness, DateTime fechaHastaEvolucioness)
        {
            var resultado = new BaseRespuesta();
            Int32 tempValue;

            PanelViewModel miVista = new PanelViewModel();
            miVista = EstablecimientoRepo.CargaDeDatos(fechaDesdeEvolucioness, fechaHastaEvolucioness,null, null);

            tempValue = miVista.evolucionesTotales;
            try
            {
                
                if (miVista.evolucionesTotales == 0)
                    throw new ApplicationException("La cantidad de Evoluciones es igual a 0");

                resultado.Mensaje = "creado correctamente";
                resultado.Ok = true;
            }
            catch(Exception ex)
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
            miVista = EstablecimientoRepo.CargaDeDatos(null,null,fechaDesdePracticass,fechaHastaPracticass);

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

        public ActionResult Paciente(string ddni)
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