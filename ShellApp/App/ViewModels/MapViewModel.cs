namespace ShalomCake.ViewModels;

public partial class MapViewModel : BaseViewModel
{
    [ObservableProperty]
    public string source;

    public MapViewModel()
    {
        // TODO: Update the default URL
        Source = "https://m.blog.naver.com/PostList.naver?blogId=dkssk9092&categoryNo=39&logCode=0&categoryName=%ED%94%8C%EB%9D%BC%EC%9B%8C%EC%BC%80%EC%9D%B4%ED%81%AC#postlist_block";
    }

    [RelayCommand]
    private async void WebViewNavigated(WebNavigatedEventArgs e)
    {
        if (e.Result != WebNavigationResult.Success)
        {
            // TODO: handle failed navigation in an appropriate way
            await Shell.Current.DisplayAlert("Navigation failed", e.Result.ToString(), "OK");
        }
    }

    [RelayCommand]
    private void NavigateBack(WebView webView)
    {
        if (!webView.CanGoBack)
            return;

        webView.GoBack();
    }

    [RelayCommand]
    private void NavigateForward(WebView webView)
    {
        if (!webView.CanGoForward)
            return;

        webView.GoForward();
    }

    [RelayCommand]
    private void RefreshPage(WebView webView)
    {
        webView.Reload();
    }

    [RelayCommand]
    private async void OpenInBrowser()
    {
        await Launcher.OpenAsync(Source);
    }
}
