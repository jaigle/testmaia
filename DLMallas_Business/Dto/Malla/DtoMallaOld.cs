using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    /*clase viewModel*/
    public class DtoMallaOld
    {
        public string idMalla { get; set; }
        public string nombreMalla { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string activoMalla { get; set; }
        public string idSociedad { get; set; }
        public string descripcionMalla { get; set; }
        public bool checking { get; set; }
        public string nombrePersonaLogin { get; set; }
        public string fechaHoy { get; set; }
        public List<ListadoMalla> ListadoMalla { get; set; }
    }
    /* clases para manejor de negocio*/
    public class ListadoMalla {
        public string idMalla { get; set; }
        public string nombreMalla { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioCreacion { get; set; }
        public string activoMalla { get; set; }
    }

    public class DetalleMalla
    {
        public string idMalla { get; set; }
        public string idSociedad { get; set; }
        public string fechaCreacion { get; set; }
        public string nombreMalla { get; set; }
        public string descripcionMalla { get; set; }
        public string activoMalla { get; set; }
        public string usuarioCreacion { get; set; }
    }

}
