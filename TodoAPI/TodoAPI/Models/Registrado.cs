using System;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public partial class Registrado
    {
        public int RegId { get; set; }
        public string RegCodigoUnico { get; set; }
        public string RegNombres { get; set; }
        public string RegApellidos { get; set; }
        public string RegNombreCompleto { get; set; }
        public string RegContrasenia { get; set; }
        public string RegEmail { get; set; }
        public string RegNumeroCelular { get; set; }
        public DateTime? RegFecha { get; set; }
        public int? AnioReg { get; set; }
        public int? MesReg { get; set; }
        public int? DiaReg { get; set; }
        public bool? Tecnologia { get; set; }
        public bool? Legales { get; set; }
        public bool? Comunicacion { get; set; }
        public bool? Comercio { get; set; }
        public bool? ArteDiseno { get; set; }
        public bool? ServiciosTecnicos { get; set; }
        public bool? Urbanismo { get; set; }
        public bool? Emprendimientos { get; set; }
    }
}
