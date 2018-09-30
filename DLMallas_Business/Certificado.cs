using DLMallas.Business.Dto.Certificado;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Malla;
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
                result = (JsonConvert.DeserializeObject<List<DtoCertificado>>(json)).First();
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
                    RutaCertificado = "/imports/7a3e33c63bd34bdda03d6f588656f7cb.jpg",
                    RutaFirma = "/imports/8e27427c0a1448f19716eacc5af609d4.jpg",
                    RutaLogo = "/imports/7a3e33c63bd34bdda03d6f588656f7cb.jpg"
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
                WebService ws = new WebService("GestionMalla", "obtenerMallaCertificadoVistaPrevia");
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
            if (!Offline)
            {
                try
                {
                    WebService ws = new WebService("GestionMalla", "guardarLogo");
                    ws.AddParameter("IdMalla", model.IdMalla);
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("RutaLogo", model.Ruta);
                    Array obj = ws.Invoke() as Array;
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public Dto.DtoJsonResult guardarImg(GuardarArchivo model)
        {
            try
            {
                if (!Offline)
                {

                    WebService ws = new WebService("GestionMalla", "guardarImg");
                    ws.AddParameter("IdMalla", model.IdMalla);
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("RutaLogo", model.Ruta);
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
                    return new DtoJsonResult
                    {
                        exito = true,
                        mensaje = "Operacion exitosa"
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
            
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

        public bool guardarFirma(GuardarArchivo model)
        {
            if (!Offline)
            {
                try
                {
                    WebService ws = new WebService("GestionMalla", "guardarFirma");
                    ws.AddParameter("IdMalla", model.IdMalla);
                    ws.AddParameter("IdSociedad", Variables.IdSociedad);
                    ws.AddParameter("RutaLogo", model.Ruta);
                    Array obj = ws.Invoke() as Array;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else {
                return true;
            }
        }
    }
}
