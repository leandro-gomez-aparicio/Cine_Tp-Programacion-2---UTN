document.addEventListener('DOMContentLoaded', () => {
    const API_URL = 'https://localhost:44373/api'; // Reemplaza con tu URL real

    // Obtener los elementos del formulario
    const form = document.getElementById('form-InicioSesion');
    const inputNombre = document.getElementById('username');
    const inputContraseña = document.getElementById('password');

    // Agregar un listener al formulario
    form.addEventListener('submit', async (event) => {
        event.preventDefault();
        console.log('Formulario enviado'); // Esto te ayudará a saber si el evento se activa

        const nombre = inputNombre.value;
        const contraseña = inputContraseña.value;

        const body = {
            NombreUsuario: nombre,
            Contraseña: contraseña
        };
        console.log('Cuerpo de la solicitud:', body); // Verifica aquí



        try {
            const response = await fetch(`${API_URL}/Usuario`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(body)
            });
            console.log('Respuesta del servidor:', response);
            if (response.ok) {
                Swal.fire({
                    title: "Bienvenido",
                    confirmButtonText: "Ok",
                  }).then((result) => {
                    if (result.isConfirmed) {
                        $('#loginModal').modal("hide")
                        $('#btnInicioSesion').hide();
                        $("#btnCerrarSesion").removeAttr('hidden');
                    } 
                  });
            } else {
                Swal.fire({
                    icon: "error",
                    title: "Oops...",
                    text: "Usuario o contraseña incorrecta",
                  });

            }
        } catch (error) {
            Swal.fire({
                icon: "error",
                text: "Error al Iniciar Sesión",
              });
        }
    });
    document.getElementById('btnCerrarSesion').addEventListener('click', function () {
        $('#btnInicioSesion').show();
        $("#btnCerrarSesion").attr("hidden",true);

    })
});


