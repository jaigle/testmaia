
using DLMallas.Business.Dto.Malla;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSLib;

namespace DLMallas.Business
{
    public class Malla
    {
        public List<ObtenerListadoMalla> obtenerListadoMalla()
        {
            List<ObtenerListadoMalla> lista = new List<ObtenerListadoMalla>();
            //WebService ws = new WebService("GestionMalla", "obtenerListadoMalla");
            //ws.AddParameter("IdSociedad", Variables.IdSociedad);
            //Array obj = ws.Invoke() as Array;
            //string json = JsonConvert.SerializeObject(obj);

            //string json = "[{'activo':'1','descripcion':'Esta es una malla creada  coon motivo de probar el desarrollo','fechaCreacion':'2018-07-28 13:49:37.513','id':'2','idSociedad':'1','nombre':'Nueva Malla  para QA','usuarioCreacion':'Administrador DL'}]";
            //Adicionando elementos a la lista;
            ObtenerListadoMalla elem1 = new ObtenerListadoMalla {
                Activo = "1",
                Descripcion = "Esta es una malla creada  coon motivo de probar el desarrollo",
                FechaCreacion = "2018-07-28 13:49:37.513",
                Id = "2",
                IdSociedad = "1",
                Nombre = "Nueva Malla para QA",
                UsuarioCreacion = "Adminsitrador"
            };
            lista.Add(elem1); 
            //lista = JsonConvert.DeserializeObject<List<ObtenerListadoMalla>>(json);
            return lista;
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