using Academia.Store.Domain.BaseEntity;

namespace Academia.Store.Domain.Contexts.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            if (product.StockQuantity < quantity)
            {
                AddNotification("Quantity", "Product out of stock");
            }
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
