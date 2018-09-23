﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Componente;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Dto.Malla;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoItinerarioMalla
    {
        public static DtoItinerario Faker(this DtoItinerario item, int id, string idMalla)
        {
            return new Faker<DtoItinerario>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, id.ToString())
                .RuleFor(r => r.Nombre, f => f.Name.JobArea())
                .RuleFor(r => r.Malla, f => (idMalla != "0") ? idMalla.ToString() : f.Name.Random.Word())
                .RuleFor(r => r.Vigencia,
                    f => f.Date.Past(1, null).ToString("dd/MM/yyyy") + " - " +
                         f.Date.Past(0, null).ToString("dd/MM/yyyy"))
                .RuleFor(r => r.Inscriptos, f => f.Random.Number(1, 50).ToString())
                .RuleFor(r => r.Estado, f => f.PickRandom(0, 1).ToString())
                .RuleFor(r => r.AvanUC, f => f.Random.Number(0, 100).ToString() + "%")
                .RuleFor(r => r.AvanColab, f => f.Random.Number(0, 100).ToString() + "%")
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(0, 100).ToString());
        }

        public static List<DtoItinerario> Faker(this List<DtoItinerario> list, string idMalla)
        {
            for (
                int i = 0; i < 100; i++)
            {
                list.Add(new DtoItinerario().Faker(i+1, (idMalla == "0") ? "0" : idMalla));
            }

            return list;
        }

    }
}