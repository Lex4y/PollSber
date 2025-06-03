using PollSber.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PollSber.ViewModels
{
    public class PollViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;

        public ObservableCollection<PollQuestion> Questions { get; } = new ObservableCollection<PollQuestion>();

        public ICommand BackCommand { get; }
        public ICommand NextCommand { get; }

        public PollViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            // Инициализация вопросов
            InitializeQuestions();

            BackCommand = new RelayCommand(_ => _mainViewModel.NavigateToHome());
            NextCommand = new RelayCommand(_ => NavigateToResults(), _ => CanNavigateToResults());
        }

        private void InitializeQuestions()
        {
            // Вопрос 1
            Questions.Add(new PollQuestion
            {
                QuestionText = (string)Application.Current.FindResource("PollQuestion1"),
                ValueTexts = new[]
                {
                    (string)Application.Current.FindResource("PollQuestion1Value1"),
                    (string)Application.Current.FindResource("PollQuestion1Value2"),
                    (string)Application.Current.FindResource("PollQuestion1Value3")
                },
                MinValue = 0,
                MaxValue = 2,
                CurrentValue = 0
            });

            // Вопрос 2
            Questions.Add(new PollQuestion
            {
                QuestionText = (string)Application.Current.FindResource("PollQuestion2"),
                ValueTexts = new[]
                {
                    (string)Application.Current.FindResource("PollQuestion2Value1"),
                    (string)Application.Current.FindResource("PollQuestion2Value2"),
                    (string)Application.Current.FindResource("PollQuestion2Value3")
                },
                MinValue = 0,
                MaxValue = 2,
                CurrentValue = 0
            });

            // Вопрос 3
            Questions.Add(new PollQuestion
            {
                QuestionText = (string)Application.Current.FindResource("PollQuestion3"),
                ValueTexts = new[]
                {
                    (string)Application.Current.FindResource("PollQuestion3Value1"),
                    (string)Application.Current.FindResource("PollQuestion3Value2"),
                    (string)Application.Current.FindResource("PollQuestion3Value3")
                },
                MinValue = 0,
                MaxValue = 2,
                CurrentValue = 0
            });

            // Вопрос 4
            Questions.Add(new PollQuestion
            {
                QuestionText = (string)Application.Current.FindResource("PollQuestion4"),
                ValueTexts = new[]
                {
                    (string)Application.Current.FindResource("PollQuestion4Value1"),
                    (string)Application.Current.FindResource("PollQuestion4Value2"),
                    (string)Application.Current.FindResource("PollQuestion4Value3")
                },
                MinValue = 0,
                MaxValue = 2,
                CurrentValue = 0
            });

            // Вопрос 5
            Questions.Add(new PollQuestion
            {
                QuestionText = (string)Application.Current.FindResource("PollQuestion5"),
                ValueTexts = new[]
                {
                    (string)Application.Current.FindResource("PollQuestion5Value1"),
                    (string)Application.Current.FindResource("PollQuestion5Value2"),
                    (string)Application.Current.FindResource("PollQuestion5Value3")
                },
                MinValue = 0,
                MaxValue = 2,
                CurrentValue = 0
            });
        }

        private bool CanNavigateToResults()
        {
            // Проверка, что все вопросы отвечены (если требуется)
            return Questions.All(q => q.CurrentValue >= q.MinValue && q.CurrentValue <= q.MaxValue);
        }

        private void NavigateToResults()
        {
            var resultData = new PollResultData
            {
                Slider1 = Questions[0].CurrentValue,
                Slider2 = Questions[1].CurrentValue,
                Slider3 = Questions[2].CurrentValue,
                Slider4 = Questions[3].CurrentValue,
                Slider5 = Questions[4].CurrentValue
            };

            _mainViewModel.NavigateToResult(resultData);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}