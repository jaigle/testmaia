using System.Collections.Generic;
using System.Linq;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Dto.Nomina;

namespace DLMallas.Models
{
    public class ProcesadosViewModels
    {
        public string Validos { get { return Procesados?.Where(p => p.Estado == "Valido").Count().ToString(); }
        }

        public string NoEncontrados { get { return Procesados?.Where(p => p.Estado == "No encontrado").Count().ToString(); } }
        public string Existentes { get { return Procesados?.Where(p => p.Estado == "Existente").Count().ToString(); } }
        public string ListaProcesar
        {
            get { return Procesados.Where(p => p.Estado == "Valido").Select(s => s.IdPersona).Aggregate((a, b) => a + "," + b); }
        }
        public List<DtoProcesados>  Procesados { get; set; }
    }
  }