<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscProgressBar.ascx.cs" Inherits="Cn_Seguridad.Controles.uscProgressBar" %>

<asp:UpdateProgress runat="server" ID="ProgressBar" AssociatedUpdatePanelID="upd_maint">
    <ProgressTemplate>
        <div class="progressBarModal" id="progressModal">
            <div class="modal-dialog" style="margin-top: 18%">
                <div class="modal-content">
                    <div data-backdrop="static" data-keyboard="false" tabindex="-1" aria-hidden="true">
                        <div class="modal-header">
                            <h3 style="margin: 0;">
                                <i class="fa fa-clock-o"></i>&nbsp;&nbsp;Por favor espere..
                            </h3>
                        </div>
                        <div class="modal-body">
                            <h4>Estamos trabajando...
                            </h4>
                            <div class="progress">
                                <%--<div  class="progress-bar" data-transitiongoal="75"></div>--%>
                                <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="99" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>
                                <%--<div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="99" aria-valuemin="0" aria-valuemax="100" style="width: 100%"></div>--%>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>