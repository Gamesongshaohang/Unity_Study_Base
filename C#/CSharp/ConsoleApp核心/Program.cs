using System;

namespace ConsoleApp核心
{

    //这一章不重要了解看看
    #region 内部类与分部类
    //并不是非常重要，了解就好
    //内部类与java中很类似,不重要
    class Person {
        public int age;
        public const int  head=10;
        public class Body {

            class Arm { }
        
        }
    
    }

    //分部类与分部方法：不重要，了解就行
    //概念：把一个类分成几部分声明,把一个方法分成
    //关键字partial

    //注意：分部类可以写在多个脚本文件中
    //访问修饰符要一致
    //分部类中不能有重复成员

    //分布方法：
    //不能加修饰符，默认私有
    //只能在分部类中声明
    //返回值只能是void
    //可以有参数，但不能用out关键字


    partial class Student {

        int age;
        partial void show();
    }

    partial class Student
    {
        // int age;
        string name;
        partial void show() {
            Console.WriteLine();
        }
    }


    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            //访问内部类实例化：外部类.内部类（内部类相当于成员，必须public） =new 外部类.内部类();
            Person.Body pb = new Person.Body();
        }
    }
}
