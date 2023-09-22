using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Upcoming.Models;
using Upcoming.Views;

namespace Upcoming;

public partial class MainPage : ContentPage
{
	public string aptcart = "SuXYuxB9DiGrtLB3avoMz6i6LrfRQihwuE0oLs4x";
	public ObservableCollection<PostCardModel> postcards = new();
    public MainPage()
	{
		InitializeComponent();
        LoadCards();
	}
	public async void LoadCards()
	{
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        HttpResponseMessage response = await client.GetAsync($" https://api.thenewsapi.com/v1/news/all?search=tech&api_token={aptcart}&language=en&limit=10");
        //response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject<dynamic>(content);
        foreach(var data in result.data)
        {
            string title = data.title;
            string description = data.description;
            string url = data.url;
            postcards.Add( new PostCardModel(title, description, url));

        }
        ArticleCollection.ItemsSource = postcards;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var item = sender as Button;
        var obj = item.BindingContext as PostCardModel;
        Uri url = new Uri(obj.SourceURL);
        await Browser.Default.OpenAsync(url);
    }

    private void Search_Clicked(object sender, EventArgs e)
    {

    }

    private void Menu_Clicked(object sender, EventArgs e)
    {

    }
}

