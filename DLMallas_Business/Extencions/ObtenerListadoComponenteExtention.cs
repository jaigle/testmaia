using System;
using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoComponenteExtention
    {
        public static ObtenerListadoComponente Faker(this ObtenerListadoComponente item, int id, bool isPrerequisites = false)
        {
            var modalities = new[] { "Precencial", "eLearning", "Todas" };
            return new Faker<ObtenerListadoComponente>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.UnidadCurricular, f => "UC" + id + 1)
                .RuleFor(r => r.Modalidad, f => f.PickRandom(modalities))
                .RuleFor(r => r.Seccion, f => "Seccion" + id + 1)
                .RuleFor(r => r.Color, f => f.Internet.Color())
                .RuleFor(r => r.Prerrequisitos, f => f.PickRandom(0, 1, 2, 3, 4, 5).CodeGenerate())
                .RuleFor(r => r.Seleccionado, f => f.PickRandom(true, false));
        }

        public static List<ObtenerListadoComponente> Faker(this List<ObtenerListadoComponente> list, int currentId = 0, bool isPrerequisites = false)
        {
            var length = (isPrerequisites) ? 10 : 100;
            for (int i = 0; i < length; i++)
            {
                var id = (currentId == i) ? length + 1 : i + 1;
                list.Add(new ObtenerListadoComponente().Faker(id, isPrerequisites));
            }

            return list;
        }

        private static string CodeGenerate(this int length)
        {
            var result = string.Empty;

            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    result += "CU000" + i + 1 + ",";
                }

                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
    }
}