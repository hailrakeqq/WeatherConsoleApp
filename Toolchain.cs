using System;
namespace WeatherConsoleApp
{
    using System.Net;
    using Newtonsoft.Json.Linq;
    public class Toolchain
    {
        public static void RequestHandler(string Timezone)
        {
            var request = new GetRequest($"https://api.open-meteo.com/v1/forecast?latitude=50.4422&longitude=30.5348&hourly=temperature_2m,relativehumidity_2m,precipitation&daily=sunrise,sunset&current_weather=true&timezone={Timezone}");
            request.Run();
            var responce = request.Responce;
            var json = JObject.Parse(responce);
            var timezone = json["timezone"]?.ToString();
            var temperature = json["current_weather"]?["temperature"];
            var windSpeed = json["current_weather"]?["windspeed"];
            var sunrise = json["daily"]?["sunrise"]?[0]?.ToString();
            var sunset = json["daily"]?["sunset"]?[0]?.ToString();
            var precipitation = json["hourly"]?["precipitation"]?.Last();
            var relativehumidity = json["hourly"]?["relativehumidity_2m"]?.Last();
            var time = json["current_weather"]?["time"];

            Console.WriteLine(precipitation);

            string[] sunriseTime = ParseTime(sunrise);
            string[] sunsetTime = ParseTime(sunset);

            Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"Timezone: {timezone}");
            Console.WriteLine($"Temperature: {temperature} °C");
            Console.WriteLine($"Wind speed: {windSpeed} km/h");
            Console.WriteLine($"Sunrise: {sunriseTime[1]} | Sunset: {sunsetTime[1]}");
            Console.WriteLine($"Precipitation: {precipitation} mm");
            Console.WriteLine($"Relativehumidity: {relativehumidity} %");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------");
        }
        public static void TestJson()
        {
            var request = new GetRequest($"https://api.open-meteo.com/v1/forecast?latitude=50.4422&longitude=30.5348&hourly=temperature_2m,relativehumidity_2m,precipitation&daily=sunrise,sunset&current_weather=true&timezone=auto");
            request.Run();
            var responce = request.Responce;
            var json = JObject.Parse(responce);
            //Console.WriteLine(json["hourly"]["relativehumidity_2m"]);
            var relativehumidityArray = json["hourly"]?["relativehumidity_2m"]?.Last();
            Console.WriteLine(relativehumidityArray);
        }
        public static double GetMediumValue(double[] array)
        {
            double sumArray = 0;
            for (int i = 0; i < array.Length; i++)
                sumArray += array[i];

            return sumArray / array.Length;
        }
        public static string[] ParseTime(string time) => time.Split("T"); // Split Time For example: 2022-10-02T14:00 to 14:00
    }
}
