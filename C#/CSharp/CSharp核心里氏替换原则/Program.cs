using System;

namespace CSharp核心里氏替换原则
{

    #region 核心里氏替换原则
    //核心里氏替换原则的概念：面向对象的7大原则中最重要的
    //概念：子类的对象以父类来表现（其实java中学习的向上向下转型那里）

    //语法表现：父类容器（类型），子类对象
    //作用：方便进行对象的存储和管理
    #endregion
    class Program
    {
        class Person {

            public void show() {
                Console.WriteLine("父类show");
            }
        
        }
        class Student:Person
        {

            public void show1()
            {
                Console.WriteLine("学生类show");
            }
        }
        class Teacher : Person
        {
            public void show1()
            {
                Console.WriteLine("教师类show");
            }

        }




        static void Main(string[] args)
        {
            Person p = new Student();//其实就是java向上转型，
            Person p1 = new Teacher();
            Person[] p2 = new Person[] { new Student(),new Teacher()};
            p.show();
            p1.show();

            //在java中学就知道，向上转型只能使用父类的方法，想要使用子类自己的方法得强制向下转型
            //而在c#中转换使用关键字 as




            //is:与java的instanceof类型，  判断对象是否为指定对象，返回bool
            //as：将对象转为指定的类对象类型，成功返回类对象


            if (p is Student)
            {
                Student stu = p as Student; //向下转型
                stu.show1();

            }
            else if (p1 is Teacher ) {
                Teacher tea = p1 as Teacher;
                tea.show1();
            };
        }
    }
}
