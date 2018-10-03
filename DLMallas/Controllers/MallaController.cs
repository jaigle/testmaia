using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto;
using DLMallas.Utilidades;
using DLMallas.Models;
using Newtonsoft.Json;
using WebGrease.Css.Ast.Selectors;
using System.Collections.Generic;

namespace DLMallas.Controllers
{
    [Authorize]
    public class MallaController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            MallaViewModels model = new MallaViewModels();
            model.ObtenerListadoMalla = _malla.ObtenerListadoMalla();
            model.NombrePersonaLogin = Variables.NombrePersona;
            model.FechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            return View(model);
        }

        public ActionResult EditarMalla(string id)
        {
            //var model = new MallaViewModels();
            //DtoOperacionResult miMmalla = _malla.ObtenerMallajson(id);
            //if (miMmalla.errorCode != 0)
            //{
            //    //return Json(new { success = false, responseText = miMmalla.mensaje}, JsonRequestBehavior.AllowGet                
            //    return View("_Error", new HandleErrorInfo(new Exception(miMmalla.mensaje), "Malla", "Index"));
            //}
            //else {
            //    model.ObtenerMalla = JsonConvert.DeserializeObject<List<ObtenerMalla>>(miMmalla.resultado);
            //    ViewBag.Escuelas = _malla.ObtenerEsceulas().Select(s => new EscuelaViewModels { Id = s.Id, Nombre = s.Nombre }).ToList();
            //    ViewBag.ActiveLink = "EditarMalla";
            //    return View(model);
            //}
            var model = new MallaViewModels();
            model.ObtenerMalla = _malla.ObtenerMalla(id);
            ViewBag.Escuelas = _malla.ObtenerEsceulas().Select(s => new EscuelaViewModels { Id = s.Id, Nombre = s.Nombre }).ToList();
            ViewBag.ActiveLink = "EditarMalla";
            return View(model);
        }

        public string getMalla()
        {
            int id = (int)Session["idmalla"];
            var model = new MallaViewModels();
            model.ObtenerMalla = _malla.ObtenerMalla(id.ToString());
            var retorno = Utilidades.Acciones.serializarObjeto(model.ObtenerMalla);
            return retorno;
        }

        //[HttpPost]
        public HttpStatusCodeResult GuardarMalla(string nombre, string escuela, string desc, string activo)
        {
            var model = new GuardarMalla
            {
                Nombre = nombre,
                Escuela = escuela,
                Descripcion = desc,
                Activo = activo
            };
            var resp = _malla.GuardarMalla(model);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }

        public HttpStatusCodeResult ActualizarMalla(string id, string nombre, string escuela, string desc, string activo)
        {
            var model = new ActualizarMalla
            {
                Id = id,
                Nombre = nombre,
                IdEscuela = escuela,
                Descripcion = desc,
                Activo = activo
            };

            var resp = _malla.ActualizarMalla(model);
            if (resp)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
        }

        public HttpStatusCodeResult EliminarMalla(string id)
        {
            try
            {
                _malla.EliminarMalla(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Ok");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error intentando guardar malla");
            }
        }

        public PartialViewResult CargarEscuelas()
        {
            var model = _malla.ObtenerEsceulas().Select(s => new EscuelaViewModels { Id = s.Id, Nombre = s.Nombre }).ToList();
            return PartialView("_Options", model);
        }
    }
}