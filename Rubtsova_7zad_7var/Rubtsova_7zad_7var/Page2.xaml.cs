using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rubtsova_7zad_7var
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private Material _selectedMaterial;

        public Page2(Material selectedMaterial)
        {
            InitializeComponent();
            _selectedMaterial = selectedMaterial;
            BindingContext = _selectedMaterial; // Привязываем данные к интерфейсу
        }

        private async void OnViewMaterialInfoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_selectedMaterial), false);
        }

        private async void OnCalculateMaterialCostClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Page3(_selectedMaterial), false);
        }
    }
}