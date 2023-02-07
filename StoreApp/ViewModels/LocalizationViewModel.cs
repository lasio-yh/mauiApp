namespace StoreApp.ViewModels;

public partial class LocalizationViewModel : BaseViewModel
{
    public string LocalizedText => StoreApp.Resources.Strings.AppResources.HelloMessage;
}
