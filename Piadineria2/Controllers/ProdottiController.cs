using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Piadineria2.Repositories;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProdottiController(IProductRepository repo)
        {
            _productRepo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var prodotti = new
            {
                Snacks = _productRepo.GetAllSnacks(),
                Bibite = _productRepo.GetAllBibite(),
                Piadine = _productRepo.GetAllPiadine()
            };
            return Ok(prodotti);
        }

        [HttpGet("{categoria}")]
        public ActionResult<IEnumerable<object>> GetByCategoria(string categoria)
        {
            switch (categoria.ToLower())
            {
                case "snacks":
                    return Ok(_productRepo.GetAllSnacks());

                case "bibite":
                    return Ok(_productRepo.GetAllBibite());

                case "piadine":
                    return Ok(_productRepo.GetAllPiadine());

                default:
                    return BadRequest("Categoria non valida.");
            }
        }

        [HttpGet("{categoria}/{id}")]
        public ActionResult<object> GetById(string categoria, int id)
        {
            IEnumerable<object> listaCategoria = null;
            switch (categoria.ToLower())
            {
                case "snacks":
                    listaCategoria = _productRepo.GetAllSnacks().Cast<object>();
                    break;

                case "bibite":
                    listaCategoria = _productRepo.GetAllBibite().Cast<object>();
                    break;

                case "piadine":
                    listaCategoria = _productRepo.GetAllPiadine().Cast<object>();
                    break;

                default:
                    return BadRequest("Categoria non valida.");
            }

            var prodotto = listaCategoria.FirstOrDefault(p => ((IProdotto)p).Id == id);

            if (prodotto == null)
            {
                return NotFound("Prodotto non trovato.");
            }

            return Ok(prodotto);
        }

    }
}
