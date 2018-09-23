
using DLMallas.Business.Dto.Malla;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Bogus;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Extencions;
using WSLib;

namespace DLMallas.Business
{
    public class Itinerario : ServiciosBase
    {
        public List<DtoItinerario> ObtenerListadoItinerarioMalla(string idMalla)
        {
            var result = new List<DtoItinerario>();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerListadoItinerarioMalla");
                ws.AddParameter("IdMalla", idMalla);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<DtoItinerario>>(json);
            }
            else
            {
                result.Faker(idMalla);
            }

            return result;
        }

        public bool GuardarItinerario(string mallaId, string nombre, string fechaInic, string fechaFin)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "guardarItinerario");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Nombre", nombre);
                    ws.AddParameter("IdMalla", mallaId);
                    ws.AddParameter("FechaInicio", fechaInic);
                    ws.AddParameter("FechaTermino", fechaFin);
                    ws.Invoke();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}