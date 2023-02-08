namespace StoreApp.ViewModels;

public partial class ManageViewModel : BaseViewModel
{
    public string StoreId { get; set; } = $"ST000000";
    public string StoreNumber { get; set; } = $"000000000";
    public string StoreOwner { get; set; } = $"최영훈";
    public string StoreName { get; set; } = $"샬롬 케익크";
    public string StoreAddressNo { get; set; } = $"00000";
    public string StoreTel { get; set; } = $"000-0000-0000";
    public string StoreType { get; set; } = $"수제케익크";
    public string StoreOpenCloseTime { get; set; } = $"오픈 - 오전 10시 , 마감 - 오후 8시";
    public string StoreUsed { get; set; } = $"영업 중";
    public string StoreHolyday { get; set; } = $"매주 월 휴무";
    public string StoreMenu { get; set; } = $"앙금 플라워 케익크";
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
