using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Piadineria2.Repositories;
using Piadineria2.Entities;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibiteController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductDbRepository _productRepoDb;

        public BibiteController(IProductRepository repo, IProductDbRepository productDb)
        {
            _productRepo = repo;
            _productRepoDb = productDb;
        }
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<BibitaEntity>>> GetBibtaAsync()
        {
            return Ok(await _productRepoDb.GetBibitaAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bibita>> GetBibitaByIdAsync(int id)
        {
            var bibitas = await _productRepoDb.GetBibitaAsync();
            var bibita = bibitas.FirstOrDefault(b => b.Id == id);

            if (bibita == null)
            {
                return NotFound("Prodotto Bibita non trovato.");
            }

            return Ok(bibita);
        }

        [HttpPost]
        public async Task<IActionResult> PostBibitaAsync([FromBody] BibitaEntity newBibita)
        {
            if ( newBibita == null)
            {
                return BadRequest("the product is not valid.");
            }
            var bibitas = await _productRepoDb.GetBibitaAsync();
            newBibita.Id = bibitas.Count() + 1;
            await _productRepoDb.AddBibitaAsync(newBibita);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibibaAsync(int id, [FromBody] Bibita updatedBibita)
        {
            if (updatedBibita == null)
            {
                return NotFound("Prodotto non trovato.");
            }

            var existingBibita = await _productRepoDb.GetBibitaAsync(id);

            if (existingBibita == null)
            {
                return NotFound("Snack non trovato.");
            }

            existingBibita.Nome = updatedBibita.Nome;
            existingBibita.Prezzo = updatedBibita.Prezzo;

            await _productRepoDb.UpdateBibitaAsync(existingBibita);

            return Ok("Snack aggiornato con successo.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibitaAsync(int id)
        {
            var existingBibita = await _productRepoDb.GetBibitaAsync(id);

            if (existingBibita == null)
            {
                return NotFound("Snack non trovato.");
            }


            await _productRepoDb.DeleteBibitaAsync(existingBibita);

            return Ok("Snack eliminato con successo.");
        }
    }
}
