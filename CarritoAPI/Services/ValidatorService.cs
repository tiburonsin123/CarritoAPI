using CarritoAPI.Data;
using CarritoAPI.Models;

namespace CarritoAPI.Services
{
    public class ValidatorService
    {
        public List<string> Validate(CartItem cart, ProductTemplate product)
        {
            var errors = new List<string>();

            // 1. Validar que el producto exista
            if (product == null)
            {
                errors.Add($"El producto con id {cart.ProductId} no existe en el catálogo.");
                return errors;
            }

            // 2. Recorrer cada grupo del catálogo
            foreach (var group in product.GroupAttributes)
            {
                var selection = cart.GroupAttributes
                                    .FirstOrDefault(g => g.GroupAttributeId == group.GroupAttributeId);

                int selectedCount = selection?.Attributes.Count ?? 0;
                int required = group.QuantityInformation.GroupAttributeQuantity;
                string rule = group.QuantityInformation.VerifyValue;

                if (rule == "EQUAL_THAN" && selectedCount != required)
                {
                    errors.Add($"El grupo '{group.GroupAttributeType.Name}' requiere exactamente {required} selección(es).");
                }

                if (rule == "LOWER_EQUAL_THAN" && selectedCount > required)
                {
                    errors.Add($"El grupo '{group.GroupAttributeType.Name}' permite como máximo {required} selección(es).");
                }

                // 3. Validar maxQuantity por atributo
                if (selection != null)
                {
                    foreach (var attr in selection.Attributes)
                    {
                        var original = group.Attributes.FirstOrDefault(a => a.AttributeId == attr.AttributeId);
                        if (original == null)
                        {
                            errors.Add($"El atributo {attr.AttributeId} no existe en el grupo '{group.GroupAttributeType.Name}'.");
                            continue;
                        }

                        if (attr.Quantity > original.MaxQuantity)
                        {
                            errors.Add($"El atributo '{original.Name}' excede la cantidad máxima de {original.MaxQuantity}.");
                        }
                    }
                }
            }

            return errors;
        }
    }
}
