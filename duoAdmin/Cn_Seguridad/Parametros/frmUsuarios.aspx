<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="Cn_Seguridad.Parametros.frmUsuarios" %>

<%@ Register TagPrefix="usc" TagName="uscProgressBar" Src="~/Controles/uscProgressBar.ascx" %>
<%@ Register TagPrefix="uscAcceso" TagName="uscAccesoUsuario" Src="~/Controles/uscAcceso.ascx" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="MainContent" runat="server">

    <usc:uscProgressBar runat="server" ID="uscProgress" />
    <uscAcceso:uscAccesoUsuario runat="server" ID="uscAccesoUsuario" />
    <asp:UpdatePanel runat="server" ID="upd_maint" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="right_col" role="main">
                <div class="title_left">
                    <h2><i class="fa fa-gears"></i>&nbsp;Mantenimiento /&nbsp;Usuarios <small>&nbsp;Modificaci&oacute;n de los datos de Usuarios</small></h2>
                </div>
                <div class="row">

                    <!--Filtros-->

                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="row">
                                <asp:Button Style="float: right; margin-right: 1%;" class="btn btn-primary" Text="Agregar " runat="server" ID="btn_agregarUsuario" OnClick="btnAdd_Click" ClientIDMode="Static" Visible ="false"></asp:Button>
                            </div>
                            <br />
                            <div class="panel panel-default" style="margin-bottom: 1%;">

                                <div class="panel-heading">
                                    <i class="">B&uacute;squeda Avanzada</i>
                                </div>


                                <div class="panel-body" style="padding: 10px; padding-bottom: 0px;">
                                    <div class="form-horizontal">
                                        <div class="form-group">


                                            <!--usuario-->

                                            <div class="col-md-6">
                                                <label class="col-md-4">Usuario</label>
                                                <div class="col-md-7 col-xs-4 col-xs-1">
                                                    <asp:TextBox runat="server" class="form-control" MaxLength="10" ID="txt_usuario" autocomplete="off" ClientIDMode="Static" onkeyup="ConsultarUsuario()" />
                                                </div>
                                            </div>


                                            <asp:Button class="btn btn-primary" Text="Buscar" runat="server" ID="btn_ConsultarUsuario" OnClick="btnConsultar_Click" ClientIDMode="Static"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--Fin Filtros-->


                    <!--Grid-->
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="row">
                                <div class="panel-body" style="padding: 10px; padding-bottom: 0px;">
                                    <div class="x_content">

                                        <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="ciUsuario,  txDescripcion, ciEstado, bdMaster, idPersona,txClave"
                                            EmptyDataText="No se encontr&oacute; ning&uacute;n resultado" Width="100%" AllowPaging="false"
                                            CssClass="table table-striped jambo_table" OnRowCommand="grvConsulta_RowCommand" GridLines="None"
                                            >
                                            <PagerStyle CssClass="pagination-ys" />
                                            <Columns>
                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="ciUsuario" HeaderText="Usuario" />
                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="txNombreCorto" HeaderText="Nombre Corto" />
                                                <%--<asp:TemplateField HeaderText="Nombre">
                                                    <ItemTemplate>
                                                        <%# Eval("rhPersonalCooperativa.txNombre")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="txDescripcion" HeaderText="Descripci&oacute;n" />
                                                <asp:BoundField HeaderStyle-CssClass="column-title" DataField="ciEstado" HeaderText="Estado" />



                                                <asp:TemplateField HeaderText="Master">
                                                    <ItemTemplate>
                                                        <%# Convert.ToBoolean(Eval("bdMaster")) ? "Si": "No"%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField HeaderText="Imagen">
                                                    <ItemTemplate>
                                                        <asp:LinkButton data-toggle='tooltip' ID="lkb_subirImagen" CommandName="imagen" runat="server" ControlStyle-CssClass="fa fa-camera fa-2x"
                                                            ToolTip="Subir Imagen" CommandArgument='<%# Eval("ciUsuario") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkb_Editar" CommandName="Editar" runat="server" ControlStyle-CssClass="fa fa-edit fa-2x"
                                                            ToolTip="Editar" CommandArgument='<%# Container.DisplayIndex %>' />
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



                    <!--Subir Imagen-->


                    <asp:FileUpload ID="fup_imagen" Style="display: none" AllowMultiple="false" accept="image/png,image/jpeg" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="hdf_idUsuarioSelect" ClientIDMode="Static" runat="server" />

                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grvConsulta" />
            <asp:AsyncPostBackTrigger ControlID="btn_Actualizar" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button runat="server" Style="display: none" ID="btn_subirImagen" OnClick="btn_subirImagen_Click" ClientIDMode="Static" />


    <!--Fin Imagen-->


    <!--Modal-->
    <div class="modal fade bs-example-modal-md" role="dialog" aria-hidden="true" id="modalMant">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                            </button>
                            <h4 class="modal-title" id="myModalLabel">Informaci&oacute;n de Usuario</h4>
                        </div>
                        <div class="modal-body">

                            <div class=" row">
                                <!--DEFINO LOS NOMBRE Y CANTIDAD DE TABS-->
                                <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                    <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                        <li role="presentation" class="active" runat="server" id="tli_DatosBasicos" clientidmode="Static"><a href="#tab_DatosBasicos" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">DATOS BASICOS</a>
                                        </li>
                                        <li role="presentation" class="" runat="server" id="tli_Perfiles" clientidmode="Static"><a href="#tab_Perfiles" role="tab" id="profile-tab" data-toggle="tab" aria-expanded="false">PERFILES ASIGNADOS</a>
                                        </li>
                                        <li role="presentation" class="" runat="server" id="tli_proveedores" clientidmode="Static"><a href="#tab_Prove" role="tab" id="profile-tab2" data-toggle="tab" aria-expanded="false">EMPRESAS</a>
                                        </li>
                                    </ul>
                                    <!--TODA LA SECCION DE LOS TABS-->
                                    <div id="myTabContent" class="tab-content">
                                        <!--FIN TAB DATOS BASICOS-->
                                        <div role="tabpanel" class="tab-pane fade active in" id="tab_DatosBasicos" runat="server" clientidmode="Static" aria-labelledby="profile-tab">
                                            <div class="col-md-12">

                                                <div class="row">

                                                    <!--USUARIO-->

                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Usuario</span>
                                                                <asp:TextBox class="form-control" runat="server" autocomplete="off" ID="txt_usuarioModal" MaxLength="15" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <!--NOMBRE CORTO-->
                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Nombre Corto</span>
                                                                <asp:TextBox class="form-control" runat="server" autocomplete="off" ID="txt_nombreCortoModal" MaxLength="50" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!--Persona-->
                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Persona</span>
                                                                <asp:DropDownList runat="server" Width="100%" ID="ddl_persona" ClientIDMode="Static"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!--DESCRIPCION-->
                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Descripci&oacute;n</span>
                                                                <asp:TextBox class="form-control" runat="server" autocomplete="off" ID="txt_descripcionModal" MaxLength="100"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!--CLAVE-->
                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Clave</span>
                                                                <asp:TextBox class="form-control" runat="server" autocomplete="off" ID="txt_claveModal" MaxLength="30"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <!--REPETIR CLAVE-->
                                                    <div class="row">
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Repetir Clave</span>
                                                                <asp:TextBox class="form-control" runat="server" autocomplete="off" ID="txt_repetirclaveModal"  MaxLength="30"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--MASTER-->
                                                    <div class="row" id="div_ContEspecial">
                                                        <div class="col-md-4 col-xs-10 col-md-offset-2">
                                                            <div class="checkbox">
                                                                <input type="checkbox" runat="server" class="flat input-md" id="chk_obligado" clientidmode="Static" aria-checked="undefined">
                                                                <asp:Label runat="server" class="input-md" ID="lblMaster">Master</asp:Label>
                                                            </div>
                                                        </div>


                                                        <!--ESTADO-->
                                                        <div class="col-md-5 col-xs-10">
                                                            <div class="form-group">
                                                                <asp:DropDownList data-toggle="dropdown" CssClass="form-control" Width="100%" runat="server" ID="ddl_Estado" ClientIDMode="Static">
                                                                    <asp:ListItem Value="A" Text="ACTIVO"></asp:ListItem>
                                                                    <asp:ListItem Value="I" Text="INACTIVO"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>


                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <!--FIN TAB DATOS BASICOS-->

                                        <!--INICIO TAB ASIGNACION DE PERFILES-->
                                        <div role="tabpanel" class="tab-pane fade" id="tab_Perfiles" runat="server" aria-labelledby="profile-tab" clientidmode="Static">
                                            <div class="row">
                                                <div class="col-md-10 col-xs-8 col-md-offset-1">

                                                    <asp:GridView ID="grvAsignaPerfiles" runat="server" AutoGenerateColumns="False"
                                                        DataKeyNames="ciPerfil"
                                                        EmptyDataText="No se encontr&oacute; ning&uacute;n resultado" Width="100%" AllowPaging="true"
                                                        PageSize="10" CssClass="table table-striped jambo_table" OnRowCommand="grvConsulta_RowCommand" GridLines="None"
                                                        OnPageIndexChanging="grvConsulta_PageIndexChanging">
                                                        <PagerStyle CssClass="pagination-ys" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Asignado">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkPerfilAsignado" runat="server" class="flat input-md" ClientIDMode="Static" aria-checked="undefined" />
                                                                    <%--<input type="checkbox" runat="server" class="flat input-md" id="chkPerfilAsignado" clientidmode="Static" aria-checked="undefined">--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:BoundField HeaderStyle-CssClass="column-title" DataField="ciPerfil" HeaderText="Codigo Perfil" />--%>
                                                            <asp:TemplateField HeaderText="Codigo Perfil" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPerfilId" runat="server" Text='<%# Bind("ciPerfil") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderStyle-CssClass="column-title" DataField="txNombre" HeaderText="Nombre Perfil" />
                                                            <asp:BoundField HeaderStyle-CssClass="column-title" DataField="txDescripcion" HeaderText="Descripcion Perfil" />

                                                        </Columns>
                                                    </asp:GridView>

                                                </div>
                                            </div>
                                        </div>
                                        <!--FIN TAB ASIGNACION DE PERFILES-->

                                        <!--INICIO TAB ASIGNACION DE PROVEEDORES-->
                                        <div role="tabpanel" class="tab-pane fade" id="tab_Prove" runat="server" aria-labelledby="profile-tab" clientidmode="Static">
                                            <div class="row">
                                                <div class="col-md-10 col-xs-8 col-md-offset-1">

                                                    <div class="row">
                                                        <label>(*)Solo si es un usuario proveedor debe asignarle el proveedor a su perfil de usuario.</label>
                                                        <div class="col-md-10 col-xs-8 col-md-offset-1">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">Proveedor</span>
                                                                <asp:DropDownList runat="server" ID="ddlProveedor"  ClientIDMode="Static" Width="100%"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <!--FIN TAB ASIGNACION DE PROVEEDORES-->
                                    </div>

                                </div>
                            </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row">
                                    <asp:Button runat="server" class="btn btn-primary" ClientIDMode="Static" ID="btn_Actualizar" Text="Actualizar" OnClick="btnGuardar_Click" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btn_Actualizar" />
                        <asp:AsyncPostBackTrigger ControlID="grvConsulta" />
                        <asp:AsyncPostBackTrigger ControlID="btn_agregarUsuario" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!--Fin-->



    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(fire);
        function fire() {
            $('input').on('ifClicked', function (ev) { $(ev.target).click() });
        }


        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                $("#btn_subirImagen").click();
            }
        }


        function openfileDialog(idUsuario) {

            $("#hdf_idUsuarioSelect").val(idUsuario);
            $("#fup_imagen").click();

        }

        function ActivarModal(bdNuevo) {
            if (bdNuevo == "1") {
                $("#txt_usuarioModal").removeAttr('disabled');
            }
            else
                $("#txt_usuarioModal").attr('disabled', '');
        }

        function refrescarToolTip() {
            $('[data-toggle="tooltip"]').tooltip();
            $("#chk_obligado").iCheck({
                checkboxClass: 'icheckbox_flat-green'

            });
            $("[type='checkbox']").iCheck({
                checkboxClass: 'icheckbox_flat-green'
            });
            $("#ddl_persona").select2({ placeholder: 'Busque y seleccione una opción' });
            $("#ddl_Estado").select2({ placeholder: 'Busque y seleccione una opción' });
            $("#ddlProveedor").select2({ placeholder: 'Busque y seleccione una opción' });
        }

    </script>

</asp:Content>

