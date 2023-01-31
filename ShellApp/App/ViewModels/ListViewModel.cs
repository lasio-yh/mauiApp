﻿namespace ShalomCake.ViewModels;

public partial class ListViewModel : BaseViewModel
{
    readonly OrderService dataService;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<OrderItem> items;

    public ListViewModel(OrderService service)
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
        await Shell.Current.GoToAsync(nameof(ListDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }
}