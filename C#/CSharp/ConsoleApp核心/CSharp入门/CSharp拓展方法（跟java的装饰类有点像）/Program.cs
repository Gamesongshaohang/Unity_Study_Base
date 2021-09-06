using System;

namespace CSharp拓展方法_跟java的装饰类有点像_
{


    #region 拓展方法
    //概念：在不继承不改变原有类的基础上，为非静态（不能是静态的）的变量类型（包括系统的int,string这些也包括自定义的），添加新方法
    //作用
    //只能给非静态的拓展
    //1，提升程序拓展性
    //2，不需要再对对象重新方法
    //3，不需要继承来拓展方法
    //4，为其他人封装的类型写额外方法，不改变别人的代码

    //注意：1，拓展方法一定写在静态类中
    //2，拓展方法必须静态修饰
    //3，拓展方法的第一个参数是指定要为哪个变量（int,或者自定义类等），用this修饰，后面的参数才是方法的参数
    #endregion

    #region 基本语法
    //public static void TuoZhanFun(this int a,参数，参数)   注意：这里的int是指定要拓展的对象，这里可以拓展int变量，而a是对象的值
    //因为要int b=10;定义了int类对变量才可以使用，而a就是10
    //
    public class Person {
        public void add() { }

    }
    public struct Student{



}
    
    public static class Tool{

        public static void TuoZhanFun(this int a) {

            Console.WriteLine("为int拓展一个方法TuoZhanFun"+a);
        }
       public   static void TuoZhanFun(this Person a)
        {

            Console.WriteLine("为Person拓展一个方法TuoZhanFun" + a);
        }
        public static void TuoZhanFun(this Student a)
        {

            Console.WriteLine("为Student结构体拓展一个方法TuoZhanFun" + a);
        }

    }

    #endregion



    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            a.TuoZhanFun();


            Person p = new Person();
            p.add();
            p.TuoZhanFun();


            Student s = new Student();
            s.TuoZhanFun();

            //注意：当为某变量类型拓展的方法名与变量本身的方法名相同时，调用的是其自身的方法
        }
    }
}
