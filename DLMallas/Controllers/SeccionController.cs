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

        public bool ActualizarSeccion(string id, string nombre, string color)
        {
            Seccion seccion = new Seccion();
            ActualizarSeccion model = new ActualizarSeccion();
            model.Id = id;
            model.Nombre = nombre;
            model.Color = color;
            var resp = seccion.actualizarSeccion(model);
            if (resp)
                return true;
            else
                return false;
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