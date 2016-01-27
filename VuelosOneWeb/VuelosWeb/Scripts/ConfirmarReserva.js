function ConfirmarReserva() {
    $.ajax({
        url: urlConfirmarUsuario,
        type: 'POST',
        data: { codigoVuelo: $("#idVuelo").val() },
        success: function (resultado) {
            if (resultado === "Exitoso") {
                alert("Se ha registrado la reserva");
                location.href = ".";
            }

        },
        error: function (resultado) {
            alert("Ocurrio un error");
        }

    });
}

function IniciarConfirmacion(codigoVueloSel) {
    $("#codigoVuelo").val(codigoVueloSel);
    $("#frmReserva").submit();
}