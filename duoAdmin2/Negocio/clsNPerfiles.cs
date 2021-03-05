using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using ModeloDatos;
using System.Transactions;

namespace Negocio
{

    public class clsNPerfiles
    {
        public List<adperfil> ConsultarPerfiles(int ciCompania)
        {
            clsDPerfiles clsPerfilesDA = new clsDPerfiles();
            var perfiles = clsPerfilesDA.Get(new adperfil() { ciCompania = ciCompania, ciEstado = clsParametos.EstadoActivo }).ToList();
            return perfiles;
        }

        public List<adusuarioperfil> ConsultarPerfilesUsuarios(int ciCompania, string ciUsuario)
        {
            clsDPerfiles clsPerfilesDA = new clsDPerfiles();
            var perfilesU = clsPerfilesDA.GetUP(new adusuarioperfil() { ciCompania = ciCompania, ciUsuario = ciUsuario, ciEstado = clsParametos.EstadoActivo }).ToList();
            return perfilesU;
        }

        public List<ModeloDatos.Entidades.clsPerfilMenuAsignado> GetPerfilMenu(int perfil)
        {
            clsDPerfiles clsPerfilesDA = new clsDPerfiles();
            var MenuPerfil = clsPerfilesDA.GetPerfilMenu(perfil);
            return MenuPerfil;
        }

        //public List<spConsultarPerfilMenuNoAsignado_Result> GetPerfilMenuNoAsignado(int perfil)
        //{
        //    clsDPerfiles clsPerfilesDA = new clsDPerfiles();
        //    var MenuPerfil = clsPerfilesDA.GetPerfilMenuNoAsignado(perfil);
        //    return MenuPerfil;
        //}

        public void SavePerfilMenu(adperfilmenu mPerfilUsuario)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                clsDPerfiles clsPerfilesDA = new clsDPerfiles();
                clsPerfilesDA.SavePerfilMenu(mPerfilUsuario);
                trans.Complete();
            }
        }

        public void DelPerfilMenu(int idMenu, int idPerfil, string idUsuario)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                clsDPerfiles clsPerfilesDA = new clsDPerfiles();
                clsPerfilesDA.DelPerfilMenu(idMenu, idPerfil, idUsuario);
                trans.Complete();
            }
        }

        public void SavePerfil(adperfil mPerfil, int ciPerfil)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                clsDPerfiles clsPerfilesDA = new clsDPerfiles();
                clsPerfilesDA.SavePerfil(mPerfil, ciPerfil);
                trans.Complete();
            }
        }

        public List<adperfil> ConsultaPerfil(int ciCompania, int ciPerfil)
        {
            clsDPerfiles clsPerfilesDA = new clsDPerfiles();
            var perfiles = clsPerfilesDA.Get(new adperfil() { ciCompania = ciCompania, ciPerfil = ciPerfil }).ToList();
            return perfiles;
        }
    }

}
