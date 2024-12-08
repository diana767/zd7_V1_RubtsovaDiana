using Rubtsova_7zad_7var.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Rubtsova_7zad_7var.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}