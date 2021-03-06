using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class ProductsTnq
    {
        public int RegProductIdTnq { get; set; }
        public int? RegProductId { get; set; }
        public int? RegPerfilId { get; set; }
        public int? RegId { get; set; }
        public string RegCodigoUnico { get; set; }
        public string RegRutaImagen { get; set; }
        public byte[] RegStreamImagen { get; set; }
        public string RegTituloProducto { get; set; }
        public string RegDescripcionProducto { get; set; }
        public string RegPreciProducto { get; set; }
        public DateTime? RegFecha { get; set; }
        public int? AnioReg { get; set; }
        public int? MesReg { get; set; }
        public int? DiaReg { get; set; }
        public int? IsDel { get; set; }
    }
}
