using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace DLMallas.Utilidades
{
    public static class Enumeracion
    {
        
    }

    public static class Variables
    {
        public static string IdSociedad
        {
            get
            {
                if (HttpContext.Current.Session["IdSociedad"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["IdSociedad"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["IdSociedad"] = value;
            }
        }

        public static string IdPersona
        {
            get
            {
                if (HttpContext.Current.Session["IdPersona"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["IdPersona"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["IdPersona"] = value;
            }
        }
        public static string NombrePersona
        {
            get
            {
                if (HttpContext.Current.Session["NombrePersona"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["NombrePersona"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["NombrePersona"] = value;
            }
        }
        public static string Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["Usuario"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }
        public static string MailSoporte
        {
            get
            {
                if (HttpContext.Current.Session["MailSoporte"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["MailSoporte"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["MailSoporte"] = value;
            }
        }
        public static string FonoSoporte
        {
            get
            {
                if (HttpContext.Current.Session["FonoSoporte"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["FonoSoporte"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["FonoSoporte"] = value;
            }
        }
        public static string UrlHcm
        {
            get
            {
                if (HttpContext.Current.Session["UrlHcm"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["UrlHcm"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["UrlHcm"] = value;
            }
        }
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["Login"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Login"] = value;
            }
        }
    }
}
