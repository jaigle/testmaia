using System.Collections.Generic;

namespace DLMallas.Business.Dto.Componente
{
    public class GuardarPrerrequisito
    {
        public string IdComponente { get; set; }
        public List<string>  IdComponentePrerrequisitos { get; set; }
    }
}
