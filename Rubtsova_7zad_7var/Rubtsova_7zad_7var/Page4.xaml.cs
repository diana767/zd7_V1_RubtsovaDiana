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
    public partial class Page4 : CarouselPage
    {
        private bool _isNavigating;

        public Page4()
        {
            InitializeComponent();
            CurrentPageChanged += OnCurrentPageChanged;

            // Пример данных
            var materials = new List<Material>
            {
                new Material { MaterialName = "Доска обрезная", WoodType = "Сосна", Category = "Строительные", Price = 500, Image = "doska.jpg", Manufacturer = "ЛесПром", Description = "Используется для строительства.", PaymentType = "Наличный расчет", RequiresProcessing = "Нет" },
                new Material { MaterialName = "Брус", WoodType = "Дуб", Category = "Отделочные", Price = 1200, Image = "brus.jpg", Manufacturer = "ДревПром", Description = "Используется для отделки.", PaymentType = "Безналичный расчет", RequiresProcessing = "Да" },
                new Material { MaterialName = "Фанера", WoodType = "Береза", Category = "Мебельные", Price = 800, Image = "fanera.jpg", Manufacturer = "ФанераПром", Description = "Используется для мебели.", PaymentType = "Наличный расчет", RequiresProcessing = "Нет" }
            };

            MaterialsCarouselView.ItemsSource = materials;
        }

        private async void OnViewInfoClicked(object sender, EventArgs e)
        {
            var selectedMaterial = (Material)MaterialsCarouselView.CurrentItem;
            await Navigation.PushAsync(new MainPage(selectedMaterial), false); // Передаем выбранный материал в Page2
        }

        private async void OnCalculateCostClicked(object sender, EventArgs e)
        {
            var selectedMaterial = (Material)MaterialsCarouselView.CurrentItem;
            await Navigation.PushModalAsync(new Page3(selectedMaterial), false); // Передаем выбранный материал в Page3
        }
        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            if (_isNavigating)
                return;

            // Проверка логина и пароля
            if (!string.IsNullOrEmpty(usernameEntry.Text) && !string.IsNullOrEmpty(passwordEntry.Text))
            {
                if (usernameEntry.Text == "ects" && passwordEntry.Text == "ects2024")
                {
                    // Логин успешен
                }
                else
                {
                    ShowErrorMessage("Логин - ects, пароль - ects2024.");
                    _isNavigating = true;
                    CurrentPage = Children[0]; // Возвращаем на первую страницу
                    _isNavigating = false;
                }
            }
            else
            {
                ShowErrorMessage("Логин и пароль не должны быть пустыми.");
                _isNavigating = true;
                CurrentPage = Children[0]; // Возвращаем на первую страницу
                _isNavigating = false;
            }
        }

        async void ShowErrorMessage(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", message, "OK");
        }
    }
}