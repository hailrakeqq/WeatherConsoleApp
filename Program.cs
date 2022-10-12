namespace WeatherConsoleApp
{
    class Program
    {
        public static void BackToMainMenu()
        {
            Console.Write("It's all?(Y/n): ");
            string? answer = Console.ReadLine();
            if (answer == "\n" || answer == "y") Main();
        }

        public static void Main()
        {
            string? chooseOption;
            do
            {
                Console.WriteLine("\n\t\t\t\tWelcome to Weather Console App\n\n");
                Console.WriteLine("Choose option(type anything for exit): \n1 -> Weather in your city\n2 -> Found weather for...");

                chooseOption = Console.ReadLine();

                Controller.ChooseOption(chooseOption);
            } while (chooseOption == "1" || chooseOption == "2");
        }
    }
}

