using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class TipoSalaRepository : ITipos_Salas
    {
        private readonly CineContext _context;

        public TipoSalaRepository(CineContext context)
        {
            _context = context;
        }
        public List<TiposSala> GetAll()
        {
            return _context.TiposSalas.ToList();
        }
    }
}
