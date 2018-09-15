using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerComponenteExtention
    {
        public static ObtenerComponente Faker(this ObtenerComponente item, string id)
        {
            return new Faker<ObtenerComponente>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => id)
                .RuleFor(r => r.IdSeccion, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.IdModalidadComponente, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.IdUnidadCurricular, f => f.Random.Number(1, 30).ToString());
        }

        public static List<ObtenerComponente> Faker(this List<ObtenerComponente> list, string id)
        {
            list.Add(new ObtenerComponente().Faker(id));
            return list;
        }
    }
}