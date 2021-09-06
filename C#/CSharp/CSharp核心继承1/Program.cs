using System;

namespace CSharp核心继承1
{




    #region 继承
    //c#的继承与java很像

    //不同点1，语法：java是关键字extends,实现。而
    //c#继承语法：class 子类名：父类{}


    //修饰符
    //protect:只能内部和子类访问
    //internal(后面讲)，内部的，只有在 同一个程序集的文件中，内部类型或者成员才可以访问


    class Person {

        public string name;
        public void show() {
            Console.WriteLine("Person的方法");
        }
        public Person()
        {

            //this.name = name;
           Console.WriteLine("Person父类的构造方法初始化", name);

        }


    }

    class Student : Person
    {
     

    }







    #endregion









    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            Student s1 = new Student("song");
        }
    }
}
