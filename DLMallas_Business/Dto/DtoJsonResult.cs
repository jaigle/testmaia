using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    public class DtoJsonResult
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public string valor { get; set; }


        public DtoJsonResult()
        {
            exito = false;
            mensaje = string.Empty;
            valor = string.Empty;
        }
    }
}
