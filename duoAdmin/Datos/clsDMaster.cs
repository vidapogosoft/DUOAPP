using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;

namespace Datos
{
    public class clsDMaster
    {
        public List<adcompania> GetAllxUsuario(string ciUsuario, bool bdAdmin)
        {
            EncuestaEntities db1 = new EncuestaEntities();
            return (from c in db1.adcompania
                    from cu in db1.adusuarioscompania.Where(q => c.ciCompania == q.ciCompania).DefaultIfEmpty()
                    where (ciUsuario == cu.ciUsuario || bdAdmin) && cu.ciEstado == clsParametos.EstadoActivo && c.ciEstado == clsParametos.EstadoActivo
                    select c).Distinct().ToList();
        }

        public List<adlocalidades> GetAllxLocalidad(string ciUsuario, int ciCompania, bool bdAdmin)
        {
            EncuestaEntities db1 = new EncuestaEntities();
            return (from c in db1.adlocalidades
                    from co in db1.adcompanialocalidad.Where(a => a.ciLocalidad == c.ciLocalidad && a.ciEstado == clsParametos.EstadoActivo)
                    from cu in db1.adusuariolocalidad.Where(a => a.ciLocalidad == c.ciLocalidad && a.ciEstado == clsParametos.EstadoActivo).DefaultIfEmpty()
                    where (ciUsuario == cu.ciUsuario && cu.ciCompania == ciCompania || bdAdmin) && cu.ciEstado == clsParametos.EstadoActivo && c.ciEstado == clsParametos.EstadoActivo
                    select c).Distinct().ToList();
        }

        public List<ModeloDatos.Entidades.clsNotificacionPupUp> GetNotificacionPupUp(int tiCompania, string tiUsuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
                return (from a in ctx.adusuarionotificacion
                        where a.ciUsuario == tiUsuario
                        && a.ciCompania == tiCompania
                        && a.bdNotificadoPopUp == false
                        select new ModeloDatos.Entidades.clsNotificacionPupUp()
                        {
                            txMensaje = a.txMensaje
                        }).ToList();
        }

        public int NotificacionPupUpLeida(int tiCompania, string tiUsuario)
        {
            int leida = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var notifica = ctx.adusuarionotificacion.Where(a => a.ciCompania == tiCompania && a.ciUsuario == tiUsuario && a.bdNotificadoPopUp == false).ToList();

                if (notifica.Count > 0)
                {
                    foreach (adusuarionotificacion NotificaLeida in notifica)
                    {
                        NotificaLeida.bdNotificadoPopUp = true;
                        NotificaLeida.fcModificacion = DateTime.Now;
                        ctx.SaveChanges();
                    }
                }
                leida = 1;
            }

            return leida;
        }

        public List<ModeloDatos.Entidades.clsNotificacionBarra> GetNotificacionBarra(int tiCompania, string tiUsuario, bool tbActualiza)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
                return (from a in ctx.adusuarionotificacion
                        join b in ctx.adusuarios on a.ciUsuario equals b.ciUsuario
                        where a.ciUsuario == tiUsuario
                        && a.ciCompania == tiCompania
                        orderby a.bdLeido, a.fcIngreso descending
                        select new ModeloDatos.Entidades.clsNotificacionBarra()
                        {
                            txMensaje = a.txMensaje,
                            txNombre = b.txNombreCorto,
                            fcIngreso = a.fcIngreso,
                            txDirectorioImagen = b.txDirectorioImagen,
                            bdLeido = a.bdLeido
                        }).ToList();
        }

        public int NotificacionBarraLeida(int tiCompania, string tiUsuario)
        {
            int leida = 0;
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var notifica = ctx.adusuarionotificacion.Where(a => a.ciCompania == tiCompania && a.ciUsuario == tiUsuario && a.bdLeido == false).ToList();

                if (notifica.Count > 0)
                {
                    foreach (adusuarionotificacion NotificaLeida in notifica)
                    {
                        NotificaLeida.bdNotificadoPopUp = true;
                        NotificaLeida.bdLeido = true;
                        NotificaLeida.fcModificacion = DateTime.Now;
                        ctx.SaveChanges();
                    }
                }
                leida = 1;
            }

            return leida;
        }
        
    }
}
