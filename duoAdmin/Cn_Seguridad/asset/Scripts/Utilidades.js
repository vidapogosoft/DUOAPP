
$.replaceAll = function (text, busca, reemplaza) {

    while (text.toString().indexOf(busca) != -1)

    text = text.toString().replace(busca, reemplaza);

    return text;

}




$.showprogress = function (progTit, progText, progImg) {
    $.hideprogress();
    $("BODY").append( ' <div id="processing_overlay" ></div>');
    $("BODY").append(  '<div id="processing_container">' +
/*        '<h1 id="processing_title">' + progTit + '</h1>' +
        '<div id="processing_content">' +
          '<div id="processing_message">' + progText +
                      '<br/><br/>' + progImg + '</div>' +
                      */
                      '<div id="myModal" class="modal" style="display:block" >  <div class="modal-content">   <span class="close">x</span>   <p>' + progText  +'</p>  </div> </div> ' +
        //'</div>' +
      '</div>');

    var pos = (navigator.appVersion.indexOf("MSIE") !== -1 && parseInt($.browser.version) <= 6) ?
               'absolute' : 'fixed';

    $("#processing_container").css({
        position: pos,
        zIndex: 99999,
        padding: 0,
        margin: 0
    });

    $("#processing_container").css({
        minWidth: $("#processing_container").outerWidth(),
        maxWidth: $("#processing_container").outerWidth()
    });

    var top = (($(window).height() / 2) -
      ($("#processing_container").outerHeight() / 2)) + (-75);
    var left = (($(window).width() / 2) -
      ($("#processing_container").outerWidth() / 2)) + 0;
    if (top < 0) top = 0;
    if (left < 0) left = 0;

    // IE6 fix
    if (navigator.appVersion.indexOf("MSIE") !== -1 && parseInt($.browser.version) <= 6) top =
        top + $(window).scrollTop();

    $("#processing_container").css({
        top: top + 'px',
        left: left + 'px'
    });
    $("#processing_overlay").height($(document).height());
}



$.hideprogress = function () {
    $("#processing_container").remove();
    $("#processing_overlay").remove();
}



$.Esperar = function (sw, titulo, texto) {

    if (sw) {
        $.showprogress(titulo, texto, '<img src="Images/cargando-4.gif"/>');
    }else{
        $.hideprogress();
    }
}



function calcularEdad(fechan) {
    var fecha = fechan;

    
    
    //if (validate_fecha(fecha) == true) {
        // Si la fecha es correcta, calculamos la edad
    
    var values = mySplit(fecha, '/');

    //var values = fecha.split("-");
        var dia = values[0];
        var mes = values[1];
        var ano = values[2];
        
        // cogemos los valores actuales
        var fecha_hoy = new Date();
        var ahora_ano = fecha_hoy.getYear();
        var ahora_mes = fecha_hoy.getMonth() + 1;
        var ahora_dia = fecha_hoy.getDate();

        // realizamos el calculo
        var edad = (ahora_ano + 1900) - ano;
        
        if (ahora_mes < mes) {
            edad--;
        }
        if ((mes == ahora_mes) && (ahora_dia < dia)) {
            edad--;
        }
        if (edad > 1900) {
            edad -= 1900;
        }

        // calculamos los meses
        var meses = 0;
        if (ahora_mes > mes)
            meses = ahora_mes - mes;
        if (ahora_mes < mes)
            meses = 12 - (mes - ahora_mes);
        if (ahora_mes == mes && dia > ahora_dia)
            meses = 11;

        // calculamos los dias
        var dias = 0;
        if (ahora_dia > dia)
            dias = ahora_dia - dia;
        if (ahora_dia < dia) {
            ultimoDiaMes = new Date(ahora_ano, ahora_mes, 0);
            dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
        }

        

        
        return edad;
}


function mySplit(str, ch) {
    var pos, start = 0, result = [];
    while ((pos = str.indexOf(ch, start)) != -1) {
        result.push(str.substring(start, pos));
        start = pos + 1;
    }
    result.push(str.substr(start));
    return (result);
}




function validate_fecha(fecha) {
    var patron = new RegExp("^(19|20)+([0-9]{2})([-])([0-9]{1,2})([-])([0-9]{1,2})$");

    if (fecha.search(patron) == 0) {
        var values = fecha.split("-");
        if (isValidDate(values[2], values[1], values[0])) {
            return true;
        }
    }
    return false;
}

/*****************************FIN UTILIDADES*************************************************************//////
jQuery.fn.center = function () {
    this.css("position", "absolute");
    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) +
                                                $(window).scrollTop()) + "px");
    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) +
                                                $(window).scrollLeft()) + "px");
    return this;
};

