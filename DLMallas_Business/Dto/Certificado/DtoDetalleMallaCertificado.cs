using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto.Certificado
{
    public class DtoDetalleMallaCertificado
    {
        public string IdMallaUnidadCurr { get; set; }
        public string NombreUnidadCurricular { get; set; }
        public string Evaluacion { get; set; }
        public string SituacionFinal { get; set; }
        public string FechaExpiracion { get; set; }

        public string Estado { get; set; }

        public string NombreMalla { get; set; }
    }
}
