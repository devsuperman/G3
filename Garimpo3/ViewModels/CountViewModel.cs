using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Garimpo3.ViewModels
{
    public class CountViewModel : BindableObject
    {
        public ICommand OnIncreaseCount { get; }
        public CountViewModel()
        {
            UpdateDisplay();
            OnIncreaseCount = new Command(UpdateDisplay);
        }

        void UpdateDisplay()
        {
            DisplayText = $"The button was clicked {count} times!";
            count++;
        }

        string displayText;
        int count = 0;
        public string DisplayText
        {
            get => displayText;

            set
            {
                if (displayText == value)
                    return;

                displayText = value;
                OnPropertyChanged();
            }
        }
    }
}
