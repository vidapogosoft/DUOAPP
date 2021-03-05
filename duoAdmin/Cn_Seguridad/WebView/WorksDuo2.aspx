<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorksDuo2.aspx.cs" Inherits="Cn_Seguridad.WebView.WorksDuo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Portal Duo: Registro de Trabajos realizados</title>


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
                                
                             <div class="page-header row" id="DivTrabajos">
                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfWorksId" />
                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfRegCodigoUnico" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdPerfil" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfFotoRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdf_tipoImagen" />
       

                 </div>

                                  <div class="page-header row">
                  <div class="col-md-12">
                      <div class="row">
                          <div class="col-sm-12">
                            <label class="control-label">Sube tu foto</label>
                          </div>

                  </div>
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
                            <asp:Label runat="server" visible="false" ID="LblRegistro" style="color:red; font-size:20px; font-style:italic;">Tu trabajo realizado ha sido registrado.</asp:Label>
                        </div>
                    </div>
                     </div>
                    <div class="page-header row">
                           <div class="row">
                               <div class="col-md-12 text-center">
                                   <asp:Button runat="server" class="btn-lg btn-primary" Text="Registrar Trabajo" ID="RegistrarTrabajo" OnClick="RegistrarTrabajo_Click" />
                               </div>
                           </div>
                    </div>

                    <div class="page-header row">
                           <div class="row">
                               <div class="col-md-12 text-center">
                                   <asp:Button runat="server" class="btn-lg btn-warning" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cancelar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" ID="BtnCancelar" OnClick="BtnCancelar_Click"/>
                               </div>
                           </div>
                    </div>

                          <!-- Modal -->
                          <div class="modal fade" id="Modal40" role="dialog">
                            <div class="modal-dialog modal-sm">
                              <div class="modal-content">
                    
                                <div class="modal-body">
                                   <div class="progress">
                                    <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" 			 style="width:40%">
                                      40%
                                    </div>
                                  </div>
              
                                </div>
                    
                              </div>
                            </div>
                          </div>
            
                                <!-- Modal -->
                              <div class="modal fade" id="Modal95" role="dialog">
                                <div class="modal-dialog modal-sm">
                                  <div class="modal-content">
                    
                                    <div class="modal-body">
                                       <div class="progress">
                                        <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="95" aria-valuemin="0" aria-valuemax="100" style="width:95%">
                                            95%
                                        </div>
                                      </div>
              
                                    </div>
                    
                                  </div>
                                </div>
                              </div>


                        </div>
                    </div>
                 
                </div>
              
 
            </ContentTemplate>

         </asp:UpdatePanel>
         <asp:Button runat="server" Style="display: none" ID="btn_subirImagen_registrada"  ClientIDMode="Static" OnClick="btn_subirImagen_registrada_Click"/>
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


