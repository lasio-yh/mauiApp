using CommunityToolkit.Maui.Core;

namespace ShalomCake.ViewModels;

public partial class RateViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<IDrawingLine> lines = new();

    [RelayCommand]
    public void Clear()
    {
        Lines.Clear();
    }
}
