using System.Text.Json;

namespace CarritoAPI.Data
{
    public class ProductCatalogService
    {
        private readonly ProductTemplate _product;

        public ProductCatalogService(IWebHostEnvironment env)
        {
            var path = Path.Combine(env.ContentRootPath, "Data", "product.json");
            if (!File.Exists(path)) throw new FileNotFoundException("product.json no encontrado", path);

            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _product = JsonSerializer.Deserialize<ProductTemplate>(json, options)
                       ?? throw new InvalidDataException("No se pudo deserializar product.json");
        }

        public ProductTemplate? GetProductById(int id)
           => _product.ProductId == id ? _product : null;
    }
}
