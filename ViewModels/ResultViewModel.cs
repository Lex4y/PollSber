using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using PollSber.Models;

namespace PollSber.ViewModels
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private bool _isPrivacyPolicyPopupOpen;
        private bool _isPersonalDataPopupOpen;
        private bool _isEmailErrorPopupOpen;
        private string _userEmail = "";
        private bool _isAgreed;

        public string ResultTitle { get; }
        public string ResultText1 { get; }
        public string ResultText2 { get; }
        public string ResultText3 { get; }
        public string ResultText4 { get; }
        public string ResultText5 { get; }
        public string ResultText6 { get; }
        public string ResultText7 { get; }
        public string ResultText8 { get; }
        public string ResultText9 { get; }

        public string UserEmail
        {
            get => _userEmail;
            set { _userEmail = value; OnPropertyChanged(nameof(UserEmail)); }
        }

        public bool IsAgreed
        {
            get => _isAgreed;
            set { _isAgreed = value; OnPropertyChanged(nameof(IsAgreed)); }
        }

        public bool IsPrivacyPolicyPopupOpen
        {
            get => _isPrivacyPolicyPopupOpen;
            set { _isPrivacyPolicyPopupOpen = value; OnPropertyChanged(nameof(IsPrivacyPolicyPopupOpen)); }
        }

        public bool IsPersonalDataPopupOpen
        {
            get => _isPersonalDataPopupOpen;
            set { _isPersonalDataPopupOpen = value; OnPropertyChanged(nameof(IsPersonalDataPopupOpen)); }
        }

        public bool IsEmailErrorPopupOpen
        {
            get => _isEmailErrorPopupOpen;
            set { _isEmailErrorPopupOpen = value; OnPropertyChanged(nameof(IsEmailErrorPopupOpen)); }
        }

        public ICommand OpenPrivacyPolicyCommand { get; }
        public ICommand OpenPersonalDataCommand { get; }
        public ICommand ClosePrivacyPolicyPopupCommand { get; }
        public ICommand ClosePersonalDataPopupCommand { get; }
        public ICommand FinishCommand { get; }
        public ICommand SendEmailCommand { get; }
        public ICommand CloseEmailErrorPopupCommand { get; }

        public ResultViewModel(PollResultData resultData, MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            double sum = resultData.Slider1 + resultData.Slider2 + resultData.Slider3 + resultData.Slider4 + resultData.Slider5;
            string groupPrefix;
            if (sum <= 2) groupPrefix = "ResultView1";
            else if (sum <= 6) groupPrefix = "ResultView2";
            else groupPrefix = "ResultView3";

            ResultTitle = Application.Current.FindResource($"{groupPrefix}ResultTitle") as string ?? "";
            ResultText1 = Application.Current.FindResource($"{groupPrefix}1") as string ?? "";
            ResultText2 = Application.Current.FindResource($"{groupPrefix}2") as string ?? "";
            ResultText3 = Application.Current.FindResource($"{groupPrefix}3") as string ?? "";
            ResultText4 = Application.Current.FindResource($"{groupPrefix}4") as string ?? "";
            ResultText5 = Application.Current.FindResource($"{groupPrefix}5") as string ?? "";
            ResultText6 = Application.Current.FindResource($"{groupPrefix}6") as string ?? "";
            ResultText7 = Application.Current.FindResource($"{groupPrefix}7") as string ?? "";
            ResultText8 = Application.Current.FindResource($"{groupPrefix}8") as string ?? "";
            ResultText9 = Application.Current.FindResource($"{groupPrefix}9") as string ?? "";

            OpenPrivacyPolicyCommand = new RelayCommand(_ => IsPrivacyPolicyPopupOpen = true);
            OpenPersonalDataCommand = new RelayCommand(_ => IsPersonalDataPopupOpen = true);
            ClosePrivacyPolicyPopupCommand = new RelayCommand(_ => IsPrivacyPolicyPopupOpen = false);
            ClosePersonalDataPopupCommand = new RelayCommand(_ => IsPersonalDataPopupOpen = false);
            FinishCommand = new RelayCommand(_ => _mainViewModel.NavigateToHome());
            SendEmailCommand = new RelayCommand(_ => SendEmailToUser()); // Без условия CanSendEmail
            CloseEmailErrorPopupCommand = new RelayCommand(_ => IsEmailErrorPopupOpen = false);
        }

        private void SendEmailToUser()
        {
            if (string.IsNullOrWhiteSpace(UserEmail))
            {
                IsEmailErrorPopupOpen = true;
                return;
            }
            if (!IsAgreed)
            {
                // Можно добавить отдельный попап или сообщение о согласии
                IsEmailErrorPopupOpen = true;
                return;
            }
            try
            {
                var emailSettings = JsonSerializer.Deserialize<EmailSettings>(
                    File.ReadAllText("Config/emailSettings.json"));

                var mail = new MailMessage
                {
                    From = new MailAddress(emailSettings.FromEmail),
                    Subject = "Результаты опроса",
                    Body = $"Вы набрали баллов: ...\n\n{ResultTitle}\n\n{ResultText1}\n{ResultText2}\n{ResultText3}\n{ResultText4}\n{ResultText5}\n{ResultText6}\n{ResultText7}\n{ResultText8}\n{ResultText9}",
                    IsBodyHtml = false
                };
                mail.To.Add(new MailAddress(UserEmail));

                using var smtp = new SmtpClient(emailSettings.SmtpHost, emailSettings.SmtpPort)
                {
                    Credentials = new NetworkCredential(emailSettings.SmtpUsername, emailSettings.SmtpPassword),
                    EnableSsl = true
                };
                smtp.Send(mail);

                _mainViewModel.NavigateToLast();
            }
            catch (Exception ex)
            {
                IsEmailErrorPopupOpen = true;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
