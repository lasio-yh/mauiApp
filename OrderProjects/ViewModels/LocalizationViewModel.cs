namespace OrderProject.ViewModels;

public partial class LocalizationViewModel : BaseViewModel
{
    public string LocalizedText => OrderProject.Resources.Strings.AppResources.HelloMessage;
}
