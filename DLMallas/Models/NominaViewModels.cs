using System.Collections.Generic;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Dto.Nomina;

namespace DLMallas.Models
{
    public class NominasViewModels
    {
        public string IdItinerario { get; set; }
        public List<DtoNomina>  ListadoNominaAcademia { get; set; }
    }

    public class NominaViewModels
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Asignacion { get; set; }
        public string Avance { get; set; }
        public string UsuarioAsig { get; set; }
    }
}