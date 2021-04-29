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
        public async Task<string> ActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await App.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }
    }
}
