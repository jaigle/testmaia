using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLMallas.Business;
using DLMallas.Data;

namespace DLMallas.Controllers
{
    public class DbController : Controller
    {
        // GET: Db
        public ActionResult Index()
        {
            //wcfserviceMalla.ServicioMallaClient obj = new wcfserviceMalla.ServicioMallaClient();
            MallasBl obj = new MallasBl();
            return View(obj.GetListMallas(3, string.Empty));
        }

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Visual(int id)
        {
            throw new NotImplementedException();
        }
    }
}