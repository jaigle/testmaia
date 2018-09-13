using DLMallas.Business.Dto.Componente;
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
    public class Componente
    {
        public List<ObtenerListadoComponente> obtenerListadoComponente(string IdVersion)
        {
            List<ObtenerListadoComponente> list = new List<ObtenerListadoComponente>();
            //WebService ws = new WebService("GestionMalla", "obtenerListadoComponente");
            //ws.AddParameter("IdVersion", IdVersion);
            //Array obj = ws.Invoke() as Array;

            //string json = JsonConvert.SerializeObject(obj);
            //list = JsonConvert.DeserializeObject<List<ObtenerListadoComponente>>(json);



        //public string Id;
        //public string UnidadCurricular;
        //public string Modalidad;
        //public string Seccion;
        //public string Color;


            var modalities = new[] { "Precencial", "eLearning", "Todas" }; 

            for (int i = 0; i < 30; i++)
            {
                var id = i;
                list.Add(new Faker<ObtenerListadoComponente>("es")
                    .StrictMode(true)
                    .RuleFor(r => r.Id, f => (id + 1).ToString())
                    .RuleFor(r => r.UnidadCurricular, f => "UC"+id+1)
                    .RuleFor(r => r.Modalidad, f => f.PickRandom(modalities))
                    .RuleFor(r => r.Seccion, f => "Seccion"+id+1)
                    .RuleFor(r => r.Color, f => f.Internet.Color())
                );
            }
            return list;
        }

        public List<ObtenerComponente> obtenerComponente(string Id)
        {
            List<ObtenerComponente> list = new List<ObtenerComponente>();
            WebService ws = new WebService("GestionMalla", "obtenerComponente");
            ws.AddParameter("Id", Id);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerComponente>>(json);
            return list;
        }

        public List<ObtenerListadoModalidadComponente> obtenerListadoModalidadComponente()
        {
            List<ObtenerListadoModalidadComponente> list = new List<ObtenerListadoModalidadComponente>();
            WebService ws = new WebService("GestionMalla", "obtenerListadoModalidadComponente");
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerListadoModalidadComponente>>(json);
            return list;
        }

        public List<ObtenerListadoCatalogoCurso> obtenerListadoCatalogoCurso()
        {
            List<ObtenerListadoCatalogoCurso> list = new List<ObtenerListadoCatalogoCurso>();
            WebService ws = new WebService("GestionMalla", "obtenerListadoCatalogoCurso");
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerListadoCatalogoCurso>>(json);
            return list;
        }

        public List<ObtenerComponentePrerrequisito> obtenerComponentePrerrequisito(string Id)
        {
            List<ObtenerComponentePrerrequisito> list = new List<ObtenerComponentePrerrequisito>();
            WebService ws = new WebService("GestionMalla", "obtenerComponentePrerrequisito");
            ws.AddParameter("Id", Id);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerComponentePrerrequisito>>(json);
            return list;
        }

        public bool guardarComponente(GuardarComponente model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarComponente");
                ws.AddParameter("IdSociedad", model.IdSociedad);
                ws.AddParameter("IdSeccion", model.IdSeccion);
                ws.AddParameter("IdModalidadComponente", model.IdModalidadComponente);
                ws.AddParameter("IdUnidadCurricular", model.IdUnidadCurricular);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool actualizarComponente(ActualizarComponente model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "actualizarComponente");
                ws.AddParameter("Id", model.Id);
                ws.AddParameter("IdSeccion", model.IdSeccion);
                ws.AddParameter("IdModalidadComponente", model.IdModalidadComponente);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarComponente(string Id)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "eliminarComponente");
                ws.AddParameter("Id", Id);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool guardarPrerrequisito(GuardarPrerrequisito model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarPrerrequisito");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("IdComponente", model.IdComponente);
                ws.AddParameter("IdComponentePrerrequisito", model.IdComponentePrerrequisito);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
