using OrdersManager.Constants;
using OrdersManager.Models;
using OrdersManager.Services;
using OrdersManager.Services.Interfaces;
using OrdersManager.UserInterface;
using OrdersManager.UserInterface.Interfaces;
using System.Text.Json;

namespace OrdersManager
{
    internal class Program
    {
        private static readonly IOutputProvider _outputProvider = new ConsoleOutputProvider();
        private static readonly IInputProvider _inputProvider = new ConsoleInputProvider();
        private static readonly IBasketService _basketService = new BasicBasketService();
        private static readonly IOrderService _orderService = new BasicOrderConfirmationService(_outputProvider);

        private static void CreateProduct()
        {
            var newProduct = new Product();

            _outputProvider.OutputLine(MessagesConstants.AddProductNameMessage);
            newProduct.Name = _inputProvider.GetInput();
            _outputProvider.OutputLine(MessagesConstants.AddProductDescriptionMessage);
            newProduct.Description = _inputProvider.GetInput();
            _outputProvider.OutputLine(MessagesConstants.AddProductPriceMessage);
            newProduct.Price = Convert.ToDouble(_inputProvider.GetInput());

            _basketService.AddProductToBasket(newProduct);
        }

        private static void DeleteProduct()
        {
            _outputProvider.OutputLine(MessagesConstants.ProvideProductIdMessage);
            var requestedId = _inputProvider.GetInput();

            _basketService.RemoveProductFromBasket(requestedId);
        }

        private static void ShowBasket()
        {
            if (_basketService.Products.Count is 0)
            {
                _outputProvider.OutputLine(MessagesConstants.BasketEmptyMessage);
            }

            foreach (var productInBasket in _basketService.Products)
            {
                _outputProvider.OutputLine(JsonSerializer.Serialize(productInBasket));
            }

            _outputProvider.OutputLine(string.Format(MessagesConstants.BasketValueMessage, _basketService.CalculateBasketValue()));
        }

        private static void MakeOrder()
        {
            var newOrder = new Order();

            _outputProvider.OutputLine(MessagesConstants.ProvideShippingAddressMessage);
            newOrder.OrderingAddress = _inputProvider.GetInput();
            newOrder.FinalizeOrder(_basketService.Products);
            _orderService.Orders.Add(newOrder);
            _basketService.Products.Clear();
        }

        private static void Main()
        {
            _outputProvider.OutputLine(MessagesConstants.WelcomeMessage);

            string userInput;
            while (true)
            {
                _outputProvider.Output(MessagesConstants.OptionsMessage);

                userInput = _inputProvider.GetInput();
                switch (userInput)
                {
                    case "1":
                        CreateProduct();
                        break;

                    case "2":
                        DeleteProduct();
                        break;

                    case "3":
                        ShowBasket();
                        break;

                    case "4":
                        MakeOrder();
                        break;

                    case "5":
                        _orderService.CheckOrdersStatuses();
                        _orderService.DisplayOrders();

                        break;

                    case "6":
                        return;

                    default:
                        _outputProvider.OutputLine(MessagesConstants.WrongImputDataMessage);

                        break;
                }
            }
        }
    }
}