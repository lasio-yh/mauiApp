namespace ShalomCake.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class OrderListDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    OrderItem item;
}
