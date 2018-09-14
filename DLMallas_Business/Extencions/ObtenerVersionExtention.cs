using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Version;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerVersionExtention
    {
        public static ObtenerVersion Faker(this ObtenerVersion item, string id)
        {
            return new Faker<ObtenerVersion>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => id.ToString())
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.IdMalla, f => f.Random.Number(1, 100).ToString())
                .RuleFor(r => r.Version, f => f.Random.Number(1, 40).ToString())
                .RuleFor(r => r.FechaInicio, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.FechaTermino, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture));
        }

        public static List<ObtenerVersion> Faker(this List<ObtenerVersion> list, string id)
        {
            list.Add(new ObtenerVersion().Faker(id));
            return list;
        }
    }
}