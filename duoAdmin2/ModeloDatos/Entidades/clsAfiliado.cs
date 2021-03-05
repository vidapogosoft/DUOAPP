using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Entidades
{
    public class clsAfiliado
    {
        public int IdAfiliado { get; set; }
        public string Afiliado { get; set; }

        public string IdentAfiliado { get; set; }
        public string ControlAfiliado { get; set; }

        public string AcercaDe { get; set; }
        public string Contacto1 { get; set; }
        public string Telefono1 { get; set; }
        public string Email1 { get; set; }

        public string Contacto2 { get; set; }
        public string Telefono2 { get; set; }
        public string Email2 { get; set; }


        public string Usuario { get; set; }
        public string FechaCreacionConsulta { get; set; }
        public string Estado { get; set; }

        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
    }
}
