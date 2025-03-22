using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBMI(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtWeight.Text, out double weight) && double.TryParse(txtHeight.Text, out double height))
            {
                height /= 100; // 轉換 cm 為 m
                double bmi = weight / (height * height);
                txtResult.Text = $"您的BMI為: {bmi:F2} ({GetBMICategory(bmi)})";
            }
            else
            {
                txtResult.Text = "請輸入有效的數值";
            }
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5) return "過輕";
            if (bmi < 24.9) return "正常";
            if (bmi < 29.9) return "過重";
            return "肥胖";
        }
    }
}