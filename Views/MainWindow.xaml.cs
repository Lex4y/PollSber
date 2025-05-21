using PollSber.ViewModels;
using System;
using System.Windows;

namespace PollSber.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            SetupWindowSize();
        }

        private void SetupWindowSize()
        {
            const int desiredWidth = 1080;
            const int desiredHeight = 1920;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Максимальная высота окна — например, 90% от высоты экрана
            double maxWindowHeight = screenHeight * 0.9;

            // Пересчитываем масштаб так, чтобы окно не превышало заданную высоту
            double scale = Math.Min(screenWidth / desiredWidth, maxWindowHeight / desiredHeight);

            Width = desiredWidth * scale;
            Height = desiredHeight * scale;

            Top = (screenHeight - Height) / 2;
            Left = (screenWidth - Width)* 3 / 4;

        }
    }
}