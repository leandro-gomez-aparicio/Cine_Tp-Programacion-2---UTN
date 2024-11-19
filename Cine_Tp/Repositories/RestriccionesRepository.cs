using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class RestriccionesRepository : IRestriccionesRepository
    {
        private readonly CineContext _context;

        public RestriccionesRepository(CineContext context)
        {
            _context = context;
        }
        public List<Restriccione> GetAll()
        {
            return _context.Restricciones.ToList();
        }
    }
}
