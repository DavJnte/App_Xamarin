using Xamarin.Forms;
using XamSQLite.Views;

namespace GSB
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new ProductPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
