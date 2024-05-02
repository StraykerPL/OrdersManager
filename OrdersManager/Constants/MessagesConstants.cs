namespace OrdersManager.Constants
{
    internal static class MessagesConstants
    {
        public static string WelcomeMessage = "Witamy - OrdersManager";
        public static string OptionsMessage = "\nOpcje działania:\n1. Dodaj produkt do koszyka,\n2. Usuń produkt z koszyka,\n3. Wyświetl stan koszyka,\n4. Zrealizuj zamówienie z koszyka,\n5. Wyświetl zamówienia,\n6. Zakończ program,\n\nProszę wybrać numer: ";
        public static string AddProductNameMessage = "Podaj nazwę produktu:";
        public static string AddProductDescriptionMessage = "Podaj opis produktu:";
        public static string AddProductPriceMessage = "Podaj cenę produktu:";
        public static string ProvideProductIdMessage = "Podaj ID produktu:";
        public static string BasketEmptyMessage = "Koszyk jest pusty.";
        public static string BasketValueMessage = "Wartość koszyka: {0}";
        public static string ProvideShippingAddressMessage = "Podaj adres dostawy:";
        public static string WrongImputDataMessage = "Błędne dane wejściowe.";
        public static string NoOrdersToDisplayMessage = "Brak zamówień do wyświetlenia.";
        public static string NoDataProvidedForProductMessage = "Błąd: nazwa lub opis produktu są puste.";
        public static string NoIdProvidedMessage = "Błąd: nie podano ID.";
        public static string NoDeliveryAddressProvidedMessage = "Błąd: nie podano adresu dostawy.";
        public static string NoProductsInBasketForOrderingMessage = "Błąd: nie można utworzyć zamówienia z pustym koszykiem.";
        public static string DoubleConvertionErrorMessage = "Błąd: podaj prawidłową liczbę z przecinkiem.";
    }
}