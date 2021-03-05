using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos.Entidades
{
    public class clsNotificacionBarra
    {
        public string txMensaje { get; set; }
        public string txNombre { get; set; }
        public DateTime fcIngreso { get; set; }
        public string txDirectorioImagen { get; set; }
        public bool bdLeido { get; set; }
    }
}
