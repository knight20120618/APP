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

namespace WeightCalculator
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

        string strInput;
        double douOutput;

        private void caculate(int _kind, double _value)
        {
            if (_kind != 0)
                txtMG.Text = string.Format("{0:0.##########}", _value / 453592.37);
            if (_kind != 1)
                txtG.Text = string.Format("{0:0.##########}", _value / 453.59237);
            if (_kind != 2)
                txtKG.Text = string.Format("{0:0.##########}", _value / 0.453592);
            if (_kind != 3)
                txtTON.Text = string.Format("{0:0.##########}", _value / 0.000454);
            if (_kind != 4)
                txtOZ.Text = string.Format("{0:0.##########}", _value / 16);
            if (_kind != 5)
                txtIB.Text = string.Format("{0:0.##########}", _value);
        }

        private void txtMG_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtMG.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(0, douOutput);
            }
            else
            {
                txtMG.Text = "";
            }
        }

        private void txtG_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtG.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(1, douOutput);
            }
            else
            {
                txtG.Text = "";
            }
        }

        private void txtKG_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtKG.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(2, douOutput);
            }
            else
            {
                txtKG.Text = "";
            }
        }

        private void txtTON_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtTON.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(3, douOutput);
            }
            else
            {
                txtTON.Text = "";
            }
        }

        private void txtOZ_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtOZ.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(4, douOutput);
            }
            else
            {
                txtOZ.Text = "";
            }
        }

        private void txtIB_KeyUp(object sender, KeyEventArgs e)
        {
            strInput = txtIB.Text;

            if (double.TryParse(strInput, out douOutput) == true)
            {
                caculate(5, douOutput);
            }
            else
            {
                txtIB.Text = "";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMG.Text = "";
            txtG.Text = "";
            txtKG.Text = "";
            txtTON.Text = "";
            txtOZ.Text = "";
            txtIB.Text = "";
        }
    }
}
