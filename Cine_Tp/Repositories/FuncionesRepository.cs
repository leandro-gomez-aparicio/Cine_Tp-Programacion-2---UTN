using Cine_Tp.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cine_Tp.Repositories
{
    public class FuncionesRepository : IFuncionRepository
    {
        private readonly CineContext _context;

        public FuncionesRepository(CineContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Funciones>> GetFuncionesByPeliculaIdAsync(int idPelicula)
        //{
        //    return await _context.Funciones.Include(f => f.Sala).ThenInclude(s => s.IdTipoSala).Where(f => f.IdPelicula == idPelicula).ToArrayAsync();



        //}



        public List<Funciones> GetFuncionList(int idPelicula)
        {
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Now);
            var funcion = _context.Funciones.Where(f => f.IdPelicula == idPelicula && f.FechaFuncion >= hoy).ToList();
            return funcion;
        }


    }
}
