using System.Collections.Generic;

namespace DLMallas.Models
{
    public class ItinerariosViewModels
    {
        public string MallaId { get; set; }
        public List<ItinerarioViewModels> Itinerarios { get; set; }
    }

    public class ItinerarioViewModels
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Vigencia { get; set; }
        public int Inscrip { get; set; }
        public bool Estado { get; set; }
        public string AvanUc { get; set; }
        public string AvanColab { get; set; }
    }
   

}