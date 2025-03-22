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
                if (value < 0) throw new ArgumentException("體重不能為負數");
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentException("身高不能為負數");
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public double BMI
        {
            get => _bmi;
            set
            {
                _bmi = value;
                OnPropertyChanged(nameof(BMI));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
