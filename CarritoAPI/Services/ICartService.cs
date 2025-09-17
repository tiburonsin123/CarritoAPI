using CarritoAPI.Models;

namespace CarritoAPI.Services
{
    public interface ICartService
    {
        IReadOnlyList<CartItem> GetAll();   // Obtener todos los items
        CartItem Add(CartItem item);        // Agregar un item al carrito
        bool Remove(Guid cartItemId);
        bool Update(Guid cartItemId, CartItem updatedItem);
        

    }
}


