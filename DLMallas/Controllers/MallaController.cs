using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Malla;
using DLMallas.Utilidades;
using DLMallas.Models;

namespace DLMallas.Controllers
{
    [Authorize]
    public class MallaController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            MallaViewModels model = new MallaViewModels();
            Malla malla = new Malla();
            model.ObtenerListadoMalla = malla.obtenerListadoMalla();
            model.NombrePersonaLogin = Variables.NombrePersona;
            model.FechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            return View(model);
        }

        public ActionResult EditarMalla(string id) 
        {
            MallaViewModels model = new MallaViewModels();
            Malla malla = new Malla();
            model.ObtenerMalla = malla.obtenerMalla(id);
            return View(model);
        }

        //[HttpPost]
        public bool GuardarMalla(string nombre, string desc, string activo)
        {
            Malla malla = new Malla();
            GuardarMalla model = new GuardarMalla();
            model.Nombre = nombre;
            model.Descripcion = desc;
            model.Activo = activo;
            var resp = malla.guardarMalla(model);
            if (resp)
                return true;
            else
                return false;
        }

        public bool ActualizarMalla(string id, string nombre, string desc, string activo) 
        {
            Malla malla = new Malla();
            ActualizarMalla model = new ActualizarMalla();
            model.Id = id;
            model.Nombre = nombre;
            model.Descripcion = desc;
            model.Activo = activo;
            var resp = malla.actualizarMalla(model);
            if (resp)
                return true;
            else
                return false;
        }

        public ActionResult EliminarMalla(string id) 
        {
            try 
            {
                Malla malla = new Malla();
                malla.eliminarMalla(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}