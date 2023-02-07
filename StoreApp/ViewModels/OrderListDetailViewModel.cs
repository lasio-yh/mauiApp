namespace StoreApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class OrderListDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    OrderItem item;

    public OrderListDetailViewModel()
    {

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
