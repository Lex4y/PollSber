using PollSber.Models;
using System.ComponentModel;

namespace PollSber.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentViewModel;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel()
        {
            NavigateToHome();
        }

        public void NavigateToHome()
        {
            CurrentViewModel = new HomeViewModel(this);
        }

        public void NavigateToPoll()
        {
            CurrentViewModel = new PollViewModel(this);
        }

        public void NavigateToResult(PollResultData resultData)
        {
            CurrentViewModel = new ResultViewModel(resultData, this);
        }

        public void NavigateToLast()
        {
            CurrentViewModel = new LastViewModel(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
