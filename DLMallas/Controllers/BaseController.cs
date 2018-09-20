using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;

namespace DLMallas.Controllers
{
    public class BaseController : Controller
    {
        public Malla _malla { get; set; }
        public Certificado _certificado { get; set; }
        public _Version _version { get; set; }

        public Seccion _seccion { get; set; }

        public Componente _componente { get; set; }

        public Itinerario _Itinerario { get; set; }

        public BaseController()
        {
            _malla = new Malla();
            _certificado = new Certificado();
            _version = new _Version();
            _seccion = new Seccion();
            _componente = new Componente();
            _Itinerario = new Itinerario();
        }
    }
}