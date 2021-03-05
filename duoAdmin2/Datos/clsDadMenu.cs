using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;

namespace Datos
{
    public class clsDadMenu
    {
        public List<ModeloDatos.Entidades.clsMenu> Get()
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.admodulo
                         join b in ctx.admenu on a.ciModulo equals b.ciModulo
                         where a.ciEstado == "A" && b.ciEstado == "A"
                         select new ModeloDatos.Entidades.clsMenu()
                         {
                             ciModulo = a.ciModulo,
                             txNombreModulo = a.txNombre,
                             ciOrdenModulo = a.ciOrden,
                             txIcono = a.txIcono,
                             ciOrdenFormulario = b.ciOrden,
                             txUrl = b.txUrl,
                             txFormulario = b.txFormulario
                         }).ToList();

                return x;
            }
        }

        public List<ModeloDatos.Entidades.clsMenu> GetMenuUsuario(string ciUsuario, int ciCompania)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.adusuarioperfil
                         join b in ctx.adperfil on a.ciPerfil equals b.ciPerfil
                         join c in ctx.adperfilmenu on b.ciPerfil equals c.ciPerfil
                         join d in ctx.admenu on c.ciMenu equals d.ciMenu
                         join e in ctx.admodulo on d.ciModulo equals e.ciModulo
                         where a.ciEstado == clsParametos.EstadoActivo
                         && b.ciEstado == clsParametos.EstadoActivo
                         && c.ciEstado == clsParametos.EstadoActivo
                         && d.ciEstado == clsParametos.EstadoActivo
                         && e.ciEstado == clsParametos.EstadoActivo
                         && a.ciCompania == ciCompania && a.ciUsuario.ToUpper() == ciUsuario.ToUpper()
                         select new ModeloDatos.Entidades.clsMenu()
                         {
                             ciModulo = e.ciModulo,
                             txNombreModulo = e.txNombre,
                             ciOrdenModulo = e.ciOrden,
                             txIcono = e.txIcono,
                             ciOrdenFormulario = d.ciOrden,
                             txUrl = d.txUrl,
                             txFormulario = d.txFormulario
                         }).ToList();

                return x;
            }
        }
    }
}
