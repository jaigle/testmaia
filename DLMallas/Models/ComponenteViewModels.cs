using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Seccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLMallas.Models
{
    public class ComponenteViewModels
    {
        public List<ObtenerListadoSeccion> ObtenerListadoSeccion { get; set; }
        public List<ObtenerListadoModalidadComponente> ObtenerListadoModalidadComponente { get; set; }
        public List<ObtenerListadoCatalogoCurso> ObtenerListadoCatalogoCurso { get; set; }
        public string IdSeccion { get; set; }
        public string[] IdUnidadCurricular { get; set; }
        public string IdModalidadComponente { get; set; }
    }
}