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
            catch (Exception)
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
                WebService ws = new WebService("GestionMalla", "guardarPrerrequisito");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("IdComponente", model.IdComponente);
                ws.AddParameter("IdComponentePrerrequisito", model.IdComponentePrerrequisito);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
