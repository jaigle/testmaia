using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Contracts
{
   public class DtoColaboradores
    {

        public int IdPersona { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int UnidadOrganizacional { get; set; }
        public int UnidadNegocio { get; set; }
        public int Cargo { get; set; }
        public bool Activo { get; set; }
        public int PerfilId { get; set; }
        public string PerfilNombre { get; set; }
        public string PerfilDescripcion { get; set; }
        public int IdVersion { get; set; }
        public string NombreVersionMalla { get; set; }
        public int Estado { get; set; }
       
       
    }
}
