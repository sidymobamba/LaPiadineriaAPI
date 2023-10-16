namespace Piadineria2.Controllers
{
    using Piadineria2.Model;
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using Piadineria2.Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public SnacksController(IProductRepository repo)
        {
            _productRepo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Snack>> Get()
        {
            return Ok(_productRepo.GetAllSnacks());
        }

        [HttpGet("{id}")]
        public ActionResult<Snack> Get(int id)
        {
            var snack = _productRepo.GetAllSnacks().FirstOrDefault(s => s.Id == id);
            if (snack == null)
            {
                return NotFound("Prodotto non trovato.");
            }
            return Ok(snack);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Snack nuovoSnack)
        {
            if (nuovoSnack == null)
            {
                return BadRequest("Il prodotto Snack non è valido.");
            }

            nuovoSnack.Id = _productRepo.GetAllSnacks().Count + 1; 
            _productRepo.GetAllSnacks().Add(nuovoSnack);

            return Ok(nuovoSnack);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Snack snackModificato)
        {
            var snack = _productRepo.GetAllSnacks().FirstOrDefault(s => s.Id == id);
            if (snack == null)
            {
                return NotFound("Prodotto non trovato.");
            }

            snack.Nome = snackModificato.Nome;
            snack.Prezzo = snackModificato.Prezzo;

            return Ok(snack);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var snackDaEliminare = _productRepo.GetAllSnacks().FirstOrDefault(s => s.Id == id);

            if (snackDaEliminare == null)
            {
                return NotFound("Prodotto Snacks non trovato.");
            }

            _productRepo.GetAllSnacks().Remove(snackDaEliminare);
            return Ok(_productRepo.GetAllSnacks()); 
        }

    }
}