function pad(campo, longitud, caracter, tf) {
    result = campo.toString();
    j = longitud - result.length;
    for (i = 0; i < j; i++) {
        if (tf === 'left') {
            result = caracter + result;
        }
        else {
            result = result + caracter;
        }
    }
    return result;
}

jQuery.fn.isNullOrEmpty = function () {
    if (this.val() === null || this.val() === '' || this.val().length === 0 || this.val() === 'undefined') {
        return true;
    }
    return false;
};

function nvl(valor, reemplazo) {
    return isNullOrEmpty(valor) ? reemplazo : valor;
}



(function ($) {
    $(".numeric").bind("keypress", function (e) {
        var keyCode = e.which ? e.which : e.keyCode;
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) !== -1);
        return ret;
    });

    $(".numeric").bind("paste", function (e) {
        return false;
    });

    $(".numeric").bind("drop", function (e) {
        return false;
    });
})(jQuery);

function isNullOrEmpty(value) {
    if (value === null || value === undefined || value === 'undefined' || value === '' || value.length === 0) {
        return true;
    }
    return false;
}

function showDialog(message, urlDestination) {
    $("#pd").text(message);
    dd = $("#dialog").dialog({
        title: _tituloDialog,
        autoOpen: false,
        modal: true,
        closeOnEscape: false,
        resizable: false,
        draggable: false,
        width: 500,
        buttons: [{
            text: "Aceptar",
            click: function () {
                dd.dialog("close");
                if (!isNullOrEmpty(urlDestination)) {
                    window.location.href = urlDestination;
                }
            }
        }]
    });
    dd.dialog("open");
}

function showListPopUp(urlPaginaLista) {
    $("#dialog").css("background-color : #C9C9C9;");
    $("#dialog").html('<iframe style="border: 0px" src="' + urlPaginaLista + '" width="100%" height="100%"></iframe>');
    dd = $("#dialog").dialog({
        title: _tituloDialog,
        autoOpen: false,
        modal: true,
        closeOnEscape: false,
        resizable: false,
        draggable: false,
        width: 1000,
        height: 600
    });
    dd.dialog("open");
    return false;
}


var specialKeys = new Array();
specialKeys.push(8); //Backspace
specialKeys.push(9);


function showDialogAut(html) {
    $("#pd").html(html);
    dd = $("#dialog").dialog({
        title: _tituloDialog,
        autoOpen: false,
        modal: true,
        closeOnEscape: false,
        resizable: false,
        draggable: false,
        width: 400,
        buttons: [{
            text: "Aceptar",
            click: function () {
                if (autorizarReverso())
                    dd.dialog("close");
            }
        },
                 {
                     text: "Cancelar",
                     click: function () {
                         dd.dialog("close");
                     }
                 }
        ]
    });
    dd.dialog("open");
}

function validarFrmLogin() {
    usuario = $("input[id*=txtUsuario]").val();
    clave = $("input[id*=txtClave]").val();
    if (!isNullOrEmpty(usuario) && !isNullOrEmpty(clave)) {
        return true;
    }
    else {
        showDialog("Ingrese todos los datos.", "");
        return false;
    }
}

function validarFrmRestablecerLogin() {
    usuario = $("input[id*=txtUsuario]").val();
    clave = $("input[id*=txtClave]").val().toUpperCase();
    claveConf = $("input[id*=txtClaveConf]").val().toUpperCase();
    if (!isNullOrEmpty(usuario) && !isNullOrEmpty(clave) && !isNullOrEmpty(claveConf)) {
        if (clave != claveConf) {
            showDialog("Los campos clave, no coinciden. Por favor, verifique.", "");
            return false;
        }
        return true;
    }
    else {
        showDialog("Ingrese todos los datos.", "");
        return false;
    }
}

function validarFrmMantServidores() {

    descripcion = $("[id*=txtDescripcion]").val();
    direccionIP = $("[id*=txtIPBDD]").val();

    puertoBDD = $("[id*=txtPuertoBDD]").val();
    nombreBDD = $("[id*=txtNombreBDD]").val();
    usuarioBDD = $("[id*=txtUsuarioBDD]").val();
    claveBDD = $("[id*=txtClaveBDD]").val();
    claveBDDConf = $("[id*=txtClaveBDDConf]").val();
    estado = $("[id*='cboEstado'] :selected").val();
    if (!isNullOrEmpty(descripcion) && !isNullOrEmpty(direccionIP) && !isNullOrEmpty(puertoBDD) &&
        !isNullOrEmpty(nombreBDD) && !isNullOrEmpty(usuarioBDD) && !isNullOrEmpty(claveBDD) &&
        !isNullOrEmpty(claveBDDConf) && !isNullOrEmpty(estado)) {
        if (claveBDD != claveBDDConf) {
            showDialog("Los campos clave, no coinciden. Por favor, verifique.", "");
            return false;
        }
        return true;
    }
    else {
        showDialog("Ingrese todos los datos.", "");
        return false;
    }
}

