﻿using DLMallas.Business.Dto.Seccion;
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
    public class Seccion
    {
        public List<ObtenerListadoSeccion> obtenerListadoSeccion(string IdVersion) 
        {
            try
            {
                List<ObtenerListadoSeccion> list = new List<ObtenerListadoSeccion>();
                WebService ws = new WebService("GestionMalla", "ObtenerListadoSeccion");
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                ws.AddParameter("IdVersion", IdVersion);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                list = JsonConvert.DeserializeObject<List<ObtenerListadoSeccion>>(json);
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ObtenerSeccion> obtenerSeccion(string Id)
        {
            List<ObtenerSeccion> list = new List<ObtenerSeccion>();
            WebService ws = new WebService("GestionMalla", "obtenerSeccion");
            ws.AddParameter("Id", Id);
            Array obj = ws.Invoke() as Array;

            string json = JsonConvert.SerializeObject(obj);
            list = JsonConvert.DeserializeObject<List<ObtenerSeccion>>(json);
            return list;
        }

        public bool guardarSeccion(GuardarSeccion model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarSeccion");
                ws.AddParameter("IdSociedad", model.IdSociedad);
                ws.AddParameter("IdVersion", model.IdVersion);
                ws.AddParameter("Nombre", model.Nombre);
                ws.AddParameter("Color", model.Color);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool actualizarSeccion(ActualizarSeccion model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "actualizarSeccion");
                ws.AddParameter("Id", model.Id);
                ws.AddParameter("Nombre", model.Nombre);
                ws.AddParameter("Color", model.Color);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarSeccion(string Id)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "eliminarSeccion");
                ws.AddParameter("Id", Id);
                ws.Invoke();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
