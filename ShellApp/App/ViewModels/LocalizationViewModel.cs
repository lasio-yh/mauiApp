namespace ShalomCake.ViewModels;

public partial class LocalizationViewModel : BaseViewModel
{
    public string LocalizedText => ShalomCake.Resources.Strings.AppResources.HelloMessage;
}
