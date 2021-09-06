using System;

namespace _9_1CSharp可变参数与可选参数
{
    class Program
    {



        #region 变长参数/可变参数

        //与java1.5特性中的可变参数类似,c#这里用关键字:params修饰参数

        //注意点：
        /* 
         * 
         1，params关键字后面跟的必须是数组（任意类型数组）
         2，可变参数可以与普通参数一起混用
         3，函数可变参数最多只能出现一个params关键字，而且与其他普通参数混用时，必须放在最后面
         */

        #region 可选参数
        //可选参数：有默认值的参数就是可选参数
        //作用：当调用函数不传值时使用默认值作为参数的值
        /*
                注意点：
                 1，支持多参数默认值，没个参数都可以有默认值
                 2，如果混用普通与可选参数，可选参数要放在最后（不放在最后，系统如何知道你传入的参数是给可选参数还是给可选参数后面的普通参数）


        */

        static void add1(string str1,string str2="shao",string str3="hang") {
            Console.WriteLine(str1+str2+str3);
        }
        #endregion



        //这里补充一点：函数重载跟java一摸一样，不同的是c#有ref与out关键字
        //加了ref与out的参数也不不同的，相当于传进的是地址
        //也是方法重载
        static void Num(string str){ }
        static void Num(ref string str) { }
       
        static void Num( string str,string str1) { }
        static void Num(string str, out string str1) {
            str1 = "";
        }
        static void add(params String[] str ) { 
        
        
        
        }



        #endregion

        //可变参数
        static void Main(string[] args)
        {
            add();
            add("1","2","ss");
            add1("song");






            


        }
    }
}
