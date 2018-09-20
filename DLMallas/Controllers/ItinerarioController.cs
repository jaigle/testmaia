using System.Collections.Generic;
using System.Web.Mvc;
using DLMallas.Models;

namespace DLMallas.Controllers
{
    public class ItinerarioController : BaseController
    {
        public ActionResult Index(string id)
        {
            ViewBag.ActiveLink = "Itinerario";
            var model = new ItinerariosViewModels
            {
                MallaId = id,
                Itinerarios = new List<ItinerarioViewModels>()
            };

            return View(model);
        }
    }
}