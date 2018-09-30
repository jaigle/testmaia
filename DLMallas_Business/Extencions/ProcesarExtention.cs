using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Nomina;

namespace DLMallas.Business.Extencions
{
    static public class ProcesarExtention
    {
        public static DtoProcesados Faker(this DtoProcesados item, int id)
        {
            var users = new[] { "Valido", "No encontrado", "Existente"};
            return new Faker<DtoProcesados>("es")
                .StrictMode(true)
                .RuleFor(r => r.IdPersona, f => (id + 1).ToString())
                .RuleFor(r => r.Cedula, f => f.Person.Phone.ToString())
                .RuleFor(r => r.NombreCompleto, f => f.Person.FullName)
                .RuleFor(r => r.Estado, f => f.PickRandom(users));
        }
        
        public static List<DtoProcesados> Faker(this List<DtoProcesados> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(new DtoProcesados().Faker(i));
            }

            return list;
        }
    }
}