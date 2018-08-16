using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMallas.Business.Dto
{
    public class DtoPersona
    {
        //public int Id { get; set; }
        //public string Nombre { get; set; }
        //public string ApellidoPaterno { get; set; }
        //public string ApellidoMaterno { get; set; }

        public string IdPersona { get; set; }
        public string IdPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public string IdJefe { get; set; }
        public string NombreJefe { get; set; }
        public string TotalRegistros { get; set; }
        public string NombrePersona { get; set; }

    }
}
