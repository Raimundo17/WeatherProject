using Prism;
using Prism.Ioc;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            await NavigationService.NavigateAsync
              ($"/{nameof(WeatherMasterDetailPage)}/NavigationPage/{nameof(HomePage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IApiServices, ApiServices>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<About, AboutViewModel>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<WeatherMasterDetailPage, WeatherMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<CityPage, CityPageViewModel>();
            containerRegistry.RegisterForNavigation<CityDetailPage, CityDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
