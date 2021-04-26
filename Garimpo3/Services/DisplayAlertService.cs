using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public class DisplayAlertService : IPopUp
    {
        public const string MyAppName = "Garimpo 3.0";

        public async Task Dialog(string message)
        {
            await App.Current.MainPage.DisplayAlert(MyAppName, message, "Ok!");
        }
        public async Task<bool> Confirm(string question, string yesText, string noText)
        {
            return await App.Current.MainPage.DisplayAlert(MyAppName, question, yesText, noText);
        }
    }
}
