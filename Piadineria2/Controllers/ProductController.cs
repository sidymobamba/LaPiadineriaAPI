using Piadineria2.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Piadineria2.Repositories;

namespace Piadineria2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductDbRepository _productRepoDb;

        public ProductController(IProductRepository repo, IProductDbRepository productDb)
        {
            _productRepo = repo;
            _productRepoDb = productDb;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllProductsAsync()
        {
            var prodotti =  new
            {
                Snacks = await _productRepoDb.GetSnackAsync(),
                Bibite = await _productRepoDb.GetBibitaAsync(),
                Piadine = await  _productRepoDb.GetPiadinaWithIngredientsAsync(),
            };
            return Ok(prodotti);
        }

        [HttpGet("{categoria}")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductsByCategoria(string categoria)
        {
            switch (categoria.ToLower())
            {
                case "snacks":
                    return Ok(await _productRepoDb.GetSnackAsync());

                case "bibite":
                    return Ok(await _productRepoDb.GetBibitaAsync());

                case "piadine":
                    return Ok(await _productRepoDb.GetPiadinaWithIngredientsAsync());

                default:
                    return BadRequest("Categoria non valida.");
            }
        }

    }
}
