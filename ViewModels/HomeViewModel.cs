using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PollSber.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;

        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            StartPollCommand = new RelayCommand(_ => _mainViewModel.NavigateToPoll());
            OpenQrUrlCommand = new RelayCommand(_ =>
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://clck.ru/3DzWzE",
                    UseShellExecute = true
                }));
        }

        public ICommand StartPollCommand { get; }
        public ICommand OpenQrUrlCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
