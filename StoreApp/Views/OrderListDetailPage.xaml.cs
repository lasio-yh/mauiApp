namespace StoreApp.Views;

public partial class OrderListDetailPage : ContentPage
{
    public OrderListDetailPage(OrderListDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        this.Title = AppResources.OrderInfoTitle;
    }
}
