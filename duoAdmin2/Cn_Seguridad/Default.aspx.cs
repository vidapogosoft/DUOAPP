using ModeloDatos;
using Negocio;
using System;
using System.Configuration;
using System.Web.UI;

namespace Cn_Seguridad
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //((SiteMaster)this.Master).MostrarMensaje("MostrarMensajeKey" + DateTime.Now.Millisecond, "Chopin APP!", "Bienvenido " + Session["txUsuario"].ToString(), clsParametos.TipoMensaje.Success);
                DateTime fcLicencia;

                try
                {
                    string key = ConfigurationManager.AppSettings.Get("Serial");
                    //clsNSeguridad seguridadBL = new clsNSeguridad();
                    //key = seguridadBL.Desencriptar(key);
                    //fcLicencia = new DateTime(int.Parse(key.Split(';')[0]), int.Parse(key.Split(';')[1]), int.Parse(key.Split(';')[2]));
                    //if(DateTime.Now.Date>= fcLicencia.Date.AddMonths(-1).Date)
                    //    ((SiteMaster)this.Master).MostrarMensaje("MostrarMensajeKeySerial", "Advertencia",
                    //        string.Format("Su licencia del EasyBAS va a caducar el {0}. Por favor renovar la licencia antes de la fecha.", fcLicencia.ToShortDateString()), clsParametos.TipoMensaje.Warning);
                }
                catch
                {
                    //((SiteMaster)this.Master).MostrarMensaje("MostrarMensajeKeySerial", "Advertencia", "Su licencia no es valida.", clsParametos.TipoMensaje.Error);
                    Session.RemoveAll();
                    Response.Redirect("~/Account/Login.aspx");

                }
            }
        }
    }
}