using DLMallas.Business.Dto.Malla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLMallas.Models
{
    public class MallaViewModels
    {
        public List<ObtenerListadoMalla> ObtenerListadoMalla { get; set; }
        public List<ObtenerMalla> ObtenerMalla { get; set; }
        public string NombrePersonaLogin { get; set; }
        public string FechaHoy { get; set; }
    }
}