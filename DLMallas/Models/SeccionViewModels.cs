using DLMallas.Business.Dto.Seccion;
using DLMallas.Business.Dto.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLMallas.Models
{
    public class SeccionViewModels
    {
        public List<ObtenerVersion> ObtenerVersion { get; set; }
        public List<ObtenerListadoSeccion> ObtenerListadoSeccion { get; set; }
        public List<ObtenerSeccion> ObtenerSeccion { get; set; }
    }
}