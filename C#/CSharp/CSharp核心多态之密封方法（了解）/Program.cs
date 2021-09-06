using System;

namespace CSharp核心多态之密封方法_了解_
{

    //密封方法与密封函数类型 使用关键字sele
    //当使用sealed修饰后，函数不能再被重写，在本方法为最终方法

    //注意：sealed几乎要与override一起使用
    //作用：让虚方法和抽象方法不能再被子类重写

   abstract class Person {

       public  virtual void show() {
            Console.WriteLine();
        }

        public abstract void show1();


    }


    class Student:Person {
       public sealed override void show() {
            Console.WriteLine("重写");
                
                
                
                }
       public sealed override void show1() {
            Console.WriteLine("重写2");


        }
    
    
    }


    class Stu : Student {

    /*    public override void show()
        {
            Console.WriteLine("重写");*/



        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Student();
            p.show();
            p.show1();

        }
    }
}
