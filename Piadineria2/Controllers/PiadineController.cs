﻿using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Piadineria2.Repositories;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiadineController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public PiadineController(IProductRepository repo)
        {
            _productRepo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Piadina>> Get()
        {
            return Ok(_productRepo.GetAllPiadine());
        }

        [HttpGet("{id}")]
        public ActionResult<Piadina> Get(int id)
        {
            var piadina = _productRepo.GetAllPiadine().FirstOrDefault(p => p.Id == id);

            if (piadina == null)
            {
                return NotFound("Piadina non trovata.");
            }

            return Ok(piadina);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Piadina nuovaPiadina)
        {
            if (nuovaPiadina == null)
            {
                return BadRequest("La piadina non è valida.");
            }

            nuovaPiadina.Id = _productRepo.GetAllPiadine().Count + 1;
            _productRepo.GetAllPiadine().Add(nuovaPiadina);
            return Ok(nuovaPiadina);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Piadina piadinaModificata)
        {
            var piadinaEsistente = _productRepo.GetAllPiadine().FirstOrDefault(p => p.Id == id);

            if (piadinaEsistente == null)
            {
                return NotFound("Piadina non trovata.");
            }

            piadinaEsistente.Prezzo = piadinaModificata.Prezzo;
            piadinaEsistente.Forma = piadinaModificata.Forma;

            return Ok(piadinaEsistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var piadinaDaEliminare = _productRepo.GetAllPiadine().FirstOrDefault(p => p.Id == id);

            if (piadinaDaEliminare == null)
            {
                return NotFound("Piadina non trovata.");
            }

            _productRepo.GetAllPiadine().Remove(piadinaDaEliminare);
            return Ok(_productRepo.GetAllPiadine()); 
        }
    }
}
