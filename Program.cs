namespace weatherConsoleApp
{
    class Program
    {

        public static void Begin()
        {
            byte chooseOption;
            do
            {
                Console.WriteLine("\t\t\t\tWelcome to Weather Console App");
                Console.WriteLine("Choose option(type 10 or press Ctrl^C for exit): \n1 -> Weather in your city\n2 -> found weather for...\n3 -> custom request\n4 -> settings\n5 -> print settings");

                chooseOption = Convert.ToByte(Console.ReadLine());

                Controller.ChooseOption(chooseOption);
            } while (chooseOption != 10);
        }
        public static void BackToMainMenu()
        {
            Console.Write("It's all?(Y/n)");
            string answer = Console.ReadLine();
            if (answer == "\n" || answer == "y") Begin();
        }

        public static void Main()
        {
            Begin();
        }
    }
}

