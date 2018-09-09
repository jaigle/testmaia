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
        public Malla _malla;
        public BaseController()
        {
            _malla = new Malla();
        }
    }
}