/* 
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */



/*validacion para motor, chasis, placa*/
function validaSoloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    //especiales = [8];

    /*tecla_especial = false
     for(var i in especiales){
     if(key == especiales[i]){
     tecla_especial = true;
     break;
     }
     }*/
    if (caracteresEspeciales(e))
        return true;
    if (caracteres.indexOf(tecla) == -1) {
        return false;
    }
}


function validaSoloDigitos(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = "0123456789";
    //especiales = [8];

    /*tecla_especial = false
     for(var i in especiales){
     if(key == especiales[i]){
     tecla_especial = true;
     break;
     }
     }*/
    if (caracteresEspeciales(e))
        return true;
    if (caracteres.indexOf(tecla) == -1) {
        return false;
    }
}


function validaSoloAlfabeto(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
    //especiales = [8];

    /*tecla_especial = false
     for(var i in especiales){
     if(key == especiales[i]){
     tecla_especial = true;
     break;
     }
     }*/
    if (caracteresEspeciales(e))
        return true;
    if (caracteres.indexOf(tecla) == -1) {
        return false;
    }
}


/*validación de solo letras y espacio */
function validaSoloNumero(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    letras = "1234567890.-\t\b";
    if (caracteresEspeciales(e))
        return true;
    if (letras.indexOf(tecla) == -1) {
        return false;
    }
}



function validaSoloDinero(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    letras = "1234567890.";
    if (caracteresEspeciales(e))
        return true;
    if (letras.indexOf(tecla) == -1) {
        return false;
    }

}

/*validacion no caracteres especiales*/
function validaCaracteresEspeciales(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";
    especiales = [8];
    if (caracteresEspeciales(e))
        return true;
    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caracteres.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function validaCaracteresEspeciales2(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-";
    especiales = [8];
    if (caracteresEspeciales(e))
        return true;
    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caracteres.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}


/*validacion no caracteres especiales*/
function validaSoloDigito(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toUpperCase();
    caracteres = "0123456789";
    especiales = [8];
    if (caracteresEspeciales(e))
        return true;
    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caracteres.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function caracteresEspeciales(e) {

    if (e.keyCode == 37) {
        return true;
    }	//right Arrow
    if (e.keyCode == 39) {
        return true;
    }
    if (e.keyCode == 8) {
        return true;
    }
    if (e.keyCode == 17) {
        return true;
    }
    if (e.keyCode == 36) {
        return true;
    }
    if (e.keyCode == 16) {
        return true;
    }
    if (e.keyCode == 20) {
        return true;
    }
    if (e.keyCode == 9) {
        return true;
    }
    if (e.keyCode == 35) {
        return true;
    }
    if (e.keyCode == 46) {
        return true;
    }
    return false;
}

