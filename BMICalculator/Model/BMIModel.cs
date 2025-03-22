using System;
using System.ComponentModel;

namespace BMICalculator.Models
{
    public class BMIModel : INotifyPropertyChanged
    {
        private double _weight;
        private double _height;
        private double _bmi;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0) throw new ArgumentException("體重必須大於 0");
                _weight = value;
                OnPropertyChanged(nameof(Weight));
                CalculateBMI();
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0) throw new ArgumentException("身高必須大於 0");
                _height = value;
                OnPropertyChanged(nameof(Height));
                CalculateBMI();
            }
        }

        public double BMI
        {
            get => _bmi;
            private set
            {
                _bmi = value;
                OnPropertyChanged(nameof(BMI));
            }
        }

        private void CalculateBMI()
        {
            if (_weight > 0 && _height > 0)
            {
                double heightInMeters = _height / 100.0;
                BMI = _weight / (heightInMeters * heightInMeters);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
