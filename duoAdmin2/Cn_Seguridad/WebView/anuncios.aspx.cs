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
    public partial class anuncios : System.Web.UI.Page
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
                img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                img_foto_reg2.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                img_foto_reg3.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                hdfIdAnuncio.Value = "0";
                hdfIdRegistrado.Value = "0";
                hdfRegCodigoUnico.Value = "0";
                hdfIdPerfil.Value = "0";
                hdfRegCodigoUnico.Value = "0";
                hdfFotoAnuncio1.Value = "http://18.218.178.167/imagesemail/backApp.jpg";
                hdfFotoAnuncio2.Value = "http://18.218.178.167/imagesemail/backApp.jpg";
                hdfFotoAnuncio3.Value = "http://18.218.178.167/imagesemail/backApp.jpg";

                TxtAnioAnuncio.Text = DateTime.Now.Year.ToString();
                TxtMesAnuncio.Text = DateTime.Now.Month.ToString();
                TxtDiaAnuncio.Text = DateTime.Now.Day.ToString();

                CargaRegistradoById(int.Parse(RegId));

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
                            fileName = string.Format("{0}{1}", "FotoAnuncio1" + DateTime.Now.Ticks.ToString() + "duo" + RegId, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCarnet.Value = fileName.ToString();
                            hdfFotoAnuncio1.Value = rutaServer + "/Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            CloseModal40();
                            DisplayModal95();

                            //fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName));

                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            int newWidth = 400; // New Width of Image in Pixel  
                            int newHeight = 400; // New Height of Image in Pixel  
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

                        if (hdf_tipoImagen.Value == "3")
                        {
                            fileName = string.Format("{0}{1}", "FotoAnuncio2" + DateTime.Now.Ticks.ToString() + "duo" + RegId, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCarnet.Value = fileName.ToString();
                            hdfFotoAnuncio2.Value = rutaServer + "/Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            CloseModal40();
                            DisplayModal95();

                            //fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName));

                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            int newWidth = 400; // New Width of Image in Pixel  
                            int newHeight = 400; // New Height of Image in Pixel  
                            var thumbImg = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            var image = System.Drawing.Image.FromStream(fs);
                            thumbGraph.DrawImage(image, imgRectangle);
                            thumbImg.Save(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName), image.RawFormat);
                            
                            img_foto_reg2.ImageUrl = string.Format("../Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + "{0}", Path.GetFileName(fileName));
                            hdf_tipoImagen.Value = "1";
                            CloseModal95();
                        }

                        if (hdf_tipoImagen.Value == "4")
                        {
                            fileName = string.Format("{0}{1}", "FotoAnuncio3" + DateTime.Now.Ticks.ToString() + "duo" + RegId, Path.GetExtension(fup_imagen_registrada.FileName));
                            //hdnNombreFotoCarnet.Value = fileName.ToString();
                            hdfFotoAnuncio3.Value = rutaServer + "/Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + fileName.ToString();
                            //fup_imagen.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Usuarios/"), fileName));
                            CloseModal40();
                            DisplayModal95();

                            //fup_imagen_registrada.SaveAs(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName));

                            Stream fs = fup_imagen_registrada.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            int newWidth = 400; // New Width of Image in Pixel  
                            int newHeight = 400; // New Height of Image in Pixel  
                            var thumbImg = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            var image = System.Drawing.Image.FromStream(fs);
                            thumbGraph.DrawImage(image, imgRectangle);
                            thumbImg.Save(string.Format("{0}{1}", Server.MapPath("~/Imagenes/Fotos/" + "duo" + "/" + RegId + "/"), fileName), image.RawFormat);
                            
                            img_foto_reg3.ImageUrl = string.Format("../Imagenes/Fotos/" + "duo" + "/" + RegId + "/" + "{0}", Path.GetFileName(fileName));
                            
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

        protected void BtnRegistroAnuncio_Click(object sender, EventArgs e)
        {
            try
            {
                int Grabado = 0;

                ModeloDatos.Anuncio Ads = new ModeloDatos.Anuncio();
                ModeloDatos.AnuncioImages AdsIm = new ModeloDatos.AnuncioImages();

                Ads.RegAnuncioId = Convert.ToInt32(hdfIdAnuncio.Value);
                Ads.RegId = Convert.ToInt32(hdfIdRegistrado.Value);
                Ads.RegCodigoUnico = hdfRegCodigoUnico.Value;

                if (int.Parse(ddlPalabraClave.SelectedValue) == 0)
                {
                    Ads.RegAnuncioPalabraClave = "ANUNCIO";
                }

                if (int.Parse(ddlPalabraClave.SelectedValue) == 1)
                {
                    Ads.RegAnuncioPalabraClave = "SOLICITO";
                }

                if (int.Parse(ddlPalabraClave.SelectedValue) == 2)
                {
                    Ads.RegAnuncioPalabraClave = "BUSCO";
                }

                if (int.Parse(ddlPalabraClave.SelectedValue) == 3)
                {
                    Ads.RegAnuncioPalabraClave = "PARA HOY";
                }

                Ads.RegAnuncioEstado = "ACTIVO";
                Ads.RegAnuncioAcercaDe = TxtDetalle.Text;
                Ads.RegAnuncioFecha = DateTime.Now;
                Ads.AnioAnuncioReg = DateTime.Now.Year;
                Ads.MesAnuncioReg = DateTime.Now.Month;
                Ads.DiaAnuncioReg = DateTime.Now.Day;

                Ads.AnioAnuncioHastaId = int.Parse(TxtAnioAnuncio.Text);
                Ads.MesAnuncioHastaId = int.Parse(TxtMesAnuncio.Text);
                Ads.DiaAnuncioHastaId = int.Parse(TxtDiaAnuncio.Text);

                Ads.RegRutaImagen1 = hdfFotoAnuncio1.Value;
                Ads.RegRutaImagen2 = hdfFotoAnuncio2.Value;
                Ads.RegRutaImagen3 = hdfFotoAnuncio3.Value;

                Ads.Titulo = TxtTitulo.Text;

                //SE GRABA EN BASE DE DATOS CENTRAL

                DisplayModal95();
                Grabado = clsRegistradosBL.SaveAnuncioDuo(Ads);

                if (Grabado > 0)
                {
                    int GrabadoIm = 0;
                    
                   
                    if (hdfFotoAnuncio1.Value != "http://18.218.178.167/imagesemail/backApp.jpg")
                    {

                        AdsIm.RegId = Convert.ToInt32(hdfIdRegistrado.Value);
                        AdsIm.RegAnuncioId = Grabado;
                        AdsIm.RegRutaImagen = hdfFotoAnuncio1.Value;
                        AdsIm.RegAnuncioEstado = "ACTIVO";
                        AdsIm.RegAnuncioFecha = DateTime.Now;

                        GrabadoIm = clsRegistradosBL.SaveAnuncioImageDuo(AdsIm);
                    }

                    if (hdfFotoAnuncio2.Value != "http://18.218.178.167/imagesemail/backApp.jpg")
                    {
                        AdsIm.RegId = Convert.ToInt32(hdfIdRegistrado.Value);
                        AdsIm.RegAnuncioId = Grabado;
                        AdsIm.RegRutaImagen = hdfFotoAnuncio2.Value;
                        AdsIm.RegAnuncioEstado = "ACTIVO";
                        AdsIm.RegAnuncioFecha = DateTime.Now;

                        GrabadoIm = clsRegistradosBL.SaveAnuncioImageDuo(AdsIm);
                    }

                    if (hdfFotoAnuncio3.Value != "http://18.218.178.167/imagesemail/backApp.jpg")
                    {
                        AdsIm.RegId = Convert.ToInt32(hdfIdRegistrado.Value);
                        AdsIm.RegAnuncioId = Grabado;
                        AdsIm.RegRutaImagen = hdfFotoAnuncio3.Value;
                        AdsIm.RegAnuncioEstado = "ACTIVO";
                        AdsIm.RegAnuncioFecha = DateTime.Now;

                        GrabadoIm = clsRegistradosBL.SaveAnuncioImageDuo(AdsIm);
                    }

                    LblRegistro.Text = "Tu anuncio en DUO ha sido registrado.";
                    LblRegistro.Visible = true;
                    CloseModal95();
                    //CargaWorksById(int.Parse(hdfIdRegistrado.Value));

                    img_foto_reg.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                    img_foto_reg2.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                    img_foto_reg3.ImageUrl = string.Format("../Imagenes/Fotos/vidapogosoft/{0}", Path.GetFileName("anuncio.png"));
                    hdfIdAnuncio.Value = "0";
                    
                    hdfFotoAnuncio1.Value = "http://18.218.178.167/imagesemail/backApp.jpg";
                    hdfFotoAnuncio2.Value = "http://18.218.178.167/imagesemail/backApp.jpg";
                    hdfFotoAnuncio3.Value = "http://18.218.178.167/imagesemail/backApp.jpg";

                    TxtDetalle.Text = String.Empty;
                    TxtTitulo.Text = String.Empty;
                    TxtAnioAnuncio.Text = DateTime.Now.Year.ToString();
                    TxtMesAnuncio.Text = DateTime.Now.Month.ToString();
                    TxtDiaAnuncio.Text = DateTime.Now.Day.ToString();

                }


            }
            catch (Exception ex)
            {
                LblRegistro.Visible = true;
                LblRegistro.Text = ex.Message;
            }
        }
    }
}