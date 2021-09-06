using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public delegate void MyDelegate1();
namespace 委托_Delegate_
{


    #region 委托（Delegate）
    //概述：委托（Delegate）：类似C中的函数指针。是一种引用类型变量：存的是某个方法的引用，引用在运行时可以被改变
    //委托特别用于实现事件和回调方法

    //委托：委托个类从数据结构上讲是是一种用户自定义类型   
    //从设计模式上讲，委托（类）提供了方法的抽象
    //但委托不是普通的方法，因为 它也是类，

    //委托是方法的抽象,他存储的就是一系列具有相同签名和返回类型的方法和地址.调用委托的时候,委托包含的所有方法将被执行.


    //客观解释:委托就是一个类,他定义了方法的类型,使得可以将方法当做另一个方法的参数来进行传递,
    //这种将方法动态地赋给参数的做法,可以避免在程序中大量使用if else 或 switch 语句,同时使得程序具有更好的可扩展性.


    //可以这样理解，委托是定义了规则，并且可以存储符合这规则的函数



    #region 委托的声明

    //可以写在的地方？namespace与class都可以

    //委托是方法的引用，所以跟方法的声明类似，跟抽象方法类似
    //语法：delegate 返回值类型 委托名（参数列表）;
    //委托的步骤：1声明委托，2，实例化委托，委托中指定关联方法（关联的这个方法需要与声明的委托的返回值，参数都一致）
    //3使用实例化的委托对象（这个对象相当于方法的引用），像方法一样使用即可。


    public delegate int MyDelegate(string s);//定义了一个可以用来存储字符串参数返回为int函数的容器（


    class DelegateApp
    {

        public static int add(string s)
        {

            Console.WriteLine("实例化委托1");
            return 10;
        }
        public static void add1()
        {
            Console.WriteLine("实例化委托2");

        }
        public static void add2(string s)
        {
            Console.WriteLine("实例化委托2");

        }
        public static int add3()
        {
            Console.WriteLine("实例化委托2");
            return default(int);
        }


    }
    #endregion


    #region 系统自带的委托
    //命名空间 using.System
    //一般而言其实不用自己定义委托，使用系统自带就可以了。

   

    class WeiTuo
    {
        //第一个，Action无参无返回值委托
        Action action = DelegateApp.add1;

        //第2个，Action有参无返回值委托,可以传入16个参数
        Action<string> action1= DelegateApp.add2;

        //第3个，有返回值无参委托 Func,
        Func<int> func = DelegateApp.add3;

        //第4个有返回值有参 Func，返回值放在最后，一共最多可以16个参数1个返回值
        Func<string, int> func1 = DelegateApp.add;




    }
    #endregion





    #endregion
    class Program
    {

        static void Main(string[] args)
        {

            #region 委托的调用（实例化委托）
            //委托常用在：1，作为类的成员 2作为函数的参数
            //DelegateApp.add


            //把方法存储进委托的方式1
            //相当于把函数存进了容器一样，
            MyDelegate s = new MyDelegate(DelegateApp.add);  //实例化委托对象，并传入关联的方法，
            //注意：关联（存储）进委托的方法返回值和参数（规则）与委托一致
            //方式2，其实是一样的只是简化了而已
            MyDelegate s1 = DelegateApp.add;




            //调用的方式1，
            //Invoke()
            //委托变量（），效果一样
            s1.Invoke("ddd");
            s("ssh");  //实例化委托对象跟方法一样的使用，委托变量相当于间接调用函数

            #endregion
            #region 多播委托
            //委托对象（因为是引用类型可以赋值给其他引用），也可以使用“+”来合并2个委托，也就是
            //一个委托关联着2个方法，但是只能在同类型的委托才行。同样的可以用“-”
            //其实就是可以对委托容器进行增加或者删除


            MyDelegate1 md = new MyDelegate1(DelegateApp.add1);
            MyDelegate1 md1 = md;
            MyDelegate1 md2 = md1 + md;
            MyDelegate1 md3 = md2 - md1;
            md2();
            md3();


            Console.WriteLine("---把委托方法作为参数传递---");
            sendfangfa(md3);//把委托方法作为参数传递



            #endregion
            Console.WriteLine("--------- 委托最大的作用：将方法名作为方法参数传递，提高代码的多变性和灵活性-------");
            Console.ReadLine();
        }


        //把委托方法作为参数传递
        public static void sendfangfa(MyDelegate1 my)
        { 

            my();

        }
    }
}
