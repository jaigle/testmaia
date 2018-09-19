using DLMallas.Business.Dto.Certificado;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLMallas.Business.Extencions;
using WSLib;

namespace DLMallas.Business
{
    public class Certificado : ServiciosBase
    {
        public DtoCertificado ObtenerCertificado(string id)
        {
            var result = new DtoCertificado();
            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "obtenerMallaCertificado");
                ws.AddParameter("Id", id);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<DtoCertificado>(json);
            }
            else
            {
                //result.Faker(id);
                DtoCertificado obj = new DtoCertificado
                {
                    Cuerpo = DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoCuerpo,
                    Encabezado = DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoEncabezado,
                    EncabezadoListaUC = DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoEncabezadoListaUC,
                    Id = "1",
                    IdSociedad = "1",
                    RutaCertificado = String.Empty,
                    RutaFirma = String.Empty,
                    RutaLogo = String.Empty
                };
                result = obj;
            }
            return result;
        }

        public List<DtoDetalleMallaCertificado> ObtenerDetalleCertificado(string id)
        {
            var result = new List<DtoDetalleMallaCertificado>();

            if (!Offline)
            {
                WebService ws = new WebService("GestionMalla", "ObtenerDetalleCertificado");
                ws.AddParameter("Id", id);
                ws.AddParameter("IdSociedad", Variables.IdSociedad);
                Array obj = ws.Invoke() as Array;

                string json = JsonConvert.SerializeObject(obj);
                result = JsonConvert.DeserializeObject<List<DtoDetalleMallaCertificado>>(json);
            }
            else
            {
                result.Faker();
            }

            return result;
        }

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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
