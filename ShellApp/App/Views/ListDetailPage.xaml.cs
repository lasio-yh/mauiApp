namespace ShalomCake.Views;

public partial class ListDetailPage : ContentPage
{
    public ListDetailPage(ListDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
