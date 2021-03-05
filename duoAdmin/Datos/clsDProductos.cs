using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Datos
{
    public class clsDProductos
    {
        //public List<ModeloDatos.Entidades.clsProducto> ConsultarProductosAdmin()
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var x = (from a in ctx.productosafiliados
        //                 join b in ctx.afiliados on a.IdAfiliado equals b.IdAfiliado
        //                 where a.Estado == "ACTIVO"
        //                 //&& a.FechaCreacion.Date.Year == DateTime.Now.Year
        //                 //&& a.FechaCreacion.Date.Month <= (DateTime.Now.Month - 1)
        //                 orderby a.IdProductoAfiliado descending
        //                 select new ModeloDatos.Entidades.clsProducto()
        //                 {
        //                     IdProducto = a.IdProductoAfiliado,
        //                     ControlProducto = a.ControlProducto,
        //                     IdAfiliado = b.IdAfiliado,
        //                     Afiliado = b.Nombre,
        //                     Titulo = a.NombreProducto,
        //                     Descripcion = a.AcercaDe,
        //                     Precio = a.PrecioConsulta,
        //                     FechaCreacion = a.FechaCreacionConsulta,
        //                     Usuario = a.UsuarioCreacion,
        //                     Estado = a.Estado,
        //                     RutaFoto = a.RutaFoto
        //                 }).Take(50).ToList();

        //        return x;
        //    }
        //}
        
        //public List<ModeloDatos.Entidades.clsProducto> ConsultarProductos(int ciUsuario)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var x = (from a in ctx.productosafiliados
        //                 join b in ctx.afiliados on a.IdAfiliado equals b.IdAfiliado
        //                 where a.Estado == "ACTIVO"
        //                 && a.IdAfiliado == ciUsuario
        //                 //&& a.FechaCreacion.Date.Year == DateTime.Now.Year
        //                 //&& a.FechaCreacion.Date.Month <= (DateTime.Now.Month - 1)
        //                 orderby a.IdProductoAfiliado descending
        //                 select new ModeloDatos.Entidades.clsProducto()
        //                 {
        //                     IdProducto = a.IdProductoAfiliado,
        //                     ControlProducto = a.ControlProducto,
        //                     IdAfiliado = b.IdAfiliado,
        //                     Afiliado = b.Nombre,
        //                     Titulo = a.NombreProducto,
        //                     Descripcion = a.AcercaDe,
        //                     Precio = a.PrecioConsulta,
        //                     FechaCreacion = a.FechaCreacionConsulta,
        //                     Usuario = a.UsuarioCreacion,
        //                     Estado = a.Estado,
        //                     RutaFoto = a.RutaFoto
        //                 }).Take(50).ToList();

        //        return x;
        //    }
        //}
        
        //public void SaveProductos(productosafiliados PromocionNueva)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var promo = ctx.productosafiliados.Where(a => a.IdProductoAfiliado == PromocionNueva.IdProductoAfiliado && PromocionNueva.Estado == "ACTIVO").ToList();

        //        if (promo.Count == 0)
        //        {
        //            ctx.productosafiliados.Add(PromocionNueva);
        //        }
        //        else
        //        {
        //            foreach (productosafiliados promos in promo)
        //            {
        //                promos.NombreProducto = PromocionNueva.NombreProducto;
        //                promos.AcercaDe = PromocionNueva.AcercaDe;

        //                promos.Precio = PromocionNueva.Precio;
        //                promos.PrecioConsulta = PromocionNueva.PrecioConsulta;
        //                promos.ControlProducto = PromocionNueva.ControlProducto;

        //                promos.IdentificacionAfiliado = PromocionNueva.IdentificacionAfiliado;
        //                promos.ControlAfiliado = PromocionNueva.ControlAfiliado;
                        
        //                promos.FechaActualizacion = PromocionNueva.FechaCreacion;
        //                promos.UsuarioActualiacion = PromocionNueva.UsuarioCreacion;
        //                promos.Estado = PromocionNueva.Estado;
                        
        //                promos.FechaCreacionConsulta = PromocionNueva.FechaCreacionConsulta;
        //                promos.IdAfiliado = PromocionNueva.IdAfiliado;
                        
        //                promos.RutaFoto = PromocionNueva.RutaFoto;
        //            }
        //        }
        //        ctx.SaveChanges();
        //    }
        //}
        
        //public void DelProductos(int idPromocion, string idUsuario)
        //{
        //    using (EncuestaEntities ctx = new EncuestaEntities())
        //    {
        //        var promo = ctx.productosafiliados.Where(a => a.IdProductoAfiliado == idPromocion).ToList();

        //        if (promo.Count > 0)
        //        {
        //            foreach (productosafiliados promos in promo)
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
