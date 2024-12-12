using Microsoft.Maui.Controls;

namespace Boxing_Trainer_App
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new AppShell());
        }
    }
}