using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class SalasRepository : ISalasRepository
    {
        private CineContext _context;

        public SalasRepository(CineContext context)
        {
            _context = context;
        }

        public List<Sala> GetAll()
        {
            return _context.Salas.ToList();
        }


        public bool Put(int id, int capacidad)
        {
            var sala = _context.Salas.Find(id);
            if (sala != null)
            {
                sala.Capacidad = capacidad;
            }
            return _context.SaveChanges() > 0;
        }
    }
}
