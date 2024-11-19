using Cine_Tp.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cine_Tp.Repositories
{
    public interface IFuncionRepository
    {
        List<Funciones> GetFuncionList(int idPelicula);

        //Task<IEnumerable<Funciones>> GetFuncionesByPeliculaIdAsync(int idPelicula);


    }


}

