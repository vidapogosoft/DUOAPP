using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public class clsDAfiliados
    {
        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliadoAdmin()
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var x = (from a in ctx.afiliados
        //                 where a.Estado == "ACTIVO"
        //                 orderby a.IdAfiliado descending
        //                 select new ModeloDatos.Entidades.clsAfiliado()
        //                 {
        //                     IdAfiliado = a.IdAfiliado,
        //                     Afiliado = a.Nombre,
        //                     IdentAfiliado = a.IdentificacionAfiliado,
        //                     ControlAfiliado = a.ControlAfiliado,
        //                     AcercaDe = a.AcercaDe,
        //                     Contacto1 = a.Contacto1,
        //                     Telefono1 = a.Tlf1,
        //                     Email1 = a.Correo1,

        //                     Contacto2 = a.Contacto2,
        //                     Telefono2 = a.Tlf2,
        //                     Email2 = a.Correo2,

        //                     Usuario = a.UsuarioCreacion,
        //                     FechaCreacionConsulta = a.FechaCreacionConsulta,
        //                     Estado = a.Estado,

        //                     Foto1 = a.RutaBanner,
        //                     Foto2 = a.RutaFoto

        //                 }).ToList();

        //        return x;
        //    }
        //}

        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliado(string ciUsuario)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var x = (from a in ctx.afiliados
        //                 join b in ctx.adusuarioafiliado on a.IdAfiliado equals b.IdAfiliado
        //                 where a.Estado == "ACTIVO" && b.ciUsuario == ciUsuario
        //                 select new ModeloDatos.Entidades.clsAfiliado()
        //                 {
        //                     IdAfiliado = a.IdAfiliado,
        //                     Afiliado = a.Nombre,
        //                     IdentAfiliado = a.IdentificacionAfiliado,
        //                     ControlAfiliado = a.ControlAfiliado,
        //                     AcercaDe = a.AcercaDe,
        //                     Contacto1 = a.Contacto1,
        //                     Telefono1 = a.Tlf1,
        //                     Email1 = a.Correo1,

        //                     Contacto2 = a.Contacto2,
        //                     Telefono2 = a.Tlf2,
        //                     Email2 = a.Correo2,

        //                     Usuario = a.UsuarioCreacion,
        //                     FechaCreacionConsulta = a.FechaCreacionConsulta,
        //                     Estado = a.Estado,

        //                     Foto1 = a.RutaBanner,
        //                     Foto2 = a.RutaFoto

        //                 }).ToList();

        //        return x;
        //    }
        //}

        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliadoById(int Idproveedor)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var x = (from a in ctx.afiliados
        //                 where a.IdAfiliado == Idproveedor
        //                 select new ModeloDatos.Entidades.clsAfiliado()
        //                 {
        //                     IdAfiliado = a.IdAfiliado,
        //                     Afiliado = a.Nombre,
        //                     IdentAfiliado = a.IdentificacionAfiliado,
        //                     ControlAfiliado = a.ControlAfiliado,
        //                     AcercaDe = a.AcercaDe,
        //                     Contacto1 = a.Contacto1,
        //                     Telefono1 = a.Tlf1,
        //                     Email1 = a.Correo1,

        //                     Contacto2 = a.Contacto2,
        //                     Telefono2 = a.Tlf2,
        //                     Email2 = a.Correo2,

        //                     Usuario = a.UsuarioCreacion,
        //                     FechaCreacionConsulta = a.FechaCreacionConsulta,
        //                     Estado = a.Estado,

        //                     Foto1 = a.RutaBanner,
        //                     Foto2 = a.RutaFoto

        //                 }).ToList();

        //        return x;
        //    }
        //}

        

        //public void SaveAfiliado(afiliados Prove)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var promo = ctx.afiliados.Where(a => a.IdAfiliado == Prove.IdAfiliado).FirstOrDefault();

        //        if (promo == null)
        //        {
        //            ctx.afiliados.Add(Prove);
        //        }
        //        else
        //        {
        //            promo.Nombre = Prove.Nombre;
        //            promo.AcercaDe = Prove.AcercaDe;
        //            promo.IdentificacionAfiliado = Prove.IdentificacionAfiliado;
        //            promo.ControlAfiliado = Prove.ControlAfiliado;

        //            promo.Contacto1 = Prove.Contacto1;
        //            promo.Tlf1 = Prove.Tlf1;
        //            promo.Correo1 = Prove.Correo1;

        //            promo.Contacto2 = Prove.Contacto2;
        //            promo.Tlf2 = Prove.Tlf2;
        //            promo.Correo2 = Prove.Correo2;

        //            promo.UsuarioActualiacion = Prove.UsuarioCreacion;
        //            promo.FechaActualizacion = Prove.FechaCreacion;

        //            promo.RutaBanner = Prove.RutaBanner;
        //            promo.RutaFoto = Prove.RutaFoto;

        //        }
        //        ctx.SaveChanges();
        //    }
        //}

        //public void DelAfiliado(int idProveedor, string idUsuario)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var promo = ctx.afiliados.Where(a => a.IdAfiliado == idProveedor).ToList();

        //        if (promo.Count > 0)
        //        {
        //            foreach (afiliados promos in promo)
        //            {
        //                promos.Estado = "INACTIVO";
        //                promos.FechaActualizacion = DateTime.Now;
        //                promos.UsuarioActualiacion = idUsuario;
        //                ctx.SaveChanges();
        //            }
        //        }

        //    }
        //}
    }
}
