using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Http;

namespace PokeDiaryMobile;

public partial class PokeInfo : ContentPage
{
    string pokName;

    public PokeInfo(string username, string pokename)
    {
        InitializeComponent();
        pokName = pokename;
    }


    private async void PageAppearing(object sender, EventArgs e)
    {
        


        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/" + pokName.ToLower());

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();

            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);

            this.PokeNameLabel.Text += d.name;

            foreach (var type in d.types)
            {
                PokeTypeLabel.Text += " " + type.type.name + ",";
            }
            PokeTypeLabel.Text = PokeTypeLabel.Text.TrimEnd(',');

            foreach (var ability in d.abilities)
            {
                PokeAblLabel.Text += ability.ability.name + ",";
            }
            PokeAblLabel.Text = PokeAblLabel.Text.TrimEnd(',');

            // Stats
            PokeHPLabel.Text += d.stats[0].base_stat;
            PokeAtkLabel.Text += d.stats[1].base_stat;
            PokeDefLabel.Text += d.stats[2].base_stat;
            PokeSpdLabel.Text += d.stats[5].base_stat;
        }

    }
}



