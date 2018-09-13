using DLMallas.Business.Dto.Version;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using WSLib;

namespace DLMallas.Business
{
    public class _Version
    {
        public List<ObtenerListadoVersion> obtenerListadoVersion(string IdMalla)
        {
            var list = new List<ObtenerListadoVersion>();
            //WebService ws = new WebService("GestionMalla", "obtenerListadoVersion");
            //ws.AddParameter("IdSociedad", Variables.IdSociedad);
            //ws.AddParameter("IdMalla", IdMalla);
            //Array obj = ws.Invoke() as Array;

            //string json = JsonConvert.SerializeObject(obj);
            //list = JsonConvert.DeserializeObject<List<ObtenerListadoVersion>>(json);

            /*
             *  public string Id;
	    public string IdSociedad;
	    public string IdMalla;
	    public string Version;
	    public string FechaInicio;
	    public string FechaTermino;
        public string TotalComponente;
             */


            for (int i = 0; i < 50; i++)
            {
                var id = i;
                list.Add(new Faker<ObtenerListadoVersion>("es")
                    .StrictMode(true)
                    .RuleFor(r => r.Id, f => (id + 1).ToString())
                    .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                    .RuleFor(r => r.IdMalla, f => f.Random.Number(1, 100).ToString())
                    .RuleFor(r => r.Version, f => f.Random.Number(1, 40).ToString())
                    .RuleFor(r => r.FechaInicio, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                    .RuleFor(r => r.FechaTermino, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                    .RuleFor(r => r.TotalComponente, f => f.Random.Number(1, 200).ToString()));
            }
            return list;
        }

        public List<ObtenerVersion> obtenerVersion(string Id)
        {
            List<ObtenerVersion> list = new List<ObtenerVersion>();
            //WebService ws = new WebService("GestionMalla", "obtenerVersion");
            //ws.AddParameter("IdSociedad", Variables.IdSociedad);
            //ws.AddParameter("Id", Id);

            //Array obj = ws.Invoke() as Array;

            //string json = JsonConvert.SerializeObject(obj);
            //list = JsonConvert.DeserializeObject<List<ObtenerVersion>>(json);

            list.Add(new Faker<ObtenerVersion>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => Id.ToString())
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.IdMalla, f => f.Random.Number(1, 100).ToString())
                .RuleFor(r => r.Version, f => f.Random.Number(1, 40).ToString())
                .RuleFor(r => r.FechaInicio, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.FechaTermino, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture)));
            return list;
        }

        public bool guardarVersion(GuardarVersion model)
        {
            try
            {
                //WebService ws = new WebService("GestionMalla", "guardarVersion");
                //ws.AddParameter("IdMalla", model.IdMalla);
                //ws.AddParameter("IdSociedad", model.IdSociedad);
                //ws.AddParameter("FechaInicio", model.FechaInicio);
                //Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public bool actualizarVersion(ActualizarVersion model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "actualizarVersion");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Id", model.Id);
                ws.AddParameter("FechaInicio", model.FechaInicio);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool eliminarVersion(string Id)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "eliminarVersion");
                ws.AddParameter("Id", Id);
                ws.Invoke();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /*

        public List<ListadoSeccion> obtenerListadoSecciones(int idMalla)
        {
            List<ListadoSeccion> list = new List<ListadoSeccion>();
            WebService ws = new WebService("GestionMalla", "obtenerListadoSecciones");
            ws.AddParameter("idMalla", idMalla.ToString());
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoSeccion>>(json);
            return list;
        }

        public List<ListadoUC> obtenerListadoUc(int idMalla)
        {
            List<ListadoUC> list = new List<ListadoUC>();
            WebService ws = new WebService("GestionMalla", "obtenerListadoUc");
            ws.AddParameter("idMalla", idMalla.ToString());
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoUC>>(json);
            return list;
        }

        

        

        public List<ListadoSeccion> obtenerSeccionesDeVersion(string idVersion)
        {
            List<ListadoSeccion> list = new List<ListadoSeccion>();
            WebService ws = new WebService("GestionMalla", "obtenerSeccionesDeVersion");
            ws.AddParameter("idVersion", idVersion);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoSeccion>>(json);
            return list;
        }

        public List<ListadoUC> obtenerComponentesDeVersion(string idVersion)
        {
            List<ListadoUC> list = new List<ListadoUC>();
            WebService ws = new WebService("GestionMalla", "obtenerComponentesDeVersion");
            ws.AddParameter("idVersion", idVersion);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoUC>>(json);
            return list;
        }

        

        public List<ListadoSeccion> ObtenerSeccion(string  id) 
        {
            WebService ws = new WebService("GestionMalla", "obtenerSeccion");
            ws.AddParameter("idSeccion", id);
            Array obj = ws.Invoke() as Array;

            List<ListadoSeccion> list = new List<ListadoSeccion>();
            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoSeccion>>(json);
            return list;
        }

        public void GuardarSeccion(DtoVersion model)
        {
            WebService ws = new WebService("GestionMalla", "guardarSeccion");
            ws.AddParameter("idSociedad", Variables.IdSociedad);
            ws.AddParameter("idVersion", model.idVersionMalla);
            ws.AddParameter("nombreSeccion", model.nombreSeccion);
            ws.AddParameter("colorSeccion", model.colorSeccion);
            ws.Invoke();
        }

        public void ActualizarSeccion(DtoVersion model)
        {
            WebService ws = new WebService("GestionMalla", "actualizarSeccion");
            ws.AddParameter("idSeccion", model.idSociedad);
            ws.AddParameter("nombreSeccion", model.nombreSeccion);
            ws.AddParameter("colorSeccion", model.colorSeccion);
            ws.Invoke();
        }

        public void EliminarSeccion(string idSeccion)
        {
            WebService ws = new WebService("GestionMalla", "eliminarSeccion");
            ws.AddParameter("idSeccion", idSeccion);
            ws.Invoke();
        }

        public List<ListadoCatalogoCurso> ObtenerListadoCatalogoCurso()
        {
            WebService ws = new WebService("GestionMalla", "obtenerListadoCatalogoCurso");
            Array obj = ws.Invoke() as Array;

            List<ListadoCatalogoCurso> list = new List<ListadoCatalogoCurso>();
            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoCatalogoCurso>>(json);
            return list;
        }

        public List<ListadoModalidadComponente> ObtenerListadoModalidadComponente()
        {
            WebService ws = new WebService("GestionMalla", "obtenerListadoModalidadComponente");
            Array obj = ws.Invoke() as Array;

            List<ListadoModalidadComponente> list = new List<ListadoModalidadComponente>();
            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoModalidadComponente>>(json);
            return list;
        }

        public List<ListadoUC> ObtenerUC(string idUnidadCurricular) 
        {
            WebService ws = new WebService("GestionMalla", "obtenerUC");
            ws.AddParameter("idUnidadCurricular", idUnidadCurricular);
            Array obj = ws.Invoke() as Array;

            List<ListadoUC> list = new List<ListadoUC>();
            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ListadoUC>>(json);
            return list;
        }

        public void GuardarUC(string idSeccion, string idModalidadComponente, string idUC)
        {
            WebService ws = new WebService("GestionMalla", "guardarUC");
            ws.AddParameter("idSociedad", Variables.IdSociedad);
            ws.AddParameter("idSeccion", idSeccion);
            ws.AddParameter("idModalidadComponente", idModalidadComponente);
            ws.AddParameter("idUC", idUC);
            ws.Invoke();
        }
         * */
    }
}
