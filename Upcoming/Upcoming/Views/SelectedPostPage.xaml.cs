namespace Upcoming.Views;

public partial class SelectedPostPage : ContentPage
{
	public SelectedPostPage(string url)
	{
		InitializeComponent();
		ViewArticle.Source = url;
	}
}