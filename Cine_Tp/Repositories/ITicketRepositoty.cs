using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public interface ITicketRepositoty
    {
        List<Ticket> GetTickets(int idFuncion);
        public Ticket CrearTicket(int idFuncion, int idButaca);
        public Ticket ModificarTicket(int idTicket, int idNuevaReserva);
        public bool EliminarTicket(int idTicket);
        List<Ticket> GetAllTickets();




    }
}
