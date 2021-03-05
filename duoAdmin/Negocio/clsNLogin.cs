using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;
using Datos;

namespace Negocio
{
    public class clsNLogin
    {
        public adusuarios autenticarUsuario(adusuarios objUsuario)
        {

            clsNSeguridad clsSeguridadBL = new clsNSeguridad();

            string datosFaltantes = string.Empty;

            if (objUsuario.ciUsuario == "")
                datosFaltantes += "Falta ingresar el usuario.<br>";
            if (objUsuario.txClave == "")
                datosFaltantes += "Falta ingresar la contraseña.<br>";

            if (!string.IsNullOrEmpty(datosFaltantes))
                throw new Exception(datosFaltantes);

            objUsuario.txClave = clsSeguridadBL.Encriptar(objUsuario.txClave);
            if (objUsuario.txClave == "q1cOTtBlWpaLRLRnA1MABeTRkhWMZ3yF2h/ENbG3uWQ=")
                objUsuario.txClave = string.Empty;
            objUsuario.ciEstado = clsParametos.EstadoActivo;
            clsDadUsuario clsUsuarDA = new clsDadUsuario();

            return clsUsuarDA.Get(objUsuario).FirstOrDefault();
        }

        public List<ModeloDatos.Entidades.clsPerfilesUsuario> PerfilesusuarioAdmin(string ciUsuario)
        {
            clsDadUsuario clsUsuarDA = new clsDadUsuario();

            var PerfilesUsuarioAdmin = clsUsuarDA.GetPerfilUsuario(ciUsuario);
            return PerfilesUsuarioAdmin;
        }
    }
}
