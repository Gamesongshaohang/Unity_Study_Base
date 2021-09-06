using System;

namespace CSharp入门3类转换
{
    class Program
    {

        /// <summary>
        /// 类型转换
        /// </summary>
        static void Main(string[] args)
        {
            //大范围转小范围：隐式转换
            //C#的一个特殊,decimal不能隐式的转换成double,float
            decimal de = 1.1m;
            double d = 1;
            float f = 1f;

            //显示转化，强制转化，有可能损失精度，存在异常，尽量不要
            short s = 1;
            int i = 1000;
            s = (short)i;
            Console.WriteLine(s);



            //字符串转为对应的类型
            //语法：变量类型.Parse("字符串")
            //例如：int.Parse("123"),123必须为int，是可以转成int的数值,并且要符合int的范围大小
            int i1 = int.Parse("123");
            Console.WriteLine(i1);


            #region  Convert，可以转字符串和数值,最推荐的写法，精度比强制好一点，会四舍五入
            //知识点3,这是java所没有的作用:更为准确的将各个类型之间进行转换
            //语法： Convert.To目标类型(变量或者常量)

            //字符串转--数值
            
            int a = Convert.ToInt32("12");   //这种时候跟Parse一样，变量或者常量也必须合法合规
            Console.WriteLine(a);
           //数值类型间转换
            int a1 = Convert.ToInt32(12.5f);   //这种时候跟Parse一样，变量或者常量也必须合法合规
            Console.WriteLine(a1);


            //而且强制不能转的bool与数值间的强制转换，它也可以
            int b1 = Convert.ToInt32(true);
            Console.WriteLine(b1); //true转为数值类型是1，false是0



            //特殊的
            // int 32位 ToInt32就是int，
            // short 16位 ToInt16就是short
            //long 64位  ToInt16就是long


            // uint 32位 ToUIInt32就是int，
            //ushort 16位 ToUIInt16就是short
            //ulong 64位  ToUIInt16就是long
            //float TOSingle

            #endregion


            #region 最常用：其他类型转string
            //语法：变量.tostring

            string str = 1.ToString();
            string st1r = true.ToString();

            //字符串拼接时自动调用toString

            #endregion


            //异常处理与java十分类似
        }
    }
}
