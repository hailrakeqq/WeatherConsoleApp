namespace weatherConsoleApp
{
    using System.Net;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    public class Option
    {
        Controller controller = new Controller();
        private static string outputStyle = "ugly responce";
        public static void LocalWeather() //weather in your city
        {
            var request = new GetRequest("https://api.open-meteo.com/v1/forecast?latitude=50.4422&longitude=30.5348&hourly=temperature_2m,relativehumidity_2m&current_weather=true&timezone=auto");
            request.Run();
            var responce = request.Responce;
            var json = JObject.Parse(responce);
            var timezone = json["timezone"].ToString();
            var temperature = json["current_weather"]["temperature"];
            var windSpeed = json["current_weather"]["windspeed"];
            var time = json["current_weather"]["time"];
            //Console.WriteLine(json.ToString());
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"timezone: {timezone}");
            Console.WriteLine($"temperature: {temperature} °C");
            Console.WriteLine($"windSpeed: {windSpeed}");
            Console.WriteLine($"time: {time}");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Program.BackToMainMenu();
        }
        public static void FoundWeatherFor()
        {

        }
        public static void CustomRequest() //make your own request
        { }
        public static void Settings()
        {
            Console.WriteLine();
            Console.Write("Choose Option(1 -> beautiful responce, 2 -> ugly responce\n");
            //byte choose = Convert.ToByte(Console.ReadLine());

            // if (choose is Byte && choose == 1 || choose == 2)
            // {
            //     if (choose == 1)
            //     {
            //         Console.WriteLine("you choose: beautiful responce");
            //         set { optionStyle = "beautiful responce"; }
            //     }
            //     else
            //     {
            //         Console.WriteLine("you choose: ugly responce");
            //         set { optionStyle = "ugly responce"; }
            //     }
            // }
            // else Console.WriteLine("You type invalid value");
            Program.BackToMainMenu();
        }
        public static void PrintSettings()
        {
            Console.WriteLine($"{outputStyle}\n");
            Program.BackToMainMenu();
        }
    }
}
