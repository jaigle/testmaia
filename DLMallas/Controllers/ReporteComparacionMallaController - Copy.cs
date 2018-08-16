using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Data;
using System.ServiceModel.Web;
using DLMallas.Contracts;
using DLMallas.Business;


namespace DLMallas.Controllers
{
    public class ReporteVersionController : Controller
    {

        int pintIdVersionMalla;
        /// <summary>
        /// Instancia de la BLL de aplicacion
        /// </summary>
        MallasBl _myBll;

        /// <summary>
        /// Propiedad para definir el encapsulamiento de la BLL
        /// </summary>
        private MallasBl MyBll
        {
            get { return _myBll ?? (_myBll = new MallasBl()); }
        }

        private int _intIdSociedad = 0;

        private int IdSociedad
        {
            //get { if (_intIdSociedad == 0) _intIdSociedad = (int)Session["sociedad"]; return _intIdSociedad; }
            get { if (_intIdSociedad == 0) _intIdSociedad = 3; return _intIdSociedad; }
        }

        // GET: Reportes
        public ActionResult Index()
        {
            ViewBag.ListMallas = new SelectList(MyBll.GetListMallas(IdSociedad, string.Empty), "IdMalla", "NombreMalla");

            return View();
        }

       
            

        public JsonResult getSituacionFinalVersion(int pintIdVersionMalla)
        {
            try
            {

                //wcfserviceMalla.ServicioMallaClient myBll = new wcfserviceMalla.ServicioMallaClient();
                //return Json(myBll.GetListMallas((int)Session["sociedad"], string.Empty));

                var retun = MyBll.GetListRptAvanceResultadoVersion(3, pintIdVersionMalla);
                var retorno = Json(retun, JsonRequestBehavior.AllowGet);
                return retorno;

            }
            catch (Exception ex)
            {

                throw new Exception("getSituacionFinalVersion => " + ex.Message);

            }
        }



        public JsonResult getEstadoVersion(int pintIdVersionMalla)
        {
            try
            {

                //wcfserviceMalla.ServicioMallaClient myBll = new wcfserviceMalla.ServicioMallaClient();
                //return Json(myBll.GetListMallas((int)Session["sociedad"], string.Empty));

                var retun = MyBll.GetListRptAvanceVersion(3, pintIdVersionMalla);
                var retorno = Json(retun, JsonRequestBehavior.AllowGet);
                return retorno;

            }
            catch (Exception ex)
            {

                throw new Exception("getEstadoVersion => " + ex.Message);

            }
        }




     




    }
}