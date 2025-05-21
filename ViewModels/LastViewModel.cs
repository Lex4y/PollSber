using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PollSber.ViewModels
{
    public class LastViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public ICommand OpenFirstQrUrlCommand { get; }
        public ICommand OpenSecondQrUrlCommand { get; }
        public ICommand GoToHomeCommand { get; }

        public LastViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            OpenFirstQrUrlCommand = new RelayCommand(_ =>
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://clck.ru/3DzWzE",
                    UseShellExecute = true
                }));

            OpenSecondQrUrlCommand = new RelayCommand(_ =>
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://clck.ru/3E2qP3",
                    UseShellExecute = true
                }));

            GoToHomeCommand = new RelayCommand(_ => _mainViewModel.NavigateToHome());
        }
    }
}
