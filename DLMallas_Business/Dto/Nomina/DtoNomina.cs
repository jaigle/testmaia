using System;

namespace DLMallas.Business.Dto.Nomina
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
