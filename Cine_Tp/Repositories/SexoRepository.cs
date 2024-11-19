using Cine_Tp.Data;
using Cine_Tp.Repositories.Utils;

namespace Cine_Tp.Repositories
{
    public class SexoRepository : ISexoRepository
    {
        private readonly CineContext _context;

        public SexoRepository(CineContext context)
        {
            _context = context;
        }

        public List<Sexo> GetAll(int id)
        {
            return _context.Sexos.Where(x => x.IdSexo == id).ToList();
        }

    }
}
