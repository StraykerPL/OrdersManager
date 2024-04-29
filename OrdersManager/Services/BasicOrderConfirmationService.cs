using OrdersManager.Models;
using OrdersManager.Services.Interfaces;

namespace OrdersManager.Services
{
    public class BasicOrderConfirmationService : IOrderService
    {
        public Order Order { get; set; } = new Order();

        public void DisplayOrder()
        {
        }
    }
}