using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Version;
using DLMallas.Models;
using DLMallas.Utilidades;

namespace DLMallas.Controllers
{
    [Authorize]
    public class VersionController : BaseController
    {
        [Authorize]
        public ActionResult Index(string id)
        {
            var model = new VersionViewModels();
            
            model.ObtenerListadoVersion = _version.obtenerListadoVersion(id);
            model.ObtenerMalla = _malla.ObtenerMalla(id);
            ViewBag.ActiveLink = "Versiones";
            return View(model);
        }

        public HttpStatusCodeResult GuardarVersion(string fechainicio, string idmalla)
        {
            var guarda = new GuardarVersion
            {
                IdMalla = idmalla,
                IdSociedad = Variables.IdSociedad,
                FechaInicio = fechainicio,
            };
            
            var resp = _version.guardarVersion(guarda);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }

        public bool ActualizarVersion(string id, string fechainicio)
        {
            _Version version = new _Version();
            ActualizarVersion up = new ActualizarVersion();
            up.Id = id;
            up.FechaInicio = fechainicio;
            var resp = version.actualizarVersion(up);
            if (resp)
                return true;
            else
                return false;
        }

        public bool EliminarVersion(string Id)
        {
            _Version version = new _Version();
            var resp = version.eliminarVersion(Id);
            if (resp)
                return true;
            else
                return false;
        }

        public ActionResult DetalleVersion(string IdVersion, string IdMalla) 
        {
            var model = new VersionViewModels();
            model.ObtenerVersion = _version.obtenerVersion(IdVersion);
            model.ObtenerMalla = _malla.ObtenerMalla(IdMalla);
            model.ObtenerListadoSeccion = _seccion.obtenerListadoSeccion(IdVersion);
            model.ObtenerListadoComponente = _componente.obtenerListadoComponente(IdVersion);
            ViewBag.ActiveLink = "Versiones";

            return View(model);
        }
    }
}