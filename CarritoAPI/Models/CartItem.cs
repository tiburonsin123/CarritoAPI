namespace CarritoAPI.Models
{
    public class CartItem
    {
        public Guid CartItemId { get; set; } = Guid.NewGuid();
        public int ProductId { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; } = 1;           // cantidad del producto en el carrito
        public decimal BasePrice { get; set; }           // precio base por unidad
        public List<CartGroupSelection> GroupAttributes { get; set; } = new();
        public decimal TotalPrice { get; set; }          // calculado por el servicio
    }

    public class CartGroupSelection
    {
        public string GroupAttributeId { get; set; } = "";
        public List<CartAttributeSelection> Attributes { get; set; } = new();
    }

    public class CartAttributeSelection
    {
        public int AttributeId { get; set; }
        public int Quantity { get; set; }
    }
}
