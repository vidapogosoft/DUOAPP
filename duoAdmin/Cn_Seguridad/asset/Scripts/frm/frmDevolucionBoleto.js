function validarfrmDevolucionBoleto() {
    txIdentificacion = $("[id*=txIdentificacion]").val();
    if (txIdentificacion!= null) {
        return true;
    } else {
        alert("Es necesario ingresar una identificacion ");
        return false;

    }

}


