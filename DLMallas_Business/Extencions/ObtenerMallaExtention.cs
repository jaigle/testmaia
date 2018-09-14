using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerMallaExtention
    {
        public static ObtenerMalla Faker(this ObtenerMalla item, string id)
        {
            var users = new[] { "jim", "jaigle", "ldtoro" };
            return new Faker<ObtenerMalla>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => id)
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.FechaCreacion, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                .RuleFor(r => r.IdEscuela, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.Descripcion, f => f.Name.JobDescriptor())
                .RuleFor(r => r.Activo, f => f.PickRandom(0, 1).ToString())
                .RuleFor(r => r.UsuarioCreacion, f => f.PickRandom(users).ToString());
        }

        public static List<ObtenerMalla> Faker(this List<ObtenerMalla> list, string id)
        {
            list.Add(new ObtenerMalla().Faker(id));
            return list;
        }
    }
}