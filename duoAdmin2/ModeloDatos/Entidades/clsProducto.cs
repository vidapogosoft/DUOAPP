using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Entidades
{
    public class clsProducto
    {
        public int IdProducto { get; set; }
        public string ControlProducto { get; set; }
        public int IdAfiliado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public string Precio { get; set; }

        public string Usuario { get; set; }
        public string FechaCreacion { get; set; }
        public string Estado { get; set; }
        
        public string Afiliado { get; set; }
        
        public string RutaFoto { get; set; }
    }
}
