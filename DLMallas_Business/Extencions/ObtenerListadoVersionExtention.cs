using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Version;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoVersionExtention
    {
        public static ObtenerListadoVersion Faker(this ObtenerListadoVersion item, int id)
        {
            return new Faker<ObtenerListadoVersion>("es")
                .RuleFor(r => r.Id, f => (id + 1))
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30))
                .RuleFor(r => r.Version, f => f.Random.Number(1, 45).ToString())
                .RuleFor(r => r.IdMalla, f => f.Random.Number(1, 100))
                .RuleFor(r => r.Vigencia, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.Uc, f => f.Random.Number(1, 40))
                .RuleFor(r => r.Estado, f => f.Random.Number(0, 1).ToString());
        }
        
        public static List<ObtenerListadoVersion> Faker(this List<ObtenerListadoVersion> list)
        {
            for (int i = 0; i < 50; i++)
            {
                list.Add(new ObtenerListadoVersion().Faker(i));
            }

            return list;
        }
    }
}