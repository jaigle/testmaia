using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Itinerario;
using DLMallas.Business.Dto.Malla;
using DLMallas.Business.Dto.Nomina;

namespace DLMallas.Business.Extencions
{
    static public class ObtenerListadoNotificacionesExtention
    {
        public static DtoNotificacionItinerario Faker(this DtoNotificacionItinerario item, int id)
        {
            var notificaciones = new[] { "Notificación vencimiento de vigencia a Colaborador",
                "Notificar asignación de itinerario a Colaborador",
                "Notificar vencimiento de vigencia a Jefe",
                "Notificar asignación de malla a Jefe"
            };
            
            return new Faker<DtoNotificacionItinerario>("es")
                .RuleFor(r => r.Id, f => (id + 1).ToString())
                .RuleFor(r => r.Codigo, f => "000"+id+1)
                .RuleFor(r => r.Nombre, f => notificaciones[id])
                .RuleFor(r => r.Seleccionado, f => f.PickRandom(0,1));
        }
        
        public static List<DtoNotificacionItinerario> Faker(this List<DtoNotificacionItinerario> list)
        {
            for (int i = 0; i < 4; i++)
            {
                list.Add(new DtoNotificacionItinerario().Faker(i));
            }

            return list;
        }
    }
}