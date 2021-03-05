using ModeloDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Cn_Seguridad
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private clsNMaster clsMasterBL;
        protected bool bdAdmin;
        private clsNLogin clsLoginBL;

        protected void Page_Init(object sender, EventArgs e)
        {

            validarUsuarioAutenticado();
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            if (!IsPostBack)
            {
                lbl_UserBienvenido.Text = Session["txUsuario"].ToString();
                lbl_UserProfile.Text = Session["txUsuario"].ToString();

                if (Session["bdAdmin"] != null)
                    bdAdmin = bool.Parse(Session["bdAdmin"].ToString());

            }
            Page.PreLoad += master_Page_PreLoad;
        }

        private void GenerarMenu()
        {
            img_perfil.ImageUrl = clsMasterBL.ConsultarImagenUsuario(Session["ciUsuario"].ToString());
            imgMenu.ImageUrl = img_perfil.ImageUrl;
            img_comp.ImageUrl = clsMasterBL.ConsultarImagenCompania(int.Parse(Session["ciCompania"].ToString()));
            if (bdAdmin)
            {
                lit_menu.Text = clsMasterBL.ConsultarMenu();
            }
            else
            {
                lit_menu.Text = clsMasterBL.ConsultarMenuUsuario(Session["ciUsuario"].ToString(), int.Parse(Session["ciCompania"].ToString()));
            }

        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            lbl_UserBienvenido.Text = Session["txUsuario"].ToString();
            lbl_UserProfile.Text = Session["txUsuario"].ToString();
            clsMasterBL = new clsNMaster();
            clsLoginBL = new clsNLogin();
            if (!IsPostBack)
            {
                Session["ciCompania"] = 1;

                bool bdAdmin = (((bool?)Session["bdAdmin"]) ?? false) || (((bool?)Session["bdAdminPerfil"]) ?? false);

                CargarCompanias(bdAdmin);
                CargarLocalidades(bdAdmin);

                if (Session["ciLocalidad"] == null)
                {
                    if (ddl_localidadMaster.SelectedValue != null && ddl_localidadMaster.SelectedValue != "")
                        Session["ciLocalidad"] = ddl_localidadMaster.SelectedValue ?? "0";
                    else

                        Session["ciLocalidad"] = 0;
                }
                else ddl_localidadMaster.SelectedValue = Session["ciLocalidad"].ToString();


                if (Session["ciCompania"] == null)
                {
                    if (ddl_compania.SelectedValue != null && ddl_compania.SelectedValue != "")
                        Session["ciCompania"] = ddl_compania.SelectedValue ?? "0";
                    else
                        Session["ciCompania"] = 0;
                }
                else ddl_compania.SelectedValue = Session["ciCompania"].ToString();

                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;

                GenerarMenu();
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
                CrearNotificacionesBarra(false);

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //       Context.GetOwinContext().Authentication.SignOut();
        }

        protected void lkb_CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Account/Login.aspx");
        }

        void validarUsuarioAutenticado()
        {
            if (Session["ciUsuario"] == null)
                Response.Redirect("~/Account/Login.aspx");
        }

        public void MostrarMensaje(string key, string titulo, string mensaje, clsParametos.TipoMensaje tipo)
        {
            mensaje = mensaje.Replace("\n", "\\n").Replace("\r", "\\r");
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
                (this.MainContent.Page, this.MainContent.Page.GetType(), key + DateTime.Now.Millisecond, string.Format("mostrarMensaje('{0}',\"{1}\",'{2}',{3}); ", titulo, mensaje, tipoMensaje, tiempo), true);
        }


        private void CargarCompanias(bool bdAdmin)
        {
            clsNMaster clsMasterBL = new clsNMaster();

            List<adcompania> listaCompanias = clsMasterBL.ConsultarCompaniaPorUsuario(Session["ciUsuario"].ToString(), bdAdmin);
            if (listaCompanias != null)
            {
                listaCompanias = listaCompanias.OrderBy(x => x.txRazonSocial).ToList();
                listaCompanias.ForEach(x => x.txRazonSocial = x.txRazonSocial.ToUpper());
                ddl_compania.DataTextField = "txNombreComercial";
                ddl_compania.DataValueField = "ciCompania";
                ddl_compania.DataSource = listaCompanias;
                ddl_compania.DataBind();
            }
        }


        private void CargarLocalidades(bool bdAdmin)
        {
            clsNMaster clsMasterBL = new clsNMaster();
            if (ddl_compania.SelectedValue != null && ddl_compania.SelectedValue != "")
            {

                List<adlocalidades> listaCompanias = clsMasterBL.ConsultarLocalidadesPorUsuarios(Session["ciUsuario"].ToString(), Session["ciCompania"] != null ? int.Parse(Session["ciCompania"].ToString()) : int.Parse(ddl_compania.SelectedValue), bdAdmin);
                if (listaCompanias != null)
                {
                    listaCompanias = listaCompanias.OrderBy(x => x.txDescripcion).ToList();
                    listaCompanias.ForEach(x => x.txDescripcion = x.txDescripcion.ToUpper());
                    ddl_localidadMaster.DataTextField = "txDescripcion";
                    ddl_localidadMaster.DataValueField = "ciLocalidad";
                    ddl_localidadMaster.DataSource = listaCompanias;
                    ddl_localidadMaster.DataBind();
                }
            }
        }


        protected void ddl_compania_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ciCompania"] = int.Parse(ddl_compania.SelectedValue);
            CargarLocalidades((((bool?)Session["bdAdmin"]) ?? false) || (((bool?)Session["bdAdminPerfil"]) ?? false));
            Response.Redirect(Request.RawUrl, true);


        }

        protected void tmr_Notificaciones_Tick(object sender, EventArgs e)
        {
            try
            {
                //CrearNotificacionesBarra(false);
                //MostrarNotificacionesPupUp();
            }
            catch
            {
            }

        }



        private void MostrarNotificacionesPupUp()
        {
            int i = 0;
            if (ddl_compania.SelectedValue != "")
            {
                foreach (var mensaje in clsMasterBL.ConsultarNotificaciones(int.Parse(ddl_compania.SelectedValue), Session["ciUsuario"].ToString()))
                {
                    MostrarMensaje("NotificacionKey" + i, "Nueva Notificación", mensaje.txMensaje, clsParametos.TipoMensaje.Notice);
                    i++;
                }
            }

            NotificacionesPupUpLeida();

        }

        private void NotificacionesPupUpLeida()
        {
            clsMasterBL.NotificacionesPopUpLeida(int.Parse(ddl_compania.SelectedValue), Session["ciUsuario"].ToString());
        }

        private void CrearNotificacionesBarra(bool tbActualiza)
        {
            if (ddl_compania.SelectedValue != "")
                clsMasterBL.ConsultarNotificaciones(int.Parse(ddl_compania.SelectedValue), Session["ciUsuario"].ToString(), ref lit_Notificaciones, ref lit_CantNotif, tbActualiza);
        }

        private void NotificacionesBarraLeida()
        {
            clsMasterBL.NotificacionesBarraLeida(int.Parse(ddl_compania.SelectedValue), Session["ciUsuario"].ToString());
        }

        protected void btnActualizarNotif_Click(object sender, EventArgs e)
        {
            CrearNotificacionesBarra(true);
            NotificacionesBarraLeida();
        }


        public void RegistrarScript(string Key, string Script)
        {
            ScriptManager.RegisterStartupScript(this.MainContent.Page, this.MainContent.Page.GetType(), Key, Script, true);
        }

        protected void ddl_localidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsNMaster clsMasterBL = new clsNMaster();
            Session["ciLocalidad"] = ddl_localidadMaster.SelectedValue;
            Response.Redirect(Request.RawUrl, true);
        }
        

    }
}