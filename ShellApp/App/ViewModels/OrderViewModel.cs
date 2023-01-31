﻿namespace ShalomCake.ViewModels;

public partial class OrderViewModel : BaseViewModel
{
    int count = 0;

    [ObservableProperty]
    public string message = "Click me";

    [RelayCommand]
    private void OnCounterClicked()
    {
        count++;

        if (count == 1)
            Message = $"Clicked {count} time";
        else
            Message = $"Clicked {count} times";

        SemanticScreenReader.Announce(Message);
    }
}