namespace OrderProject.Views;

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
        await ViewModel.LoadDataAsync();
    }
}
