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
                Itinerarios = _itinerario.ObtenerListadoItinerarioMalla("0"),
                MallaId = "0"
            };

            return View(model);
        }

        public HttpStatusCodeResult GuardarItinerario(string mallaId, string nombre, string fechaInic, string fechaFin)
        {
            var resp = _itinerario.GuardarItinerario(mallaId, nombre, fechaInic, fechaFin);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }

        public HttpStatusCodeResult GuardarParticipantes(string idItinerario, string participantes)
        {
            var resp = _itinerario.GuardarParticipantes(idItinerario, participantes);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }

        
        
        public HttpStatusCodeResult ActualizarItinerario(string id, string mallaId, string nombre, string fechaInic, string fechaFin)
        {
            var resp = _itinerario.ActualizarItinerario(id, mallaId, nombre, fechaInic, fechaFin, "1");
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }
        public HttpStatusCodeResult EliminarNominaTodos(string idItinerario)
        {
            var resp = _itinerario.EliminarNominasTodos(idItinerario);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }

        public HttpStatusCodeResult EliminarNominaSelecionados(string idItinerario, string Idslist)
        {
            var resp = _itinerario.EliminarNominasSelecionados(idItinerario, Idslist);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }

        

        public PartialViewResult  TablaSelecionarMalla(string idMalla)
        {
            ViewBag.idMalla = idMalla;
            var model = _malla.ObtenerListadoMalla();
            return PartialView("_SelecionarMalla", model);
        }

        public ActionResult EditarItinerario(string id)
        {
            ViewBag.ActiveLink = "EditarItinerario";
            var model = _itinerario.ObtenerItinerario(id);
            return View(model);
        }

        public ActionResult Audiencia(string id)
        {
            var model = new NominasViewModels
            {
                IdItinerario = id,
                ListadoNominaAcademia = _itinerario.ObtenerListadoNomina(id)
            };
            ViewBag.ActiveLink = "Audiencia";
            return View(model);
        }

        public PartialViewResult  BuscarParticipante(string cedulaIdent, string apellidoPat, string apellidoMat, string cargo, string sociedadCont, string unidadOrg, string franquicia, string unidadNeg)
        {
            var model = _itinerario.ObtenerListadoNominAcademia(cedulaIdent, apellidoPat, apellidoMat, cargo, sociedadCont, unidadOrg, franquicia, unidadNeg);
            return PartialView("_ResultadoBuscarParticipante", model);
        }
    }
}

