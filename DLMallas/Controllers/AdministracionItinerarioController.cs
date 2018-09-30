using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Dto.Nomina;
using DLMallas.Models;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using OfficeOpenXml;

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



        public PartialViewResult TablaSelecionarMalla(string idMalla)
        {
            ViewBag.idMalla = idMalla;
            var model = _malla.ObtenerListadoMalla();
            return PartialView("_SelecionarMalla", model);
        }

        public PartialViewResult Procesar(HttpPostedFileBase fileExcel, string idItinerario, string tipoDesmImportar)
        {
            var model = new ProcesadosViewModels();
            model.Procesados = new List<DtoProcesados>();
            using (ExcelPackage package = new ExcelPackage(fileExcel.InputStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var row = 2;
                var ruts = new List<string>();
                while (worksheet.Cells[row, 1].Value != null)
                {
                    ruts.Add(worksheet.Cells[row, 1].Value.ToString());
                    row++;
                }

                var strRuts = ruts.Aggregate((a, b) => a + ", " + b);

                var importar = (tipoDesmImportar == "importar") ? "1" : "0";
                model.Procesados = _itinerario.ValidarListadoRut(idItinerario, strRuts, importar);
            }

            return PartialView("_Porcesados", model);
        }

        public HttpStatusCodeResult EjecutarProcesados(string idItinerario, string tipoDesmImportar, string lista)
        {
            var resp = _itinerario.EjecutarProcesados(idItinerario, tipoDesmImportar, lista);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
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

        public PartialViewResult BuscarParticipante(string cedulaIdent, string apellidoPat, string apellidoMat, string cargo, string sociedadCont, string unidadOrg, string franquicia, string unidadNeg)
        {
            var model = _itinerario.ObtenerListadoNominAcademia(cedulaIdent, apellidoPat, apellidoMat, cargo, sociedadCont, unidadOrg, franquicia, unidadNeg);
            return PartialView("_ResultadoBuscarParticipante", model);
        }

        public ActionResult Informes(string id)
        {
            ViewBag.ActiveLink = "Informes";
            ViewBag.IdItinerario = id;
            return View();
        }

        public ActionResult Notificaciones(string id)
        {
            ViewBag.ActiveLink = "Notificaciones";
            ViewBag.IdItinerario = id;
            var model = _itinerario.ObtenerListadoNotificaciones(id);
            return View(model);
        }

        public HttpStatusCodeResult ActualizarNotificaciones(string idItinerario, string lista)
        {
            var resp = _itinerario.ActualizarNotificaciones(idItinerario, lista);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error");
        }
    }
}

