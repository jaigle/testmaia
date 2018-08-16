using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Seccion;
using DLMallas.Business.Dto.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLMallas.Models
{
    public class VersionViewModels
    {
        public List<ObtenerListadoVersion> ObtenerListadoVersion { get; set; }
        public List<ObtenerVersion> ObtenerVersion { get; set; }
        public List<ObtenerMalla> ObtenerMalla { get; set; }
        public List<ObtenerListadoSeccion> ObtenerListadoSeccion { get; set; }
        public List<ObtenerListadoComponente> ObtenerListadoComponente { get; set; }
        public List<ObtenerComponentePrerrequisito> ObtenerComponentePrerrequisito { get; set; }
    }
}