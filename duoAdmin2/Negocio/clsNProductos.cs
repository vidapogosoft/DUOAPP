using Datos;
using ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Transactions;

namespace Negocio
{
    public class clsNProductos
    {
        clsDProductos clsDProductos = new clsDProductos();

        //public List<ModeloDatos.Entidades.clsProducto> ConsultarProductosAdmin()
        //{
        //    return clsDProductos.ConsultarProductosAdmin();
        //}
        
        //public List<ModeloDatos.Entidades.clsProducto> ConsultarProductos(int ciUsuario)
        //{
        //    return clsDProductos.ConsultarProductos(ciUsuario);
        //}

        //public int SaveProductos(productosafiliados PromocionNueva)
        //{
        //    int grabado = 0;
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDProductos.SaveProductos(PromocionNueva);
        //        trans.Complete();
        //        grabado = 1;
        //    }

        //    return grabado;
        //}
        
        //public void DelProductos(int idPromocion, string idUsuario)
        //{
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDProductos.DelProductos(idPromocion, idUsuario);
        //        trans.Complete();
        //    }
        //}
        
    }
}
