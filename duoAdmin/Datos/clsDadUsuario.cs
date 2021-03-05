using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;
using System.Data.Entity;

namespace Datos
{
    public class clsDadUsuario
    {
        public bool Include { get; set; }
        public bool idPersona { get; set; }
        public bool All { get; set; }

        public clsDadUsuario()
        {
            Include = false;
            idPersona = false;
            All = false;
        }

        public List<adusuarios> Get(adusuarios Filtro = null)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                IQueryable<adusuarios> query = ctx.adusuarios;

                if (Include)
                {
                    if (All || idPersona)
                        query = query.Include(a => a.idPersona);
                }
                if (Filtro != null)
                {
                    if (!string.IsNullOrEmpty(Filtro.ciUsuario))
                        query = query.Where(a => a.ciUsuario.ToUpper() == Filtro.ciUsuario.ToUpper());

                    if (!string.IsNullOrEmpty(Filtro.txClave))
                        query = query.Where(a => a.txClave == Filtro.txClave);

                    if (Filtro.idPersona != null && Filtro.idPersona != 0)
                        query = query.Where(a => a.idPersona == Filtro.idPersona);

                    if (!string.IsNullOrEmpty(Filtro.ciEstado))
                        query = query.Where(a => a.ciEstado == Filtro.ciEstado);

                }
                return query.AsNoTracking().ToList();
            }
        }

        public List<ModeloDatos.Entidades.clsPerfilesUsuario> GetPerfilUsuario(string ciUsuario)
        {

            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.adusuarios
                         join b in ctx.adusuarioperfil on a.ciUsuario equals b.ciUsuario
                         join c in ctx.adperfil on b.ciPerfil equals c.ciPerfil
                         where c.bdAdmin == true
                         && c.ciEstado == clsParametos.EstadoActivo
                         && b.ciEstado == clsParametos.EstadoActivo
                         && a.ciUsuario.ToUpper() == ciUsuario.ToUpper()
                         && a.ciEstado == clsParametos.EstadoActivo
                         select new ModeloDatos.Entidades.clsPerfilesUsuario()
                         {
                             ciUsuario = a.ciUsuario,
                             ciPerfil = b.ciPerfil
                         }).ToList();

                return x;
            }
        }

        public List<ModeloDatos.Entidades.clsPerfilMenuAsignado> GetPantallaAccesoUsuario(int ciCompania, string ciUsuario, string txUrl)
        {

            using (EncuestaEntities ctx = new EncuestaEntities())
                return (from a in ctx.admodulo
                        join b in ctx.admenu on a.ciModulo equals b.ciModulo
                        join c in ctx.adperfilmenu on b.ciMenu equals c.ciMenu
                        join d in ctx.adusuarioperfil on c.ciPerfil equals d.ciPerfil
                        where d.ciUsuario == ciUsuario
                        && b.ciEstado == clsParametos.EstadoActivo
                        && a.ciEstado == clsParametos.EstadoActivo
                        && c.ciEstado == clsParametos.EstadoActivo
                        && d.ciEstado == clsParametos.EstadoActivo
                        && b.txUrlAcceso == txUrl
                        select new ModeloDatos.Entidades.clsPerfilMenuAsignado()
                        {
                            ciMenu = b.ciMenu,
                            txNombre = a.txNombre,
                            txFormulario = b.txFormulario,
                            txUrl = b.txUrlAcceso
                        }).ToList();
        }

        public void SaveUsuarioPerfil(adusuarioperfil pUsuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var usuario = ctx.adusuarioperfil.Where(a => a.ciPerfil == pUsuario.ciPerfil && a.ciUsuario == pUsuario.ciUsuario
                                                        && a.ciCompania == pUsuario.ciCompania).ToList();

                if (usuario.Count > 0)
                {
                    foreach (adusuarioperfil PerfilUsuario in usuario)
                    {
                        PerfilUsuario.ciEstado = pUsuario.ciEstado;
                        PerfilUsuario.ciUsuarioModificacion = pUsuario.ciUsuarioModificacion;
                        PerfilUsuario.fcModificacion = pUsuario.fcModificacion;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    if (pUsuario.ciEstado == "A")
                    {
                        ctx.adusuarioperfil.Add(pUsuario);
                        ctx.SaveChanges();
                    }
                }
            }
        }

        public void Save(adusuarios toUsuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var usuario = ctx.adusuarios.Where(a => a.ciUsuario == toUsuario.ciUsuario).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.ciUsuario = toUsuario.ciUsuario;
                    usuario.txNombreCorto = toUsuario.txNombreCorto;
                    usuario.idPersona = toUsuario.idPersona;
                    usuario.txDescripcion = toUsuario.txDescripcion;
                    usuario.txClave = toUsuario.txClave;
                    usuario.ciEstado = toUsuario.ciEstado;
                    usuario.bdMaster = toUsuario.bdMaster;
                    if (!string.IsNullOrEmpty(toUsuario.txDirectorioImagen.Trim()))
                        usuario.txDirectorioImagen = toUsuario.txDirectorioImagen.Trim();
                }
                else
                    ctx.adusuarios.Add(toUsuario);

                ctx.SaveChanges();

            }
        }

        //public void SaveUsuarioProveedor(adusuarioproveedor toUsuario)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var usuario = ctx.adusuarioproveedor.Where(a => a.ciUsuario == toUsuario.ciUsuario).FirstOrDefault();

        //        if (usuario != null)
        //        {
        //            usuario.ciUsuario = toUsuario.ciUsuario;
        //            usuario.FechaModificacion = toUsuario.FechaIngreso;
        //            usuario.UsuarioModificacion = toUsuario.UsuarioModificacion;
        //            usuario.IdProveedor = toUsuario.IdProveedor;
        //        }
        //        else
        //            ctx.adusuarioproveedor.Add(toUsuario);

        //        ctx.SaveChanges();

        //    }
        //}

    }
}
