
namespace MauiDemoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //MainPage = new AppShell();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }

    }
}
