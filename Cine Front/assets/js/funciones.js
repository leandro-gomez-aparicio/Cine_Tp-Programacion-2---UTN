let peliculaFunciionSeleccionadaId = 0;

async function FuncionesPorPeliculas(peliculaFunciionSeleccionadaId){
    const idPelicula = parseInt(peliculaFunciionSeleccionadaId);
    if (idPelicula) {

        const response = await fetch(`https://localhost:44373/api/Pelicula/Api/GET_FUNCIONES?idpeli=${idPelicula}`);
        const funciones = await response.json();
        const $tbody = document.getElementById('tbodyFuncionesPeliculas');
        let tbody = '';
        funciones.$values.forEach(element => {
            tbody += `
            <tr>
                
                <td style="display: none;" >
                    ${element.IdFuncion}
                </td>
                <td>
                    ${element.FechaFuncion}
                </td>
                <td>
                    ${element.HoraFuncion}
                </td>
                <td>
                    ${element.IdSala}
                </td>
                <td>
                    <button type="button" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#modalButacas" onClick="GetButacas(${element.IdFuncion}, ${element.IdSala})" >Crear Ticket</button>
                </td>
            </tr>`
        });
        
        $tbody.innerHTML = tbody

    }

}

function buscarFunciones(){

}



document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('btnBuscarFunciones').addEventListener('click', function () {
        $("#peliculaSeleccionada").attr("hidden",false);})
//FuncionesPorPeliculas(peliculaSeleccionadaId);
   

   
})
