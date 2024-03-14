using System.Net;
using Microsoft.Maui.Controls;

namespace PokeDiaryMobile
{
    public partial class NewPage1 : ContentPage
    {
        string usernamek;
        public NewPage1(string username)
        {
            InitializeComponent();
            usernamek = username;
            UsernameLabel.Text = "Username: " + username;
        }

        async void OnFindClicked(object sender, EventArgs e)
        {
            string pokemonName = PokeNameEntry.Text.ToLower();
            pokemonName = pokemonName.ToLower();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pokeapi.co/api/v2/pokemon/" + pokemonName);

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
                await Navigation.PushAsync(new PokeInfo(usernamek, pokemonName));
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    await DisplayAlert("Oops", "This pokemon doesn't exist", "OK");
                }
            };
        }
    }
}
