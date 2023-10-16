using Piadineria2.Entities;

namespace Piadineria2.Repositories
{
    public interface IProductDbRepository
    {
        Task<IEnumerable<BibitaEntity>> GetBibitaAsync();
        Task<IEnumerable<SnackEntity>> GetSnackAsync();
        Task<IEnumerable<PiadinaEntity>> GetPiadinaAsync();
    }
}
