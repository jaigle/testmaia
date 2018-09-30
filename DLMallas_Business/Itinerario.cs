
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
                    ws.AddParameter("IdMalla", mallaId);
                    ws.AddParameter("Nombre", nombre);
                    ws.AddParameter("FechaInicio", fechaInic);
                    ws.AddParameter("FechaTermino", fechaFin);
                    ws.Invoke();
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GuardarParticipantes(string idItinerario, string participantes)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "adicionarNominaItinerario");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("IdItinerario", idItinerario);
                    ws.AddParameter("Lista", participantes);
                    ws.AddParameter("Usuario", Variables.Usuario);
                    ws.Invoke();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarNominasTodos(string idItinerario)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "eliminarNominaItinerario");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("IdItinerario", idItinerario);
                    ws.AddParameter("Todos", "1");
                    ws.AddParameter("Lista", "");
                    ws.Invoke();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarNominasSelecionados(string idItinerario, string ids)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "eliminarNominaItinerario");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("IdItinerario", idItinerario);
                    ws.AddParameter("Todos", "0");
                    ws.AddParameter("Lista", ids);
                    ws.Invoke();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        
        public DtoItinerarioEdit ObtenerItinerario(string id)
        {
            var result = new DtoItinerarioEdit();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerItinerario");
                ws.AddParameter("Id", id);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                var obj = ws.Invoke() as object;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<DtoItinerarioEdit>(json);
            }
            else
            {
                result = new DtoItinerarioEdit().Faker(Convert.ToInt32(id), "0");
            }

            return result;
        }

        public bool ActualizarItinerario(string id, string mallaId, string nombre, string fechaInic, string fechaFin, string activo)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "actualizarItinerario");
                    ws.AddParameter("IdItinerario", id);
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Nombre", nombre);
                    ws.AddParameter("IdMalla", mallaId);
                    ws.AddParameter("Activo", activo);
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

        public List<DtoNomina> ObtenerListadoNomina(string id)
        {
            var result = new List<DtoNomina>();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerListadoNomina");
                ws.AddParameter("IdItinerario", id);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                var obj = ws.Invoke() as object;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<DtoNomina>>(json);
            }
            else
            {
                result = new List<DtoNomina>().Faker(id);
            }

            return result;
        }

        public List<DtoNominaAcademia> ObtenerListadoNominAcademia(string cedulaIdent, string apellidoPat, string apellidoMat, string cargo, string sociedadCont, string unidadOrg, string franquicia, string unidadNeg)
        {
            var result = new List<DtoNominaAcademia>();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "buscarColaboradorAcademia");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Cedula", cedulaIdent);
                ws.AddParameter("Paterno", apellidoPat);
                ws.AddParameter("Materno", apellidoMat);
                ws.AddParameter("Franquicia", franquicia);
                ws.AddParameter("SContratante", sociedadCont);
                ws.AddParameter("UnidadOrganizacional", unidadOrg);
                ws.AddParameter("Cargo", cargo);
                ws.AddParameter("UnidadNegocio", unidadNeg);
                var obj = ws.Invoke() as object;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<DtoNominaAcademia>>(json);
            }
            else
            {
                result = new List<DtoNominaAcademia>().Faker();
            }

            return result;
        }
    }
}