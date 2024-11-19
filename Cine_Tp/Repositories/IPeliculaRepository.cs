using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        List<Pelicula> GetGenero(int IdGenero);
        bool Create(Pelicula oPelicula);
        bool Update(int id, int duracion);
        bool Delete(int id);
    }
}
