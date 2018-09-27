using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    public class DtoNomina
    {
        public int IdPersona { get; set; }
        public string Rut { get; set; }
        public string NombreCompleto { get; set; }
        public TimeSpan Asignacion { get; set; }
        public int? Avance { get; set; }
        public string UsuarioAsig { get; set; }
    }
}
