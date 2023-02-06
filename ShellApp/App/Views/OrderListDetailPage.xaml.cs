namespace ShalomCake.Views;

public partial class OrderListDetailPage : ContentPage
{
    public OrderListDetailPage(OrderListDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
