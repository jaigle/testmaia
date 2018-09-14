
using DLMallas.Business.Dto.Malla;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Bogus;
using DLMallas.Business.Dto;
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
                Array obj = ws.Invoke() as Array;
                var json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoMalla>>(json);
            }
            else
            {
                result = result.Faker();
            }

            return result;
        }

        public List<Escuela> ObtenerEsceulas()
        {
            List<Escuela> result = new List<Escuela>();

            for (int i = 0; i < 10; i++)
            {
                var id = i;
                result.Add(new Faker<Escuela>("es")
                    .RuleFor(r => r.Id, f => (id + 1))
                    .RuleFor(r => r.Nombre, f => f.Company.CompanyName())
                );
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
                result.Faker(id);
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
                    ws.AddParameter("Escuela", model.Escuela);
                    ws.AddParameter("Descripcion", model.Descripcion);
                    ws.AddParameter("Activo", model.Activo);
                    ws.AddParameter("UsuarioCreacion", Variables.IdPersona);
                    ws.Invoke();
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
                    var ws = new WebService("GestionMalla", "actualizarMalla");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", model.Id);
                    ws.AddParameter("Nombre", model.Nombre);
                    ws.AddParameter("Descripcion", model.Descripcion);
                    ws.AddParameter("Activo", model.Activo);
                    ws.Invoke();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarMalla(string id)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "eliminarMalla");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("Id", id);
                    Array obj = ws.Invoke() as Array;

                    string json = JsonConvert.SerializeObject(obj);
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