namespace ShalomCake.Views;

public partial class ListPage : ContentPage
{
    ListViewModel ViewModel;

    public ListPage(ListViewModel viewModel)
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
