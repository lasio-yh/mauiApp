namespace OrderProject.Views;

public partial class ManagePage : ContentPage
{
	public ManagePage(ManageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
