namespace ShalomCake;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(OrderListPage), typeof(OrderListPage));
        Routing.RegisterRoute(nameof(OrderListDetailPage), typeof(OrderListDetailPage));
	}
}