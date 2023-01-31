namespace ShalomCake;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ListDetailPage), typeof(ListDetailPage));
	}
}
