using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    /*clase viewModel*/
    public class DtoVersion
    {
        public string idVersionMalla { get; set; }
        public string idSociedad { get; set; }
        public string idMalla { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
        public string idEstadoVersion { get; set; }
        public string numeroUC { get; set; }
        public string idSeccion { get; set; }
        public string nombreSeccion { get; set; }
        public string colorSeccion { get; set; }
        public string[] idCatalogo { get; set; }
        public string idModadlidad { get; set; }
        public string idUnidadCurricular { get; set; }
        public string idComponente { get; set; }
        public List<ListadoVersion> ListadoVersion { get; set; }
        public List<ListadoSeccion> ListadoSeccion { get; set; }
        public List<ListadoUC> ListadoUC { get; set; }
        public List<ListadoCatalogoCurso> ListadoCatalogoCurso { get; set; }
        public List<ListadoModalidadComponente> ListadoModalidadComponente { get; set; }

        public string nombreMalla { get; set; }
        public string fechaCreacionMalla { get; set; }
        public string usuarioCreacionMalla { get; set; }
        public string activoMalla { get; set; }
    }
    /* clases para manejor de negocio*/
    public class ListadoVersion 
    {
        public string idVersionMalla { get; set; }
        public string idSociedad { get; set; }
        public string idMalla { get; set; }
        public string idEstadoVersion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
        public string numeroUC { get; set; }
    }

    public class ListadoSeccion 
    {
        public string idSeccion { get; set; }
        public string idSociedad { get; set; }
        public string idVersionMalla { get; set; }
        public string nombreSeccion { get; set; }
        public string colorSeccion { get; set; }
    }

    public class ListadoUC
    {
        public string idComponente { get; set; }
        public string idSociedad { get; set; }
        public string idUnidadCurricular { get; set; }
        public string nombreUnidadCurricular { get; set; }
        public string modalidadComponente { get; set; }
        public string idSeccion { get; set; }
        public string nombreSeccion { get; set; }
        public string colorSeccion { get; set; }
    }

    public class ListadoCatalogoCurso
    {
        public string idCatalogoCurso { get; set; }
        public string nombreCatalogoCurso { get; set; }
    }

    public class ListadoModalidadComponente 
    {
        public string idModalidadComponente { get; set; }
        public string nombreModalidadComponente { get; set; }
        public string codigoInternoModalidadComponente { get; set; }
        public string orderModalidadComponente { get; set; }
    }
}
