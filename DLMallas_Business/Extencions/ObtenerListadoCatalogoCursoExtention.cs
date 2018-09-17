using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoCatalogoCursoExtention
    {
        public static ObtenerListadoCatalogoCurso Faker(this ObtenerListadoCatalogoCurso item, int id)
        {
            var users = new[] { "jim", "jaigle", "ldtoro" };
            return new Faker<ObtenerListadoCatalogoCurso>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.Nombre, f => f.Name.JobArea());
        }
        
        public static List<ObtenerListadoCatalogoCurso> Faker(this List<ObtenerListadoCatalogoCurso> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ObtenerListadoCatalogoCurso().Faker(i));
            }

            return list;
        }
    }
}