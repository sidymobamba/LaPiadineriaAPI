using Piadineria2.Model;

namespace Piadineria2.Repositories
{
    public interface IProductRepository
    {
        List<Snack> GetAllSnacks();
        List<Bibita> GetAllBibite();
        List<Piadina> GetAllPiadine();
    }
}
