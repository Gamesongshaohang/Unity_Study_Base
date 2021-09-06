using System;

namespace _9_2CSharp递归
{
    class Program
    {
        //递归的一些题目：
        static int ChenNum(int num) {

            if (num - 1 <= 1)
                return 0;

            Console.WriteLine(num);
           


           return num * ChenNum(num-1);


        }




        static void Main(string[] args)
        {

            ChenNum(10);


        }
    }
}
