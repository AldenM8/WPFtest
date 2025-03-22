using System.Windows;
using BMICalculator.ViewModels;

namespace BMICalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BMIViewModel();
        }
    }
}
