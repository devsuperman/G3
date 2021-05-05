using Garimpo3.Services;
using Garimpo3.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using System;
using System.Threading.Tasks;


namespace Garimpo3.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string login;
        string password;
        string errorMessage;
        public string Login { get => login; set => SetProperty(ref login, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public string ErrorMessage { get => errorMessage; set => SetProperty(ref errorMessage, value); }

        public AsyncCommand LoginCommand { get; }

        public LoginViewModel()
        {
#if DEBUG
            Login = "hsbtiago@gmail.com";
            Password = "555555";
#endif
            Title = "Garimpo 3.0";
            LoginCommand = new AsyncCommand(LoginAsync);
            RedirectIfLogged();
        }

        private async void RedirectIfLogged()
        {
            IsBusy = true;

            if(MyRealmConfig.UserIsLogged())
                await Xamarin.Forms.Shell.Current.GoToAsync($"//{nameof(HomePage)}");

            IsBusy = false;
        }

        private async Task LoginAsync()
        {
            IsBusy = true;
            var loginResult = await MyRealmConfig.LoginAsync(Login, Password);

            if (loginResult.Success)
                await Xamarin.Forms.Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            else
                ErrorMessage = loginResult.ErrorMessage;

            IsBusy = false;
        }
    }
}
