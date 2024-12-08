using Rubtsova_7zad_7var.ViewModels;
using Rubtsova_7zad_7var.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Rubtsova_7zad_7var
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
