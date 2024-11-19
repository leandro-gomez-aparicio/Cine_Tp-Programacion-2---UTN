using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private CineContext _context;
        public UsuarioRepository(CineContext context) 
        {
            _context = context;
        }
        public bool GetUsuario(string nombre, string contraseña)
        {
            return _context.Usuarios.Any(u => u.NombreUsuario == nombre && u.Contraseña == contraseña);
        }
    }
}
