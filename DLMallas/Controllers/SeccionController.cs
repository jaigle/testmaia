using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Seccion;
using DLMallas.Models;
using DLMallas.Utilidades;

namespace DLMallas.Controllers
{
    public class SeccionController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public HttpStatusCodeResult GuardarSeccion(string idversion, string nombre, string color) 
        {
            var model = new GuardarSeccion
            {
                IdSociedad = Variables.IdSociedad,
                IdVersion = idversion,
                Nombre = nombre,
                Color = color,
            };
           
            var resp = _seccion.guardarSeccion(model);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }

        public HttpStatusCodeResult ActualizarSeccion(string id, string nombre, string color)
        {
            var model = new ActualizarSeccion
            {
                Id = id,
                Nombre = nombre,
                Color = color,
            };

            var resp = _seccion.actualizarSeccion(model);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }

        public HttpStatusCodeResult EliminarSeccion(string Id)
        {
            var resp = _seccion.eliminarSeccion(Id);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }
    }
}