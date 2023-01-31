namespace ShalomCake.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class ListDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    OrderItem item;
}
