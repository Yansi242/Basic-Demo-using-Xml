using MauiDemoApp.ViewModels;

namespace MauiDemoApp.Views;

public partial class LoginPage : ContentPage
{
 
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}