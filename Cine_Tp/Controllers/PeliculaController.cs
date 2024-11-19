using Microsoft.AspNetCore.Mvc;
using Cine_Tp.Repositories;
using Cine_Tp.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json.Serialization;

namespace Cine_Tp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IGeneroRepository _generosRepository;
        private IRestriccionesRepository _restriccionRepository;
        private IPeliculaRepository _peliRepository;
        private ITipos_Salas _tSalaRepository;
        private ISalasRepository _salaRepository;
        private IButaca _butRepository;
        private IFuncionRepository _funcionRepository;
        private IReserva _resRepository;
        private ITicketRepositoty _ticRepository;

        public PeliculaController(IGeneroRepository genRepository, IRestriccionesRepository resRepository,
            IPeliculaRepository peliRepository, ITipos_Salas t_salasRepo, ISalasRepository salaRepo,
            IButaca butRepository, IFuncionRepository funcionrepo, IReserva reservarepo,
            ITicketRepositoty ticRepository)
        {
            _generosRepository = genRepository;
            _restriccionRepository = resRepository;
            _peliRepository = peliRepository;
            _tSalaRepository = t_salasRepo;
            _salaRepository = salaRepo;
            _butRepository = butRepository;
            _funcionRepository = funcionrepo;
            _resRepository = reservarepo;
            _ticRepository = ticRepository;
        }

        [HttpGet("/API/GENEROS")]

        public IActionResult GetGenero()
        {
            try
            {
                return Ok(_generosRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error interno: {ex.Message}");
            }
        }

        [HttpGet("API/RESTRICCIONES")]

        public IActionResult GetRestriccion()
        {
            try
            {
                return Ok(_restriccionRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }

        [HttpGet("API/PELICULAS")]

        public IActionResult GetPelicula()
        {
            try
            {
                var peliculas = _peliRepository.GetAll();
                if (peliculas == null)
                {
                    return NotFound("No hay peliculas en cartelera");
                }
                return Ok(peliculas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");

            }
        }

        [HttpGet("API/PELICULAS_GENERO")]

        public IActionResult GetPelicuasGenero(int id)
        {
            try
            {
                var peli = _peliRepository.GetGenero(id);
                if (peli == null)
                {
                    return NotFound("No hay peliculas con ese Genero");
                }
                return Ok(peli);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {

            try
            {
                if (!IsValid(pelicula))
                {
                    return BadRequest("No se ingresaron los datos necesarios");

                }
                else
                    _peliRepository.Create(pelicula);
                return Ok("Pelicula registrada con éxito!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }


        }

        private bool IsValid(Pelicula pelicula)
        {
            return pelicula.IdPelicula > 0 &&
                !string.IsNullOrEmpty(pelicula.Nombre) &&
                pelicula.Duracion > 0 &&
                pelicula.IdGenero > 0 &&
                pelicula.IdRestriccion > 0 &&
                pelicula.Estreno == true ||
                pelicula.Estreno == false;

        }

        [HttpPut]

        public IActionResult Put(int id, int duracion)
        {
            try
            {
                if (id < 0 || duracion < 0)
                {
                    return NotFound("Pelicula no encontrada");
                }
                var actualizado = _peliRepository.Update(id, duracion);

                if (!actualizado)
                {
                    return NotFound("No se puede actualizar");
                }
                return Ok("Pelicula actualizada exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(_peliRepository.Delete(id));
                }
                return BadRequest("Identificador inexistente");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }

        }

        [HttpGet("API/TIPOS_SALAS")]
        public IActionResult GetTipoSala()
        {
            try
            {
                return Ok(_tSalaRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }

        }

        [HttpGet("API/SALAS")]

        public IActionResult GetSala()
        {
            try
            {
                return Ok(_salaRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }

        [HttpPut("API/ACTUALIZAR_SALAS")]

        public IActionResult PutSalas(int id, int capacidad)
        {
            try
            {
                if (capacidad < 0)
                {
                    return NotFound("Debe ingresar los datos correctos");
                }
                var act = _salaRepository.Put(id, capacidad);

                if (act == false)
                {
                    return NotFound("No se puede actualizar");
                }
                return Ok("Sala Actualizada exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("API/BUTACAS-SALA")]
        public IActionResult GetButacas(int idSala)
        {
            var butaca = _butRepository.GetIdSala(idSala);
            if (butaca == null || butaca.Count == 0)
            {
                return NotFound();
            }
            return Ok(butaca);

        }

        [HttpDelete("API/DISPONIBILIDAD-BUTACA")]

        public IActionResult DeleteButaca(int idButaca)
        {
            try
            {
                if (idButaca > 0)
                {
                    return Ok(_butRepository.Delete(idButaca));
                }
                return BadRequest("Identificador inexistente");

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }

        }

        [HttpGet("Api/GET_FUNCIONES")]

        public IActionResult GetFuncionPelicula(int idpeli)
        {
            var funcion = _funcionRepository.GetFuncionList(idpeli);
            if (funcion == null )
            { return NotFound("No se encuenta una funcion con esa Pelicula"); }
            return Ok(funcion);
        
        }

        [HttpGet("API/GET_RESERVA")]
        public IActionResult GetReserva(int idEstado)
        { 
            var reserva = _resRepository.GetEstado(idEstado);
            if (reserva == null)
            {
                return NotFound("No se encuentran reservas disponibles");
            }
            return Ok(reserva);
        }

        [HttpDelete("API/BAJA_RESERVA")]
        public IActionResult DeleteReserva(int idReserva) 
        {
            try
            {
                if (idReserva > 0)
                {
                    _resRepository.Delete(idReserva);
                }
                return BadRequest("No hay reservas");
            }
            catch (Exception) 
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPost("API/CREAR_TICKET")]
        public IActionResult PostTicket(int idFuncion, int idButaca)
        {
            try
            {
                var ticket = _ticRepository.CrearTicket(idFuncion, idButaca);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error interno: {ex.Message}");
            }

        }

        [HttpPut("API/MODIFICAR_TICKET")]
        public IActionResult PutTicket(int idTicket,int idNuevaButaca)
        {
            try
            {
                var ticket = _ticRepository.ModificarTicket(idTicket, idNuevaButaca);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("API/ELIMINAR_TICKET")]
        public IActionResult DeleteTicket(int idTicket) 
        {
            try
            {
                _ticRepository.EliminarTicket(idTicket);
                return Ok("Ticket eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("API/CONSULTAR_TICKET")]
        public IActionResult GetTicket(int idFuncion) 
        {
            try
            {
                var ticket = _ticRepository.GetTickets(idFuncion);
                if (ticket == null || ticket.Count == 0)
                {
                    return NotFound("No se encuentran ticket para esa funcion");
                }
                return Ok(ticket);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Error al obtener tickets: {ex.Message}");
            }
        }

        [HttpGet("API/CONSULTAR_ALL_TICKET")]
        public IActionResult GetAllTicket()
        {
            try
            {
                var ticket = _ticRepository.GetAllTickets();
                if (ticket == null || ticket.Count == 0)
                {
                    return NotFound("No se encuentran ticket para esa funcion");
                }
                //return Ok(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener tickets: {ex.Message}");
            }

        }
    }
}
