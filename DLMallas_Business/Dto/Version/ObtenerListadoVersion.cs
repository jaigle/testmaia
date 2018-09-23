using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto.Version
{
    //public class ObtenerListadoVersion
    //{
    //    public string Id;
	   // public string IdSociedad;
	   // public string IdMalla;
	   // public string Version;
	   // public string FechaInicio;
	   // public string FechaTermino;
    //    public string TotalComponente;
    //}

    public class ObtenerListadoVersion
    {
        public int Id;
        public int IdSociedad;
        public int IdMalla;
        public string Version;
        public string Vigencia;
        public int Uc;
        public string Estado;
    }
}

