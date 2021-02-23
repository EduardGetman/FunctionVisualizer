using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FunctionVisualizer.Functions;
using FunctionVisualizer.Functions.Validators;

namespace FunctionVisualizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ValidString validString = new ValidString(FunctionTBox.Text);
            double startInterval = -10.0;//Convert.ToDouble(StartIntervalTBox.Text);
            double endInterval = 10.0;//Convert.ToDouble(EndIntervalTBox.Text);
            double step = (endInterval - startInterval) / 20;
            CalculData calculData = new CalculData(startInterval,endInterval,step);
            FunctionsControler controler = new FunctionsControler(calculData,validString);
            foreach (var item in controler)
            {
                OutputTB.Text += ((double)item).ToString() + Environment.NewLine;
            }

        }
    }
}
