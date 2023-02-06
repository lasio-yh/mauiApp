namespace ShalomCake.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    //TODO 로그인 프로세스 주입.
    public string IdValue => string.Empty;
    public string PasswordValue => string.Empty;

    [RelayCommand]
    private async void OnLoginClicked()
    {
        await Shell.Current.GoToAsync("OrderListPage");
    }
}