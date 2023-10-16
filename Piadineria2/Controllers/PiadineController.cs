using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Piadineria2.Repositories;
using Piadineria2.Entities;
using Piadineria2.Dto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiadineController : ControllerBase
    {
        private readonly IProductDbRepository _productRepoDb;
        private readonly IMapper _mapper;

        public PiadineController(IProductDbRepository repoDb, IMapper mapper)
        {
            _productRepoDb = repoDb;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PiadinaEntity>>> GetPiadina()
        {
            return Ok(await _productRepoDb.GetPiadinaWithIngredientsAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PiadinaEntity>> GetPiadinaById(int id)
        {
            var piadinas = await _productRepoDb.GetPiadinaWithIngredientsAsync();
            var piadina = piadinas.FirstOrDefault(p => p.Id == id);

            if (piadina == null)
            {
                return NotFound("Piadina non trovata.");
            }

            return Ok(piadina);
        }

       [HttpPost] // Todo
       
        [HttpPut("{id}")] // Todo
  

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiadinaAsync(int id)
        {
            try
            {
                var existingPiadina = await _productRepoDb.GetPiadinaAsync(id);

                if (existingPiadina == null)
                {
                    return NotFound("Piadina non trovata.");
                }
                await _productRepoDb.DeletePiadinaAsync(existingPiadina);

                return Ok("Piadina eliminata con successo.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Si è verificato un errore durante l'eliminazione della piadina.");
            }
        }

    }
}

