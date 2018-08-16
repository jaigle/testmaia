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
    public class ComponenteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerListadoSeccion(string idversion) {
            Seccion s = new Seccion();
            var a = s.obtenerListadoSeccion(idversion).ToList();
            return Json(a, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult OtenerListadoCatalogoCurso()
        {
            Componente s = new Componente();
            var b = s.obtenerListadoCatalogoCurso().ToList();
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerListadoModalidadComponente()
        {
            Componente s = new Componente();
            var c = s.obtenerListadoModalidadComponente().ToList();
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerComponente(string id)
        {
            Componente co = new Componente();
            var get = co.obtenerComponente(id).ToList();
            return Json(get, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerComponentePrerrequisito(string id) 
        {
            Componente co = new Componente();
            var get = co.obtenerComponentePrerrequisito(id).ToList();
            return Json(get, JsonRequestBehavior.AllowGet);
        }

        public bool GuardarComponente(string idseccion, string idmodalidad, string iduc)
        {
            GuardarComponente model = new GuardarComponente();
            model.IdSeccion = idseccion;
            model.IdModalidadComponente = idmodalidad;
            model.IdUnidadCurricular = iduc;
            Componente co = new Componente();
            var resp = co.guardarComponente(model);
            if (resp)
                return true;
            else
                return false;
        }

        public bool ActualizarComponente(string id, string idseccion, string idmodalidad)
        {
            ActualizarComponente model = new ActualizarComponente();
            model.Id = id;
            model.IdSeccion = idseccion;
            model.IdModalidadComponente = idmodalidad;
            Componente co = new Componente();
            var resp = co.actualizarComponente(model);
            if (resp)
                return true;
            else
                return false;
        }

        public bool EliminarComponente(string id)
        {
            Componente c = new Componente();
            var resp = c.eliminarComponente(id);
            if (resp)
                return true;
            else
                return false;
        }

        public bool GuardarPrerrequisito(string idcomponente, string idcomponenteprerrequisito)
        {
            GuardarPrerrequisito model = new GuardarPrerrequisito();
            model.IdComponente = idcomponente;
            model.IdComponentePrerrequisito = idcomponenteprerrequisito;
            Componente co = new Componente();
            var resp = co.guardarPrerrequisito(model);
            if (resp)
                return true;
            else
                return false;
        }
    }
}