using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;
using System.Data.Entity;

namespace Datos
{
    public class clsDSolicitud
    {
        public List<spObtenerSolicitudAdmin_Result> ConsultarSolicitudesAdmin()
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = ctx.spObtenerSolicitudAdmin().ToList();

                return x;
            }
        }

        public List<spObtenerSolicitudGeneral_Result> ConsultarSolicitudesGeneral(string usuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = ctx.spObtenerSolicitudGeneral(usuario).ToList();

                return x;
            }
        }
    }
}
