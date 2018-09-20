using DLMallas.Business;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Certificado;
using DLMallas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLMallas.Controllers
{
    [Authorize]
    public class CertificadoController : BaseController
    {
        [Authorize]
        public ActionResult Index(string id)
        {
            CertificadoViewModels model = new CertificadoViewModels();
            model.ObtenerMalla = _malla.ObtenerMalla(id);
            model.ObtenerCertificado = _certificado.ObtenerCertificado(1.ToString());
            model.ObtenerDetalleCertificado = _certificado.ObtenerDetalleCertificado(id);
            return View(model);
        }

        public ActionResult VistaPrevia(string id)
        {
            CertificadoViewModels model = new CertificadoViewModels();
            model.ObtenerDetalleCertificado = _certificado.ObtenerDetalleCertificado(id);
            return View(model);
        }

        public string guardarLogo(HttpPostedFileBase filelogo, string idmalla)
        {
            var miResultado = new DtoJsonResult();
            string nombrearchivo1 = filelogo.FileName.ToString();
            nombrearchivo1 = Right(nombrearchivo1, 3);
            bool resp;
            if (nombrearchivo1.Equals("jpg") || nombrearchivo1.Equals("bmp") || nombrearchivo1.Equals("gif") || nombrearchivo1.Equals("png") || nombrearchivo1.Equals("svgp") || nombrearchivo1.Equals("tiff") || nombrearchivo1.Equals("dds") || nombrearchivo1.Equals("wdp") || nombrearchivo1.Equals("emf") || nombrearchivo1.Equals("ico") || nombrearchivo1.Equals("wmf"))
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var ext = "." + filelogo.FileName.Split('.').Last();
                fileName += ext;
                if (filelogo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/imports"), fileName);
                    var pathfinal = Path.Combine("~/imports", fileName);
                    GuardarArchivo model = new GuardarArchivo();
                    Certificado c = new Certificado();
                    model.IdMalla = idmalla;
                    model.Ruta = pathfinal;
                    resp = c.guardarLogo(model);
                    if (resp)
                    {
                        miResultado.exito = true;
                        return Utilidades.Acciones.serializarObjeto(miResultado);
                    }                  
                    else
                    if (resp)
                    {
                        miResultado.exito = false;
                        return Utilidades.Acciones.serializarObjeto(miResultado);
                    }
                }
            }
            else
            {

                miResultado.mensaje = "Extension del archivo invalida";
                return Utilidades.Acciones.serializarObjeto(miResultado);
            }
            miResultado.mensaje = "Se detecto un archivo vacio. Seleccione otro por favor.";
            return Utilidades.Acciones.serializarObjeto(miResultado);
        }

        public bool guardarImg(HttpPostedFileBase fileimg, string idmalla)
        {
            string nombrearchivo1 = fileimg.FileName.ToString();
            nombrearchivo1 = Right(nombrearchivo1, 3);
            bool resp;
            if (nombrearchivo1.Equals("jpg") || nombrearchivo1.Equals("bmp") || nombrearchivo1.Equals("gif") || nombrearchivo1.Equals("png") || nombrearchivo1.Equals("svgp") || nombrearchivo1.Equals("tiff") || nombrearchivo1.Equals("dds") || nombrearchivo1.Equals("wdp") || nombrearchivo1.Equals("emf") || nombrearchivo1.Equals("ico") || nombrearchivo1.Equals("wmf"))
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var ext = "." + fileimg.FileName.Split('.').Last();
                fileName += ext;
                if (fileimg.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/imports"), fileName);
                    var pathfinal = Path.Combine("~/imports", fileName);
                    GuardarArchivo model = new GuardarArchivo();
                    Certificado c = new Certificado();
                    model.IdMalla = idmalla;
                    model.Ruta = pathfinal;
                    resp = c.guardarImg(model);
                    if (resp)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool guardarFirma(HttpPostedFileBase filefirma, string idmalla)
        {
            string nombrearchivo1 = filefirma.FileName.ToString();
            nombrearchivo1 = Right(nombrearchivo1, 3);
            bool resp;
            if (nombrearchivo1.Equals("jpg") || nombrearchivo1.Equals("bmp") || nombrearchivo1.Equals("gif") || nombrearchivo1.Equals("png") || nombrearchivo1.Equals("svgp") || nombrearchivo1.Equals("tiff") || nombrearchivo1.Equals("dds") || nombrearchivo1.Equals("wdp") || nombrearchivo1.Equals("emf") || nombrearchivo1.Equals("ico") || nombrearchivo1.Equals("wmf"))
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "");
                var ext = "." + filefirma.FileName.Split('.').Last();
                fileName += ext;
                if (filefirma.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/imports"), fileName);
                    var pathfinal = Path.Combine("~/imports", fileName);
                    GuardarArchivo model = new GuardarArchivo();
                    Certificado c = new Certificado();
                    model.IdMalla = idmalla;
                    model.Ruta = pathfinal;
                    resp = c.guardarFirma(model);
                    if (resp)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }
    }
}