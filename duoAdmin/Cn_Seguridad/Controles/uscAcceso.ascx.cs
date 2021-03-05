using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ModeloDatos;
using Negocio;


namespace Cn_Seguridad.Controles
{
    public partial class uscAcceso : UserControl
    {
        protected string ciUsuario;
        protected bool bdAdmin;
        protected bool bdAdminPerfil;

        clsNUsuario clsUsuarioBL = new clsNUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {

                    int ciCompania = int.Parse(Session["ciCompania"].ToString());

                    if (Session["ciUsuario"] != null)
                        ciUsuario = Session["ciUsuario"].ToString();

                    if (Session["bdAdmin"] != null)
                        bdAdmin = bool.Parse(Session["bdAdmin"].ToString());


                    if (Session["bdAdminPerfil"] != null)
                        bdAdminPerfil = bool.Parse(Session["bdAdminPerfil"].ToString());


                    Uri MyUrl = Request.Url;
                    var PantallaAccedida = MyUrl.Segments[MyUrl.Segments.Length - 1];

                    var res = clsUsuarioBL.GetPantallaAccesoUsuario(ciCompania, ciUsuario, PantallaAccedida);

                    if (!(bdAdmin || bdAdminPerfil) && res.Count == 0)
                        HttpContext.Current.Response.Redirect("~/Acceso.html");


                }
                catch (Exception ex)
                {
                    ((SiteMaster)Page.Master).MostrarMensaje("MensajeKey" + DateTime.Now.Millisecond, "Advertencia Seguridad",
                        string.Format("{0}", ex.InnerException == null ? ex.Message : ex.InnerException.Message), clsParametos.TipoMensaje.Warning);
                }
            }

        }
    }
}