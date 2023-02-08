namespace StoreApp.ViewModels;

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
        await Shell.Current.GoToAsync(nameof(OrderListDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }

    [RelayCommand]
    private async void OnReceiveClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            if(item.Status.Equals(AppResources.ReceiveTitle))
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
            if (item.Status.Equals(AppResources.AcceptTitle))
                Items.Add(item);
        }
    }

    [RelayCommand]
    private async void OnInProcessClicked()
    {
        var items = await dataService.GetItems();
        Items.Clear();
        foreach (var item in items)
        {
            if (item.Status.Equals(AppResources.InProcessTitle))
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
            if (item.Status.Equals(AppResources.CompleateTitle))
                Items.Add(item);
        }
    }

    [RelayCommand]
    private void OnBilgeClicked()
    {
        //TODO 영수증을 출력 주입.
        //var text = await dataService.JsonSerializeAsync(Items);
    }

    [RelayCommand]
    private void OnCallClicked()
    {
        //TODO 배달 호출 주입.
        //var text = await dataService.JsonSerializeAsync(Items);
    }
}
