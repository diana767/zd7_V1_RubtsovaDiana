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
    public partial class Page3 : ContentPage
    {
        private Material _selectedMaterial;

        public Page3(Material selectedMaterial)
        {
            InitializeComponent();
            _selectedMaterial = selectedMaterial; // Сохраняем выбранный материал
        }

        private async void OnCalculateCostClicked(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, заполнены ли поля
                if (string.IsNullOrWhiteSpace(MetersEntry.Text) || string.IsNullOrWhiteSpace(DaysEntry.Text))
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                    return;
                }

                int days = int.Parse(DaysEntry.Text);
                int meters = int.Parse(MetersEntry.Text);
                string paymentType = PaymentTypePicker.SelectedItem?.ToString();

                if (paymentType == null)
                {
                    await DisplayAlert("Ошибка", "Пожалуйста, выберите способ оплаты.", "OK");
                    return;
                }

                double basePrice = _selectedMaterial.Price; // Используем цену выбранного материала
                double discount = 0;

                // Логика расчета скидки
                if (days >= 20 && days <= 30)
                    discount = -0.05;
                else if (days >= 10 && days <= 18)
                    discount = 0.10;
                else if (days >= 1 && days <= 5)
                    discount = 0.25;

                double paymentAdjustment = paymentType == "Наличный расчет" ? -0.10 : 0.10;
                double finalPrice = basePrice * (1 + discount + paymentAdjustment) * meters;

                await DisplayAlert("Рассчитанная стоимость", $"Итоговая стоимость: {finalPrice}", "OK");
            }
            catch (FormatException)
            {
                await DisplayAlert("Ошибка", "Пожалуйста, введите корректные числовые значения.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
            }
        }
        private async void OnBackToRootClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(false); // Возвращаемся на корневую страницу
        }

        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(false); // Возвращаемся на главную страницу
        }
    }
}
