using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Seccion;
using DLMallas.Models;
using DLMallas.Utilidades;

namespace DLMallas.Controllers
{
    public class SeccionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public bool GuardarSeccion(string idversion, string nombre, string color) 
        {
            Seccion seccion = new Seccion();
            GuardarSeccion model = new GuardarSeccion();
            model.IdSociedad = Variables.IdSociedad;
            model.IdVersion = idversion;
            model.Nombre = nombre;
            model.Color = color;
            var resp = seccion.guardarSeccion(model);
            if (resp)
                return true;
            else
                return false;
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

        public bool EliminarSeccion(string Id)
        {
            Seccion s = new Seccion();
            var resp = s.eliminarSeccion(Id);
            if (resp)
                return true;
            else
                return false;
        }
    }
}