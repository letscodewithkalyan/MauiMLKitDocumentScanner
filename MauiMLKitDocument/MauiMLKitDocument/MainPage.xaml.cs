namespace MauiMLKitDocument;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        var service = Handler.MauiContext.Services.GetService<IDocumentScannerService>();
        var image = await service.OpenDocumentScannerAsync();
        if (image != null)
        {
            BindableLayout.SetItemsSource(ImagesLayout, image.Images);
        }
    }
}


