using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Models;
using DLMallas.Utilidades;

namespace DLMallas.Controllers
{
    public class AdministracionItinerarioController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.ActiveLink = "Itinerario";
            var model = new ItinerariosViewModels
            {
                Itinerarios = _Itinerario.ObtenerListadoItinerarioMalla("0"),
                MallaId = "0"
            };

            return View(model);
        }

        public HttpStatusCodeResult GuardarItinerario(string mallaId, string nombre, string fechaInic, string fechaFin)
        {
            var resp = _Itinerario.GuardarItinerario(mallaId, nombre, fechaInic, fechaFin);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }
        

        public PartialViewResult  TablaSelecionarMalla()
        {
            var model = _malla.ObtenerListadoMalla();
            return PartialView("_SelecionarMalla", model);
        }
    }
}