using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datos
{

    public class clsDPerfiles
    {
        public bool Include { get; set; }
        public bool All { get; set; }
        public bool adPerfil { get; set; }
        public bool adUsuarioPerfil { get; set; }

        public clsDPerfiles()
        {
            Include = false;
            All = false;
            adPerfil = false;
            adUsuarioPerfil = false;
        }

        public List<adperfil> Get(adperfil toFilter = null)
        {
            return GetQuery(toFilter).AsNoTracking().ToList();
        }

        public IQueryable<adperfil> GetQuery(adperfil Filtro = null)
        {
            EncuestaEntities ctx = new EncuestaEntities();

            IQueryable<adperfil> query = ctx.adperfil;

            //if (Include)
            //{
            //    if (All || adPerfil)
            //        query = query.Include(i => i.adCompania).OrderByDescending(i => i.fcIngreso);
            //}

            if (Filtro != null)
            {
                if (Filtro.ciCompania != 0)
                    query = query.Where(c => c.ciCompania == Filtro.ciCompania);

                if (!string.IsNullOrEmpty(Filtro.txNombre))
                    query = query.Where(a => a.txNombre.Contains(Filtro.txNombre));

                if (!string.IsNullOrEmpty(Filtro.ciEstado))
                    query = query.Where(a => a.ciEstado == Filtro.ciEstado);

                if (Filtro.ciPerfil != 0)
                    query = query.Where(a => a.ciPerfil == Filtro.ciPerfil);

            }
            return query;

        }

        public List<adusuarioperfil> GetUP(adusuarioperfil toFilter = null)
        {
            return GetQueryUP(toFilter).AsNoTracking().ToList();
        }

        public IQueryable<adusuarioperfil> GetQueryUP(adusuarioperfil Filtro = null)
        {
            EncuestaEntities ctx = new EncuestaEntities();

            IQueryable<adusuarioperfil> query = ctx.adusuarioperfil;

            if (Include)
            {
                if (All || adPerfil)
                    query = query.Include(i => i.ciUsuario).OrderByDescending(i => i.fcIngreso);
            }

            if (Filtro != null)
            {
                if (!string.IsNullOrEmpty(Filtro.ciUsuario))
                    query = query.Where(a => a.ciUsuario == Filtro.ciUsuario);

                if (Filtro.ciCompania != 0)
                    query = query.Where(c => c.ciCompania == Filtro.ciCompania);

                if (!string.IsNullOrEmpty(Filtro.ciEstado))
                    query = query.Where(a => a.ciEstado == Filtro.ciEstado);

                if (Filtro.ciPerfil != 0)
                    query = query.Where(a => a.ciPerfil == Filtro.ciPerfil);

            }
            return query;

        }

        public List<ModeloDatos.Entidades.clsPerfilMenuAsignado> GetPerfilMenu(int perfil)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var x = (from a in ctx.admodulo
                         join b in ctx.admenu on a.ciModulo equals b.ciModulo
                         join c in ctx.adperfilmenu on b.ciMenu equals c.ciMenu
                         where c.ciPerfil == perfil && c.ciEstado == "A"
                         orderby a.txNombre ascending, b.txFormulario ascending
                         select new ModeloDatos.Entidades.clsPerfilMenuAsignado()
                         {
                             ciMenu = b.ciMenu,
                             txNombre = a.txNombre,
                             txFormulario = b.txFormulario
                         }).ToList();

                return x;
            }
        }

        //public List<spConsultarPerfilMenuNoAsignado_Result> GetPerfilMenuNoAsignado(int perfil)
        //{
        //    using (fedesEntities ctx = new fedesEntities())
        //    {
        //        var x = ctx.spConsultarPerfilMenuNoAsignado(perfil).ToList();
        //        return x;
        //    }
        //}

        public void SavePerfilMenu(adperfilmenu mPerfilUsuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var usuario = ctx.adperfilmenu.Where(a => a.ciPerfil == mPerfilUsuario.ciPerfil && a.ciMenu == mPerfilUsuario.ciMenu).ToList();

                if (usuario.Count > 0)
                {
                    foreach (adperfilmenu Perfilmenu in usuario)
                    {
                        Perfilmenu.ciEstado = "A";
                        Perfilmenu.ciUsuarioModificacion = mPerfilUsuario.ciUsuarioIngreso;
                        Perfilmenu.fcModificacion = DateTime.Now;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    ctx.adperfilmenu.Add(mPerfilUsuario);
                    ctx.SaveChanges();
                }

            }
        }

        public void DelPerfilMenu(int idMenu, int idPerfil, string idUsuario)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var usuario = ctx.adperfilmenu.Where(a => a.ciPerfil == idPerfil && a.ciMenu == idMenu).ToList();

                if (usuario.Count > 0)
                {
                    foreach (adperfilmenu Perfilmenu in usuario)
                    {
                        Perfilmenu.ciEstado = "I";
                        Perfilmenu.ciUsuarioModificacion = idUsuario;
                        Perfilmenu.fcModificacion = DateTime.Now;
                        ctx.SaveChanges();
                    }
                }

            }
        }

        public void SavePerfil(adperfil mPerfil, int ciPerfil)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var perfil = ctx.adperfil.Where(a => a.ciPerfil == ciPerfil && a.ciCompania == mPerfil.ciCompania).ToList();

                if (perfil.Count > 0)
                {
                    foreach (adperfil Perfiles in perfil)
                    {
                        Perfiles.ciEstado = "A";
                        Perfiles.ciUsuarioModificacion = mPerfil.ciUsuarioIngreso;
                        Perfiles.fcModificacion = DateTime.Now;
                        Perfiles.bdAdmin = mPerfil.bdAdmin;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    ctx.adperfil.Add(mPerfil);
                    ctx.SaveChanges();
                }

            }
        }
    }

}
