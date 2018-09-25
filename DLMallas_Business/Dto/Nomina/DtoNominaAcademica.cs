using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    public class DtoNominaAcademia
    {
        public int IdPersona { get; set; }
        public string Cedula { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string FranquiciaSence { get; set; }
        public string SociedadContratante { get; set; }
    }
}
