using MauiDemoApp.ViewModels;

namespace MauiDemoApp.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}