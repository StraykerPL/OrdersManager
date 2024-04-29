using OrdersManager.Models;

namespace OrdersManager.Services.Interfaces
{
    public interface IBasketService
    {
        ICollection<Product> Products { get; }

        void AddProductToBasket(Product productToAdd);

        void RemoveProductFromBasket(string productId);

        double CalculateBasketValue();
    }
}