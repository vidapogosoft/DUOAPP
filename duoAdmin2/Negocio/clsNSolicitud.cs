using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using ModeloDatos;
using System.Transactions;

namespace Negocio
{
    public class clsNSolicitud
    {
        clsDSolicitud clsDSolicitud = new clsDSolicitud();

        public List<spObtenerSolicitudAdmin_Result> ConsultarSolicitudesAdmin()
        {
            return clsDSolicitud.ConsultarSolicitudesAdmin();
        }

        public List<spObtenerSolicitudGeneral_Result> ConsultarSolicitudesGeneral(string usuario)
        {
            return clsDSolicitud.ConsultarSolicitudesGeneral(usuario);
        }
    }
}
