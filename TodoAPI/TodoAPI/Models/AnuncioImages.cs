using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class AnuncioImages
    {
        public int RegAnuncioImagenId { get; set; }
        public int RegAnuncioId { get; set; }
        public int? RegId { get; set; }
        public string RegAnuncioEstado { get; set; }
        public DateTime? RegAnuncioFecha { get; set; }
        public string RegRutaImagen { get; set; }
    }
}
