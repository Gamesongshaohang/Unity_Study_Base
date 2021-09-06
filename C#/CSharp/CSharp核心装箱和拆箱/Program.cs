using System;

namespace CSharp核心装箱和拆箱
{
    #region 密封类
    //其实就是让类无法被继承，就是java中的最终类，java中用fanal修饰，
    //关键字：sealed修饰类，最终类
    //保证程序的安全性，规范性
    sealed class Father { }
   /* class Son : Father { }*/
    #endregion

    #region 装箱与拆箱


    class Person { }
    class Student : Person{ }


    #endregion
    class Program
    {



        static void Main(string[] args)
        {

            //上节课得关键字as:转换类型，但是一般只能用于向下转型，也就是原来的类型要转与换成得类型为继承关系，所有可以用（）强制转换
            Person p = new Person();
            Student s= p as Student;

           //强制转换
            Student s1 = (Student)p;


            //装箱：值类型-》Object类型，栈内存移动到堆内存
            //拆箱：Object类型-》值类型，堆内存移动到栈内存

            //好处：Object，可以接受任何类型的参数类型，最大的好处就是方便
            //坏处：存在内存迁移，增加性能的消耗

            //记得java也有这个，不过泛型后应该很好用这个
            //注意：虽然有时很方便，但是不能常用，性能消耗


            Object o = 10;//装箱，值类型用Object类型存储（表示），堆内存存储

            int i = (int)o;//拆箱：把Object类型转为值类型（转到栈内存）


            Console.WriteLine("Hello World!");
        }

        public void add(params string[] str) { //params:变长参数
        
        }
        public void add(params Object[] str)
        { //params:变长参数

        }

       




    }
}
