using ModeloDatos;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cn_Seguridad
{
    public abstract class clsBase : Page
    {
        #region Atributos


        protected enum TipoEdicion { id, index };

        protected int ciCompania;
        protected string ciUsuario;
        protected int ciVentanilla;
        protected int ciLocalidad;
        protected string ciIp;
        protected bool bdAdmin;
        protected bool bdAdminPerfil;
        protected string txAnioDeportivo;
        #endregion


        #region Eventos

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            ciCompania = int.Parse(Session["ciCompania"].ToString());
            ciUsuario = Session["ciUsuario"].ToString();
            if (Session["ciVentanilla"] == null)
                ciVentanilla = 0;
            else
                ciVentanilla = int.Parse(Session["ciVentanilla"].ToString());
            ciIp = Session["ipUsuario"].ToString();

            if (Session["ciLocalidad"] != null && Session["ciLocalidad"].ToString() != "")
                ciLocalidad = int.Parse(Session["ciLocalidad"].ToString());
            else ciLocalidad = 0;

            if (Session["bdAdmin"] != null)
                bdAdmin = bool.Parse(Session["bdAdmin"].ToString());

            if (Session["bdAdminPerfil"] != null)
                bdAdminPerfil = bool.Parse(Session["bdAdminPerfil"].ToString());

            dynamic grid = Master.FindControl("maincontent").FindControl("grvConsulta");

            if (grid != null && grid.HeaderRow != null)
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;

            if (Session["AnioDeportivo"] != null)
                txAnioDeportivo = Session["AnioDeportivo"].ToString();

        }

        protected void grvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LimpiarModal();
                // Este comando se debera usar cuando se tienen todos los datos en el grid y no es necesario consultarlos nuevamente
                if (e.CommandName.Equals("Editar"))
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    AsignarDatosAControles(TipoEdicion.index, index);
                    AbrirModal();
                }

                else if (e.CommandName.Equals("EditarXId"))
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    AsignarDatosAControles(TipoEdicion.id, id);
                    AbrirModal();
                }
                else /*if (e.CommandName != "Page")*/
                    ProcesarComandos(e);

            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        // Boton de la pantalla modal que envia a guardar la informacion 
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validar())
                {
                    ActualizarDatos();
                    CerrarModal();
                    Consultar();

                    ((SiteMaster)Page.Master).MostrarMensaje("MensajeModalExitoKey", "Exito", "Se grabo correctamente", clsParametos.TipoMensaje.Success);
                }
                else return;
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarConsulta())
                    Consultar();
            }

            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        protected void grvConsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                ((GridView)sender).PageIndex = e.NewPageIndex;
                Consultar();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        // Este es el evento del boton en la pantalla que sirve para presentar la panatalla modal para ingresar nuevos registros 
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarDatosAControles();
                AbrirModal();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }

        }

        // Boton de la pantalla que envia a guardar la informacion 
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validar())
                {
                    ActualizarDatos();
                    MostrarMensaje("Exito", "Se grabo correctamente", clsParametos.TipoMensaje.Success);
                    //((SiteMaster)Page.Master).MostrarMensaje("MensajeModalExitoKey", "Exito", "Se grabo correctamente", clsParametos.TipoMensaje.Success);
                }
                else return;
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #endregion

        // Este metodo sirve para levantar la pantalla modal con los datos de la fila escogida para poder modificarlos 

        protected void MostrarError(string error)
        {
            MostrarMensaje("Error", error, clsParametos.TipoMensaje.Error);
        }

        protected void MostrarError(Exception ex)
        {
            MostrarError(string.Format("{0}", ex.InnerException == null ? ex.Message : ex.InnerException.Message));
        }

        public void MostrarMensaje(string Titulo, string Mensaje, clsParametos.TipoMensaje tipo)
        {
            MostrarMensaje("MensajeKey" + DateTime.Now.Millisecond, Titulo, Mensaje, tipo);
        }

        public void MostrarMensaje(string key, string Titulo, string Mensaje, clsParametos.TipoMensaje tipo)
        {
            ((SiteMaster)Page.Master).MostrarMensaje(key, Titulo, Mensaje, tipo);
        }

        protected void CerrarModal()
        {
            ((SiteMaster)Page.Master).RegistrarScript("CerrarModalMantKey" + DateTime.Now.Millisecond, "$('#modalMant').modal('hide');");
        }

        protected void AbrirModal()
        {
            ((SiteMaster)Page.Master).RegistrarScript("AbrirModalMantKey", "$('#modalMant').modal('show');");
        }

        #region Metodo para sobreescribir

        protected virtual void Consultar() { }
        protected virtual void AsignarDatosAControles() { }
        protected virtual void AsignarDatosAControles(TipoEdicion tipo, int valor) { }
        protected virtual void ProcesarComandos(GridViewCommandEventArgs e) { }
        protected virtual bool Validar() { return true; }
        protected virtual bool ValidarConsulta() { return true; }

        protected virtual void ActualizarDatos() { }
        protected virtual void LimpiarModal() { }

        #endregion


        protected void ExportToExcel(object sender, EventArgs e)
        {
            GenerarArchivoExcel();
        }
        protected void GenerarArchivoExcel()
        {/*
            //To Export all pages
            _gridView.AllowPaging = false;
            _gridView.ShowFooter = false;
            this.Consultar();

            // Reference your own GridView here
            if (_gridView.Rows.Count > 65535)
            {
                MostrarError("Exportacion a Excel no esta permitiro debido al excesivo numero de filas .");
                return;
            }

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + _filename + ".xls");
            Response.Charset = "";

            // SetCacheability doesn't seem to make a difference (see update)
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

            // Replace all gridview controls with literals
            _master.ClearControls(_gridView);

            // Throws exception: Control 'ComputerGrid' of type 'GridView'
            // must be placed inside a form tag with runat=server.
            // ComputerGrid.RenderControl(htmlWrite);

            // Alternate to ComputerGrid.RenderControl above
            System.Web.UI.HtmlControls.HtmlForm form
                = new System.Web.UI.HtmlControls.HtmlForm();
            Controls.Add(form);
            form.Controls.Add(_gridView);
            form.RenderControl(htmlWriter);

            Response.Write(stringWriter.ToString());
            Response.End();*/
        }


        public void RegistrarScript(string Key, string Script)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), Key + DateTime.Now.Millisecond, Script, true);
        }

    }
}