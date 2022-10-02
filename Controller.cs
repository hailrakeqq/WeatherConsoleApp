namespace weatherConsoleApp
{
    public class Controller
    {
        Option operation = new Option();
        Controller controller = new Controller();

        public static void ChooseOption(string option)
        {
            switch (option)
            {
                case "1":
                    Option.LocalWeather();
                    break;
                case "2":
                    Option.FoundWeatherFor();
                    break;
            }
        }
    }
}