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

            outputProvider.OutputLine("Witamy - OrdersManager");

            string userInput = "a";
            while (Convert.ToChar(userInput) != '5')
            {
                outputProvider.OutputLine("\nOpcje działania:");
                outputProvider.OutputLine("1. Dodaj produkt do koszyka,");
                outputProvider.OutputLine("2. Usuń produkt z koszyka,");
                outputProvider.OutputLine("3. Wyświetl stan koszyka,");
                outputProvider.OutputLine("4. Zrealizuj zamówienie z koszyka,");
                outputProvider.OutputLine("5. Zakończ program,\n");
                outputProvider.Output("Proszę wybrać numer: ");

                userInput = inputProvider.GetInput();

                switch (userInput)
                {
                    case "1":
                        var newProduct = new Product();

                        outputProvider.OutputLine("Podaj nazwę produktu:");
                        newProduct.Name = inputProvider.GetInput();
                        outputProvider.OutputLine("Podaj opis produktu:");
                        newProduct.Description = inputProvider.GetInput();
                        outputProvider.OutputLine("Podaj cenę produktu:");
                        newProduct.Price = Convert.ToDouble(inputProvider.GetInput());

                        basketService.AddProductToBasket(newProduct);
                        break;

                    case "2":

                        break;

                    case "3":
                        if (basketService.Products.Count is 0)
                        {
                            outputProvider.OutputLine("Koszyk jest pusty.");
                        }

                        foreach (var productInBasket in basketService.Products)
                        {
                            outputProvider.OutputLine(JsonSerializer.Serialize(productInBasket));
                        }

                        break;

                    case "4":

                        break;

                    default:
                        break;
                }
            }
        }
    }
}