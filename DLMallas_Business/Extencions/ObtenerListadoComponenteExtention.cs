using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoComponenteExtention
    {
        public static ObtenerListadoComponente Faker(this ObtenerListadoComponente item, int id)
        {
            var modalities = new[] { "Precencial", "eLearning", "Todas" }; 
            return new Faker<ObtenerListadoComponente>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.UnidadCurricular, f => "UC"+id+1)
                .RuleFor(r => r.Modalidad, f => f.PickRandom(modalities))
                .RuleFor(r => r.Seccion, f => "Seccion"+id+1)
                .RuleFor(r => r.Color, f => f.Internet.Color())
                .RuleFor(r => r.Prerrequisitos, f => f.Internet.Color())
                .RuleFor(r => r.Seleccionado, f => f.PickRandom(true,false));
        }
        
        public static List<ObtenerListadoComponente> Faker(this List<ObtenerListadoComponente> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ObtenerListadoComponente().Faker(i));
            }

            return list;
        }
    }
}