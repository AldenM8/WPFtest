using System;
using System.ComponentModel;
using System.Windows.Input;
using BMICalculator.Models;

namespace BMICalculator.ViewModels
{
    public class BMIViewModel : INotifyPropertyChanged
    {
        public BMIModel BMIModel { get; set; }
        public ICommand CalculateCommand { get; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BMIViewModel()
        {
            BMIModel = new BMIModel();
            CalculateCommand = new RelayCommand(CalculateBMI);
        }

        private void CalculateBMI(object parameter)
        {
            if (parameter is BMIModel bmiModel)
            {
                try
                {
                    if (bmiModel.Weight > 0 && bmiModel.Height > 0)
                    {
                        double heightInMeters = bmiModel.Height / 100.0;
                        bmiModel.BMI = bmiModel.Weight / (heightInMeters * heightInMeters);
                        ErrorMessage = ""; // 計算成功，清除錯誤訊息
                    }
                    else
                    {
                        ErrorMessage = "體重與身高必須大於 0";
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"輸入錯誤: {ex.Message}";
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
