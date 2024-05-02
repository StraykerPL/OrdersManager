using OrdersManager.Models.Interfaces;

namespace OrdersManager.Services.Interfaces
{
    public interface IOrderService
    {
        ICollection<IOrder> Orders { get; }

        void DisplayOrders();

        void CheckOrdersStatuses();
    }
}