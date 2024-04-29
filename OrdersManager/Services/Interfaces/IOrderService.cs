using OrdersManager.Models;

namespace OrdersManager.Services.Interfaces
{
    public interface IOrderService
    {
        Order Order { get; }

        void DisplayOrder();
    }
}