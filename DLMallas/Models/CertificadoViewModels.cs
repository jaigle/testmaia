using DLMallas.Business.Dto.Certificado;
using DLMallas.Business.Dto.Malla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLMallas.Models
{
    public class CertificadoViewModels
    {
        public List<ObtenerMalla> ObtenerMalla { get; set; }
        public DtoCertificado ObtenerCertificado { get; set; }
        public List<DtoDetalleMallaCertificado> ObtenerDetalleCertificado { get; set; }
    }
}