using Microsoft.Maui.Controls;
using PokeDiaryMobile;
namespace PokeDiaryMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            // Проверяем доступ к UsernameEntry
            if (UsernameEntry != null)
            {
                string username = UsernameEntry.Text;
                await Navigation.PushAsync(new NewPage1(username));
            }
            else
            {
                // Если UsernameEntry не найден, выводим сообщение об ошибке
                await DisplayAlert("Error", "UsernameEntry is null", "OK");
            }
        }
    }
}
