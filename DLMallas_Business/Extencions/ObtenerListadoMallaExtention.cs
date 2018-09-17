using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoMallaExtention
    {
        public static ObtenerListadoMalla Faker(this ObtenerListadoMalla item, int id)
        {
            var users = new[] { "jim", "jaigle", "ldtoro" };
            return new Faker<ObtenerListadoMalla>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.Escuela, f => f.Company.CompanyName())
                .RuleFor(r => r.FechaCreacion, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                .RuleFor(r => r.Descripcion, f => f.Name.JobDescriptor())
                .RuleFor(r => r.Activo, f => f.Random.Number(0, 1).ToString())
                .RuleFor(r => r.UsuarioCreacion, f => f.PickRandom(users))
                .RuleFor(r => r.CantVersiones, f => f.Random.Number(1, 10).ToString())
                .RuleFor(r => r.ItinerariosTotal, f => f.Random.Number(0, 50).ToString())
                .RuleFor(r => r.ItinerariosActivos, f => f.Random.Number(0, 50).ToString());
        }
        
        public static List<ObtenerListadoMalla> Faker(this List<ObtenerListadoMalla> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ObtenerListadoMalla().Faker(i));
            }

            return list;
        }
    }
}