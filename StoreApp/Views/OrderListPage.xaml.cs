namespace StoreApp.Views;

public partial class OrderListPage : ContentPage
{
    OrderListViewModel ViewModel;

    public OrderListPage(OrderListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        this.Title = AppResources.OrderTitle;
        await ViewModel.LoadDataAsync();
    }
}
