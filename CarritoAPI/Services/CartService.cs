using CarritoAPI.Models;

namespace CarritoAPI.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _items = new();
        public IReadOnlyList<CartItem> GetAll() => _items.AsReadOnly();

        public CartItem Add(CartItem item)
        {
            item.CartItemId = Guid.NewGuid();
            _items.Add(item);
            return item;
        }
        public bool Remove(Guid cartItemId)
        {
            var item = _items.FirstOrDefault(i => i.CartItemId == cartItemId);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
        public bool Update(Guid cartItemId, CartItem updatedItem)
        {
            var index = _items.FindIndex(i => i.CartItemId == cartItemId);
            if (index == -1) return false;

            // Mantener el mismo CartItemId
            updatedItem.CartItemId = cartItemId;

            _items[index] = updatedItem;
            return true;
        }

    }
}
