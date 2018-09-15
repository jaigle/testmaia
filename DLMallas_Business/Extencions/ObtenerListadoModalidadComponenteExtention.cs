using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Componente;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoModalidadComponenteExtention
    {
        public static ObtenerListadoModalidadComponente Faker(this ObtenerListadoModalidadComponente item, int id)
        {
            var users = new[] { "jim", "jaigle", "ldtoro" };
            return new Faker<ObtenerListadoModalidadComponente>("es")
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.Nombre, f => f.Name.JobArea());
        }
        
        public static List<ObtenerListadoModalidadComponente> Faker(this List<ObtenerListadoModalidadComponente> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ObtenerListadoModalidadComponente().Faker(i));
            }

            return list;
        }
    }
}