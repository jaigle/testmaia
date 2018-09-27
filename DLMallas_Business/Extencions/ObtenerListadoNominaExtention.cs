using System;
using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoNominaExtention
    {
        public static DtoNomina Faker(this DtoNomina item, int id)
        {
            return new Faker<DtoNomina>("es")
                .StrictMode(true)
                .RuleFor(r => r.IdPersona, f => id)
                .RuleFor(r => r.Rut, f => f.Person.Phone)
                .RuleFor(r => r.NombreCompleto, f => f.Name.FullName())
                .RuleFor(r => r.Asignacion, f => f.Date.Timespan())
                .RuleFor(r => r.Avance, f => f.Random.Number(0, 100))
                .RuleFor(r => r.UsuarioAsig, f => f.Random.Number(0, 200).ToString());
        }

        public static List<DtoNomina> Faker(this List<DtoNomina> list, string itinerarioId = "0")
        {
            for (int i = 0; i < 100; i++)
            {
               list.Add(new DtoNomina().Faker(i+1));
            }

            return list;
        }
    }
}