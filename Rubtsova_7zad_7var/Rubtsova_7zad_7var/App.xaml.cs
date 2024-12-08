using Rubtsova_7zad_7var.Services;
using Rubtsova_7zad_7var.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rubtsova_7zad_7var
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Page4());
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
