﻿using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Piadineria2.Repositories;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibiteController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public BibiteController(IProductRepository repo)
        {
            _productRepo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Bibita>> Get()
        {
            return Ok(_productRepo.GetAllBibite());
        }

        [HttpGet("{id}")]
        public ActionResult<Bibita> Get(int id)
        {
            var bibita = _productRepo.GetAllBibite().FirstOrDefault(b => b.Id == id);

            if (bibita == null)
            {
                return NotFound("Prodotto Bibita non trovato.");
            }

            return Ok(bibita);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Bibita nuovaBibita)
        {
            if (nuovaBibita == null)
            {
                return BadRequest("Il prodotto Bibita non è valido.");
            }

            nuovaBibita.Id = _productRepo.GetAllBibite().Count + 1; 
            _productRepo.GetAllBibite().Add(nuovaBibita);
            return Ok(nuovaBibita);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bibita bibitaModificata)
        {
            var bibitaEsistente = _productRepo.GetAllBibite().FirstOrDefault(b => b.Id == id);

            if (bibitaEsistente == null)
            {
                return NotFound("Prodotto Bibita non trovato.");
            }

            bibitaEsistente.Nome = bibitaModificata.Nome;
            bibitaEsistente.Prezzo = bibitaModificata.Prezzo;

            return Ok(bibitaEsistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bibitaDaEliminare = _productRepo.GetAllBibite().FirstOrDefault(b => b.Id == id);

            if (bibitaDaEliminare == null)
            {
                return NotFound("Prodotto Bibita non trovato.");
            }

            _productRepo.GetAllBibite().Remove(bibitaDaEliminare);
            return Ok(_productRepo.GetAllBibite());
        }
    }
}
