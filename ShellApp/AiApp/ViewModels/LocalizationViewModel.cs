namespace AiApp.ViewModels;

public partial class LocalizationViewModel : BaseViewModel
{
    public string LocalizedText => AiApp.Resources.Strings.AppResources.HelloMessage;
}
