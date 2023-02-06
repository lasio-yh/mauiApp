namespace OrderProject.ViewModels;

public partial class OrderListViewModel : BaseViewModel
{
    readonly OrderService dataService;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<OrderItem> items;

    public OrderListViewModel(OrderService service)
    {
        dataService = service;
    }

    [RelayCommand]
    private async void OnRefreshing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task LoadMore()
    {
        var items = await dataService.GetItems();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    public async Task LoadDataAsync()
    {
        Items = new ObservableCollection<OrderItem>(await dataService.GetItems());
    }

    [RelayCommand]
    private async void GoToDetails(OrderItem item)
    {
        if (!item.Status.Equals("접수대기"))
            return;

        await Shell.Current.GoToAsync(nameof(OrderListDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }

    [RelayCommand]
    private async void OnLoginClicked()
    {
        await Shell.Current.GoToAsync("OrderListPage");
    }

    [RelayCommand]
    private async void OnPauseClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            item.Status = $"접수대기";
            Items.Add(item);
        }
    }

    [RelayCommand]
    private async void OnAcceptClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            item.Status = $"접수";
            Items.Add(item);
        }
    }

    [RelayCommand]
    private async void OnPickupClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            item.Status = $"처리 중";
            Items.Add(item);
        }
    }

    [RelayCommand]
    private async void OnCompleateClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            item.Status = $"완료";
            Items.Add(item);
        }
    }

    [RelayCommand]
    private async void OnBilgeClicked()
    {
        //TODO 영수증을 출력합니다.
        await Task.Delay(1000);  
    }
}
