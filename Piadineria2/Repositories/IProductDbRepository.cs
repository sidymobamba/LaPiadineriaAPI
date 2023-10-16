using Piadineria2.Dto;
using Piadineria2.Entities;

namespace Piadineria2.Repositories
{
    public interface IProductDbRepository
    {
        Task<IEnumerable<BibitaEntity>> GetBibitaAsync();
        Task<IEnumerable<SnackEntity>> GetSnackAsync();
        Task<IEnumerable<PiadinaWithIngredients>> GetPiadinaWithIngredientsAsync();
        Task AddSnackAsync(SnackEntity snack);
        Task UpdateSnackAsync(SnackEntity updatedSnack);
        Task<SnackEntity> GetSnackAsync(int id);
    }
}
