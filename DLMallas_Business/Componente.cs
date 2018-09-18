﻿using DLMallas.Business.Dto.Componente;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using DLMallas.Business.Extencions;
using WSLib;

namespace DLMallas.Business
{
    public class Componente : ServiciosBase
    {
        public List<ObtenerListadoComponente> obtenerListadoComponente(string IdVersion)
        {
            var result = new List<ObtenerListadoComponente>();

            if (!Offline)
            {
                var ws = new WebService("GestionMalla", "obtenerListadoComponente");
                ws.AddParameter("IdVersion", IdVersion);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoComponente>>(json);
            }
            else
            {
                result.Faker();
            }

            return result;
        }

        public List<ObtenerComponente> obtenerComponente(string Id)
        {
            var result = new List<ObtenerComponente>();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerComponente");
                ws.AddParameter("Id", Id);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerComponente>>(json);
            }
            else
            {
                result.Faker(Id);
            }
           
            return result;
        }

        public List<ObtenerListadoModalidadComponente> obtenerListadoModalidadComponente()
        {
            var result = new List<ObtenerListadoModalidadComponente>();

            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerListadoModalidadComponente");
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoModalidadComponente>>(json);
            }
            else
            {
                result.Faker();
            }

            return result;
        }

        public List<ObtenerListadoCatalogoCurso> obtenerListadoCatalogoCurso()
        {
            var result = new List<ObtenerListadoCatalogoCurso>();
            if (!Offline)
            {
                var ws = new WebService("GestionMalla", "obtenerListadoCatalogoCurso");
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoCatalogoCurso>>(json);
            }
            else
            {
                result.Faker();
            }

            return result;
        }

        //String IdVersion, String IdSociedad, String ParaRequesitos, String IdUcActual
        public List<ObtenerListadoComponente> ObtenerListadoPrerrequisitos(string idVersion, string idSociedad, string idUcActual)
        {
            var result = new List<ObtenerListadoComponente>();

            if (!Offline)
            {
                var ws = new WebService("GestionMalla", "obtenerListadoComponente");
                ws.AddParameter("IdVersion", idVersion);
                ws.AddParameter("IdSociedad", idSociedad);
                ws.AddParameter("ParaRequesitos", "1");
                ws.AddParameter("IdUcActual", idUcActual);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<ObtenerListadoComponente>>(json);
            }
            else
            {
                result.Faker(Convert.ToInt32(idUcActual), true);
            }

            return result;
        }

        //public List<ObtenerComponentePrerrequisito> obtenerComponentePrerrequisito(string Id)
        //{
        //    List<ObtenerComponentePrerrequisito> list = new List<ObtenerComponentePrerrequisito>();
        //    WebService ws = new WebService("GestionMalla", "obtenerComponentePrerrequisito");
        //    ws.AddParameter("Id", Id);
        //    Array obj = ws.Invoke() as Array;

        //    string json = JsonConvert.SerializeObject(obj);
        //    list = JsonConvert.DeserializeObject<List<ObtenerComponentePrerrequisito>>(json);
        //    return list;
        //}

        public bool guardarComponente(GuardarComponente model)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "guardarComponente");
                    ws.AddParameter("IdSociedad", model.IdSociedad);
                    ws.AddParameter("IdSeccion", model.IdSeccion);
                    ws.AddParameter("IdModalidadComponente", model.IdModalidadComponente);
                    ws.AddParameter("IdUnidadCurricular", model.IdUnidadCurricular);
                    Array obj = ws.Invoke() as Array;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool actualizarComponente(ActualizarComponente model)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "actualizarComponente");
                    ws.AddParameter("Id", model.Id);
                    ws.AddParameter("IdSeccion", model.IdSeccion);
                    ws.AddParameter("IdModalidadComponente", model.IdModalidadComponente);
                    Array obj = ws.Invoke() as Array;
                }
               
                return true;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool guardarPrerrequisito(GuardarPrerrequisito model)
        {
            try
            {
                if (!Offline)
                {
                    WebService ws = new WebService("GestionMalla", "guardarPrerrequisitos");
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("IdComponente", model.IdComponente);

                    foreach (var item in model.IdComponentePrerrequisitos)
                    {
                        ws.AddParameter("IdComponentePrerrequisito", item);
                    }
                    
                    Array obj = ws.Invoke() as Array;
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
