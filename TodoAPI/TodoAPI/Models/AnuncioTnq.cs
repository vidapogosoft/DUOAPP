using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class AnuncioTnq
    {
        public int RegAnuncioIdTnq { get; set; }
        public int RegAnuncioId { get; set; }
        public int? RegId { get; set; }
        public string RegCodigoUnico { get; set; }
        public string RegAnuncioPalabraClave { get; set; }
        public string RegAnuncioAcercaDe { get; set; }
        public string RegAnuncioEstado { get; set; }
        public DateTime? RegAnuncioFecha { get; set; }
        public int? AnioAnuncioReg { get; set; }
        public int? MesAnuncioReg { get; set; }
        public int? DiaAnuncioReg { get; set; }
        public int? AnioAnuncioHastaId { get; set; }
        public int? MesAnuncioHastaId { get; set; }
        public int? DiaAnuncioHastaId { get; set; }
    }
}
