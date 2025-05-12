using MauiAppPrevisaoTempo.Helpers;
using System.IO;

namespace MauiAppPrevisaoTempo
{
    public partial class App : Application
    {
        static WeatherDatabaseHelper _weatherDatabase;

        public static WeatherDatabaseHelper WeatherDatabase
        {
            get
            {
                if (_weatherDatabase == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "weather_history.db3");

                    _weatherDatabase = new WeatherDatabaseHelper(path);
                }
                return _weatherDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            // Set the main page to a weather page or shell navigation
            MainPage = new NavigationPage(new MainPage());
        }
    }
}