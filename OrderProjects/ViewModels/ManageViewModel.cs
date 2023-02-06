namespace OrderProject.ViewModels;

public partial class ManageViewModel : BaseViewModel
{
    public string Id { get; set; } = $"ST000000";
    public string StoreNo { get; set; } = $"000000000";
    public string Owner { get; set; } = $"최영훈";
    public string StoreName { get; set; } = $"샬롬 케익크";
    public string StoreAddressNo { get; set; } = $"00000";
    public string StoreTel1 { get; set; } = $"000-0000-0000";
    public string StoreTel2 { get; set; } = $"000-0000-0000";
    public string StoreAddress { get; set; } = $"경기도 시흥시 월곶중앙로 58번길 블루밍 더마크 102동 1002호";

    public ManageViewModel()
    {

    }

    [RelayCommand]
    private async void OnApplyClicked()
    {
        await Task.Delay(1000);
    }
}
