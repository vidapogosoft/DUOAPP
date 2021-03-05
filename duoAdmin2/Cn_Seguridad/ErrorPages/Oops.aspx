<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="Cn_Seguridad.ErrorPages.Oops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Portal Duo: Lo sentimos!!!!!</title>


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



</head>
<body>
    <form id="formPedidosregular" runat="server">
   
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>

    
             <asp:UpdatePanel runat="server" ID="upd_maint" UpdateMode="Conditional">
            <ContentTemplate>
                
                <div class="container-fluid">
                    <br />
                     <div class="row">
                      <div class="col-sm-12 text-center">
                          <asp:Image runat="server" Width="195px" Hight ="195px" ID="img_foto_reg" ImageUrl="~/Imagenes/Fotos/vidapogosoft/ErrorDuo.gif" />
                      </div>
                  </div>
                <div class="page-header row">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label runat="server" visible="true" ID="LblRegistro" style="color:red; font-size:20px; font-style:italic;">OOPS... We can't seem to find the page you're looking for.!</asp:Label>
                        </div>
                    </div>
                     </div>


                </div>
              
 
            </ContentTemplate>

         </asp:UpdatePanel>
         
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


