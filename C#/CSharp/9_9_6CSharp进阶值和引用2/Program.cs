using System;

namespace _9_9_6CSharp进阶值和引用2
{
    class Program
    {


        //判断是引用类型还是值类型f12查看，struct的为值类型，class为引用


        //像struct，emum，int等值类型
        //string ,类，数组，集合等引用类型

        //问题一：在struct（值类型）中声明的值类型与引用类型存储的位置
        //值类型：struct为值类型，在栈中开辟空间   值类型放在其中， 引用类型的地址放在其中
        //结论：值类型仍然存在栈中，引用仍然存在堆中

        //问题一：在类（引类型）中声明的值类型与引用类型存储的位置
        //引用类型：类  类在堆中开辟了空间。值类型存在了其堆中  引用：引用类型的地址存储在其中
        //结论：值类型换成在堆中，引用不变

        //总结：值类型跟着大哥(外层)走，引用始终在堆中
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
