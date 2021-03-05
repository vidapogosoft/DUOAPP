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
    public class clsNRegistrados
    {
        clsDRegistrados clsDRegistrados = new clsDRegistrados();

        public List<ModeloDatos.Entidades.clsRegistrado> ConsultarRegistradoById(int IdRegistrado)
        {
            return clsDRegistrados.ConsultarRegistradoById(IdRegistrado);
        }

        public int SavePerfilDuo(PerfilDuo Perfil)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                grabado = clsDRegistrados.SavePerfilDuo(Perfil);
                trans.Complete();
            }

            return grabado;
        }

        public int SaveTrabajoDuo(works Perfil)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                grabado = clsDRegistrados.SaveTrabajoDuo(Perfil);
                trans.Complete();
            }

            return grabado;
        }

        public int SaveProductDuo(Products Perfil)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                grabado = clsDRegistrados.SaveProductDuo(Perfil);
                trans.Complete();
            }

            return grabado;
        }

        public int SaveAnuncioDuo(Anuncio Ads)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                grabado = clsDRegistrados.SaveAnuncioDuo(Ads);
                trans.Complete();
            }

            return grabado;
        }

        public int SaveAnuncioImageDuo(AnuncioImages AdsIm)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                grabado = clsDRegistrados.SaveAnuncioImageDuo(AdsIm);
                trans.Complete();
            }

            return grabado;
        }

        public List<ModeloDatos.Entidades.clsPerfilDUO> ConsultarPerfilById(int IdRegistrado)
        {
            return clsDRegistrados.ConsultarPerfilById(IdRegistrado);
        }

        public List<ModeloDatos.Entidades.clsPerfilDUO> ConsultarWorksById(int IdRegistrado)
        {
            return clsDRegistrados.ConsultarWorksById(IdRegistrado);
        }
    }
}
