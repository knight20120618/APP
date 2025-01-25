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

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculate calculate = new Calculate(); // 建立計算機物件
        int operators = -1; // 記錄選擇哪一種運算符號？0:加、1:減、2:乘、3:除、-1:重新設定

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("1");
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("2");
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("3");
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("4");
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("5");
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("6");
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("7");
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("8");
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("9");
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("0");
        }

        // 按下數字按鍵函式
        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
            txtNumber.Text = txtNumber.Text + _number;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(0);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(1);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(2);
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(3);
        }

        // 運算符號按鍵函式
        private void Select_Operator(int _operator)
        {
            calculate.firstNumber = Convert.ToSingle(txtNumber.Text); //將輸入文字框轉換成浮點數，再將數字存到計算機物件的firstNumber屬性裡面
            operators = _operator;
            txtNumber.Text = "0"; //重新將輸入文字框重新設定為0
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            // 確認輸入文字框中完全沒有小數點
            if (txtNumber.Text.IndexOf(".") == -1)
                txtNumber.Text = txtNumber.Text + ".";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumber.Text = "0";
            calculate.Reset();
            operators = -1;
            //重新設定計算機物件
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            float finalResults = 0f; //宣告最後計算結果變數
            //將輸入文字框轉換成浮點數，再將數字存到計算機物件的secondNumber屬性裡面
            calculate.secondNumber = Convert.ToSingle(txtNumber.Text);

            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = calculate.Add();// 執行加法
                    break;
                case 1:
                    finalResults = calculate.Subtract();// 執行減法
                    break;
                case 2:
                    finalResults = calculate.Multiply();// 執行乘法
                    break;
                case 3:
                    finalResults = calculate.Divide();// 執行除法
                    break;
            }

            txtNumber.Text = string.Format("{0:0.##########}", finalResults); //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容

            //重新設定計算機物件
            calculate.Reset();
            operators = -1;
        }
    }
}