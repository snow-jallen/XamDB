using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;


namespace XamDB.ViewModels
{
    public partial class AboutViewModel : ObservableObject
    {
        public AboutViewModel()
        {
            Title = "About";
        }

        [ObservableProperty]
        private string title;

        [ICommand]
        private void ShowCurrentTime()
        {
            CurrentTime = DateTime.Now;
            Title = DateTime.Now.ToString();
            OpenWebCommand.NotifyCanExecuteChanged();
        }

        [ICommand(CanExecute = nameof(CanOpenWeb))]
        private async Task OpenWeb()
        {
            await Browser.OpenAsync("https://aka.ms/xamarin-quickstart");
        }

        private bool CanOpenWeb()
        {
            return DateTime.Now.Second % 2 == 0;
        }

        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(Greeting))]
        private DateTime currentTime;

        public string Greeting => $"Current Time: {CurrentTime:t}";
    }
}