using CarritoAPI.Data;
using CarritoAPI.Models;
using CarritoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarritoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET api/cart
        [HttpGet]
        public IActionResult GetCart()
        {
            var items = _cartService.GetAll();
            return Ok(items);
        }
        // POST api/cart
        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem item, [FromServices] ProductCatalogService catalog, [FromServices] ValidatorService validator)
        {
            // 1. Buscar el producto en el catálogo
            var product = catalog.GetProductById(item.ProductId);

            // 2. Validar reglas
            var errors = validator.Validate(item, product);

            if (errors.Any())
                return BadRequest(new { Errors = errors });

            // 3. Si pasa validaciones, agregar al carrito
            var added = _cartService.Add(item);
            return Ok(added);
        }

        [HttpDelete("{cartItemId}")]
        public IActionResult RemoveFromCart(Guid cartItemId)
        {
            var removed = _cartService.Remove(cartItemId);
            if (!removed)
                return NotFound(new { message = "Item no encontrado en el carrito" });

            return Ok(new { message = "Item eliminado del carrito" });
        }

        [HttpPut("{cartItemId}")]
        public IActionResult UpdateCartItem(Guid cartItemId,
                                            [FromBody] CartItem updatedItem,
                                            [FromServices] ProductCatalogService catalog,
                                            [FromServices] ValidatorService validator)
        {
            var product = catalog.GetProductById(updatedItem.ProductId);
            var errors = validator.Validate(updatedItem, product);

            if (errors.Any())
                return BadRequest(new { Errors = errors });

            var updated = _cartService.Update(cartItemId, updatedItem);
            if (!updated)
                return NotFound(new { message = "Item no encontrado en el carrito" });

            return Ok(updatedItem);
        }



    }
}
