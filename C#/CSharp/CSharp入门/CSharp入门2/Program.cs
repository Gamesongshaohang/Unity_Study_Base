using System;

namespace CSharp入门2
{
    class Program
    {
        
        /// <summary>
        /// 变量
        /// 总：整数用int,小数用float,字符用string,
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            // Console.WriteLine，在控制台数出内容
            //Console.Read();在控制台输入内容
            Console.Write("Hello World!");
            Console.WriteLine("Hello World!");
            Console.Read();

            //有符号的整形变量,正负数
            //1,sbyte -128-到127
            sbyte sb = 1;
            //2,int   -21亿到21亿  
            //3,short  -3万多-
            //4,long  -9万到9万


            //无符号的整形变量，0-范围
            //例如：sbyte -128-127，那么范围大小位255
            //byte 0-255
            //uint 0-42亿
            //ushort 0-65535
            //ulong 0-18万



            //浮点数
            //5,float
            //保存7/8位有效数字，从左开始非0开始算有效数字，最后面要加f/F
            float f = 1.0000f;
            //如果没有加f，默认小数都是double
            //6,double,存储有效15-17位有效数字
            double d = 0.1111;

            //7， decimal,C#特有的，
            //存储有效有效数字27-28位，不建议使用,最后加m/M
            decimal de = 0.1111111111111111111111111111111111111111m;


            //特殊类型
            //8,bool

            //9,char,一个字符
            char c = '人';

            //引用类型
           //10,string





        }
    }
}
