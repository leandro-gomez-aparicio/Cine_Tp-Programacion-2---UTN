using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public interface IReserva
    {
        List<Reserva> GetEstado(int idEstadoReserva);
        public bool Delete(int idReserva);

    }
}
