using Realms;
using Realms.Sync;
using Garimpo3.Models;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public static class MyRealmConfig
    {
        const string LOGIN = "login";
        const string PASSWORD = "password";
        const string DREDGEID = "DredgeId";

        public static string DredgeId()
        {
            return Task.Run(() => SecureStorage.GetAsync(DREDGEID)).Result;
        }

        public static SyncConfiguration GetConfig(string login = null, string password = null)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                login = Task.Run(() => SecureStorage.GetAsync(LOGIN)).Result;
                password = Task.Run(() => SecureStorage.GetAsync(PASSWORD)).Result;
            }
            
            var app = Realms.Sync.App.Create(Constants.AppId);

            var user = Task.Run(() => app.LogInAsync(Credentials.EmailPassword(login, password))).Result;

            var userCustomData = user.GetCustomData<CustomUserData>();

            return new SyncConfiguration(userCustomData.DredgeId, user);
        }

        internal static async Task LogoutAsync()
        {
            var app = Realms.Sync.App.Create(Constants.AppId);            
            await app.CurrentUser.LogOutAsync();
        }

        internal static bool UserIsLogged()
        {
            var app = Realms.Sync.App.Create(Constants.AppId);
            return app.CurrentUser != null;
            //var login = await SecureStorage.GetAsync(LOGIN);
            //var password = await SecureStorage.GetAsync(PASSWORD);

            //if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            //    return false;

            //var retorno = false;

            //try
            //{
            //    var config = GetConfig();
            //    retorno = (config.User.State == UserState.LoggedIn);
            //}
            //catch (System.Exception)
            //{

            //}

            //return retorno;

        }

        public static async Task<LoginResult> LoginAsync(string login, string password)
        {
            var loginResult = new LoginResult();

            try
            {             
                var config = GetConfig(login, password);
                var realm = await Realm.GetInstanceAsync(config);

                var userCustomData = config.User.GetCustomData<CustomUserData>();

                await SecureStorage.SetAsync(DREDGEID, userCustomData.DredgeId);
                await SecureStorage.SetAsync(LOGIN, login);
                await SecureStorage.SetAsync(PASSWORD, password);

                realm.Dispose();
            }
            catch (System.Exception ex)
            {
                loginResult.RegisterError(ex.Message);
            }

            return loginResult;
        }

        public class LoginResult
        {
            public bool Success { get; set; } = true;
            public string ErrorMessage { get; set; }

            internal void RegisterError(string message)
            {
                this.ErrorMessage = message;
                this.Success = false;
            }
        }
    }
}
