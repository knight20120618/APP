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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Temperature
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double output;

        private void txtFahrenheit_KeyUp(object sender, KeyEventArgs e)
        {
            if (double.TryParse( txtFahrenheit.Text , out output) == true)
            {
                temperature(0 , output);
            }
            else
            {
                txtFahrenheit.Text = "";
            }
        }

        private void txtCelsius_KeyUp(object sender, KeyEventArgs e)
        {
            if ( double.TryParse( txtCelsius.Text , out output ) == true)
            {
                temperature(1 , output);
            }
            else
            {
                txtCelsius.Text = "";
            }
        }

        private void temperature(int _number , double _value)
        {
            if (_number == 0)
            {
                txtCelsius.Text = Convert.ToString( ( _value - 32 ) * 5 / 9 );
            }
            if (_number == 1)
            {
                txtFahrenheit.Text = Convert.ToString( _value * 9 / 5 + 32 );
            }
        }
    }
}
