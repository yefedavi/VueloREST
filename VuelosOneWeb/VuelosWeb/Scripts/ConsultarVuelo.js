function ConsultarVuelos() {
    var checkedTipo = $('input:radio[name=tipoconsulta]:checked').val();
    if (checkedTipo === "horario") {
        $.ajax({
            url: urlConsultarTipoHorario,
            type: 'POST',
            data: { ciudadOrigen: $("#ciudadorigen").val(), ciudadDestino: $("#ciudaddestino").val(), },
            success: function (resultado) {
                $("#vuelosDisponiblesHorarioDiv").css("display", "block");
                $("#divTabla").html(resultado);
            },
            error: function (resultado) {
                alert("Ocurrio un error");
            }
        });
    } else {
        $.ajax({
            url: urlConsultarTipoTarifa,
            type: 'POST',
            data: { ciudadOrigen: $("#ciudadorigen").val(), ciudadDestino: $("#ciudaddestino").val(), },
            success: function (resultado) {
                $("#vuelosDisponiblesHorarioDiv").css("display", "block");
                $("#divTabla").html(resultado);
            },
            error: function (resultado) {
                alert("Ocurrio un error");
            }
        });
    }
}