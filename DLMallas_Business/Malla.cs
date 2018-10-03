
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
    public class Malla : ServiciosBase
    {
        public List<ObtenerListadoMalla> ObtenerListadoMalla()
        {
            var result = new List<ObtenerListadoMalla>();

            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerListadoMalla");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("Nombre", "");
                ws.AddParameter("Escuela", "");
                Array obj = ws.Invoke() as Array;
                var json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoMalla>>(json);
            }
            else
            {
                result.Faker();
            }

            return result;
        }

        public List<Escuela> ObtenerEsceulas()
        {
            List<Escuela> result = new List<Escuela>();
           if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerEscuelas");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                Array obj = ws.Invoke() as Array;
                var json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<Escuela>>(json);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    var id = i;
                    result.Add(new Faker<Escuela>("es")
                        .RuleFor(r => r.Id, f => (id + 1))
                        .RuleFor(r => r.Nombre, f => f.Company.CompanyName())
                    );
                }
            }
            return result;
        }

        public List<ObtenerMalla> ObtenerMalla(string id)
        {
            var result = new List<ObtenerMalla>();

            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerMalla");
                ws.AddParameter("Id", id);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerMalla>>(json);
            }
            else
            {
                result = null; //.Faker(id);
            }

            return result;
        }

        public DtoOperacionResult ObtenerMallajson(string id)
        {
            var result = new DtoOperacionResult();

            if (!Offline)
            {
                try
                {
                    WebService ws = new WebService("GestionMalla", "obtenerMallaJSON");
                    ws.AddParameter("Id", id);
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    Array obj = ws.Invoke() as Array;

                    string json = JsonConvert.SerializeObject(obj);
                    result = JsonConvert.DeserializeObject<DtoOperacionResult>(json);
                }
                catch (Exception e)
                {
                    result.errorCode = 100;
                    result.mensaje = e.Message;
                    return result;
                }
               
            }
            else
            {
                result = null; //.Faker(id);
            }

            return result;
        }

        public bool GuardarMalla(GuardarMalla model)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "guardarMalla");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Nombre", model.Nombre);
                    ws.AddParameter("Descripcion", model.Descripcion);
                    ws.AddParameter("Activo", model.Activo);
                    ws.AddParameter("UsuarioCreacion", Variables.IdPersona);
                    ws.AddParameter("Escuela", model.Escuela);
                    Array obj = ws.Invoke() as Array;

                    string json = JsonConvert.SerializeObject(obj);
                    List<DtoResponse> result = JsonConvert.DeserializeObject<List<DtoResponse>>(json);
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarMalla(ActualizarMalla model)
        {
            try
            {
                if (!Offline)
                {
                    var ws = new WebService("GestionMalla", "guardarMalla");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", model.Id);
                    ws.AddParameter("Nombre", model.Nombre);
                    ws.AddParameter("Descripcion", model.Descripcion);
                    ws.AddParameter("Activo", model.Activo);
                    ws.AddParameter("Escuela", model.IdEscuela);
                    ws.Invoke();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DtoJsonResult EliminarMalla(string id)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "eliminarMalla");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", id);
                    Array obj = ws.Invoke() as Array;
                    var json = JsonConvert.SerializeObject(obj);
                    List<DtoOperacionResult> result = new List<DtoOperacionResult>();
                    result = JsonConvert.DeserializeObject<List<DtoOperacionResult>>(json);
                    DtoJsonResult resultado = _TransformarMensaje(result[0]);
                    if (resultado.exito)
                        return resultado;
                    throw new Exception(resultado.mensaje);
                }
                else
                {
                    return new DtoJsonResult {
                           exito = true,
                           mensaje = "Operacion exitosa"
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eliminar Malla: Ocurrió un error al momento de ejecutar la operación. Detalles :" + ex.Message);
            }
        }

        private DtoJsonResult _TransformarMensaje(Array obj)
        {
            DtoJsonResult miResultado = new DtoJsonResult
            {
                exito = false,
                mensaje = "falso mensaje",
                valor = ""
            };
            return miResultado;
        }

        private DtoJsonResult _TransformarMensaje(DtoOperacionResult obj)
        {
            DtoJsonResult miResultado = new DtoJsonResult
            {
                exito = (obj.errorCode == 0),
                mensaje = obj.mensaje,
                valor = obj.resultado
            };
            return miResultado;
        }
    }
}