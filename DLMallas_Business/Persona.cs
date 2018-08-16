using DLMallas.Business.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSLib;

namespace DLMallas.Business
{
    public class Persona
    {
        public List<DtoPersona> GetListadoPersonas(string idSociedad, string registrosPorPagina, string paginaActual, string nombreActual)
        {
            WebService ws = new WebService("GOP", "obtenerPersonasPorFiltro");
            ws.AddParameter("IdSociedad", idSociedad); //"4164"
            ws.AddParameter("RegistrosPorPagina", registrosPorPagina); //"10"
            ws.AddParameter("PaginaActual", paginaActual);//1
            ws.AddParameter("Nombre", nombreActual);//opcional
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            List<DtoPersona> lstPersona = JsonConvert.DeserializeObject<List<DtoPersona>>(json);

            return lstPersona;
        }

        public DtoPersona GetPersonaPorId(string idSociedad, string idPersona)
        {
            //WebService ws = new WebService("GOP", "obtenerPersonaPorId");
            //ws.AddParameter("IdSociedad", idSociedad); //"4164"
            //ws.AddParameter("IdPersona", idPersona); //"10"
            //Array obj = ws.Invoke() as Array;

            //string json = JsonConvert.SerializeObject(obj);
            //List<DtoPersona> lstPersona = JsonConvert.DeserializeObject<List<DtoPersona>>(json);
            //return lstPersona.First();

            List<DtoPersona> lstPersona = new List<DtoPersona>();
            DtoPersona aPersona = new DtoPersona();
            aPersona.Nombre = "Jose";
            return aPersona;
        }
    }
}
