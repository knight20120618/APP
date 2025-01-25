using System;
using System.Collections.Generic;
using System.Data;
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

namespace NO3
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

        string KG , M;
        double kg , m;

        private void btnBMI_Click(object sender, RoutedEventArgs e)
        {
            KG = txtKG.Text;
            M = txtM.Text;
            if( double.TryParse(KG ,out kg ) == true && double.TryParse(M , out m) == true && M != "0")
            {
                txtShow.Text = Convert.ToString( kg / ( m * m ) );
            }
            else
            {
                txtKG.Text = "";
                txtM.Text = "";
                txtShow.Text = "輸入錯誤";
            }
        }
    }
}
