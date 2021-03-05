using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public class clsDUsuarioCompania
    {

        public bool Include { get; set; }
        public bool All { get; set; }
        public bool adUsuario { get; set; }
        public bool rhPersonalCoperativa { get; set; }

        public clsDUsuarioCompania()
        {
            Include = false;
            All = false;
            adUsuario = false;
            rhPersonalCoperativa = false;
        }

        public List<adusuarioscompania> Get(adusuarioscompania toFilter = null)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                IQueryable<adusuarioscompania> query = ctx.adusuarioscompania;

                //if (Include)
                //{
                //    if (All || adUsuario)
                //        query = query.Include(a => a.ad);

                //    if (All || rhPersonalCoperativa)
                //        query = query.Include(a => a.adUsuarios.rhPersonalCooperativa);

                //}

                if (toFilter != null)
                {
                    if (toFilter.ciCompania != 0)
                        query = query.Where(a => a.ciCompania == toFilter.ciCompania);

                    if (!string.IsNullOrEmpty(toFilter.ciUsuario))
                        query = query.Where(a => a.ciUsuario == toFilter.ciUsuario);

                    if (!string.IsNullOrEmpty(toFilter.ciEstado))
                        query = query.Where(a => a.ciEstado == toFilter.ciEstado);
                }
                return query.ToList();
            }
        }



        public void Save(adusuarioscompania toUsuarioComp)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {
                var usuario = ctx.adusuarioscompania.Where(a => a.ciUsuario == toUsuarioComp.ciUsuario && a.ciCompania == toUsuarioComp.ciCompania).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.ciEstado = toUsuarioComp.ciEstado;
                    usuario.fcModificacion = DateTime.Now;
                    usuario.ciUsuarioModificacion = toUsuarioComp.ciUsuarioIngreso;

                }
                else
                    ctx.adusuarioscompania.Add(toUsuarioComp);
                ctx.SaveChanges();

            }


        }

    }
}
