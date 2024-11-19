async function GenerarTicket(IdFuncion, IdButaca){
    const API_URL =`https://localhost:44373/api/Pelicula/API/CREAR_TICKET?idFuncion=${IdFuncion}&idButaca=${IdButaca}`
    try {
        const response = await fetch(`${API_URL}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Ticket generado exitosamente",
                showConfirmButton: false,
                timer: 1500
              });
              $('#modalButacas').modal("hide")
        } else {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Ha ocurrido un error!",
              });
        }
    } catch (error) {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "Ha ocurrido un error!",
          });
    }
};


async function GetTicket(){
    const response = await fetch(`https://localhost:44373/api/Pelicula/API/CONSULTAR_ALL_TICKET`);
        const tickets = await response.json();
        const $tbody = document.getElementById('tbodyTickets');
        let tbody = ''
        tickets.$values.forEach(element => {
            if(element){
                tbody += `
                <tr>
                    <td>
                        ${element.NumTicket ?? "-"}
                    </td>
                    <td>
                        ${element.Fecha ?? "-"}
                    </td>
                    <td>
                        ${element.Butaca?.IdSala ?? "-"}
                    </td>
                    <td>
                        ${element.Butaca?.Numero ?? 0}
                    </td>
                    <td>
                        ${element.Butaca?.Fila ?? 0}
                    </td>
                    <td>
                        ${element.Precio ?? 0}
                    </td>
                    <td>
                        <button class="btn btn-success"  data-bs-toggle="modal" data-bs-target="#modalButacasModificar" onClick="GetButacasModificar(${element.NumTicket}, ${element.Butaca?.IdSala}, ${element.Butaca?.Numero}, '${element.Butaca?.Fila}')">Modificar</button>
                        <button class="btn btn-danger" onclick="EliminarTicket(${element.NumTicket})">Eliminar</button>
                    </td>
                </tr>`
            }
            
        });
        $tbody.innerHTML = tbody
}

async function EliminarTicket(NumTicket){
    const API_URL =`https://localhost:44373/api/Pelicula/API/ELIMINAR_TICKET?idTicket=${NumTicket}`
    try {
        const response = await fetch(`${API_URL}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Ticket eliminado exitosamente",
                showConfirmButton: false,
                timer: 1500
              });
              $("#consultaPeliculasdiv").attr("hidden",true);
              $("#consultaTicketsdiv").attr("hidden",true);
        } else {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Ha ocurrido un error!",
              });
        }
    } catch (error) {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "Ha ocurrido un error!",
          });
    }
};


async function ModificarTicket(NumTicket, IdButaca){
    const API_URL =`https://localhost:44373/api/Pelicula/API/MODIFICAR_TICKET?idTicket=${NumTicket}&idNuevaButaca=${IdButaca}`
    try {
        const response = await fetch(`${API_URL}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Ticket actualizado exitosamente",
                showConfirmButton: false,
                timer: 1500
              });
              $('#modalButacasModificar').modal("hide")
              $("#consultaPeliculasdiv").attr("hidden",true);
              $("#consultaTicketsdiv").attr("hidden",true);
        } else {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Ha ocurrido un error!",
              });
        }
    } catch (error) {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "Ha ocurrido un error!",
          });
    }
};

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('ConsultarTickets').addEventListener('click', function () {
        $("#consultaPeliculasdiv").attr("hidden",true);
        $("#consultaTicketsdiv").attr("hidden",false);
        GetTicket()

    })
})


