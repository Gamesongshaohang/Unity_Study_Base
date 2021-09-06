using System;

namespace CSharp入门运算符
{
    class Program
    {/// <summary>
     /// 运算符
     /// </summary>
     /// <param name="args"></param>
        static void Main(string[] args)
        {

            //++，--最经典的问题

            int i = 1;
            //++在后：先用再加
            //++在前：先加再用

            Console.WriteLine(i++);
            Console.WriteLine(++i);

            #region 知识点：string.Format()
            //不同于其他语言的占位符，不是%d,%s这些
            //而是{0},{1},{2},string.Format("son{0}shang", "shao")
            Console.WriteLine(string.Format("song{0}hang{1}", "shao", 1));

            //有个控制台拼接方式与 string.Format()几乎一样的方法就不写出来了
            #endregion
            { 

            #region 知识点 位运算符
            //&，|,与运算符&& ，||区别很大
            int a = 1;
            int b = 2;
            Console.WriteLine(true && true);

            //位运算符作用：用于数值计算
            //将数值转为2进制再进行位运算
            //&：有0则0，|：有1则1
            int c = a & b;  //1：001
                            //2：010
                            //c: 000
            Console.WriteLine(c);

            int c1 = a | b;  //1：001
                             //2：010
                             //c: 011
            Console.WriteLine(c1);

            //异或 ^,相同为0，不同为1

            int c2 = a ^ b ^ a;  //1：001
                                 //2：010
                                 //c: 011

            Console.WriteLine(c2);

                //位取反 ~，了解就行
                int a1 = 5;
                //  a1=0000 0000 0000 0000 0000 0000 0000  0000 0101
                //    1111  1111  1111  1111  1111 1111 1111 1010
                //利用反码，

                //左移 <<，右移 >>
                int a3 = 5;      //101
                int c3 = a3 << 5;//10100000,160

            }
            #endregion



            #region 三目运算符
            //让代码更加简便

            int i1 = true ? 1 : 2;  //条件位true返回前面的，false返回后面的
            Console.WriteLine(i1);
            #endregion

            #region switch
            /*   switch(变量)
             *   {
             *   case:常量:
             *       代码；
             *       break;
             *       
             *    case:常量:
             *       代码；
             *       break;
             *    default;
             *      代码
             *      break;
             *   当变量==常量时，执行
             *   }

   */
            int ann3 = 10;
            switch (ann3) {
                case 10:
                    Console.WriteLine("时10");
                    break;
                default:
                    Console.WriteLine("不是10");
                    break;
            }
            #endregion



            //知识点：continute,break与java一样
            //break：跳出循环（跟循环配合使用）
            //continute: 跳出本次循环
            //增强for循环，for(数据类型 变量 in  表/数组（容器）) 与java格式：for(数据类型 变量 ： 表/数组（容器）)
        }
    }
}
