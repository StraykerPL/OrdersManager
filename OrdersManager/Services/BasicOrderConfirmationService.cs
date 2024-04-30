using OrdersManager.Models;
using OrdersManager.Services.Interfaces;
using OrdersManager.UserInterface.Interfaces;
using System.Text.Json;

namespace OrdersManager.Services
{
    public class BasicOrderConfirmationService : IOrderService
    {
        private readonly IOutputProvider _outputProvider;

        public ICollection<Order> Orders { get; } = new List<Order>();

        public BasicOrderConfirmationService(IOutputProvider provider)
        {
            _outputProvider = provider;
        }

        public void DisplayOrders()
        {
            if (Orders.Count < 0)
            {
                _outputProvider.OutputLine("Brak zamówień do wyświetlenia.");

                return;
            }

            foreach (var order in Orders)
            {
                _outputProvider.OutputLine(JsonSerializer.Serialize(order));
            }
        }

        public void CheckOrdersStatuses()
        {
            foreach (var order in Orders)
            {
                if (DateTime.UtcNow > order.OrderDate.ToUniversalTime().AddMinutes(5))
                {
                    order.OrderStatus = OrderStatuses.Sended;
                }
            }
        }
    }
}