using CarritoAPI.Data;
using Microsoft.AspNetCore.Mvc;


namespace CarritoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController:ControllerBase
    {
        private readonly ProductCatalogService _catalog;

        public TestController(ProductCatalogService catalog)
        {
            _catalog = catalog;
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _catalog.GetProductById(id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }
    }
}

