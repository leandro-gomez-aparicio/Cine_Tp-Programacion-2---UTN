using Cine_Tp.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cine_Tp.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private CineContext _context;

        public PeliculaRepository(CineContext context)
        {
            _context = context;
        }

        public bool Create(Pelicula oPelicula)
        {
            _context.Peliculas.Add(oPelicula);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula != null && pelicula.Estreno == true)
            {
                pelicula.Estreno = false;
            }
            return _context.SaveChanges() >0;

        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.ToList();
        }

        public List<Pelicula> GetGenero(int IdGenero)
        {
            DateOnly fech = DateOnly.FromDateTime(DateTime.Now);
            var peliculas = _context.Peliculas.Where(x => x.IdGenero == IdGenero && x.Funciones.Any(f=>f.FechaFuncion >= fech)).ToList();
            return peliculas;
        }

        public bool Update(int id, int duracion)
        {
            var peliculaActualizada = _context.Peliculas.Find(id);
            if (peliculaActualizada != null)
            {
                peliculaActualizada.Duracion = duracion;

            }
            
            return _context.SaveChanges() > 0;
        }
    }
}
