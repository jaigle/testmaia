using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLMallas.Controllers
{
    public class HomeController : Controller
    {
        public static int pintIdMalla = 0;
        // GET: Home


      
        public ActionResult Index()
        {
          //  Session["IdMalla"] = 0;
           
            return View();
        }


        public void CerrarSesion(string direccion)
        {

            try
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect(direccion + "/logout.aspx");

            }
            catch (Exception ex)
            {

                throw new Exception("CerrarSesion => " + ex.Message);
            }

            
        }
    }
}