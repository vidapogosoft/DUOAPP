using ModeloDatos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

namespace Cn_Seguridad.Mantenimientos
{
    public partial class MAfiliados : clsBase
    {

        clsNAfiliados clsAfiliadosBL = new clsNAfiliados();
        String fileName = string.Empty;

        protected override void Page_Load(object sender, EventArgs e)
        {

            base.Page_Load(sender, e);

            fup_imagen_registrada.Attributes["onchange"] = "UploadFileExistente(this)";

            if (!IsPostBack)
            {
                SetStyle();
                RegistrarScript("initKey", "init();");
                RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");

                var scriptManager = ScriptManager.GetCurrent(Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CssKey", "init_page();", true);
                img_foto_reg.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
                img_foto_reg2.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
                hdfIdProveedor.Value = "0";
                hdfControlAfiliado.Value = "0";
                try
                {
                    if (bdAdmin)
                    {
                        CargaAfiliadoAdmin();
                    }
                    else
                    {
                        CargaAfiliado();
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex);
                }

            }
        }


        private void SetStyle()
        {
            RegistrarScript("initPageKey", "init_page();");
        }

        private void CargaAfiliadoAdmin()
        {
            List<ModeloDatos.Entidades.clsAfiliado> res = new List<ModeloDatos.Entidades.clsAfiliado>();
            //res = clsAfiliadosBL.ConsultarAfiliadoAdmin();

            if (res.Count > 0)
                grvConsultaPromos.DataSource = res;
            grvConsultaPromos.DataBind();

            if (grvConsultaPromos != null && grvConsultaPromos.HeaderRow != null)
                grvConsultaPromos.HeaderRow.TableSection = TableRowSection.TableHeader;

            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            SetStyle();
        }

        private void CargaAfiliado()
        {
            List<ModeloDatos.Entidades.clsAfiliado> res = new List<ModeloDatos.Entidades.clsAfiliado>();
            //res = clsAfiliadosBL.ConsultarAfiliado(ciUsuario);

            if (res.Count > 0)
                grvConsultaPromos.DataSource = res;
            grvConsultaPromos.DataBind();

            if (grvConsultaPromos != null && grvConsultaPromos.HeaderRow != null)
                grvConsultaPromos.HeaderRow.TableSection = TableRowSection.TableHeader;

            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            SetStyle();

        }

        protected void grvConsultaPromos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvConsultaPromos.PageIndex = e.NewPageIndex;
                if (bdAdmin)
                {
                    CargaAfiliadoAdmin();
                }
                else
                {
                    CargaAfiliado();
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        protected void btn_subirImagen_registrada_Click(object sender, EventArgs e)
        {
            SetStyle();
            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");

            try
            {
                string rutaServer = ConfigurationManager.AppSettings["WebServer"].ToString();
                if (fup_imagen_registrada.HasFile)
                {

                    string ruta = ConfigurationManager.AppSettings["Directorio"].ToString();
                    string path = ruta + ciUsuario + "\\";

                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }


                    if (Path.GetExtension(fup_imagen_registrada.FileName) == ".jpeg" || Path.GetExtension(fup_imagen_registrada.FileName) == ".png" || Path.GetExtension(fup_imagen_registrada.FileName) == ".jpg"
                        || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPEG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".PNG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPG"
                        )
                    {

                        if (hdf_tipoImagen.Value == "2")
                        {
                            fileName = string.Format("{0}{1}", "FotoPrincipal" + DateTime.Now.Ticks.ToString() + ciUsuario, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCarnet.Value = fileName.ToString();
                            hdnNombreFotoCarnet.Value = rutaServer + "/Imagenes/Fotos/" + ciUsuario + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + ciUsuario + "/"), fileName));
                            img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/" + ciUsuario + "/" + "{0}", Path.GetFileName(fileName));
                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            hdf_tipoImagen.Value = "1";
                        }

                        if (hdf_tipoImagen.Value == "3")
                        {
                            fileName = string.Format("{0}{1}", "FotoSecundaria" + DateTime.Now.Ticks.ToString() + ciUsuario, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCedula.Value = fileName.ToString();
                            hdnNombreFotoCedula.Value = rutaServer + "/Imagenes/Fotos/" + ciUsuario + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + ciUsuario + "/"), fileName));
                            img_foto_reg2.ImageUrl = string.Format("../Imagenes/Fotos/" + ciUsuario + "/" + "{0}", Path.GetFileName(fileName));
                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            hdf_tipoImagen.Value = "1";
                        }


                        if (hdf_tipoImagen.Value == "1")
                        {
                            MostrarMensaje("Exito", "Imagen Actualizada", clsParametos.TipoMensaje.Success);
                            hdf_tipoImagen.Value = "0";
                        }

                    }
                    else
                    {
                        MostrarMensaje("Advertencia", "Tipo de archivo no admitido", clsParametos.TipoMensaje.Warning);
                        hdf_tipoImagen.Value = "0";
                    }

                }

            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }

        }

        protected void grvConsultaPromos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {

                try
                {
                    Label _IdPromoControl = (Label)grvConsultaPromos.Rows[indice].FindControl("IdAfiliado");
                    Label _ControlAfiliado = (Label)grvConsultaPromos.Rows[indice].FindControl("ControlAfiliado");
                    hdfIdProveedor.Value = _IdPromoControl.Text;
                    hdfControlAfiliado.Value = _ControlAfiliado.Text;
                    Label _Foto1 = (Label)grvConsultaPromos.Rows[indice].FindControl("Foto1");
                    Label _Foto2 = (Label)grvConsultaPromos.Rows[indice].FindControl("Foto2");

                    Label _NombreProveedor = (Label)grvConsultaPromos.Rows[indice].FindControl("Afiliado");
                    Label _AcercaProveedor = (Label)grvConsultaPromos.Rows[indice].FindControl("AcercaDe");
                    Label _IdentAfiliado = (Label)grvConsultaPromos.Rows[indice].FindControl("IdentAfiliado");
                    Label _Contacto1 = (Label)grvConsultaPromos.Rows[indice].FindControl("Contacto1");
                    Label _Fono1 = (Label)grvConsultaPromos.Rows[indice].FindControl("Telefono1");
                    Label _Email1 = (Label)grvConsultaPromos.Rows[indice].FindControl("Email1");

                    Label _Contacto2 = (Label)grvConsultaPromos.Rows[indice].FindControl("Contacto2");
                    Label _Fono2 = (Label)grvConsultaPromos.Rows[indice].FindControl("Telefono2");
                    Label _Email2 = (Label)grvConsultaPromos.Rows[indice].FindControl("Email2");


                    this.TxtNombre.Text = _NombreProveedor.Text.ToString();
                    this.TxtAcerca.Text = _AcercaProveedor.Text.ToString();
                    this.TxtIdentificacionAfiliado.Text = _IdentAfiliado.Text.ToString();

                    this.TxtContacto1.Text = _Contacto1.Text.ToString();
                    this.TxtFono1.Text = _Fono1.Text.ToString();
                    this.TtxtCorreo1.Text = _Email1.Text.ToString();

                    this.TxtContacto2.Text = _Contacto2.Text.ToString();
                    this.TxtFono2.Text = _Fono2.Text.ToString();
                    this.TtxtCorreo2.Text = _Email2.Text.ToString();

                    this.img_foto_reg.ImageUrl = _Foto1.Text.ToString();
                    hdnNombreFotoCarnet.Value = _Foto1.Text.ToString();
                    this.img_foto_reg2.ImageUrl = _Foto2.Text.ToString();
                    hdnNombreFotoCedula.Value = _Foto2.Text.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MostrarMensaje("Error", "Problema en la edicion de datos, revise los datos seleccionados.", clsParametos.TipoMensaje.Error);
                }
                finally
                {
                    //Refresco las consultas
                    if (bdAdmin)
                    {
                        CargaAfiliadoAdmin();

                    }
                    else
                    {
                        CargaAfiliado();
                    }
                    RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
                }
            }

            if (e.CommandName == "Eliminar")
            {

                try
                {
                    Label _IdPromoControl = (Label)grvConsultaPromos.Rows[indice].FindControl("IdAfiliado");

                    if (Convert.ToInt32(_IdPromoControl.Text) == 34)
                    {
                        MostrarMensaje("Denegado!", "No puede eliminar los datos de este Afiliado. CHOPIN APP.", clsParametos.TipoMensaje.Warning);
                    }
                    else
                    {
                        //clsAfiliadosBL.DelAfiliado(Convert.ToInt32(_IdPromoControl.Text), ciUsuario);
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    MostrarMensaje("Error", "Problema en la eliminacion de datos, revise los datos seleccionados.", clsParametos.TipoMensaje.Error);
                }
                finally
                {
                    LimpiarControles();
                    //Refresco las consultas
                    if (bdAdmin)
                    {
                        CargaAfiliadoAdmin();

                    }
                    else
                    {
                        CargaAfiliado();
                    }
                    RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
                }
            }
        }

        protected void btnGrabarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                int Grabado = 0;
                //afiliados Prove = new afiliados();

                if (string.IsNullOrEmpty(TxtNombre.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un nombre de afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TxtIdentificacionAfiliado.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar una identificacion valida del afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TxtAcerca.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un breve descripcion del afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TxtContacto1.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un dato de contacto del afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TxtFono1.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un dato de telefono de contacto del afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TtxtCorreo1.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un dato de correo de contacto del afiliado.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                //Prove.IdAfiliado = Convert.ToInt32(hdfIdProveedor.Value);
                //Prove.Nombre = TxtNombre.Text;
                //Prove.AcercaDe = TxtAcerca.Text;

                //Prove.IdentificacionAfiliado = TxtIdentificacionAfiliado.Text;

                //if (hdfControlAfiliado.Value == "0")
                //{
                //    Prove.ControlAfiliado = "A" + TxtIdentificacionAfiliado.Text + "-" + Guid.NewGuid().ToString();
                //}
                //else
                //{
                //    Prove.ControlAfiliado = hdfControlAfiliado.Value.ToString();
                //}
                

                //Prove.Contacto1 = TxtContacto1.Text;
                //Prove.Tlf1 = TxtFono1.Text;
                //Prove.Correo1 = TtxtCorreo1.Text;

                //Prove.Contacto2 = TxtContacto2.Text;
                //Prove.Tlf2 = TxtFono2.Text;
                //Prove.Correo2 = TtxtCorreo2.Text;

                //Prove.FechaCreacion = DateTime.Now;
                //Prove.FechaCreacionConsulta = DateTime.Now.ToShortDateString();
                //Prove.UsuarioCreacion = ciUsuario;

                //Prove.RutaBanner = hdnNombreFotoCarnet.Value;
                //Prove.RutaFoto = hdnNombreFotoCedula.Value;
                //Prove.Estado = "ACTIVO";

                //Grabado = clsAfiliadosBL.SaveAfiliado(Prove);

                if (Grabado == 1)
                {
                    MostrarMensaje("Exito", "Afiliado Registrado", clsParametos.TipoMensaje.Success);

                    LimpiarControles();
                    if (bdAdmin)
                    {
                        CargaAfiliadoAdmin();

                    }
                    else
                    {
                        CargaAfiliado();
                    }
                }

                SetStyle();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }


        }

        public void LimpiarControles()
        {
            hdfIdProveedor.Value = "0";
            hdfControlAfiliado.Value = "0";
            this.TxtNombre.Text = string.Empty;
            this.TxtAcerca.Text = string.Empty;
            this.TxtIdentificacionAfiliado.Text = string.Empty;

            this.TxtContacto1.Text = string.Empty;
            this.TxtFono1.Text = string.Empty;
            this.TtxtCorreo1.Text = string.Empty;

            this.TxtContacto2.Text = string.Empty;
            this.TxtFono2.Text = string.Empty;
            this.TtxtCorreo2.Text = string.Empty;

            hdnNombreFotoCarnet.Value = string.Empty;
            hdnNombreFotoCedula.Value = string.Empty;

            this.img_foto_reg.ImageUrl = string.Empty;
            this.img_foto_reg2.ImageUrl = string.Empty;

            fup_imagen_registrada.Attributes["onchange"] = "UploadFileExistente(this)";
            var scriptManager = ScriptManager.GetCurrent(Page);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CssKey", "init_page();", true);
            img_foto_reg.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
            img_foto_reg2.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
        }

    }
}