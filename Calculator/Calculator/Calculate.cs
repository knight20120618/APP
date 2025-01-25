using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculate
    {
        public float firstNumber { get; set; } = 0;  // 屬性：firstNumber 儲存第一個數字
        public float secondNumber { get; set; } = 0; // 屬性：secondNumber 儲存第二個數字

        // 相加方法
        public float Add()
        {
            return firstNumber + secondNumber;
        }

        // 相減方法
        public float Subtract()
        {
            return firstNumber - secondNumber;
        }

        // 相乘方法
        public float Multiply()
        {
            return firstNumber * secondNumber;
        }

        // 相除方法
        public float Divide()
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return firstNumber / secondNumber;
        }

        // 重新設定方法
        public void Reset()
        {
            firstNumber = 0;
            secondNumber = 0;
        }
    }
}