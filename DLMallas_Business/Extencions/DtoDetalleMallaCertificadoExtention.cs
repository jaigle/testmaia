using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Certificado;

namespace DLMallas.Business.Extencions
{
    static public class DtoDetalleMallaCertificadoExtention
    {
        public static DtoDetalleMallaCertificado Faker(this DtoDetalleMallaCertificado item, string id)
        {
            var cadenas = new[] { "Abc", "Bcd", "Cde" };
            return new Faker<DtoDetalleMallaCertificado>("es")
                .StrictMode(true)
                .RuleFor(r => r.IdMallaUnidadCurr, f => f.Random.Number(30).ToString())
                .RuleFor(r => r.Estado, f => f.PickRandom(cadenas).ToString())
                .RuleFor(r => r.Evaluacion, f => 100.ToString())
                .RuleFor(r => r.FechaExpiracion, f => f.Date.Past(1, null).ToString(CultureInfo.InvariantCulture))
                .RuleFor(r => r.NombreMalla, f => f.PickRandom(cadenas).ToString())
                .RuleFor(r => r.NombreUnidadCurricular, f => f.PickRandom(cadenas).ToString())
                .RuleFor(r => r.SituacionFinal, f => f.PickRandom(cadenas).ToString());
        }

        public static List<DtoDetalleMallaCertificado> Faker(this List<DtoDetalleMallaCertificado> list)
        {
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DtoDetalleMallaCertificado().Faker(i.ToString()));
            }

            return list;
        }
    }
}