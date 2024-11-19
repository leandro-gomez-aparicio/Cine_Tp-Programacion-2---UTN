let peliculaSeleccionadaId = 0;

function cargar_vista(url, callback=null) {
    fetch(url)
        .then((res) => {
            return res.text()
        })
        .then((txt) => {
            const $panel_content = document.getElementById('panel-content')
            $panel_content.innerHTML = txt
            
            if(callback) 
                callback();
        })
}

function CheckPelicula(id){
    peliculaSeleccionadaId = id
    }

async function cargar_generos() {
    try {
        const response = await fetch(`https://localhost:44373/API/GENEROS`);
        const generos = await response.json();
        const $generos = document.getElementById('generos');
        generos.$values.forEach(element => {
            const $option = document.createElement('option');
            $option.value = element.IdGenero;
            $option.textContent = element.Genero1;
            $generos.appendChild($option);
        });
    } catch (error) {
        console.error("Error al cargar los géneros:", error);

    }
}



async function PeliculasPorGenero(){
    const idGenero = parseInt(document.getElementById("generos").value);
    if (idGenero) {

        const response = await fetch(`https://localhost:44373/api/Pelicula/API/PELICULAS_GENERO?id=${idGenero}`);
        const peliculas = await response.json();
        const $tbody = document.getElementById('tbodyGeneroPelicula');
        let tbody = ''
        peliculas.$values.forEach(element => {
            tbody += `
            <tr>

                <td><input type="checkbox" class="checkPeliculasGral" onClick="CheckPelicula(${element.IdPelicula})" value="${element.$id}"/></td>
                <td style="display: none;" >
                    ${element.IdPelicula}
                </td>
                <td>
                    ${element.Nombre}
                </td>
            </tr>`
        });
        $tbody.innerHTML = tbody

    }

}

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('ConsultarPeliculas').addEventListener('click', function () {
        $("#consultaPeliculasdiv").attr("hidden",false);
        $("#consultaTicketsdiv").attr("hidden",true);
        cargar_generos()

    })
    document.getElementById('btnConsultar').addEventListener('click', function () {
        PeliculasPorGenero();

    })  
    
    document.getElementById('btnBuscarFunciones').addEventListener('click', function () {
        FuncionesPorPeliculas(peliculaSeleccionadaId);

    }) 
})

