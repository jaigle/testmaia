using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Version;
using DLMallas.Models;
using DLMallas.Utilidades;

namespace DLMallas.Controllers
{
    [Authorize]
    public class VersionController : Controller
    {
        [Authorize]
        public ActionResult Index(string id)
        {
            VersionViewModels model = new VersionViewModels();
            Malla malla = new Malla();
            _Version version = new _Version();
            model.ObtenerListadoVersion = version.obtenerListadoVersion(id);
            model.ObtenerMalla = malla.obtenerMalla(id);
            return View(model);
        }

        public bool GuardarVersion(string fechainicio, string idmalla)
        {
            _Version version = new _Version();
            GuardarVersion guarda = new GuardarVersion();
            guarda.IdMalla = idmalla;
            guarda.IdSociedad = Variables.IdSociedad;
            guarda.FechaInicio = fechainicio;
            var resp = version.guardarVersion(guarda);
            if (resp)
                return true;
            else
                return false;
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
            VersionViewModels model = new VersionViewModels();
            Seccion seccion = new Seccion();
            Componente componente = new Componente();
            Malla malla = new Malla();
            _Version version = new _Version();
            model.ObtenerVersion = version.obtenerVersion(IdVersion);
            model.ObtenerMalla = malla.obtenerMalla(IdMalla);
            model.ObtenerListadoSeccion = seccion.obtenerListadoSeccion(IdVersion);
            model.ObtenerListadoComponente = componente.obtenerListadoComponente(IdVersion);

            return View(model);
        }
    }
}