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

    public class DtoOperacionResult
    {
        public int errorCode { get; set; }
        public string mensaje { get; set; }
        public string resultado { get; set; }


        public DtoOperacionResult()
        {
            errorCode = 0;
            mensaje = string.Empty;
            resultado = string.Empty;
        }
    }
}
