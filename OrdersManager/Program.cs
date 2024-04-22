namespace OrdersManager
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Witamy - OrdersManager\n");
            Console.WriteLine("Opcje działania:");
            Console.WriteLine("1. Dodaj produkt do koszyka,");
            Console.WriteLine("2. Usuń produkt z koszyka,");
            Console.WriteLine("3. Wyświetl stan koszyka,");
            Console.WriteLine("4. Zrealizuj zamówienie z koszyka,");
            Console.WriteLine("5. Zakończ program,\n");
            Console.Write("Proszę wybrać numer: ");

            string userInput = Console.ReadLine() ?? string.Empty;

            while (Convert.ToChar(userInput) != '5') { }
        }
    }
}