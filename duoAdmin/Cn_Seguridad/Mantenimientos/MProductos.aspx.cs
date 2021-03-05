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
    public partial class MProductos : clsBase
    {
        clsNProductos clsProductosBL = new clsNProductos();
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
                
                hdfIdPromocion.Value = "0";
                hdfControlAfiliado.Value = "0";
                hdfIdenAfiliado.Value = "0";
                hdfControlProducto.Value = "0";
                var scriptManager = ScriptManager.GetCurrent(Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CssKey", "init_page();", true);
                img_foto_reg.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
                hdnNombreFotoCarnet.Value = "http://18.218.178.167/Content/images/NosotrosAso.png";
                try
                {
                    if (bdAdmin)
                    {
                        CargaAfiliadosAdmin();
                        ConsultarProductosAdmin();
                    }
                    else
                    {
                        CargaAfiliados();
                        ConsultarProductos(int.Parse(ddlAfiliado.SelectedValue));
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex);
                }

            }
        }

        protected void ConsultarProductosAdmin()
        {


            //var res = clsProductosBL.ConsultarProductosAdmin();
            //if (res.Count > 0)
            //    grvConsultaPromos.DataSource = res;
            //grvConsultaPromos.DataBind();

            if (grvConsultaPromos != null && grvConsultaPromos.HeaderRow != null)
                grvConsultaPromos.HeaderRow.TableSection = TableRowSection.TableHeader;

            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            SetStyle();

        }

        protected void ConsultarProductos(int ciUsuario)
        {


            //var res = clsProductosBL.ConsultarProductos(ciUsuario);
            //if (res.Count > 0)
            //    grvConsultaPromos.DataSource = res;
            //grvConsultaPromos.DataBind();

            if (grvConsultaPromos != null && grvConsultaPromos.HeaderRow != null)
                grvConsultaPromos.HeaderRow.TableSection = TableRowSection.TableHeader;

            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            SetStyle();
        }

        protected void btnGrabarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                int Grabado = 0;
                //productosafiliados PromocionNueva = new productosafiliados();

                if (string.IsNullOrEmpty(TxtTitulo.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar un titulo al producto.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                if (string.IsNullOrEmpty(TxtDescripcion.Text))
                {
                    MostrarMensaje("ERROR", "Debe Ingresar una descripcion al producto.", clsParametos.TipoMensaje.Warning);
                    SetStyle();
                    return;
                }

                CargaAfiliadoById(int.Parse(ddlAfiliado.SelectedValue));


                //PromocionNueva.IdProductoAfiliado = Convert.ToInt32(hdfIdPromocion.Value);
                //PromocionNueva.NombreProducto = TxtTitulo.Text;
                //PromocionNueva.AcercaDe = TxtDescripcion.Text;
                //PromocionNueva.Precio = Convert.ToDecimal(float.Parse(TxtPrecio.Text.Replace(".",",")));
                //PromocionNueva.PrecioConsulta = TxtPrecio.Text.Replace(".", ",");
                //PromocionNueva.FechaCreacion = DateTime.Now;
                //PromocionNueva.UsuarioCreacion = ciUsuario;
                //PromocionNueva.Estado = "ACTIVO";
                //PromocionNueva.FechaCreacionConsulta = DateTime.Now.ToString();
                //PromocionNueva.IdAfiliado = int.Parse(ddlAfiliado.SelectedValue);
                //PromocionNueva.ControlAfiliado = hdfControlAfiliado.Value.ToString();
                //PromocionNueva.IdentificacionAfiliado = hdfIdenAfiliado.Value.ToString();

                if (hdfControlProducto.Value == "0")
                {
                    //PromocionNueva.ControlProducto = "P" + hdfIdenAfiliado.Value.ToString() + "-" + Guid.NewGuid().ToString();
                }
                else
                {
                    //PromocionNueva.ControlProducto = hdfControlProducto.Value.ToString();
                 }
                

                //PromocionNueva.RutaFoto = hdnNombreFotoCarnet.Value;

                //Grabado = clsProductosBL.SaveProductos(PromocionNueva);

                if (Grabado == 1)
                {
                    MostrarMensaje("Exito", "Producto Registrado", clsParametos.TipoMensaje.Success);

                    LimpiarControles();
                    if (bdAdmin)
                    {
                        CargaAfiliadosAdmin();
                        ConsultarProductosAdmin();
                    }
                    else
                    {
                        CargaAfiliados();
                        ConsultarProductos(int.Parse(ddlAfiliado.SelectedValue));
                        
                    }
                }
                SetStyle();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
                SetStyle();
            }

        }

        protected void btn_subirImagen_registrada_Click(object sender, EventArgs e)
        {
            SetStyle();
            RegistrarScript("initKey", "init();");
            RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
            try
            {

                if (fup_imagen_registrada.HasFile)
                {
                    hdf_tipoImagen.Value = "0";
                    string ruta = ConfigurationManager.AppSettings["Directorio"].ToString();
                    string rutaServer = ConfigurationManager.AppSettings["WebServer"].ToString();
                    string path = ruta + ciUsuario + "\\";

                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }


                    if (Path.GetExtension(fup_imagen_registrada.FileName) == ".jpeg" || Path.GetExtension(fup_imagen_registrada.FileName) == ".png" || Path.GetExtension(fup_imagen_registrada.FileName) == ".jpg"
                        || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPEG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".PNG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPG"
                        )
                    {

                        fileName = string.Format("{0}{1}", "Foto" + DateTime.Now.Ticks.ToString() + ciUsuario, Path.GetExtension(fup_imagen_registrada.FileName));
                        hdnNombreFotoCarnet.Value = rutaServer + "/Imagenes/Fotos/" + ciUsuario + "/" + fileName.ToString();
                        //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                        fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + ciUsuario + "/"), fileName));
                        img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/" + ciUsuario + "/" + "{0}", Path.GetFileName(fileName));
                        Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        hdf_tipoImagen.Value = "1";

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
                SetStyle();
            }

        }

        private void SetStyle()
        {
            RegistrarScript("initPageKey", "init_page();");
            
        }

        private void CargaAfiliadosAdmin()
        {
            List<ModeloDatos.Entidades.clsAfiliado> unidades = new List<ModeloDatos.Entidades.clsAfiliado>();
            //unidades = clsAfiliadosBL.ConsultarAfiliadoAdmin();
            unidades.Insert(0, new ModeloDatos.Entidades.clsAfiliado()
            {
                IdAfiliado = 0,
                Afiliado = "{ESCOJA AFILIADO...}"
            });


            ddlAfiliado.DataSource = unidades;
            ddlAfiliado.DataTextField = "Afiliado";
            ddlAfiliado.DataValueField = "IdAfiliado";
            ddlAfiliado.DataBind();
        }

        private void CargaAfiliados()
        {
            List<ModeloDatos.Entidades.clsAfiliado> unidades = new List<ModeloDatos.Entidades.clsAfiliado>();
            //unidades = clsAfiliadosBL.ConsultarAfiliado(ciUsuario);


            ddlAfiliado.DataSource = unidades;
            ddlAfiliado.DataTextField = "Afiliado";
            ddlAfiliado.DataValueField = "IdAfiliado";
            ddlAfiliado.DataBind();
        }

        private void CargaAfiliadoById(int Idproveedor)
        {
            List<ModeloDatos.Entidades.clsAfiliado> unidades = new List<ModeloDatos.Entidades.clsAfiliado>();
            //unidades = clsAfiliadosBL.ConsultarAfiliadoById(Idproveedor);

            int i;

            if (unidades.Count > 0)
            {
                for (i = 0; i < unidades.Count; i++)
                {
                    this.hdfIdenAfiliado.Value = unidades[i].IdentAfiliado;
                    this.hdfControlAfiliado.Value = unidades[i].ControlAfiliado;
                }

            }
            
            ddlAfiliado.DataSource = unidades;
            ddlAfiliado.DataTextField = "Afiliado";
            ddlAfiliado.DataValueField = "IdAfiliado";
            ddlAfiliado.DataBind();
        }

        public void LimpiarControles()
        {
            
            this.TxtTitulo.Text = "";
            this.TxtDescripcion.Text = "";
            this.TxtPrecio.Text = "";
            hdfIdPromocion.Value = "0";
            hdfControlAfiliado.Value = "0";
            hdfIdenAfiliado.Value = "0";
            hdfControlProducto.Value = "0";
            hdnNombreFotoCarnet.Value = "http://18.218.178.167/Content/images/NosotrosAso.png";
            fup_imagen_registrada.Attributes["onchange"] = "UploadFileExistente(this)";
            var scriptManager = ScriptManager.GetCurrent(Page);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CssKey", "init_page();", true);
            img_foto_reg.ImageUrl = string.Format("../Imagenes/Usuarios/{0}", Path.GetFileName("noimage.png"));
        }

        protected void grvConsultaPromos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {

                try
                {
                    Label _IdPromoControl = (Label)grvConsultaPromos.Rows[indice].FindControl("IdProducto");
                    Label _ControlProducto = (Label)grvConsultaPromos.Rows[indice].FindControl("ControlProducto");
                    hdfIdPromocion.Value = _IdPromoControl.Text;
                    hdfControlProducto.Value = _ControlProducto.Text;
                    Label _IdProveedor = (Label)grvConsultaPromos.Rows[indice].FindControl("IdAfiliado");
                    Label _RutaFoto = (Label)grvConsultaPromos.Rows[indice].FindControl("RutaFoto");
                    Label _Titulo = (Label)grvConsultaPromos.Rows[indice].FindControl("Titulo");
                    Label _Descripcion = (Label)grvConsultaPromos.Rows[indice].FindControl("Descripcion");
                    Label _Precio = (Label)grvConsultaPromos.Rows[indice].FindControl("Precio");

                    CargaAfiliadoById(Convert.ToInt32(_IdProveedor.Text));
                    this.TxtTitulo.Text = _Titulo.Text.ToString();
                    this.TxtDescripcion.Text = _Descripcion.Text.ToString();
                    this.TxtPrecio.Text = _Precio.Text.ToString();

                    this.img_foto_reg.ImageUrl = _RutaFoto.Text.ToString();
                    hdnNombreFotoCarnet.Value = _RutaFoto.Text.ToString();

                }
                catch (ArgumentOutOfRangeException)
                {
                    MostrarMensaje("Error", "Problema en la edicion de datos del producto, revise los datos seleccionados.", clsParametos.TipoMensaje.Error);
                }
                finally
                {
                    RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
                }

            }
            

            if (e.CommandName == "Eliminar")
            {

                try
                {
                    Label _IdPromoControl = (Label)grvConsultaPromos.Rows[indice].FindControl("IdProducto");
                    Int32 _IdPromoControlSelected = Convert.ToInt32(_IdPromoControl.Text);
                    //clsProductosBL.DelProductos(_IdPromoControlSelected, ciUsuario);

                }
                catch (ArgumentOutOfRangeException)
                {
                    MostrarMensaje("Error", "Problema en la eliminacion de productos, revise los datos seleccionados.", clsParametos.TipoMensaje.Error);
                }
                finally
                {
                    LimpiarControles();
                    //Refresco las consultas
                    if (bdAdmin)
                    {
                        CargaAfiliadosAdmin();
                        ConsultarProductosAdmin();
                    }
                    else
                    {
                        CargaAfiliados();
                        ConsultarProductos(int.Parse(ddlAfiliado.SelectedValue));
                    }
                    RegistrarScript("refrescarToolTipKey", "refrescarToolTip();");
                }
            }
        }
    }
}