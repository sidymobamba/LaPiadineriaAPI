namespace Piadineria2.Controllers
{
    using Piadineria2.Model;
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using Piadineria2.Repositories;
    using Piadineria2.Entities;
    using System.Collections;

    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductDbRepository _productRepoDb;

        public SnacksController(IProductRepository repo, IProductDbRepository productDb)
        {
            _productRepo = repo;
            _productRepoDb = productDb; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snack>>> Get()
        {
            return Ok(await _productRepoDb.GetSnackAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Snack>> GetSnackById(int id)
        {
            var snacks = await _productRepoDb.GetSnackAsync();
            var snack = snacks.FirstOrDefault(s => s.Id == id);
            if (snack == null)
            {
                return NotFound("Prodotto non trovato.");
            }
            return Ok(snack);
        }

        [HttpPost]
        public async Task<IActionResult> PostSnackAsync([FromBody] SnackEntity nuovoSnack)
        {
            if (nuovoSnack == null)
            {
                return BadRequest("the product is not valid.");
            }
            var snacks = await _productRepoDb.GetSnackAsync();
            nuovoSnack.Id = snacks.Count() + 1;
            await _productRepoDb.AddSnackAsync(nuovoSnack);

            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnackAsync(int id, [FromBody] Snack updatedSnack)
        {
            if (updatedSnack == null)
            {
                return NotFound("Prodotto non trovato.");
            }

            var existingSnack = await _productRepoDb.GetSnackAsync(id);

            if (existingSnack == null)
            {
                return NotFound("Snack non trovato.");
            }

            existingSnack.Nome = updatedSnack.Nome;
            existingSnack.Prezzo = updatedSnack.Prezzo;

            await _productRepoDb.UpdateSnackAsync(existingSnack);

            return Ok("Snack aggiornato con successo.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingSnack = await _productRepoDb.GetSnackAsync(id);

            if (existingSnack == null)
            {
                return NotFound("Snack non trovato.");
            }

            // Use the repository method to delete the snack.
            await _productRepoDb.DeleteSnackAsync(existingSnack);

            return Ok("Snack eliminato con successo.");
        }

    }
}
