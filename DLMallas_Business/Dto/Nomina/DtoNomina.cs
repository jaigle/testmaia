using System;

namespace DLMallas.Business.Dto.Nomina
{
    public class DtoNomina
    {
        public int IdPersona { get; set; }
        public string Rut { get; set; }
        public string NombreCompleto { get; set; }
        public string Asignacion { get; set; }
        public string Avance { get; set; }
        public string UsuarioAsig { get; set; }
    }
}
