using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;


namespace XamDB.ViewModels
{
    public partial class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
        }

        [ICommand]
        private void ShowCurrentTime()
        {
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
    }
}