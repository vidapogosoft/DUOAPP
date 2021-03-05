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
    public class clsNUsuario
    {
        clsDadUsuario clsUsuarioDA = new clsDadUsuario();
        clsDPersona clsPersonalDA = new clsDPersona();
        public List<ModeloDatos.Entidades.clsPerfilMenuAsignado> GetPantallaAccesoUsuario(int ciCompania, string ciUsuario, string txUrl)
        {

            return clsUsuarioDA.GetPantallaAccesoUsuario(ciCompania, ciUsuario, txUrl);
        }

        public List<adusuarios> ConsultarUsuarios(string idUsuario, int ciCompania)
        {
            return clsUsuarioDA.Get(new adusuarios() { ciUsuario = idUsuario, ciEstado = clsParametos.EstadoActivo }).ToList();
        }

        public List<persona> ConsultarPersonal(int ciCompania)
        {

            var personas = clsPersonalDA.Get(new persona() { ciEstado = clsParametos.EstadoActivo, IdPersona = 5 }).ToList();
            //personas.Insert(0, new persona() { IdPersona = 0, ApellidoPaterno = "SELECCIONE" });
            return personas;
        }

        //public int ActualizarUsuario(adusuarios toUsuario, int ciCompania)
        //{
        //    int grabado = 0;
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDadUsuario clsUsuarioDA = new clsDadUsuario();
        //        clsUsuarioDA.Save(toUsuario);

        //        clsDUsuarioCompania clsUsuarioComp = new clsDUsuarioCompania();
        //        clsUsuarioComp.Save(new adusuarioscompania()
        //        {
        //            ciCompania = ciCompania,
        //            ciUsuario = toUsuario.ciUsuario,
        //            fcUsuarioIngreso = DateTime.Now,
        //            ciUsuarioIngreso = toUsuario.ciUsuarioIngreso,
        //            ciEstado = toUsuario.ciEstado
        //        });
        //        trans.Complete();
        //        grabado = 1;
        //        return grabado;
        //    }
        //}

        public void ActualizarPerfilUsuario(adusuarioperfil pUsuario)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                clsDadUsuario clsUsuarioDA = new clsDadUsuario();
                clsUsuarioDA.SaveUsuarioPerfil(pUsuario);
                trans.Complete();
            }
        }

        public List<persona> ConsultarPersonalAdmin(int ciCompania)
        {

            var personas = clsPersonalDA.Get(new persona() { ciEstado = clsParametos.EstadoActivo }).ToList();
            //personas.Insert(0, new persona() { IdPersona = 0, ApellidoPaterno = "SELECCIONE" });
            return personas;
        }

        public int ActualizarUsuario(adusuarios toUsuario, int ciCompania)
        {
            int grabado = 0;
            using (TransactionScope trans = new TransactionScope())
            {
                clsDadUsuario clsUsuarioDA = new clsDadUsuario();
                clsUsuarioDA.Save(toUsuario);

                clsDUsuarioCompania clsUsuarioComp = new clsDUsuarioCompania();
                clsUsuarioComp.Save(new adusuarioscompania()
                {
                    ciCompania = ciCompania,
                    ciUsuario = toUsuario.ciUsuario,
                    fcUsuarioIngreso = DateTime.Now,
                    ciUsuarioIngreso = toUsuario.ciUsuarioIngreso,
                    ciEstado = toUsuario.ciEstado
                });
                trans.Complete();
                grabado = 1;
                return grabado;
            }
        }

        //public int ActualizarUsuarioProveedor(adusuarioproveedor toUsuario)
        //{
        //    int grabado = 0;
        //    using (TransactionScope trans = new TransactionScope())
        //    {
        //        clsDadUsuario clsUsuarioDA = new clsDadUsuario();
        //        clsUsuarioDA.SaveUsuarioProveedor(toUsuario);

        //        trans.Complete();
        //        grabado = 1;
        //        return grabado;
        //    }
        //}

        public void ActualizarImagen(string tsIdUsuario, string tsRuta, string tsUsuarioModificacion)
        {
            clsDadUsuario clsUsuarioDA = new clsDadUsuario();
            var usuario = clsUsuarioDA.Get(new adusuarios() { ciUsuario = tsIdUsuario }).FirstOrDefault();
            if (usuario != null)
            {
                usuario.txDirectorioImagen = tsRuta;
                usuario.ciUsuarioModificacion = tsUsuarioModificacion;
                usuario.fcModificacion = DateTime.Now;
                clsUsuarioDA.Save(usuario);
            }
        }

        //public bool validarUsuario(string idUsuario, int ciCompania, int ciPersonaSeleccionada)
        //{
        //    clsDUsuarioCompania clsUsuarioCompDA = new clsDUsuarioCompania() { Include = true, adUsuario = true };
        //    var res = clsUsuarioCompDA.Get(new adusuarioscompania() { ciCompania = ciCompania, ciEstado = clsParametos.EstadoActivo }).ToList();
        //    var personas = res.Where(a => a.ciUsuario != idUsuario).Select(a => a.adUsuarios).ToList();
        //    return personas.Where(a => a.ciPersonalCooperativa == ciPersonaSeleccionada).Count() > 0;
        //}
    }
}

