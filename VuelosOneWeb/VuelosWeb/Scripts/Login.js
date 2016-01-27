function LoguearUsuario() {
    $.ajax({
        url: urlLoginUsuario,
        type: 'POST',
        data: { Username: $("#usuario").val(), Password: $("#password").val() },
        success: function (resultado) {
            if (resultado === "Exitoso") {
                alert("Bienvenido");
                location.href = ".";
            } else {
                alert("Datos incorrectos,el usuario no existe");
            }
            
        },
        error: function (resultado) {
            alert("Datos incorrectos,el usuario no existe");
        }

    });
}