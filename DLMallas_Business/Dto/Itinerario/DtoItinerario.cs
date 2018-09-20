using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto.Itinerario
{
    public class DtoItinerario
    {
        public string Nombre { get; set; }
        public string Malla { get; set; }
        public string Vigencia { get; set; }
        public string Inscriptos { get; set; }
        public string Estado { get; set; }
        public string AvanUC { get; set; }
        public string AvanColab { get; set; }
    }

    public class DtoNotificacionItinerario
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Seleccionado { get; set; }
    }

    public class DtoListadoNomina
    {
        public string IdPersona { get; set; }
        public string Rut { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Asignacion { get; set; }
        public string Avance { get; set; }
    }
}
