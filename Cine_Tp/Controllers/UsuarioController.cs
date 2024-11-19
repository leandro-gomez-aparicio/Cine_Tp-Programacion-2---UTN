using Cine_Tp.Data;
using Cine_Tp.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cine_Tp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: api/<UsuarioController>
        [HttpPost]
        public IActionResult Get([FromBody] Usuario usuario)
        {
            try
            {
                return _usuarioRepository.GetUsuario(usuario.NombreUsuario, usuario.Contraseña) ? Ok() : BadRequest(false);
            }
            catch (Exception) { return StatusCode(500, "Error"); }
        }

        
    }
}
