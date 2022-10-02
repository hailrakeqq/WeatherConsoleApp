namespace weatherConsoleApp
{
    using System.Net;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    public class Option
    {
        public static void LocalWeather() //weather in your city
        {
            string timezone = "auto";
            Toolchain.RequestHandler(timezone);
            Program.BackToMainMenu();
        }
        public static void FoundWeatherFor()
        {
            Console.WriteLine();
            Console.Write("Found Weather for (Region City): ");
            try
            {
                string searchData = Console.ReadLine();
                string[] splitResult = searchData.Split();
                string result = (String.Join("%2F", splitResult));

                Toolchain.RequestHandler(result);
                Program.BackToMainMenu();
            }
            catch (System.Exception)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("You input invalid data. Please try again.");
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
            }
        }
    }
}
