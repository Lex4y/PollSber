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
        public bool IsAnyPopupOpen => IsPrivacyPolicyPopupOpen || IsPersonalDataPopupOpen || IsEmailErrorPopupOpen;
        public Results Result { get; }

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
            set
            {
                _isPrivacyPolicyPopupOpen = value;
                OnPropertyChanged(nameof(IsPrivacyPolicyPopupOpen));
                OnPropertyChanged(nameof(IsAnyPopupOpen));
            }
        }

        public bool IsPersonalDataPopupOpen
        {
            get => _isPersonalDataPopupOpen;
            set
            {
                _isPersonalDataPopupOpen = value;
                OnPropertyChanged(nameof(IsPersonalDataPopupOpen));
                OnPropertyChanged(nameof(IsAnyPopupOpen));
            }
        }

        public bool IsEmailErrorPopupOpen
        {
            get => _isEmailErrorPopupOpen;
            set
            {
                _isEmailErrorPopupOpen = value;
                OnPropertyChanged(nameof(IsEmailErrorPopupOpen));
                OnPropertyChanged(nameof(IsAnyPopupOpen));
            }
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

            Result = new Results
            {
                Title = Application.Current.FindResource($"{groupPrefix}ResultTitle") as string ?? "",
                Text1 = Application.Current.FindResource($"{groupPrefix}1") as string ?? "",
                Text2 = Application.Current.FindResource($"{groupPrefix}2") as string ?? "",
                Text3 = Application.Current.FindResource($"{groupPrefix}3") as string ?? "",
                Text4 = Application.Current.FindResource($"{groupPrefix}4") as string ?? "",
                Text5 = Application.Current.FindResource($"{groupPrefix}5") as string ?? "",
                Text6 = Application.Current.FindResource($"{groupPrefix}6") as string ?? "",
                Text7 = Application.Current.FindResource($"{groupPrefix}7") as string ?? "",
                Text8 = Application.Current.FindResource($"{groupPrefix}8") as string ?? "",
                Text9 = Application.Current.FindResource($"{groupPrefix}9") as string ?? ""
            };

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
            // Проверка, что поле Email не пустое
            if (string.IsNullOrWhiteSpace(UserEmail))
            {
                IsEmailErrorPopupOpen = true;
                return;
            }

            // Проверка, что пользователь согласен
            if (!IsAgreed)
            {
                IsEmailErrorPopupOpen = true;
                return;
            }
            
            try
            {

                // Чтение настроек из JSON файла
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "emailSettings.json");
                var emailSettingsJson = File.ReadAllText(path);
                var emailSettings = JsonSerializer.Deserialize<EmailSettings>(emailSettingsJson);
                if (emailSettings == null)
                {
                    // Обработка ошибки, если настройки не прочитались
                    throw new Exception("Настройки почты не найдены");
                }

                // Формирование письма
                var mail = new MailMessage
                {
                    From = new MailAddress(emailSettings.FromEmail),
                    Subject = "Результаты опроса",
                    Body = $"{Result.Title}\n\n{Result.Text1}\n{Result.Text2}\n{Result.Text3}\n{Result.Text4}\n{Result.Text5}\n{Result.Text6}\n{Result.Text7}\n{Result.Text8}\n{Result.Text9}",
                    IsBodyHtml = false
                };
                mail.To.Add(new MailAddress(UserEmail));
                // Настройка SMTP клиента
                using var smtp = new SmtpClient(emailSettings.SmtpHost, emailSettings.SmtpPort)
                {
                    Credentials = new NetworkCredential(emailSettings.SmtpUsername, emailSettings.SmtpPassword),
                    EnableSsl = true
                };
                // Отправка письма
                smtp.Send(mail);
                // После успешной отправки — навигация или другое действие
                _mainViewModel.NavigateToLast();
            }
            catch (Exception ex)
            {
                // Обработка ошибок (например, логирование)
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
