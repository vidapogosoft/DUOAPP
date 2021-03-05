<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilDuo.aspx.cs" Inherits="Cn_Seguridad.WebView.PerfilDuo" %>


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
    <link rel="stylesheet" href="./assets/plugins/perfect-scrollbar/src/perfect-scrollbar.css"/>
    <link rel="stylesheet" href="../assets/css/theme_light.css" type="text/css" id="skin_color"/>
    <link rel="stylesheet" href="../assets/css/print.css" type="text/css" media="print" />
    <!--[if IE 7]>
		<link rel="stylesheet" href="assets/plugins/font-awesome/css/font-awesome-ie7.min.css">
		<![endif]-->
    <!-- end: MAIN CSS -->
    <!-- start: CSS REQUIRED FOR THIS PAGE ONLY -->
  
  <link href="../Styles/ui-lightness/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <script  src="../scripts/jquery-1.10.2.js" type="text/javascript"></script>    
    <script src="../scripts/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>  

    <style>
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input { 
  opacity: 0;
  width: 0;
  height: 0;
}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>

</head>
<body>
    <form id="formPedidosregular" runat="server">
   
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>

    
             <asp:UpdatePanel runat="server" ID="upd_maint" UpdateMode="Conditional">
            <ContentTemplate>
                
                <div class="container-fluid">
                 
                                  <div class="page-header row">
                  <div class="col-md-12">
                      <div class="row">
                          <div class="col-sm-12">
                            <label class="control-label">Sube tu foto</label>
                          </div>

                  </div>
                  <div class="row">
                           <div class="col-sm-12 text-center">
                          <asp:Image runat="server" Width="250px" Hight ="250px" ID="img_foto_reg"/>
                                            <a data-toggle='tooltip' id="lkb_subirImagenReg" href="javascript:openfileDialogExistente('2');"
                                                class="fa fa-camera fa-2x col-md-offset-1" title="Cambiar la Imagen" tooltip="Subir Imagen"></a>
                      </div>
                  </div>
                  </div>
               
                      
                 
                </div>
                <div class="page-header row">
                     <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfRegCodigoUnico" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdPerfil" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfFotoRegistrado" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdf_tipoImagen" />
                    <div class="col-md-12">
                          <div class="row">
                       <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Registra tu profesion" class="form-control" MaxLength="30" ID="TxtProfesion" autocomplete="off" ClientIDMode="Static"/>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Date a conocer, cuentanos sobre ti" class="form-control" MaxLength="100" ID="TxtAcerca" autocomplete="off" ClientIDMode="Static" TextMode="MultiLine" Rows="3"/>
                        </div>
                    </div>
                  
                    
                </div>
                    
                      </div>

                    <div class="page-header row">

                    <div class="col-md-12">
                          <div class="row">
                       <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Tus nombres" class="form-control" MaxLength="30" ID="TxtNombresRegistrado" autocomplete="off" ClientIDMode="Static"/>
                        </div>
                    </div>
     
                    
                </div>
                    
                              <div class="col-md-12">
                          <div class="row">
                       <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Tus apellidos" class="form-control" MaxLength="30" ID="TxtApellidosRegistrado" autocomplete="off" ClientIDMode="Static"/>
                        </div>
                    </div>
     
                    
                </div>

                         
                              <div class="col-md-12">
                          <div class="row">
                       <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Tu email" class="form-control" 
                                MaxLength="30" ID="TxtEmailRegistrado" autocomplete="off" ClientIDMode="Static" ReadOnly="true"/>
                        </div>
                    </div>
     
                    
                </div>

                         
                              <div class="col-md-12">
                          <div class="row">
                       <div class="col-md-12">
                            <asp:TextBox runat="server" placeholder="Tu numero de celular" class="form-control" MaxLength="10" ID="TxtCelularRegistrado" autocomplete="off" ClientIDMode="Static"/>
                        </div>
                    </div>
     
                    
                </div>

                      </div>

              <div class="page-header row">
          
                 <div class="row">
                          <div class="col-sm-12">
                              <label class="control-label">¿Como te gustaria que te busquen en DUO?</label>
                          </div>

                  </div>
                  
                    <br />
                  
                  <div class="row">

                     
                      <div class="col-md-12">

                           <table>
                          <tr>
                              <td>
                                          
                        <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Tecnologia</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Tecnologia"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>
                              </td>
                              <td>
                                       
                           <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Arte y Diseño</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="ArteDiseno"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>

                              </td>
                          </tr>

                                <tr>
                              <td>
                                          
                        <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Legales</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Legales"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>
                              </td>
                              <td>
                                       
                           <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Servicios Tecnicos</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="ServiciosTecnicos"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>

                              </td>
                          </tr>

                                <tr>
                              <td>
                                          
                        <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Comunicacion</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Comunicacion"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>
                              </td>
                              <td>
                                       
                           <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Urbanismo</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Urbanismo"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>

                              </td>
                          </tr>


                                 <tr>
                              <td>
                                          
                        <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Comercio</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Comercio"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>
                              </td>
                              <td>
                                       
                           <div class="row">
                            <div class="col-md-6">
                                   <div class="col-md-2">
                                 <label class="control-label">Emprendimientos</label>
                            </div>

                    <div class="col-md-6">
                        <label class="switch">
                            <asp:CheckBox  runat="server" ID="Emprendimientos"/>
                            <span class="slider round"></span>
                        </label>
                    </div>
                            </div>
                            
                    </div>

                              </td>
                          </tr>
                      </table>

                 
                      </div>
                     


                      </div>
                  </div>
              
                    <div class="page-header row">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label runat="server" visible="false" ID="LblRegistro" style="color:red; font-size:14px; font-style:italic;">Tus datos de perfil han sido registrado.</asp:Label>
                        </div>
                    </div>
                     </div>
                       
                    <div class="page-header row">
                           <div class="row">
                               <div class="col-md-12 text-center">
                                   <asp:Button runat="server" class="btn-lg btn-primary" Text="Registrar Datos"  ID="BtnRegistrarPerfil" OnClick="BtnRegistrarPerfil_Click"/>
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
