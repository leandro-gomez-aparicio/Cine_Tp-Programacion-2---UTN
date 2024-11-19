using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly CineContext _context;

        public GeneroRepository(CineContext context)
        { 
            _context = context;
        }
        public List<Genero> GetAll()
        {
            return _context.Generos.ToList();
        }
    }
}
