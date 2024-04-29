using OrdersManager.Models;

namespace OrdersManager.Services.Interfaces
{
    public interface IOrderService
    {
        ICollection<Order> Orders { get; }

        void DisplayOrders();

        void CheckOrdersStatuses();
    }
}