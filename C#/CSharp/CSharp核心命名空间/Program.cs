using System;
using Ns1;   //导入命名空间



  #region 命名空间
//概念：其实就是java中的包的概念
//关键字namespace using(导入)


namespace Ns1
{
    class Person
    {


    }


}
namespace Ns2
{


    class Student { }

}
namespace Ns2
{


    class Person { }

}



#endregion
namespace CSharp核心命名空间
{





    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();//其实Console方法就是System命名空间里的方法

            //命名空间的2使用的2种方式：
            //方式1 using 命名空间
            //方式2 指明命名空间   命名空间.类/方法等

            Ns2.Student ns = new Ns2.Student();

            //注意2，命名空间可以分开写，跟分部类一样
            //注意3，不命名空间中可以出现一样的类名，但是这时不要使用using这种方式，使用指明命名空间这种方式


            Ns1.Person ns1 = new Ns1.Person();
            Ns2.Person ns2 = new Ns2.Person();
         

            //注意4，不同命名空间可以相互调用
            //注意5，命名空间中可以嵌套，调用方法，命名空间.命名空间

            //注意6，修饰类的修饰符
            //public 
            //internal 只能再该程序集使用（程序集：解决方案下的），了解就好
            //abstract
            //sealed  密封
            //partial 分部类


            //快捷键f12可以查看代码的详情api

        }
    }
}
