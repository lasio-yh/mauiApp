namespace ShalomCake.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class OrderListDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    OrderItem item;

    [ObservableProperty]
    public string source;

    public OrderListDetailViewModel()
    {
        // TODO: Update the default URL
        Source = "https://www.naver.com";
    }

    [RelayCommand]
    private async void WebViewNavigated(WebNavigatedEventArgs e)
    {
        if (e.Result != WebNavigationResult.Success)
        {
            // TODO: handle failed navigation in an appropriate way
            await Shell.Current.DisplayAlert("Navigation failed", e.Result.ToString(), "OK");
        }
    }

    [RelayCommand]
    private async void Ok()
    {
        await Shell.Current.GoToAsync("../");
    }

    [RelayCommand]
    private async void Refuse()
    {
        await Shell.Current.GoToAsync("../");
    }
}
