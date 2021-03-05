using ModeloDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Cn_Seguridad.Parametros
{
    public partial class frmUsuarios : clsBase
    {
        clsNUsuario clsUsuarioBL;
        clsNPerfiles clsPerfilesBL = new clsNPerfiles();
        const string ImgDefault = "~/Imagenes/Usuarios/default.png";
        // clsProveedoresBL = new clsNProveedores();


        protected override void Page_Load(object sender, EventArgs e)
        {
            if (grvAsignaPerfiles != null && grvAsignaPerfiles.HeaderRow != null)
                grvAsignaPerfiles.HeaderRow.TableSection = TableRowSection.TableHeader;

            base.Page_Load(sender, e);
            clsUsuarioBL = new clsNUsuario();

            fup_imagen.Attributes["onchange"] = "UploadFile(this)";
            if (!IsPostBack)
            {
                try
                {
                    RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");

                    Consultar();

                    if (bdAdmin)
                    {
                        //CargaProveedorAdmin();
                        cargarPersonalAdmin();
                    }
                    else
                    {
                        //CargaProveedor();
                        cargarPersonal();
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex);
                }

            }

        }
        private void cargarPersonal()
        {
            ddl_persona.DataSource = clsUsuarioBL.ConsultarPersonal(ciCompania);
            ddl_persona.DataTextField = "ApellidoPaterno";
            ddl_persona.DataValueField = "IdPersona";
            ddl_persona.DataBind();
        }

        private void cargarPersonalAdmin()
        {
            ddl_persona.DataSource = clsUsuarioBL.ConsultarPersonalAdmin(ciCompania);
            ddl_persona.DataTextField = "ApellidoPaterno";
            ddl_persona.DataValueField = "IdPersona";
            ddl_persona.DataBind();
        }

        protected override void Consultar()
        {
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            if (bdAdmin || bdAdminPerfil)
            {
                grvConsulta.DataSource = clsUsuarioBL.ConsultarUsuarios(txt_usuario.Text, ciCompania);
                btn_agregarUsuario.Visible = true;
            }
            else
            { grvConsulta.DataSource = clsUsuarioBL.ConsultarUsuarios(ciUsuario, ciCompania); }

            grvConsulta.DataBind();

            if (grvConsulta != null && grvConsulta.HeaderRow != null)
                grvConsulta.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected override void ProcesarComandos(GridViewCommandEventArgs e)
        {
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            if (e.CommandName == "imagen")
                RegistrarScript("SubirImagenKey", string.Format("openfileDialog('{0}');", e.CommandArgument));

        }


        protected override void AsignarDatosAControles()
        {
            RegistrarScript("LimpiarModalKey", "ActivarModal(1);");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            txt_usuarioModal.Text = string.Empty;
            txt_nombreCortoModal.Text = string.Empty;
            txt_descripcionModal.Text = string.Empty;
            txt_claveModal.Text = string.Empty;
            txt_repetirclaveModal.Text = string.Empty;

            ddl_Estado.SelectedValue = clsParametos.EstadoActivo;
            ddl_persona.SelectedValue = "2"; //Persona Proveedor
            if (bdAdmin || bdAdminPerfil)
            {
                lblMaster.Visible = true;
                chk_obligado.Visible = true;
                chk_obligado.Checked = false;
                ddl_persona.Enabled = true;
                CargarPerfiles();
                //CargaProveedorAdmin();
            }
            else
            {
                lblMaster.Visible = false;
                chk_obligado.Checked = false;
                chk_obligado.Visible = false;
                ddl_persona.Enabled = false;
            }

        }
        protected override void AsignarDatosAControles(TipoEdicion toTipoEdicion, int valor)
        {
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            if (toTipoEdicion == TipoEdicion.index)
            {
                var Master = HttpUtility.HtmlDecode(grvConsulta.DataKeys[valor]["bdMaster"].ToString());

                clsNSeguridad seguridadBL = new clsNSeguridad();
                RegistrarScript("LimpiarModalKey", "ActivarModal(0);");


                txt_usuarioModal.Text = HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[0].Text);
                txt_nombreCortoModal.Text = HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[1].Text);
                txt_descripcionModal.Text = HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[2].Text);
                txt_claveModal.Text = seguridadBL.Desencriptar(HttpUtility.HtmlDecode(grvConsulta.DataKeys[valor]["txClave"].ToString()));
                txt_repetirclaveModal.Text = txt_claveModal.Text;

                ddl_Estado.SelectedValue = HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[4].Text) != null ? HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[4].Text).ToString().Trim() : "A";


                //List<ModeloDatos.Entidades.clsProveedor> unidades = new List<ModeloDatos.Entidades.clsProveedor>();
                //unidades = clsProveedoresBL.ConsultarProveedor(txt_usuarioModal.Text);

                //if (unidades.Count > 0)
                //{
                //    ddlProveedor.DataSource = unidades;
                //    ddlProveedor.DataTextField = "Proveedor";
                //    ddlProveedor.DataValueField = "IdProveedor";
                //    ddlProveedor.DataBind();

                //}
                //else
                //{

                //    unidades = clsProveedoresBL.ConsultarProveedorAdmin();

                //    ddlProveedor.DataSource = unidades;
                //    ddlProveedor.DataTextField = "Proveedor";
                //    ddlProveedor.DataValueField = "IdProveedor";
                //    ddlProveedor.DataBind();
                //}



                if (bdAdmin || bdAdminPerfil)
                {
                    CargarPerfiles();//Cargo todos los perfiles creados
                    lblMaster.Visible = true;
                    chk_obligado.Visible = true;
                    ddl_persona.Enabled = true;
                    ddlProveedor.Enabled = true;
                    chk_obligado.Checked = Convert.ToBoolean(grvConsulta.DataKeys[valor]["bdMaster"]);
                    CargarPerfilesUsuario(HttpUtility.HtmlDecode(grvConsulta.Rows[valor].Cells[0].Text));///Este metodo consulta los perfiles que se asignaron al usuario
                }
                else
                {
                    lblMaster.Visible = false;
                    chk_obligado.Checked = false;
                    chk_obligado.Visible = false;
                    ddl_persona.Enabled = false;
                    ddlProveedor.Enabled = false;
                }


                try
                {
                    ddl_persona.SelectedValue = grvConsulta.DataKeys[valor]["idPersona"] != null ? grvConsulta.DataKeys[valor]["idPersona"].ToString() : "0";
                    //Cargo proveedor
                    ddlProveedor.SelectedValue = grvConsulta.DataKeys[valor]["IdProveedor"] != null ? grvConsulta.DataKeys[valor]["IdProveedor"].ToString() : "0";
                }
                catch (ArgumentOutOfRangeException)
                {
                    //MostrarMensaje("Advertencia", "La persona que estaba asignado a este usuario ya no se encuentra disponible", clsParametos.TipoMensaje.Warning);
                }

            }

        }

        protected override void ActualizarDatos()
        {
            int grabado = 0;
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            clsNSeguridad clsSeguridadBL = new clsNSeguridad();
            adusuarios nuevousuario = new adusuarios
            {
                ciUsuario = txt_usuarioModal.Text.Trim(),
                txNombreCorto = txt_nombreCortoModal.Text.Trim(),
                idPersona = int.Parse(ddl_persona.SelectedValue),
                txDescripcion = txt_descripcionModal.Text.Trim(),
                txClave = clsSeguridadBL.Encriptar(txt_claveModal.Text.Trim()),
                ciEstado = ddl_Estado.SelectedValue,
                txDirectorioImagen = ImgDefault,
                fcIngreso = DateTime.Now,
                ciUsuarioIngreso = ciUsuario
            };
            if (bdAdmin)
                nuevousuario.bdMaster = chk_obligado.Checked;
            else
                nuevousuario.bdMaster = false;


            try
            {
                //Creo el usuario
                grabado = clsUsuarioBL.ActualizarUsuario(nuevousuario, ciCompania);
                if (bdAdmin || bdAdminPerfil)
                {
                    //Asigno sus perfiles
                    if (grabado == 1)
                    {
                        if (grvAsignaPerfiles.Rows.Count > 0)
                        {
                            for (int J = 0; J < grvAsignaPerfiles.Rows.Count; J++)
                            {
                                CheckBox _ChkPerfil = (CheckBox)grvAsignaPerfiles.Rows[J].FindControl("chkPerfilAsignado");
                                Label _PerfilId = (Label)grvAsignaPerfiles.Rows[J].FindControl("lblPerfilId");
                                Int32 PerfilIdSelected = Convert.ToInt32(_PerfilId.Text);
                                adusuarioperfil pUsuario = new adusuarioperfil();
                                pUsuario.ciPerfil = PerfilIdSelected;
                                pUsuario.ciUsuario = nuevousuario.ciUsuario;
                                pUsuario.ciCompania = ciCompania;
                                if (_ChkPerfil.Checked)
                                {
                                    pUsuario.ciEstado = "A";
                                    pUsuario.fcIngreso = DateTime.Now;
                                    pUsuario.ciUsuarioIngreso = ciUsuario;
                                }
                                else
                                {
                                    pUsuario.ciEstado = "I";
                                    pUsuario.fcModificacion = DateTime.Now;
                                    pUsuario.ciUsuarioModificacion = ciUsuario;
                                }
                                //Grabo todos los perfiles asignados al usuario
                                clsUsuarioBL.ActualizarPerfilUsuario(pUsuario);
                            }
                        }

                        //adusuarioproveedor nuevousuarioprov = new adusuarioproveedor
                        //{
                        //    ciUsuario = txt_usuarioModal.Text.Trim(),
                        //    IdProveedor = int.Parse(ddlProveedor.SelectedValue),
                        //    FechaIngreso = DateTime.Now,
                        //    UsuarioIngreso = ciUsuario
                        //};
                        //clsUsuarioBL.ActualizarUsuarioProveedor(nuevousuarioprov);
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MostrarMensaje("Error", "Problema en la creacion de usuarios, revise los datos ingresados y la asignacion de perfiles que desea realizar.", clsParametos.TipoMensaje.Error);
            }

        }




        protected override bool Validar()
        {
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            txt_usuarioModal.Text = validaIdUsuario(txt_usuarioModal.Text);

            if (string.IsNullOrEmpty(txt_usuarioModal.Text))
            {
                MostrarMensaje("ERROR", "Debe Ingresar el usuario", clsParametos.TipoMensaje.Warning);
                return false;
            }



            if (string.IsNullOrEmpty(txt_nombreCortoModal.Text))
            {
                MostrarMensaje("ERROR", "Debe el nombre corto", clsParametos.TipoMensaje.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txt_claveModal.Text))
            {
                MostrarMensaje("ERROR", "Debe Ingresar la Clave", clsParametos.TipoMensaje.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txt_repetirclaveModal.Text))
            {
                MostrarMensaje("ERROR", "Debe Confirmar la Clave", clsParametos.TipoMensaje.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(txt_repetirclaveModal.Text) && !string.IsNullOrEmpty(txt_claveModal.Text))
                if (txt_claveModal.Text != txt_repetirclaveModal.Text)
                {
                    MostrarMensaje("ERROR", "Las contraseñas no coinciden", clsParametos.TipoMensaje.Warning);
                    return false;
                }


            if (ddl_persona.SelectedValue == "0")

            {
                MostrarMensaje("ERROR", "Debe seleccionar una parsona asociada al usuario", clsParametos.TipoMensaje.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txt_descripcionModal.Text))
            {
                MostrarMensaje("ERROR", "Debe Ingresar una descripción", clsParametos.TipoMensaje.Warning);
                return false;
            }

            //if (clsUsuarioBL.validarUsuario(txt_usuarioModal.Text.Trim(), ciCompania, int.Parse(ddl_persona.SelectedValue)))
            //{
            //    MostrarMensaje("ERROR", "La persona seleccionada ya se encuenta asignada a otro usuario", clsParametos.TipoMensaje.Warning);
            //    return false;
            //}
            return true;
        }


        private string validaIdUsuario(string id)
        {
            return id.Trim().ToLower().Replace(" ", "").Replace("\n", "").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
        }

        protected void btn_subirImagen_Click(object sender, EventArgs e)
        {
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            try
            {
                if (fup_imagen.HasFile)
                {
                    if (Path.GetExtension(fup_imagen.FileName) == ".jpeg" || Path.GetExtension(fup_imagen.FileName) == ".png" || Path.GetExtension(fup_imagen.FileName) == ".jpg")
                    {
                        String fileName = string.Format("{0}{1}", hdf_idUsuarioSelect.Value, Path.GetExtension(fup_imagen.FileName));
                        fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                        MostrarMensaje("Exito", "Imagen Actualizada", clsParametos.TipoMensaje.Success);
                        clsUsuarioBL.ActualizarImagen(hdf_idUsuarioSelect.Value, string.Format("~/Imagenes/Usuarios/{0}", fileName), ciUsuario);
                    }
                    else
                        MostrarMensaje("Advertencia", "Tipo de archivo no admitido", clsParametos.TipoMensaje.Warning);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }


        }

        public void CargarPerfiles()
        {
            List<adperfil> res = clsPerfilesBL.ConsultarPerfiles(ciCompania);
            grvAsignaPerfiles.DataSource = res.Count != 0 || res == null ? res : null;
            grvAsignaPerfiles.DataBind();
            grvAsignaPerfiles.UseAccessibleHeader = true;
            if (res.Count != 0)
                grvAsignaPerfiles.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void CargarPerfilesUsuario(string ciUsuario)
        {
            List<adusuarioperfil> res = clsPerfilesBL.ConsultarPerfilesUsuarios(ciCompania, ciUsuario);

            if (res.Count > 0)
            {
                foreach (adusuarioperfil per in res)
                {
                    for (int J = 0; J < grvAsignaPerfiles.Rows.Count; J++)
                    {
                        Label _PerfilId = (Label)grvAsignaPerfiles.Rows[J].FindControl("lblPerfilId");
                        CheckBox _ChkPerfil = (CheckBox)grvAsignaPerfiles.Rows[J].FindControl("chkPerfilAsignado");
                        if (_PerfilId.Text == Convert.ToString(per.ciPerfil))
                        {
                            _ChkPerfil.Checked = true;
                        }
                    }
                }
            }
        }

        //private void CargaProveedorAdmin()
        //{
        //    List<ModeloDatos.Entidades.clsProveedor> unidades = new List<ModeloDatos.Entidades.clsProveedor>();
        //    unidades = clsProveedoresBL.ConsultarProveedorAdmin();
        //    unidades.Insert(0, new ModeloDatos.Entidades.clsProveedor()
        //    {
        //        IdProveedor = 0,
        //        Proveedor = "{ESCOJA PROVEEDOR...}"
        //    });


        //    ddlProveedor.DataSource = unidades;
        //    ddlProveedor.DataTextField = "Proveedor";
        //    ddlProveedor.DataValueField = "IdProveedor";
        //    ddlProveedor.DataBind();
        //}

        //private void CargaProveedor()
        //{
        //    List<ModeloDatos.Entidades.clsProveedor> unidades = new List<ModeloDatos.Entidades.clsProveedor>();
        //    unidades = clsProveedoresBL.ConsultarProveedor(ciUsuario);


        //    ddlProveedor.DataSource = unidades;
        //    ddlProveedor.DataTextField = "Proveedor";
        //    ddlProveedor.DataValueField = "IdProveedor";
        //    ddlProveedor.DataBind();
        //}

    }
}