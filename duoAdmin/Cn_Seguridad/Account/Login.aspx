<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cn_Seguridad.Account.Login" %>

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Chopin APP Ecuador</title>

    <!-- Bootstrap -->
    <link href="../asset/vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../asset/vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../asset/vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../asset/vendors/animate.css/animate.min.css" rel="stylesheet">
    <link href="../asset/vendors/pnotify/dist/pnotify.css" rel="stylesheet">
    <link href="../asset/vendors/pnotify/dist/pnotify.buttons.css" rel="stylesheet">
    <link href="../asset/vendors/pnotify/dist/pnotify.nonblock.css" rel="stylesheet">
    <!-- Custom Theme Style -->
    <link href="../asset/build/css/custom.min.css" rel="stylesheet">
    <link href="../asset/css/basBoleteria.css" rel="stylesheet">
</head>

<body class="login">
    <div>
        <a class="hiddenanchor" id="signup"></a>
        <a class="hiddenanchor" id="signin"></a>

        <div class="login_wrapper">
            <div class="animate form login_form">
                <section class="login_content">
                    <form runat="server">
                        <asp:HiddenField ID="hdf_ipUser" runat="server" />
                        <h1>Inicio de Sesión</h1>
                        <div>
                            <asp:TextBox ID="txt_Usuario" type="text" class="form-control" placeholder="Usuario" runat="server" />
                        </div>
                        <div>
                            <asp:TextBox ID="txt_Password" TextMode="Password" class="form-control" placeholder="Contraseña" runat="server" />
                        </div>
                        <div>
                            <asp:Button runat="server" ID="btn_LogIn" CssClass="btn btn-primary" OnClick="LogIn" Text="Iniciar Sesión" />
                            <a class="reset_pass" href="#">Olvidaste tu contraseña?</a>
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">

                            <div class="clearfix"></div>
                            <br />

                            <div>
                                <h1>CHOPIN</h1>
                                <p>©2020 Todos los derechos reservados. Desarrollado por Chopin APP Ecuador</p>
                            </div>
                        </div>
                        <script type="text/javascript">

                            window.RTCPeerConnection = window.RTCPeerConnection || window.mozRTCPeerConnection || window.webkitRTCPeerConnection;   //compatibility for firefox and chrome
                            var pc = new RTCPeerConnection({ iceServers: [] }), noop = function () { };
                            pc.createDataChannel("");    //create a bogus data channel
                            pc.createOffer(pc.setLocalDescription.bind(pc), noop);    // create offer and set local description
                            pc.onicecandidate = function (ice) {  //listen for candidate events
                                if (!ice || !ice.candidate || !ice.candidate.candidate) return;
                                var myIP = /([0-9]{1,3}(\.[0-9]{1,3}){3}|[a-f0-9]{1,4}(:[a-f0-9]{1,4}){7})/.exec(ice.candidate.candidate)[1];
                                $("#hdf_ipUser").val(myIP);
                                pc.onicecandidate = noop;
                            };

                            function mostrarMensaje(titulo, mensaje, tipo) {
                                new PNotify({
                                    title: titulo,
                                    text: mensaje,
                                    type: tipo,
                                    delay:3500,
                                    styling: 'bootstrap3'
                                });
                            }
                        </script>
                        <!-- jQuery -->
                        <script src="../asset/vendors/jquery/dist/jquery.min.js"></script>
                        <!-- Bootstrap -->
                        <script src="../asset/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
                        <!-- FastClick -->
                        <script src="../asset/vendors/fastclick/lib/fastclick.js"></script>
                        <!-- NProgress -->
                        <script src="../asset/vendors/nprogress/nprogress.js"></script>
                        <!-- bootstrap-progressbar -->
                        <script src="../asset/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"></script>
                        <!-- iCheck -->
                        <script src="../asset/vendors/iCheck/icheck.min.js"></script>
                        <!-- PNotify -->
                        <script src="../asset/vendors/pnotify/dist/pnotify.js"></script>
                        <script src="../asset/vendors/pnotify/dist/pnotify.buttons.js"></script>
                        <script src="../asset/vendors/pnotify/dist/pnotify.nonblock.js"></script>

                        <!-- Custom Theme Scripts -->
                        <script src="../asset/build/js/custom.min.js"></script>
                    </form>
                </section>
            </div>


        </div>
    </div>



</body>

