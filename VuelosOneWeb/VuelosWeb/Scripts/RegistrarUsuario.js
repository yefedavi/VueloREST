function IngresarUsuario() {
    $.ajax({
        url: urlIngresarUsuario,
        type: 'POST',
        data: { Username: $("#usuario").val(), Password: $("#password").val(), FechaNacimiento: $("#fechaNacimiento").val() },
        success: function (resultado) {
            if (resultado === "Exitoso") {
                alert("Se ha registrado el usuario");
                location.href = ".";
            }
            
        },
        error: function (resultado) {
            alert("Ocurrio un error");
        }

    });
}