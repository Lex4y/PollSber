using PollSber.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace PollSber.ViewModels
{
    public class PollViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;

        private double _slider1;
        private double _slider2;
        private double _slider3;
        private double _slider4;
        private double _slider5;

        public double Slider1
        {
            get => _slider1;
            set { _slider1 = value; OnPropertyChanged(nameof(Slider1)); }
        }
        public double Slider2
        {
            get => _slider2;
            set { _slider2 = value; OnPropertyChanged(nameof(Slider2)); }
        }
        public double Slider3
        {
            get => _slider3;
            set { _slider3 = value; OnPropertyChanged(nameof(Slider3)); }
        }
        public double Slider4
        {
            get => _slider4;
            set { _slider4 = value; OnPropertyChanged(nameof(Slider4)); }
        }
        public double Slider5
        {
            get => _slider5;
            set { _slider5 = value; OnPropertyChanged(nameof(Slider5)); }
        }

        public ICommand BackCommand { get; }
        public ICommand NextCommand { get; }

        public PollViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            BackCommand = new RelayCommand(_ => _mainViewModel.NavigateToHome());
            NextCommand = new RelayCommand(_ =>
            {
                var resultData = new PollResultData
                {
                    Slider1 = this.Slider1,
                    Slider2 = this.Slider2,
                    Slider3 = this.Slider3,
                    Slider4 = this.Slider4,
                    Slider5 = this.Slider5
                };
                _mainViewModel.NavigateToResult(resultData);
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
