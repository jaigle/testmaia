using System.Collections.Generic;
using System.Web.Mvc;
using DLMallas.Models;

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
    }
}