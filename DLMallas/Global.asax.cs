using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DLMallas.Business;
using Microsoft.AspNet.Identity;
using DLMallas.Utilidades;
using System.Web.UI;


namespace DLMallas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Session_Start(object sender, EventArgs e)
        {           
            Session["idversion"] = 0;
            try
            {

                //var identity = (ClaimsIdentity)User.Identity; jaigle

                //var cookieSociedad = identity.Claims.Where(p => p.Type == "urn:digital-learning/id-sociedad").FirstOrDefault(); jaigle
                var cookieSociedad = new Claim("urn:digital-learning/id-sociedad", "1");
                if (cookieSociedad == null)
                {
                    //Buscar IdSociedad en URL
                    var idSociedad = Request.QueryString["Sociedad"];
                    if (idSociedad != null)
                    {
                        var seguridadSvc = new Seguridad();
                        Variables.UrlHcm = seguridadSvc.ObtenerParametroAplicacion(idSociedad, "UrlHcm");
                        Variables.Login = seguridadSvc.ObtenerParametroAplicacion(idSociedad, "Login");

                        string localUrl = Request.Url.AbsoluteUri;

                        string path = Variables.UrlHcm + "/" + Variables.Login + "?RedirectTo=" + localUrl;
                        Session.Abandon();
                        Response.Redirect(path);
                    }
                    else //no hay cookie ni idSociedad en la url
                    {
                        Response.Redirect("Error?message=Este contenido no esta disponible.=Este contenido no esta disponible");
                    }
                }
                else
                {
                    //String[] result = identity.Name.Split('|');jaigle
                    var idUsuario = "0";
                    var seguridadSvc = new Seguridad();
                    //seguridadSvc.ActualizarVariablesSistema(cookieSociedad.Value.ToString(), User.Identity.GetUserId().ToString(), idUsuario.ToString());jaigle
                    seguridadSvc.ActualizarVariablesSistemafake("1", "admin", "0");
                }
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }   
        }      
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
