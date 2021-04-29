using System.Threading.Tasks;

namespace Garimpo3.Services
{
    public interface IPopUp
    {
        Task Dialog(string message);
        Task<bool> Confirm(string question, string yesText, string noText);
        Task<string> ActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
