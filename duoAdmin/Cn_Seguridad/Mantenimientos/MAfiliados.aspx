<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MAfiliados.aspx.cs" Inherits="Cn_Seguridad.Mantenimientos.MAfiliados" %>

<%@ Register TagPrefix="usc" TagName="uscProgressBar" Src="~/Controles/uscProgressBar.ascx" %>
<%@ Register TagPrefix="uscAcceso" TagName="uscAccesoUsuario" Src="~/Controles/uscAcceso.ascx" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="MainContent" runat="server">

    <usc:uscProgressBar runat="server" ID="uscProgress" />
    <uscAcceso:uscAccesoUsuario runat="server" ID="uscAccesoUsuario" />

       <script type="text/javascript">

        function init_page() {
            
        }

        $(document).ready(function () {
            init_page();
        });

    </script>

    <asp:UpdatePanel runat="server" ID="upd_maint" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="right_col" role="main">
                 <div class="row">
                      <div class="col-md-12">
                          <div class="title_left">
                            <h2> <i class="fa fa-gears"></i> &nbsp;Mantenimiento /&nbsp;Afiliados<small>&nbsp;Modificación y Registro de afiliados.</small></h2>
                    
                            </div>
                      </div>
                </div>

                <div class="row">

                    <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                         <section id="sec_PerfilesPermisos">
                                <div class="x_panel">
                                <div class="x_content">
                                    <div id="tabs" class="" role="tabpanel" data-example-id="togglable-tabs">
                                        <ul id="myTabBoleto" class="nav nav-tabs bar_tabs" role="tablist">
                                            <li role="presentation" class="active" runat="server" id="Li1" clientidmode="Static">
                                                <a href="#tab_boleto" id="Li1-tab" role="tab" data-toggle="tab" aria-expanded="true">DATOS DEL AFILIADO</a></li>
                                            <%--<li role="presentation" class="" runat="server" id="Li2" clientidmode="Static">
                                                <a href="#tab_Documentos" id="Li2-tab" role="tab" data-toggle="tab" aria-expanded="true">DOCUMENTOS</a>
                                            </li>--%>
                                        </ul>
                                        <div id="myTabContentBoleto" class="tab-content">

                                            <!--TAB ASIGNA MODULOS AL PERFIL-->
                                            <div role="tabpanel" class="tab-pane fade active in" id="tab_boleto" runat="server" clientidmode="Static" aria-labelledby="profile-tab">
                                                <div class="col-md-12">
                                                    
                                                    <div class="row">
                                                        <div class="col-md-12 col-xs-12">
                                                            <label class="col-md-12 input-xs">Datos para registrar afiliado</label>
                                                        </div>
                                                        
                                                    </div>
                                                    
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Nombre del afiliado" class="form-control" MaxLength="50" ID="TxtNombre" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                        <div class="col-md-3 col-xs-3">
                                                            <%--<button type="button" id="btnAgregarperfil" class="btn btn-success btn-md col-md-6 input-md" onclick="ModalAgregarPerfil()">
                                                            <spam class="glyphicon glyphicon-plus"></spam>--%>
                                                            <asp:Button runat="server" class="btn btn-success btn-xs col-md-12 input-xs" ClientIDMode="Static" ID="btnGrabarDatos" Text="Registrar Afiliado" OnClick="btnGrabarDatos_Click"/>
                                                             
                                                        </button>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Identificacion Afiliado" class="form-control" MaxLength="15" ID="TxtIdentificacionAfiliado" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Acerca del" class="form-control" MaxLength="50" ID="TxtAcerca" autocomplete="off" ClientIDMode="Static" TextMode="MultiLine" Rows="6"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Nombre del Contacto 1" class="form-control" MaxLength="50" ID="TxtContacto1" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Telefono del Contacto 1" class="form-control" MaxLength="50" ID="TxtFono1" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Email del Contacto 1" class="form-control" MaxLength="50" ID="TtxtCorreo1" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>

                                                                <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Nombre del Contacto 2" class="form-control" MaxLength="50" ID="TxtContacto2" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Telefono del Contacto 2" class="form-control" MaxLength="50" ID="TxtFono2" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-9 col-xs-9">
                                                           <asp:TextBox runat="server" placeholder="Email del Contacto 2" class="form-control" MaxLength="50" ID="TtxtCorreo2" autocomplete="off" ClientIDMode="Static"/>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfIdProveedor" />
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdf_tipoImagen" />
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnNombreFotoCarnet" />
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnNombreFotoCedula" />
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdfControlAfiliado" />
                                           

                                        </div>
                                    </div>
                                </div>
                            </div>

                            
                        </section>
                        </div>
                    </div>
                </div>
                 
                    <div class="col-md-6">
                    <div class="row">
                        <section id="sec_PerfilesAsignados">
                            <div class="x_panel">
                                <div class="x_content">
                                    <div id="tabs2" class="" role="tabpanel" data-example-id="togglable-tabs">
                                        <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                        <li role="presentation" class="active" runat="server" id="tli_DocumentosRegistrados" clientidmode="Static"><a href="#tab_DocumentosRegistrados" id="tabDocReg" role="tab" data-toggle="tab" aria-expanded="true">FOTOS</a>
                                        </li>
                                    </ul>
                                        <div id="myTabContentBoleto2" class="tab-content">

                                            <!--TAB MENUS ASIGNADOS-->
                                     

                                            <div role="tabpanel" class="tab-pane fade active in" id="tab_DocumentosRegistrados" runat="server" clientidmode="Static" aria-labelledby="profile-tab">
                                            
                                                
                                                   <div class="row">
                                                            <div class="col-sm-6">
                                                            <!-- IMAGE UPLOAD -->
                                                            <label class="col-md-12 input-xs">
                                                                Foto Principal Afiliado (490px × 290px)
                                                            </label>
                                                            <asp:Image runat="server" Width="390px" Hight ="190px" ID="img_foto_reg"/>
                                                            <a data-toggle='tooltip' id="lkb_subirImagenReg" href="javascript:openfileDialogExistente('2');"
                                                                class="fa fa-camera fa-2x col-md-offset-1" title="Cambiar la Imagen" tooltip="Cambiar la Imagen"></a>
                                      
                                                             <!-- END IMAGE UPLOAD -->
                                                        </div>
                                                </div>
                                                <div class="row">
                                                            <div class="col-sm-6">
                                                            <!-- IMAGE UPLOAD -->
                                                            <label class="col-md-12 input-xs">
                                                                Foto Secundaria (200px × 200px)
                                                            </label>
                                                            <asp:Image runat="server" Width="200px" Hight ="200px" ID="img_foto_reg2"/>
                                                            <a data-toggle='tooltip' id="lkb_subirImagenCedulaReg" href="javascript:openfileDialogExistente('3');"
                                                                class="fa fa-camera fa-2x col-md-offset-1" title="Cambiar la Imagen" tooltip="Cambiar la Imagen"></a>
                                      
                                                             <!-- END IMAGE UPLOAD -->
                                                        </div>
                                                </div>
                                        </div>

                                            

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>

                </div>

                <div class="row">
                     <!--Grid-->
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <label class="col-md-12 input-xs">
                                                                Afiliados Registrados:
                                                            </label>
                            <div class="row">
                                <div class="panel-body" style="padding: 10px; padding-bottom: 0px;">
                                    <div class="x_content">

                                        <asp:GridView ID="grvConsultaPromos" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="IdAfiliado"
                                            EmptyDataText="No se encontr&oacute; ning&uacute;n resultado" Width="100%"  
                                            CssClass="table table-striped jambo_table"  GridLines="None"
                                            AllowPaging="true" PageSize="5" OnPageIndexChanging="grvConsultaPromos_PageIndexChanging" OnRowCommand="grvConsultaPromos_RowCommand"
                                            >
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>

                                                <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Foto1" runat="server" Text='<%# Bind("Foto1") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Foto2" runat="server" Text='<%# Bind("Foto2") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="ControlAfiliado" runat="server" Text='<%# Bind("ControlAfiliado") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>

                                               <%-- <asp:BoundField HeaderStyle-CssClass="column-title" DataField="IdPromocion" HeaderText="Codigo" />--%>
                                                <asp:TemplateField HeaderText="Codigo" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="IdAfiliado" runat="server" Text='<%# Bind("IdAfiliado") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Proveedor" HeaderText="Proveedor" />--%>
                                                <asp:TemplateField HeaderText="Afiliado" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Afiliado" runat="server" Text='<%# Bind("Afiliado") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ident.Afiliado" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="IdentAfiliado" runat="server" Text='<%# Bind("IdentAfiliado") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="AcercaDe" HeaderText="Acerca de" />--%>
                                                 <asp:TemplateField HeaderText="Acerca de" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="AcercaDe" runat="server" Text='<%# Bind("AcercaDe") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Contacto1" HeaderText="Cont.1" />--%>
                                                 <asp:TemplateField HeaderText="Cont.1" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Contacto1" runat="server" Text='<%# Bind("Contacto1") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Telefono1" HeaderText="Fono.1" />--%>
                                                <asp:TemplateField HeaderText="Fono.1" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Telefono1" runat="server" Text='<%# Bind("Telefono1") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Email1" HeaderText="Email.1" />--%>
                                                <asp:TemplateField HeaderText="Email.1" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Email1" runat="server" Text='<%# Bind("Email1") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>

                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Contacto2" HeaderText="Cont.2" />--%>
                                                <asp:TemplateField HeaderText="Cont.2" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Contacto2" runat="server" Text='<%# Bind("Contacto2") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Telefono2" HeaderText="Fono.2" />--%>
                                                <asp:TemplateField HeaderText="Fono.2" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Telefono2" runat="server" Text='<%# Bind("Telefono2") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Email2" HeaderText="Email.2" />--%>
                                                <asp:TemplateField HeaderText="Email.2" Visible="True">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Email2" runat="server" Text='<%# Bind("Email2") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                     </asp:TemplateField>

                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="Usuario" HeaderText="Creado Por." />
                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="FechaCreacionConsulta" HeaderText="Fecha Creacion" />
                                                <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="Estado" HeaderText="Estado" />--%>

                                                <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkb_Editar" CommandName="Editar" runat="server" ControlStyle-CssClass="fa fa-edit fa-2x"
                                                            ToolTip="Editar" CommandArgument='<%# Container.DisplayIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkb_Eliminar" CommandName="Eliminar" runat="server" ControlStyle-CssClass="fa fa-trash fa-2x"
                                                            ToolTip="Eliminar Proveedor" CommandArgument='<%# Container.DisplayIndex %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                    
                                </div>
                                
                            </div>
                            
                        </div>
                    </div>
                    <!--Fin Grid-->
                </div>
               

            </div>

            
        </ContentTemplate>
        <Triggers>
            
           
            <asp:AsyncPostBackTrigger ControlID="btnGrabarDatos" />
           
           
        </Triggers>
    </asp:UpdatePanel>

         <%--<asp:Button runat="server" Style="display: none" ID="btn_subirImagen" OnClick="btn_subirImagen_Click" ClientIDMode="Static" />
         <asp:FileUpload ID="fup_imagen" Style="display: none" AllowMultiple="false" accept="image/png,image/jpeg" ClientIDMode="Static" runat="server" />--%>
         <asp:Button runat="server" Style="display: none" ID="btn_subirImagen_registrada"  OnClick="btn_subirImagen_registrada_Click" ClientIDMode="Static" />
        <asp:FileUpload ID="fup_imagen_registrada" Style="display: none" AllowMultiple="false" accept="image/png,image/jpeg,image/jpg" ClientIDMode="Static" runat="server" />
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

</asp:Content>