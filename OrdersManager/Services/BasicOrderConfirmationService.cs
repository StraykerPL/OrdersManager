using OrdersManager.Constants;
using OrdersManager.Models;
using OrdersManager.Models.Interfaces;
using OrdersManager.Services.Interfaces;
using OrdersManager.UserInterface.Interfaces;
using System.Text.Json;

namespace OrdersManager.Services
{
    public sealed class BasicOrderConfirmationService : IOrderService
    {
        private readonly IOutputProvider _outputProvider;

        public ICollection<IOrder> Orders { get; } = [];

        public BasicOrderConfirmationService(IOutputProvider provider)
        {
            _outputProvider = provider;
        }

        public void DisplayOrders()
        {
            if (Orders.Count is 0)
            {
                _outputProvider.OutputLine(MessagesConstants.NoOrdersToDisplayMessage);

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