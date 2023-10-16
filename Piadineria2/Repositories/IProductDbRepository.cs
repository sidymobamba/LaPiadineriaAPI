using Piadineria2.Dto;
using Piadineria2.Entities;

namespace Piadineria2.Repositories
{
    public interface IProductDbRepository
    {
        // Products
        Task<IEnumerable<BibitaEntity>> GetBibitaAsync();
        Task<IEnumerable<SnackEntity>> GetSnackAsync();
        Task<IEnumerable<PiadinaWithIngredients>> GetPiadinaWithIngredientsAsync();
        // Snacks
        Task AddSnackAsync(SnackEntity snack);
        Task UpdateSnackAsync(SnackEntity updatedSnack);
        Task<SnackEntity> GetSnackAsync(int id);
        Task DeleteSnackAsync(SnackEntity snack);
        // Bibite
        Task AddBibitaAsync(BibitaEntity bibita);
        Task<BibitaEntity> GetBibitaAsync(int id);
        Task UpdateBibitaAsync(BibitaEntity updatedBibita);
        Task DeleteBibitaAsync(BibitaEntity bibita);
        // Piadine
        Task<PiadinaWithIngredients> AddPiadinaAsync(PiadinaEntity piadina);
        Task<PiadinaEntity> GetPiadinaAsync(int id);
        Task UpdatePiadinaAsync(PiadinaEntity updatedPiadina);
        Task DeletePiadinaAsync(PiadinaEntity piadina);
    }
}
