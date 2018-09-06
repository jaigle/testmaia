
using DLMallas.Business.Dto.Malla;
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
    public class Malla
    {
        public List<ObtenerListadoMalla> obtenerListadoMalla()
        {
            List<ObtenerListadoMalla> result = new List<ObtenerListadoMalla>();
            //WebService ws = new WebService("GestionMalla", "obtenerListadoMalla");
            //ws.AddParameter("IdSociedad", Variables.IdSociedad);
            //Array obj = ws.Invoke() as Array;
            //string json = JsonConvert.SerializeObject(obj);

            //string json = "[{'activo':'1','descripcion':'Esta es una malla creada  coon motivo de probar el desarrollo','fechaCreacion':'2018-07-28 13:49:37.513','id':'2','idSociedad':'1','nombre':'Nueva Malla  para QA','usuarioCreacion':'Administrador DL'}]";
            //Adicionando elementos a la lista;

            //Id,
            //IdSociedad,
            //Escuela,
            //FechaCreacion,
            //Nombre,
            //Descripcion,
            //Activo,
            //UsuarioCreacion,
            //CantVersiones,
            //ItinerariosTotal,
            //ItinerariosActivos

            var userType = new[] { "Adminsitrador", "Profesor", "Estudiante"};
            var users = new[] {"jim","jaigle","ldtoro"};

            for (int i = 0; i < 100; i++)
            {
                var id = i;
                result.Add(new Faker<ObtenerListadoMalla>("es")
                    .StrictMode(true)
                    .RuleFor(r => r.Id, f => (id + 1).ToString())
                    .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                    .RuleFor(r => r.Escuela, f => f.Company.CompanyName())
                    .RuleFor(r => r.FechaCreacion, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                    .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                    .RuleFor(r => r.Descripcion, f => f.Name.JobDescriptor())
                    .RuleFor(r => r.Activo, f => f.Random.Number(0, 1).ToString())
                    .RuleFor(r => r.UsuarioCreacion, f => f.PickRandom(users))
                    .RuleFor(r => r.CantVersiones, f => f.Random.Number(1, 10).ToString())
                    .RuleFor(r => r.ItinerariosTotal, f => f.Random.Number(0, 50).ToString())
                    .RuleFor(r => r.ItinerariosActivos, f => f.Random.Number(0, 50).ToString())
                );
            }

            return result;
        }

        public List<ObtenerMalla> obtenerMalla(string Id)
        {
            List<ObtenerMalla> list = new List<ObtenerMalla>();
            WebService ws = new WebService("GestionMalla", "obtenerMalla");
            ws.AddParameter("Id", Id);
            ws.AddParameter("IdSociedad", Variables.IdSociedad);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerMalla>>(json);
            return list;
        }

        public bool guardarMalla(GuardarMalla model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarMalla");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Nombre", model.Nombre);
                ws.AddParameter("Descripcion", model.Descripcion);
                ws.AddParameter("Activo", model.Activo);
                ws.AddParameter("UsuarioCreacion", Variables.IdPersona);
                ws.Invoke();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool actualizarMalla(ActualizarMalla model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "actualizarMalla");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Id", model.Id);
                ws.AddParameter("Nombre", model.Nombre);
                ws.AddParameter("Descripcion", model.Descripcion);
                ws.AddParameter("Activo", model.Activo);
                ws.Invoke();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarMalla(string Id)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "eliminarMalla");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Id", Id);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}