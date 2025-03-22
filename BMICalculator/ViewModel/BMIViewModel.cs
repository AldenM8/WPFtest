using System;
using System.Windows.Input;
using BMICalculator.Models;

namespace BMICalculator.ViewModels
{
    public class BMIViewModel
    {
        public BMIModel BMIModel { get; set; }
        public ICommand CalculateCommand { get; }

        public BMIViewModel()
        {
            BMIModel = new BMIModel();
            CalculateCommand = new RelayCommand(CalculateBMI);
        }

        private void CalculateBMI(object parameter)
        {
            try
            {
                BMIModel.Weight = Convert.ToDouble(parameter as string);
                BMIModel.Height = Convert.ToDouble(parameter as string);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"輸入錯誤: {ex.Message}");
            }
        }
    }
}
