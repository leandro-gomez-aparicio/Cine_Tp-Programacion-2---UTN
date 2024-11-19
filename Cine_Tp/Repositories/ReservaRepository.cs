using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class ReservaRepository : IReserva
    {
        private CineContext _context;
        public ReservaRepository(CineContext context)
        {
            _context = context;
        }
        public bool Delete(int idReserva)
        {
            var reserva = _context.Reservas.Find(idReserva);
            if (reserva != null && reserva.IdEstadoReserva == 1)
            {
                reserva.IdEstadoReserva = 2;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Reserva> GetEstado(int idEstadoReserva)
        {
            return _context.Reservas.Where(r => r.IdReserva == idEstadoReserva).ToList();
        }
    }
}
