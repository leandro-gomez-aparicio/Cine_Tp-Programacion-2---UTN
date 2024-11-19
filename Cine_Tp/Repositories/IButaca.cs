using Cine_Tp.Data;

namespace Cine_Tp.Repositories
{
    public interface IButaca
    {
        List<Butaca> GetIdSala(int IdSala);
        public bool Delete(int IdButaca);
        
    }
}
