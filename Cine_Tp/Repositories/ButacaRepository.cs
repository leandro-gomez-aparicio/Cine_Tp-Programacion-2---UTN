using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public class ButacaRepository:IButaca
    {
        private CineContext _context;

        public ButacaRepository( CineContext context )
        {
            _context = context;
        }

        public bool Delete(int IdButaca)
        {
            var baja = _context.Butacas.Find(IdButaca);
            if (baja != null && baja.Estado == true)
            {
                baja.Estado = false;
            }
            return _context.SaveChanges() > 0;
   

        }

        public List<Butaca> GetIdSala(int idSala)
        {
            return _context.Butacas.Where(x => x.IdSala == idSala).ToList();
                     
        }
    }
}
