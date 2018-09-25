using DLMallas.Business.Dto.Seccion;
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
    public class Seccion : ServiciosBase
    {
        public List<ObtenerListadoSeccion> obtenerListadoSeccion(string IdVersion) 
        {
            try
            {
                List<ObtenerListadoSeccion> list = new List<ObtenerListadoSeccion>();
                if (!Offline)
                {

                    WebService ws = new WebService("GestionMalla", "ObtenerListadoSeccion");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("IdVersion", IdVersion);
                    Array obj = ws.Invoke() as Array;

                    string json = JsonConvert.SerializeObject(obj);
                    list = JsonConvert.DeserializeObject<List<ObtenerListadoSeccion>>(json);
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var id = i;
                        var item = new Faker<ObtenerListadoSeccion>("es")
                            .StrictMode(true)
                            .RuleFor(r => r.Id, f => id + 1.ToString())
                            .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                            .RuleFor(r => r.IdVersion, f => IdVersion)
                            .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                            .RuleFor(r => r.Color, f => f.Internet.Color());
                        list.Add(item);
                    }
                }

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ObtenerSeccion> obtenerSeccion(string Id)
        {
            List<ObtenerSeccion> list = new List<ObtenerSeccion>();

            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "obtenerSeccion");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", Id);
                    Array obj = ws.Invoke() as Array;

                    string json = JsonConvert.SerializeObject(obj);
                    list = JsonConvert.DeserializeObject<List<ObtenerSeccion>>(json);
                    return list;
                }
                else
                {
                    for (int i = 0; i < 1; i++)
                    {
                        var id = i;
                        var item = new Faker<ObtenerSeccion>("es")
                            .StrictMode(true)
                            .RuleFor(r => r.Id, f => id + 1.ToString())
                            .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                            .RuleFor(r => r.IdVersion, f => 1.ToString())
                            .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                            .RuleFor(r => r.Color, f => f.Internet.Color());
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool guardarSeccion(GuardarSeccion model)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "guardarSeccion");
                    ws.AddParameter("IdSociedad", model.IdSociedad);
                    ws.AddParameter("IdVersion", model.IdVersion);
                    ws.AddParameter("Nombre", model.Nombre);
                    ws.AddParameter("Color", model.Color);
                    Array obj = ws.Invoke() as Array;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool actualizarSeccion(ActualizarSeccion model)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "actualizarSeccion");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", model.Id);
                    ws.AddParameter("Nombre", model.Nombre);
                    ws.AddParameter("Color", model.Color);
                    Array obj = ws.Invoke() as Array;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarSeccion(string Id)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "eliminarSeccion");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", Id);
                    ws.Invoke();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