function validarFrmMantEmpresas() {

    razonSocial = $("[id*=txtRazonSocial]").val();
    ruc = $("[id*=txtRUC]").val();
    direccion = $("[id*=txtDireccion]").val();
    telefono = $("[id*=txtTelefono]").val();
    servidorBDD = $("[id*='cboServidorBDD'] :selected").val();
    estado = $("[id*='cboEstado'] :selected").val();

    if (!isNullOrEmpty(razonSocial) && !isNullOrEmpty(ruc) && !isNullOrEmpty(direccion) &&
        !isNullOrEmpty(telefono) && !isNullOrEmpty(servidorBDD) && !isNullOrEmpty(estado)) {
        return true;
    }
    else {
        showDialog("Ingrese todos los datos.", "");
        return false;
    }
}

function validarFrmMantUsuarios(validarClave, esUsuarioBAT) {

    usuario = $("[id*=txtUsuario]").val();
    nombres = $("[id*=txtNombres]").val();
    pApellido = $("[id*=txtPApellido]").val();
    sApellido = $("[id*=txtSApellido]").val();
    telefono = $("[id*=txtTelefono]").val();
    email = $("[id*=txtEmail]").val();
    identificacion = $("[id*=txtIdentificacion]").val();
    clave = $("[id*=txtClave]").val().toUpperCase();
    claveConf = $("[id*=txtClaveConf]").val().toUpperCase();
    empresa = $("[id*='cboEmpresa'] :selected").val();
    estado = $("[id*='cboEstado'] :selected").val();

    if (!isNullOrEmpty(usuario) && !isNullOrEmpty(nombres) && !isNullOrEmpty(pApellido) &&
        !isNullOrEmpty(sApellido) && !isNullOrEmpty(telefono) && !isNullOrEmpty(email) &&
        !isNullOrEmpty(identificacion) && !isNullOrEmpty(clave) && !isNullOrEmpty(claveConf) &&
        (esUsuarioBAT ? !isNullOrEmpty(empresa) : true) && !isNullOrEmpty(estado)) {
        if (validarClave) {
            if (clave != claveConf) {
                showDialog("Los campos clave, no coinciden. Por favor, verifique.", "");
                return false;
            }
        }
        return true;
    }
    else {
        showDialog("Ingrese todos los datos.", "");
        return false;
    }
}

function abrirPopup(pagina) {
    if (window.showModalDialog) {
        var objRetorno = showModalDialog(pagina, true, "menubar:no;dialogWidth:800px;dialogHeight:450px;resizable:no");
        return true;
    }
    else {
        window.open(pagina, 'name', 'height=450,width=800,toolbar=no,directories=no,status=no,continued from previous linemenubar=no,scrollbars=no,resizable=no ,modal=yes').focus();
        return true;
    }
}

function closeWindow() {
    window.parent.dd.dialog("close");
    window.parent.form1.submit();
}

function setDataPicker() {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi\u00E9rcoles', 'Jueves', 'Viernes', 'S\u00E1bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi\u00E9', 'Juv', 'Vie', 'S\u00E1b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S\u00E1'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        changeMonth: true,
        changeYear: true,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);
    $(".inputDateReport").datepicker({
        dateFormat: 'dd/mm/yy'
    });
}

function validarParamsReporte() {
    fechaDesde = $("[id*=txtFechaDesde]").val();
    fechaHasta = $("[id*=txtFechaHasta]").val();
    if (isNullOrEmpty(fechaDesde) || isNullOrEmpty(fechaHasta)) {
        showDialog("Ingrese Fecha Desde y Fecha Hasta", "");
        return false;
    }
    return true;
}

function setFormatClaves() {
    /*$("").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && e.ctrlKey === true) || 
            (e.keyCode >= 35 && e.keyCode <= 39)) {
                return;
            }
 
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });*/

    jQuery("[id *= txtClave], [id *= txtClaveConf]").keypress(function (e) {
        var regex = new RegExp("^[a-zA-Z0-9_]+$");
        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
        if (regex.test(str) || e.keyCode == 8 || e.keyCode == 46 || e.keyCode == 9) {
            return true;
        }

        e.preventDefault();
        return false;
    });

}






