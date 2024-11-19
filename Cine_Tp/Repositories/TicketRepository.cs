using Cine_Tp.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cine_Tp.Repositories
{
    public class TicketRepository : ITicketRepositoty
    {
        private CineContext _context;
        public TicketRepository (CineContext context)
        {
            _context = context;
        }
        public Ticket CrearTicket(int idFuncion, int idButaca)
        {
            var funcion = _context.Funciones
                        .Include(x=>x.Pelicula)
                        .Include(f => f.Sala)
                            .ThenInclude(s => s.Butacas).FirstOrDefault(f => f.IdFuncion == idFuncion);
            if (funcion == null)
            {
                throw new Exception("La función especificada no existe.");
            }

            
            var butaca = funcion.Sala.Butacas.FirstOrDefault(b => b.IdButaca == idButaca);
            if (butaca == null || !butaca.Estado == true)
            {
                throw new Exception("La butaca especificada no existe o no está disponible.");
            }

            
            butaca.Estado = false;

            var ultimoTicket = _context.Tickets.OrderByDescending(x => x.NumTicket).Take(1).FirstOrDefault()?.NumTicket ??0;

            var ticket = new Ticket
            {
                IdFuncion = idFuncion,
                IdButaca = butaca.IdButaca,
                NumTicket = ultimoTicket +1, 
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                Precio = funcion.Pelicula?.Precio ?? 0,
            };

            #region insert
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            #endregion

            return ticket;

        }

        public bool EliminarTicket(int idTicket)
        {
            var ticket = _context.Tickets.Find(idTicket);

            if (ticket == null)
            {
                throw new Exception("El ticket especificado no existe.");
            }
            var butaca = _context.Butacas.FirstOrDefault(b => b.IdButaca == ticket.IdButaca);
            if (butaca == null || !butaca.Estado == false)
            {
                throw new Exception("La butaca especificada no existe o no está disponible.");
            }
            butaca.Estado = true;



            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return true;
        }

        public List<Ticket> GetTickets(int idFuncion)
        {
            return _context.Tickets.Where(t => t.IdFuncion == idFuncion).ToList();
        }
        public List<Ticket> GetAllTickets()
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Now);
            return _context.Tickets.Where(x => x.Fecha >= hoy)
                .Include(x=>x.Butaca)
                .Include(x=>x.Funciones)
                .OrderByDescending(x => x.NumTicket)
                .ToList();
        }

        public Ticket ModificarTicket(int idTicket, int idNuevaButaca)
        {
            var ticket = _context.Tickets
                        .Include(t => t.Butaca)                   
                        .Include(t => t.Funciones)                    
                        .ThenInclude(f => f.Sala)                   
                        .FirstOrDefault(t => t.NumTicket == idTicket);
            if (ticket == null)
            {
                throw new Exception("El ticket especificado no existe.");
            }

            var butacaActual = ticket.Butaca;
            if (butacaActual != null)
            {
                butacaActual.Estado = true;
            }

            var nuvaButaca = _context.Butacas.Include(b => b.Tickets). FirstOrDefault(b => b.IdButaca == idNuevaButaca);
            if (nuvaButaca == null || nuvaButaca.Estado == false)
            {
                throw new Exception("La nueva butaca especificada no existe o no está disponible.");
            }
           
            nuvaButaca.Estado = false;
            ticket.IdButaca = nuvaButaca.IdButaca;

            _context.SaveChanges();

            return ticket;
        }

       
    }
}
