using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Version;
using DLMallas.Utilidades;
using DLMallas.Models;
using DLMallas.Business.Dto.Componente;

namespace DLMallas.Controllers
{
    public class ComponenteController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerListadoSeccion(string idversion)
        {
            var a = _seccion.obtenerListadoSeccion(idversion).ToList();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OtenerListadoCatalogoCurso()
        {
            Componente s = new Componente();
            var b = _componente.obtenerListadoCatalogoCurso().ToList();
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerListadoModalidadComponente()
        {

            var result = _componente.obtenerListadoModalidadComponente().ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerComponente(string id)
        {
            Componente co = new Componente();
            var get = co.obtenerComponente(id).ToList();
            return Json(get, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ObtenerComponentePrerrequisito(string idVersion, string idSociedad, string idUcActual)
        {
            var model = _componente.ObtenerListadoPrerrequisitos(idVersion, idUcActual);
            return PartialView("_Prerrequisitos", model);
        }

        public bool GuardarComponente(string idseccion, string idmodalidad, string iduc)
        {
            var model = new GuardarComponente();
            model.IdSeccion = idseccion;
            model.IdModalidadComponente = idmodalidad;
            model.ListaCsv = iduc.Aggregate((a, x) => a + ", " + x);
            var resp = true;
            resp = _componente.guardarComponente(model).errorCode == 0;
            return resp;
        }

        public bool ActualizarComponente(string id, string idseccion, string idmodalidad)
        {
            var model = new ActualizarComponente();
            model.Id = id;
            model.IdSeccion = idseccion;
            model.IdModalidadComponente = idmodalidad;

            var resp = _componente.actualizarComponente(model);
            if (resp)
                return true;

            return false;
        }

        public bool EliminarComponente(string id)
        {
            var resp = _componente.eliminarComponente(id);
            if (resp)
                return true;
            else
                return false;
        }

        public bool GuardarPrerrequisito(String IdComponente, List<String> ListaUC)
        {
            var model = new GuardarPrerrequisito
            {
                IdComponente = IdComponente,
                IdComponentePrerrequisitos = ListaUC
            };
            var resp = _componente.guardarPrerrequisito(model);
            if (resp)
                return true;
            else
                return false;
        }

        public PartialViewResult OtenerContenidoCatalogoCurso()
        {
            var model =  _componente.obtenerListadoCatalogoCurso().ToList();
            return PartialView("~/Views/Version/_ContenidoSelecionarUC.cshtml", model);
        }
    }
}