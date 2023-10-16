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

        // Products
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

        // Snacks
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

        public async Task DeleteSnackAsync(SnackEntity snack)
        {
            if (snack != null)
            {
                _context.Snacks.Remove(snack);
                await _context.SaveChangesAsync();
            }
        }

        // Bibite
        public async Task AddBibitaAsync(BibitaEntity bibita)
        {
            if (bibita != null)
            {
                _context.Bibite.Add(bibita);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BibitaEntity> GetBibitaAsync(int id)
        {
            return await _context.Bibite.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateBibitaAsync(BibitaEntity updatedBibita)
        {
            if (updatedBibita != null)
            {
                var existingBibita = await _context.Bibite.FindAsync(updatedBibita.Id);

                if (existingBibita != null)
                {
                    existingBibita.Nome = updatedBibita.Nome;
                    existingBibita.Prezzo = updatedBibita.Prezzo;

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteBibitaAsync(BibitaEntity bibita)
        {
            if (bibita != null)
            {
                _context.Bibite.Remove(bibita);
                await _context.SaveChangesAsync();
            }
        }

        // Piadine
        public async Task<PiadinaWithIngredients> AddPiadinaAsync(PiadinaEntity piadina)
        {
            try
            {
                // Map PiadinaWithIngredients to PiadinaEntity

                // Add the PiadinaEntity to the context
                _context.Piadine.Add(piadina);

                await _context.SaveChangesAsync();

                // Map the created PiadinaEntity back to PiadinaWithIngredients
                var createdPiadina = _mapper.Map<PiadinaWithIngredients>(piadina);

                return createdPiadina;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<PiadinaEntity> GetPiadinaAsync(int id)
        {
            return await _context.Piadine.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePiadinaAsync(PiadinaEntity updatedPiadina)
        {
            if (updatedPiadina != null)
            {
                var existingPiadina = await _context.Piadine.FindAsync(updatedPiadina.Id);

                if (existingPiadina != null)
                {
                    existingPiadina.Nome = updatedPiadina.Nome;
                    existingPiadina.Prezzo = updatedPiadina.Prezzo;
                    existingPiadina.Forma = updatedPiadina.Forma;

                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task DeletePiadinaAsync(PiadinaEntity piadina)
        {
            if (piadina != null)
            {
                _context.Piadine.Remove(piadina);

                await _context.SaveChangesAsync();
            }
        }

    }
}