$.ValidaRUC = function validarRUCCED(number) {
    
    var dto = number.length;
    var valor;
    var acu = 0;
    if (number == "") {
        alert('No has ingresado ningún dato, porfavor ingresar los datos correspondientes.');
        return false;
    }
    else {
        for (var i = 0; i < dto; i++) {
            valor = number.substring(i, i + 1);
            if (valor == 0 || valor == 1 || valor == 2 || valor == 3 || valor == 4 || valor == 5 || valor == 6 || valor == 7 || valor == 8 || valor == 9) {
                acu = acu + 1;
            }
        }
        if (acu == dto) {
            while (number.substring(10, 13) != 001) {
                alert('Los tres últimos dígitos no tienen el código del RUC 001.');
                return false;
            }
            while (number.substring(0, 2) > 24) {
                alert('Los dos primeros dígitos no pueden ser mayores a 24.');
                return false;
            }
            return true;
            var porcion1 = number.substring(2, 3);
            if (porcion1 < 6) {
                alert('El tercer dígito es menor a 6, por lo \ntanto el usuario es una persona natural.\n');
            }
            else {
                if (porcion1 == 6) {
                    alert('El tercer dígito es igual a 6, por lo \ntanto el usuario es una entidad pública.\n');
                }
                else {
                    if (porcion1 == 9) {
                        alert('El tercer dígito es igual a 9, por lo \ntanto el usuario es una sociedad privada.\n');
                    }
                }
            }
        }
        else {
            alert("ERROR: Por favor no ingrese texto");
            return false;
        }
    }
}


$.ValidaCedula = function Validacedula(number) {
    var cedula = number;
    array = cedula.split("");
    num = array.length;
    if (num == 10) {
        total = 0;
        digito = (array[9] * 1);
        for (i = 0; i < (num - 1) ; i++) {
            mult = 0;
            if ((i % 2) != 0) {
                total = total + (array[i] * 1);
            }
            else {
                mult = array[i] * 2;
                if (mult > 9)
                    total = total + (mult - 9);
                else
                    total = total + mult;
            }
        }
        decena = total / 10;
        decena = Math.floor(decena);
        decena = (decena + 1) * 10;
        final = (decena - total);
        if ((final == 10 && digito == 0) || (final == digito)) {
            return true;
        }
        else {
            alert("La cedula NO es valida!!!");
            return false;
        }
    }
    else {
        alert("La cedula no puede tener menos de 10 digitos");
        return false;
    }
      
}

 function ValidaAsientoOcupado(ciCompania, ciLocalidad, ciVentanilla, ciViaje, ciAsiento) {
    var aData = 0 + ';' + ciCompania + ';' + ciLocalidad + ';' + ciVentanilla + ';' + ciViaje + ';' + ciAsiento;
    var jsonData = JSON.stringify({ op: aData });
    var data;
    $.ajax({
        async: false,
        type: "POST",
        url: "Services/ServiceBoleto.svc/ExistsSelBoleto",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var items = response.d;
            if (items != "ok") {
                alert("El asiento con número " + ciAsiento + ", no se encuentra disponible o está ocupado, por favor vuelva a escoger nuevamente");
                data = false;
              
            } else {
                data =true;

            }
            
        }//fin function
            , error: function () { window.location.href = "errorPage.aspx?var1=" + "error asiento disponible en utilidades"; }

    });//fin ajax
    return data;
    
 }



 function DialogBar( modal, bar, intervalo ) {

    var modal = document.getElementById(modal);
     modal.style.display = "block";
     var elem = document.getElementById(bar);
     var width = 0;
     //pausecomp(8000);
     var id = setInterval(frame, intervalo);
     function frame() {
         if (width >= 100) {
             clearInterval(id);
         } else {
             width = width + 10;
             pausecomp(1000);
             elem.style.width = width + '%';
             elem.innerHTML = width * 1 + '%';
             if (width == 1000)
                 modal.style.display = "none";

         }
     }
 }

 function pausecomp(millis) {
     var date = new Date();
     var curDate = null;
     do {
         curDate = new Date();
     }
     while (curDate - date < millis);
 
 }









 var isMobile = {
     mobilecheck: function () {
         return (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino|android|ipad|playbook|silk/i.test(navigator.userAgent || navigator.vendor || window.opera) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test((navigator.userAgent || navigator.vendor || window.opera).substr(0, 4)))
     }
 }

 




