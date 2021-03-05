using ModeloDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;


namespace Cn_Seguridad.Account
{
    public partial class Login : Page
    {

        clsNLogin clsLoginBL;
        protected void Page_Load(object sender, EventArgs e)
        {
            //UsuarioLogIn("vidapogosoft", "012018");
        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                bool valido = false;
                //DateTime fcLicencia;
                try
                {
                    //string key = ConfigurationManager.AppSettings.Get("Serial");
                    //clsNSeguridad seguridadBL = new clsNSeguridad();
                    //key = seguridadBL.Desencriptar(key);
                    //fcLicencia = new DateTime(int.Parse(key.Split(';')[0]), int.Parse(key.Split(';')[1]), int.Parse(key.Split(';')[2]));
                    //valido = DateTime.Now <= fcLicencia && key.Split(';')[3] == "FMAvalido";
                    valido = true;

                }
                catch
                {
                    valido = false;
                    MostrarMensaje("Advertencia", "Su licencia no es valida.", clsParametos.TipoMensaje.Error);
                }


                if (valido)
                    UsuarioLogIn(txt_Usuario.Text.Trim(), txt_Password.Text);
                else
                    MostrarMensaje("Advertencia", "Su licencia ha caducado", clsParametos.TipoMensaje.Error);
            }

            catch (Exception ex)
            {
                string mensaje = ex.Message;
                if (ex.InnerException != null)
                    mensaje += "  " + ex.InnerException.Message;
                MostrarMensaje("Advertencia", mensaje, clsParametos.TipoMensaje.Error);
            }
        }


        void UsuarioLogIn(string txUsuario, string txClave)
        {
            //Session["ciUsuario"] = "vidapogosoft";
            //Session["txUsuario"] = "Victor Portugal";

            clsLoginBL = new clsNLogin();
            adusuarios usuarioAutenticar = new adusuarios() { txClave = txClave.Trim(), ciUsuario = txUsuario.Trim(), ciEstado = clsParametos.EstadoActivo };
            adusuarios usuarioResp = clsLoginBL.autenticarUsuario(usuarioAutenticar);


            if (usuarioResp != null)
            {
                Session["bdAdmin"] = usuarioResp.bdMaster;
                Session["ciUsuario"] = usuarioResp.ciUsuario;
                Session["txUsuario"] = usuarioResp.txNombreCorto;
                //Session["bdAdminPerfil"] = clsLoginBL.PerfilesusuarioAdmin(usuarioResp.ciUsuario).Count > 0;
                var res = clsLoginBL.PerfilesusuarioAdmin(usuarioResp.ciUsuario);

                if (res.Count > 0)
                {
                    Session["bdAdminPerfil"] = true;
                }

                if (string.IsNullOrEmpty(hdf_ipUser.Value))
                    Session["ipUsuario"] = GetIPAddress();
                else
                    Session["ipUsuario"] = hdf_ipUser.Value;


                HttpContext.Current.Response.Redirect("~/Default.aspx");
                //Response.Redirect("~/Default.aspx");
            }
            else
            {
                MostrarMensaje("Advertencia", "Los datos ingresados no coinciden.", clsParametos.TipoMensaje.Error);
            }

        }


        protected string GetIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddress = "";
            foreach (var item in ipHostInfo.AddressList)
            {
                if (item.ToString().Length <= 15)
                    ipAddress = item.ToString();
            }

            return ipAddress;
        }


        void MostrarMensaje(string titulo, string mensaje, clsParametos.TipoMensaje tipo)
        {
            mensaje = mensaje.Replace("\n", "\\n").Replace("\r", "\\r").Replace("\t", "\\t");
            string tipoMensaje = string.Empty;

            int tiempo = 7000;
            switch (tipo)
            {
                case clsParametos.TipoMensaje.Success:
                    tipoMensaje = "success";
                    tiempo = 5500;
                    break;
                case clsParametos.TipoMensaje.Error:
                    tipoMensaje = "error";
                    titulo = "Advertencia";
                    tiempo = 7000;
                    break;
                case clsParametos.TipoMensaje.Info:
                    tipoMensaje = "info";
                    tiempo = 10000;
                    break;
                case clsParametos.TipoMensaje.Warning:
                    tipoMensaje = "warning";

                    break;
                case clsParametos.TipoMensaje.Notice:
                    tipoMensaje = "notice";

                    break;
            }
            ScriptManager.RegisterStartupScript
               (Page, Page.GetType(), "MensajeLogInKey" + DateTime.Now.Millisecond, string.Format("mostrarMensaje('{0}',\"{1}\",'{2}',{3}); ", titulo, mensaje, tipoMensaje, tiempo), true);
        }
    }
}