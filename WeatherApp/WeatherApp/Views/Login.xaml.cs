using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Login());
        }
    }
}
