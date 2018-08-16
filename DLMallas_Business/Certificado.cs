using DLMallas.Business.Dto.Certificado;
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
    public class Certificado
    {
        public bool guardarLogo(GuardarArchivo model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarLogo");
                ws.AddParameter("IdMalla", model.IdMalla);
                ws.AddParameter("RutaLogo", model.Ruta);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool guardarImg(GuardarArchivo model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarImg");
                ws.AddParameter("IdMalla", model.IdMalla);
                ws.AddParameter("RutaLogo", model.Ruta);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool guardarFirma(GuardarArchivo model)
        {
            try
            {
                WebService ws = new WebService("GestionMalla", "guardarFirma");
                ws.AddParameter("IdMalla", model.IdMalla);
                ws.AddParameter("RutaLogo", model.Ruta);
                Array obj = ws.Invoke() as Array;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
