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
    public class clsNAfiliados
    {
        clsDAfiliados clsDAfiliado = new clsDAfiliados();

        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliadoAdmin()
        //{
        //    return clsDAfiliado.ConsultarAfiliadoAdmin();
        //}

        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliado(string ciUsuario)
        //{
        //    return clsDAfiliado.ConsultarAfiliado(ciUsuario);
        //}

        //public List<ModeloDatos.Entidades.clsAfiliado> ConsultarAfiliadoById(int Idproveedor)
        //{
        //    return clsDAfiliado.ConsultarAfiliadoById(Idproveedor);
        //}

        

        //public int SaveAfiliado(afiliados Prove)
        //{
        //    int grabado = 0;
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDAfiliado.SaveAfiliado(Prove);
        //        trans.Complete();
        //        grabado = 1;
        //    }

        //    return grabado;
        //}

        //public void DelAfiliado(int idProveedores, string idUsuario)
        //{
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDAfiliado.DelAfiliado(idProveedores, idUsuario);
        //        trans.Complete();
        //    }
        //}


    }
}
