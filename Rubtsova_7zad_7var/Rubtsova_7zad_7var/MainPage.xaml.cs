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
    public partial class MainPage : ContentPage
    {
        private Material _selectedMaterial;

        public MainPage()
        {
            InitializeComponent();
        }


        public MainPage(Material selectedMaterial)
        {
            InitializeComponent();
            _selectedMaterial = selectedMaterial; // Сохраняем выбранный материал
            // Создаем список с одним элементом для отображения информации о выбранном материале
            var materials = new List<Material> { _selectedMaterial };
            MaterialsCollectionView.ItemsSource = materials; // Привязываем данные к CollectionView
        }

        private async void OnCalculateCostClicked(object sender, EventArgs e)
        {
            // Переход на Page3 с выбранным материалом
            await Navigation.PushModalAsync(new Page3(_selectedMaterial), false);
        }
        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}