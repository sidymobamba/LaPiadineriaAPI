using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Piadineria2.DbContexts;
using Piadineria2.Dto;
using Piadineria2.Entities;

namespace Piadineria2.Repositories
{
    public class ProductDbRepository : IProductDbRepository
    {
        private ProductInfoContext _context;
        private readonly IMapper _mapper;

        public ProductDbRepository(ProductInfoContext ctx, IMapper mapper)
        {
            _context = ctx ?? throw new NotImplementedException(nameof(ctx));
            _mapper = mapper ?? throw new NotImplementedException(nameof(mapper));
        }
        public async Task<IEnumerable<BibitaEntity>> GetBibitaAsync()
        {
           var bibitas = await _context.Bibite.ToListAsync();
            return bibitas;
        }

        public async Task<IEnumerable<PiadinaWithIngredients>> GetPiadinaWithIngredientsAsync()
        {
            var piadinas = await _context.Piadine
                .Include(piadina => piadina.Ingredients) 
                .ToListAsync();

            var piadinasWithIngredients = _mapper.Map<IEnumerable<PiadinaWithIngredients>>(piadinas);

            return piadinasWithIngredients;
        }

        public async Task<IEnumerable<SnackEntity>> GetSnackAsync()
        {
            var Snacks = await _context.Snacks.ToListAsync();
            return Snacks;
        }

        public async Task AddSnackAsync(SnackEntity snack)
        {
            if (snack != null)
            {
                _context.Snacks.Add(snack);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<SnackEntity> GetSnackAsync(int id)
        {
            return await _context.Snacks.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task UpdateSnackAsync(SnackEntity updatedSnack)
        {
            if (updatedSnack != null)
            {
                var existingSnack = await _context.Snacks.FindAsync(updatedSnack.Id);

                if (existingSnack != null)
                {
                    existingSnack.Nome = updatedSnack.Nome;
                    existingSnack.Prezzo = updatedSnack.Prezzo;

                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}
