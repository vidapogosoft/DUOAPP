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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cn_Seguridad.WebView
{
    public partial class ProductsDuo2 : System.Web.UI.Page
    {
        clsNRegistrados clsRegistradosBL = new clsNRegistrados();
        String fileName = string.Empty;
        public string RegId;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegId = Request.QueryString["RegId"];
            fup_imagen_registrada.Attributes["onchange"] = "UploadFileExistente(this)";

            if (!IsPostBack)
            {
                var scriptManager = ScriptManager.GetCurrent(Page);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CssKey", "init_page();", true);
                img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("Products.png"));
                hdfIdProducto.Value = "0";
                hdfIdRegistrado.Value = "0";
                hdfIdPerfil.Value = "0";
                hdfRegCodigoUnico.Value = "0";
                hdfFotoRegistrado.Value = "http://18.218.178.167/imagesemail/Products.png";

                CargaRegistradoById(int.Parse(RegId));
                CargaPerfilById(int.Parse(RegId));

            }
        }

        private void CargaRegistradoById(int IdRegistrado)
        {
            List<ModeloDatos.Entidades.clsRegistrado> res = new List<ModeloDatos.Entidades.clsRegistrado>();
            res = clsRegistradosBL.ConsultarRegistradoById(IdRegistrado);

            if (res.Count > 0)
            {
                int i;

                for (i = 0; i < res.Count; i++)
                {
                    hdfIdRegistrado.Value = res[i].RegId.ToString();
                    hdfRegCodigoUnico.Value = res[i].RegCodigoUnico;

                }
            }
        }

        private void CargaPerfilById(int IdRegistrado)
        {
            List<ModeloDatos.Entidades.clsPerfilDUO> res = new List<ModeloDatos.Entidades.clsPerfilDUO>();
            res = clsRegistradosBL.ConsultarPerfilById(IdRegistrado);

            if (res.Count > 0)
            {
                int i;

                for (i = 0; i < res.Count; i++)
                {
                    hdfIdPerfil.Value = res[i].RegPerfilId.ToString();

                }
            }
        }

        protected void BtnRegistroProducto_Click(object sender, EventArgs e)
        {
            int Grabado = 0;

            ModeloDatos.Products Perfil = new ModeloDatos.Products();

            Perfil.RegProductId = Convert.ToInt32(hdfIdProducto.Value);
            Perfil.RegPerfilId = Convert.ToInt32(hdfIdPerfil.Value);
            Perfil.RegId = Convert.ToInt32(hdfIdRegistrado.Value);
            Perfil.RegCodigoUnico = hdfRegCodigoUnico.Value;
            
            Perfil.RegFecha = DateTime.Now;
            Perfil.AnioReg = DateTime.Now.Year;
            Perfil.MesReg = DateTime.Now.Month;
            Perfil.DiaReg = DateTime.Now.Day;
            Perfil.IsNew = 1;
            Perfil.RegRutaImagen = hdfFotoRegistrado.Value;

            DisplayModal95();
            Grabado = clsRegistradosBL.SaveProductDuo(Perfil);

            if (Grabado > 0)
            {
                hdfIdProducto.Value = "0";
               
                img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("Products.png"));
                hdfFotoRegistrado.Value = "http://18.218.178.167/imagesemail/Products.png";

                LblRegistro.Visible = true;
                CloseModal95();
                //CargaWorksById(int.Parse(hdfIdRegistrado.Value));

                
            }
        }

        protected void btn_subirImagen_registrada_Click(object sender, EventArgs e)
        {
            try
            {
                string rutaServer = ConfigurationManager.AppSettings["WebServer"].ToString();
                if (fup_imagen_registrada.HasFile)
                {

                    //var tamanio = fup_imagen_registrada.FileContent.Length;

                    string ruta = ConfigurationManager.AppSettings["Directorio"].ToString();
                    string path = ruta + "duo" + "\\" + RegId + "\\";

                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }


                    if (Path.GetExtension(fup_imagen_registrada.FileName) == ".jpeg" || Path.GetExtension(fup_imagen_registrada.FileName) == ".png" || Path.GetExtension(fup_imagen_registrada.FileName) == ".jpg"
                        || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPEG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".PNG" || Path.GetExtension(fup_imagen_registrada.FileName) == ".JPG"
                        )
                    {
                        DisplayModal40();
                        if (hdf_tipoImagen.Value == "2")
                        {
                            fileName = string.Format("{0}{1}", "FotoProducts" + DateTime.Now.Ticks.ToString() + "duo" + RegId, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCarnet.Value = fileName.ToString();
                            hdfFotoRegistrado.Value = rutaServer + "/Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            CloseModal40();
                            DisplayModal95();

                            //fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName));

                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            int newWidth = 550; // New Width of Image in Pixel  
                            int newHeight = 700; // New Height of Image in Pixel  
                            var thumbImg = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            var image = System.Drawing.Image.FromStream(fs);
                            thumbGraph.DrawImage(image, imgRectangle);
                            thumbImg.Save(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName), image.RawFormat);

                            img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + "{0}", Path.GetFileName(fileName));

                            hdf_tipoImagen.Value = "1";
                            CloseModal95();
                        }

                    }
                    else
                    {
                        //MostrarMensaje("Advertencia", "Tipo de archivo no admitido", clsParametos.TipoMensaje.Warning);
                        LblRegistro.Visible = true;
                        LblRegistro.Text = "Tipo de archivo no admitido";
                        hdf_tipoImagen.Value = "0";
                    }

                }

            }
            catch (Exception ex)
            {
                //throw;
                //MostrarMensaje("Error", ex.Message, clsParametos.TipoMensaje.Error);
                LblRegistro.Visible = true;
                LblRegistro.Text = ex.Message;
            }
        }

        private void DisplayModal40()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Modal40').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        private void CloseModal40()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Modal40').modal('hide');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

        }

        private void DisplayModal95()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Modal95').modal('show');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        private void CloseModal95()
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("$('#Modal95').modal('hide');");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

        }

        protected void Btncancelar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.close();</script>");

            //string script = "window.close();";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", script, true);

        }
    }
}