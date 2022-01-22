using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using WeatherApp.Services;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private readonly INavigationService _navigationService;
        private DelegateCommand _loginCommand;
        //private readonly IUserService _userService;
        //private List<PropertyResponse> _myProperties;
        private readonly IApiServices _apiService;
        // private ObservableCollection<PropertyItemViewModel> _properties;

        public LoginViewModel(INavigationService navigationService, IApiServices apiService) : base(navigationService)
        {
            Title = "Login";
            _navigationService = navigationService;
            _apiService = apiService;
            // _userService = userService;
            //IsEnabled = true;
            // LoadPropertiesAsync();
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));



        public string Email { get; set; }


        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        //public ObservableCollection<PropertyItemViewModel> Properties
        //{
        //    get => _properties;
        //    set => SetProperty(ref _properties, value);
        //}

        //[HttpGet]
        //[Route("api/UserCredentials/username={username}/password={password}")]
        private async void Login()
        {

            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                Password = string.Empty;
                return;
            }

            string url = "https://weatherproject20211104225842.azurewebsites.net/";

            string email = Email;
            string password = Password;


            var response = await _apiService.CheckUserAPI(url, "api/User/", email + "/" + "password=" + password);

            var user = (bool)response.IsSuccess;

            if (!user)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or Password incorrect.", "Accept");
                return;
            }

            await _navigationService.NavigateAsync($"/{nameof(CityPage)}");
        }

        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}
