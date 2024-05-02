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
        private static void Main()
        {
            IOutputProvider outputProvider = new ConsoleOutputProvider();
            IInputProvider inputProvider = new ConsoleInputProvider();
            IBasketService basketService = new BasicBasketService();
            IOrderService orderService = new BasicOrderConfirmationService(outputProvider);

            outputProvider.OutputLine(MessagesConstants.WelcomeMessage);

            string userInput = "a";
            while (Convert.ToChar(userInput) != '6')
            {
                outputProvider.Output(MessagesConstants.OptionsMessage);

                userInput = inputProvider.GetInput();

                switch (userInput)
                {
                    case "1":
                        var newProduct = new Product();

                        outputProvider.OutputLine(MessagesConstants.AddProductNameMessage);
                        newProduct.Name = inputProvider.GetInput();
                        outputProvider.OutputLine(MessagesConstants.AddProductDescriptionMessage);
                        newProduct.Description = inputProvider.GetInput();
                        outputProvider.OutputLine(MessagesConstants.AddProductPriceMessage);
                        newProduct.Price = Convert.ToDouble(inputProvider.GetInput());

                        basketService.AddProductToBasket(newProduct);

                        break;

                    case "2":
                        outputProvider.OutputLine(MessagesConstants.ProvideProductIdMessage);
                        var requestedId = inputProvider.GetInput();

                        basketService.RemoveProductFromBasket(requestedId);

                        break;

                    case "3":
                        if (basketService.Products.Count is 0)
                        {
                            outputProvider.OutputLine(MessagesConstants.BasketEmptyMessage);
                        }

                        foreach (var productInBasket in basketService.Products)
                        {
                            outputProvider.OutputLine(JsonSerializer.Serialize(productInBasket));
                        }

                        outputProvider.OutputLine(string.Format(MessagesConstants.BasketValueMessage, basketService.CalculateBasketValue()));

                        break;

                    case "4":
                        var newOrder = new Order();

                        outputProvider.OutputLine(MessagesConstants.ProvideShippingAddressMessage);
                        newOrder.OrderingAddress = inputProvider.GetInput();
                        newOrder.FinalizeOrder(basketService.Products);
                        orderService.Orders.Add(newOrder);
                        basketService.Products.Clear();

                        break;

                    case "5":
                        orderService.CheckOrdersStatuses();
                        orderService.DisplayOrders();

                        break;

                    case "6":
                        return;

                    default:
                        outputProvider.OutputLine(MessagesConstants.WrongImputDataMessage);

                        break;
                }
            }
        }
    }
}