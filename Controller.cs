namespace weatherConsoleApp
{
    public class Controller
    {
        Option operation = new Option();
        Controller controller = new Controller();

        public static void ChooseOption(byte option)
        {
            switch (option)
            {
                case 1:
                    Option.LocalWeather();
                    break;
                case 2:
                    Option.FoundWeatherFor();
                    break;
                case 3:
                    Option.CustomRequest();
                    break;
                case 4:
                    Option.Settings();
                    break;
                case 5:
                    Option.PrintSettings();
                    break;
            }
        }
    }
}