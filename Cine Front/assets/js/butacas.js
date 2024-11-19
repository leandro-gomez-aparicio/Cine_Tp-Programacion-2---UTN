async function GetButacas(IdFuncion, IdSala){
    const idSala = parseInt(IdSala);
    let coloBtn = "";
    if (idSala) {

        const response = await fetch(`https://localhost:44373/api/Pelicula/API/BUTACAS-SALA?idSala=${idSala}`);
        const butacas = await response.json();
        const $tbody = document.getElementById('tbodyButacas');
        let tbody = '';
        let i = 0;
        butacas.$values.forEach(element => {
            i ++;
            if(element.Estado)
                coloBtn = "butacaDisponible"
            else
                coloBtn = "butacaOcupada"
             if(i == 1){
                 tbody += `<div class="col-1"></div>`}
            tbody += `<div class="col-2">
                <button class="btn_sq ${coloBtn}" onclick="GenerarTicket(${IdFuncion},${element.IdButaca})" >${element.Numero}</button>
            </div>`
             if(i == 5){
                 tbody += `<div class="col-1"></div>`
                 i = 0
            }
                
             
        });
        
        $tbody.innerHTML = tbody

    }

}

async function GetButacasModificar(NumTicket, IdSala, numeroButaca, numeroFila){
    const idSala = parseInt(IdSala);
    let coloBtn = "";
    if (idSala) {

        const response = await fetch(`https://localhost:44373/api/Pelicula/API/BUTACAS-SALA?idSala=${idSala}`);
        const butacas = await response.json();
        const $tbody = document.getElementById('tbodyButacasModificar');
        let tbody = '';
        let i = 0;
        butacas.$values.forEach(element => {
            i ++;
            if(element.Estado)
                coloBtn = "butacaDisponible"
            else
                coloBtn = "butacaOcupada"

            if(element.Numero == numeroButaca && element.Fila == numeroFila)
                coloBtn = "butacaAnterior"
             if(i == 1){
                 tbody += `<div class="col-1"></div>`}
            tbody += `<div class="col-2">
                <button class="btn_sq ${coloBtn}" onclick="ModificarTicket(${NumTicket},${element.IdButaca})" >${element.Numero}</button>
            </div>`
             if(i == 5){
                 tbody += `<div class="col-1"></div>`
                 i = 0
            }
                
             
        });
        
        $tbody.innerHTML = tbody

    }

}