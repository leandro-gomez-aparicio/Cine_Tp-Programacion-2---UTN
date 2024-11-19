using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public interface IUsuarioRepository
    {
        bool GetUsuario(string nombre, string contraseña);
    }
}
