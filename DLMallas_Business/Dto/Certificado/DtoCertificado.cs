using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto.Certificado
{
    public class DtoCertificado
    {
        public string Id { get; set; }
        public string IdSociedad { get; set; }
        public string Cuerpo { get; set; }
        public string Encabezado { get; set; }
        public string EncabezadoListaUC { get; set; }
        public string RutaCertificado { get; set; }
        public string RutaFirma { get; set; }
        public string RutaLogo { get; set; }
    }
}
