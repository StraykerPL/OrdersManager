using OrdersManager.Models;
using OrdersManager.Services.Interfaces;

namespace OrdersManager.Services
{
    public class BasicBasketService : IBasketService
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public void AddProductToBasket(Product productToAdd)
        {
        }

        public void RemoveProductFromBasket(int productId)
        {
        }

        public double CalculateBasketValue()
        {
            return 0.0;
        }
    }
}