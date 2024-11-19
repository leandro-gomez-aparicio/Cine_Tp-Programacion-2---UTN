using Cine_Tp.Data;
namespace Cine_Tp.Repositories

{
    public interface ISalasRepository
    {
      
        List<Sala> GetAll();

        public bool Put(int id, int capacidad);


    }
}
