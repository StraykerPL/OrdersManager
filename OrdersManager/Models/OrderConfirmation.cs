using OrdersManager.Models.Interfaces;
using OrdersManager.Providers;
using OrdersManager.UserInterface.Interfaces;
using System.Text.Json;

namespace OrdersManager.Models
{
    internal class OrderConfirmation : IOrderConfirmation
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public IOrder AssignedOrder { get; private set; }

        private readonly IOutputProvider _outputProvider;

        public OrderConfirmation(
            IOrder assignedOrder,
            IOutputProvider outputProvider)
        {
            AssignedOrder = assignedOrder;
            _outputProvider = outputProvider;
        }

        public void DisplayConfirmationInfo()
        {
            _outputProvider.Output(JsonSerializer.Serialize(AssignedOrder, JsonSerializerOptionsProvider.GetOptionsObject()));
        }
    }
}