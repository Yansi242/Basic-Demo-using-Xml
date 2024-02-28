using MauiDemoApp.ViewModels;

namespace MauiDemoApp.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}