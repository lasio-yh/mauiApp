using CommunityToolkit.Maui.Core;

namespace AiApp.ViewModels;

public partial class DrawingViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<IDrawingLine> lines = new();

    [RelayCommand]
    public void Clear()
    {
        Lines.Clear();
    }
}
