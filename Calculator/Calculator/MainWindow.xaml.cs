using System;
using System.Windows;

namespace Calculator
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

        Calculate calculate = new Calculate(); // 建立計算機物件
        int operators = -1;

        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
            txtNumber.Text = txtNumber.Text + _number;
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            //只需要呼叫Add_Number函式，並且設定參數為數字0
            Add_Number("0");
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

        private void Select_Operator(int _operator)
        {
            //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
            calculate.firstNumber = Convert.ToSingle(txtNumber.Text);
            //重新將輸入文字框重新設定為0
            txtNumber.Text = "0";
            operators = _operator;
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

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            //確認輸入文字框中完全沒有小數點
            if (txtNumber.Text.Contains(".") == false)
                txtNumber.Text = txtNumber.Text + ".";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumber.Text = "0";
            calculate.Reset();
            operators = -1;
        }

        private void btnRewind_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text.Length > 1)
            {
                txtNumber.Text = txtNumber.Text.Substring(0 , txtNumber.Text.Length-1);
            }
            else
            {
                txtNumber.Text = "0";
            }
        }

        private void btnPercentage_Click(object sender, RoutedEventArgs e)
        {
            //將輸入文字框轉換成浮點數
            calculate.firstNumber = Convert.ToSingle(txtNumber.Text);
            calculate.firstNumber /= 100;
            txtNumber.Text = string.Format("{0:P2}", calculate.firstNumber);
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            //宣告最後計算結果變數
            float finalResults = 0f;
            //將輸入文字框轉換成浮點數，存入第二個數字的全域變數
            calculate.secondNumber = Convert.ToSingle(txtNumber.Text);

            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                //執行加法
                case 0:
                    finalResults = calculate.Add();
                    break;
                //執行減法
                case 1:
                    finalResults = calculate.Subtract(); 
                    break;
                //執行乘法
                case 2:
                    finalResults = calculate.Multiply(); 
                    break;
                //執行除法
                case 3:
                    finalResults = calculate.Divide(); 
                    break;
            }

            //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容
            txtNumber.Text = string.Format("{0:0.##########}", finalResults);

            //重置所有全域變數
            calculate.Reset();
            operators = -1;
        }
    }
}
