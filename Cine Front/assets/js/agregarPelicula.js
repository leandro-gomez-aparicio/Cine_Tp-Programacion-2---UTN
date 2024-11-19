document.getElementById("formAgregarPelicula").addEventListener("submit", async function (event) {
    event.preventDefault();

    // Obtener valores del formulario
    const idPelicula = document.getElementById("idPelicula").value;
    const nombre = document.getElementById("nombre").value;
    const duracion = document.getElementById("duracion").value;
    const idGenero = document.getElementById("idGenero").value;
    const idRestriccion = document.getElementById("idRestriccion").value;
    const estreno = document.getElementById("estreno").value === "true";

    // Crear objeto de película
    const nuevaPelicula = {
        idPelicula: parseInt(idPelicula),
        nombre: nombre,
        duracion: parseInt(duracion),
        idGenero: parseInt(idGenero),
        idRestriccion: parseInt(idRestriccion),
        estreno: estreno
    };

    try {
        // Llamada a la API
        const response = await fetch('https://localhost:44373/api/Pelicula', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevaPelicula)
        });

        // Manejo de la respuesta
        const resultado = await response.text();
        if (response.ok) {
            document.getElementById("resultado").textContent = "Película agregada con éxito: " + resultado;
        } else {
            document.getElementById("resultado").textContent = "Error: " + resultado;
        }
    } catch (error) {
        document.getElementById("resultado").textContent = "Ocurrió un error: " + error;
    }
});
