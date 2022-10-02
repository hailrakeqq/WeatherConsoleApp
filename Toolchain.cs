using System;
namespace weatherConsoleApp
{
    using System.Net;
    using Newtonsoft.Json.Linq;
    public class Toolchain
    {
        public static void RequestHandler(string Timezone)
        {
            var request = new GetRequest($"https://api.open-meteo.com/v1/forecast?latitude=50.4422&longitude=30.5348&hourly=temperature_2m,relativehumidity_2m,rain&daily=weathercode,sunrise,sunset&current_weather=true&timezone={Timezone}");
            request.Run();
            var responce = request.Responce;
            var json = JObject.Parse(responce);
            var timezone = json["timezone"].ToString();
            var temperature = json["current_weather"]["temperature"];
            var windSpeed = json["current_weather"]["windspeed"];
            var sunrise = json["daily"]["sunrise"][0].ToString();
            var sunset = json["daily"]["sunset"][0].ToString();
            // var precipitation = json["hourly"]["precipitation"].ToString();
            // var relativehumidity = json["hourly"]["relativehumidity_2m"].ToString();
            var time = json["current_weather"]["time"];

            string[] sunriseTime = ParseTime(sunrise);
            string[] sunsetTime = ParseTime(sunset);

            // double precipitationMedium = GetMediumValue(precipitation);
            // double relativehumidityMedium = GetMediumValue(relativehumidity);

            Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"Timezone: {timezone}");
            Console.WriteLine($"Temperature: {temperature} °C");
            Console.WriteLine($"Wind speed: {windSpeed} km/h");
            Console.WriteLine($"Sunrise: {sunriseTime[1]} | Sunset: {sunsetTime[1]}");
            // Console.WriteLine($"Precipitation: {precipitationMedium} mm");
            // Console.WriteLine($"Relativehumidity: {relativehumidityMedium} %");
            Console.WriteLine($"Time: {time}");
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------");
        }
        public static double GetMediumValue(string Array)
        {
            double[] array = new double[Array.Length];

            for (int x = 0; x < Array.Length; x++)
                array[x] = Convert.ToDouble(Array[x]);

            double sumArray = 0;
            for (int i = 0; i < array.Length; i++)
                sumArray += array[i];

            return sumArray / array.Length;
        }
        public static string[] ParseTime(string time) => time.Split("T"); // Split Time For example: 2022-10-02T14:00 to 14:00
    }
    public class GetRequest
    {
        HttpWebRequest _request;
        string _address;
        public string Responce { get; set; }

        public GetRequest(string address) { _address = address; }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Responce = new StreamReader(stream).ReadToEnd();
            }
            catch (System.Exception)
            {
            }
        }
    }
}