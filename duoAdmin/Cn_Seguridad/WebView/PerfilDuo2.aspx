<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilDuo2.aspx.cs" Inherits="Cn_Seguridad.WebView.PerfilDuo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Portal Duo: Registro de Perfil</title>


         <!-- start: MAIN CSS -->
    <link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../assets/plugins/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../assets/fonts/style.css"/>
    <link rel="stylesheet" href="../assets/css/main.css"/>
    <link rel="stylesheet" href="../assets/css/main-responsive.css"/>
    <link rel="stylesheet" href="../assets/plugins/iCheck/skins/all.css"/>
    <link rel="stylesheet" href="../assets/plugins/bootstrap-colorpalette/css/bootstrap-colorpalette.css"/>
    <link rel="stylesheet" href="../assets/plugins/perfect-scrollbar/src/perfect-scrollbar.css"/>
    <link rel="stylesheet" href="../assets/css/theme_light.css" type="text/css" id="skin_color"/>
    <link rel="stylesheet" href="../assets/css/print.css" type="text/css" media="print" />

</head>
<body>
    <form id="formPedidosregular" runat="server">
   
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>

    
             <asp:UpdatePanel runat="server" ID="upd_maint" UpdateMode="Conditional">
            <ContentTemplate>
                
                <div class="container-fluid">
                 
                    <div class="row">
                        <div class="col-md-12">

                            <div class="page-header row">
                                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfRegCodigoUnico" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdPerfil" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfFotoRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdf_tipoImagen" />
                  <div class="col-md-12">
                      
                  <div class="row">
                           <div class="col-sm-12 text-center">
                          <asp:Image runat="server" Width="550px" Hight ="700px" ID="img_foto_reg"/>
                                            <a data-toggle='tooltip' id="lkb_subirImagenReg" href="javascript:openfileDialogExistente('2');"
                                                class="fa fa-camera fa-2x col-md-offset-1" title="Cambiar la Imagen"></a>
                      </div>
                  </div>
                  </div>
               
                      
                 
                </div>
                
                    <div class="page-header row">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label runat="server" visible="false" ID="LblRegistro" style="color:red; font-size:20px; font-style:italic;">Tus foto de perfil ha sido registrado.</asp:Label>
                        </div>
                    </div>
                     </div>
                       
                    <div class="page-header row">
                           <div class="row">
                               <div class="col-md-12 text-center">
                                   <asp:Button runat="server" class="btn-lg btn-primary" Text="&nbsp;&nbsp;SUBIR FOTO&nbsp;&nbsp;"  ID="BtnRegistrarPerfil" OnClick="BtnRegistrarPerfil_Click"/>
                               </div>
                           </div>
                    </div>
                            <div class="page-header row">
                           <div class="row">
                               <div class="col-md-12 text-center">
                                   <asp:Button runat="server" class="btn-lg btn-warning" Text="&nbsp;&nbsp;&nbsp;CANCELAR&nbsp;&nbsp;&nbsp;"  ID="BtnCancelar" OnClick="BtnCancelar_Click"/>
                               </div>
                           </div>
                    </div>

                        </div>
                    </div>

                </div>
                
            </ContentTemplate>

         </asp:UpdatePanel>
         <asp:Button runat="server" Style="display: none" ID="btn_subirImagen_registrada"  ClientIDMode="Static" OnClick="btn_subirImagen_registrada_Click" />
        <asp:FileUpload ID="fup_imagen_registrada" Style="display: none" AllowMultiple="false" accept="image/png,image/jpeg,image/jpg" ClientIDMode="Static" runat="server" />

    </form>

    
    <script type="text/javascript">

        //window.onload = init();
        function init() {

            $('[data-toggle="tooltip"]').tooltip();

            fire();
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fire);
        function fire() {
            $('input').on('ifClicked', function (ev) { $(ev.target).click() });
        }


        function refrescarToolTip() {
            $('[data-toggle="tooltip"]').tooltip();
            
         
        }

        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                $("#btn_subirImagen").click();
            }
        }

        function openfileDialog(tipo) {

            $("#hdf_tipoImagen").val(tipo);
            $("#fup_imagen").click();
        }

        function openfileDialogExistente(tipo) {

            $("#hdf_tipoImagen").val(tipo);
            $("#fup_imagen_registrada").click();
        }

        function UploadFileExistente(fileUpload) {
            if (fileUpload.value != '') {
                $("#btn_subirImagen_registrada").click();
            }
        }

    </script>

    <script src="../assets/plugins/jQuery-lib/2.0.3/jquery.min.js"></script>
    <!--<![endif]-->
    <script src="../assets/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="../assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js"></script>
    <script src="../assets/plugins/blockUI/jquery.blockUI.js"></script>
    <script src="../assets/plugins/iCheck/jquery.icheck.min.js"></script>
    <script src="../assets/plugins/perfect-scrollbar/src/jquery.mousewheel.js"></script>
    <script src="../assets/plugins/perfect-scrollbar/src/perfect-scrollbar.js"></script>
    <script src="../assets/plugins/less/less-1.5.0.min.js"></script>
    <script src="../assets/plugins/jquery-cookie/jquery.cookie.js"></script>
    <script src="../assets/plugins/bootstrap-colorpalette/js/bootstrap-colorpalette.js"></script>
    <script src="../assets/js/main.js"></script>
    <!-- end: MAIN JAVASCRIPTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="../assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="../assets/js/login.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->


</body>
</html>