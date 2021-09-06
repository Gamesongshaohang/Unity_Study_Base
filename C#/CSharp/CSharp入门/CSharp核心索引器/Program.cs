using System;

namespace CSharp核心索引器
{

    //有几个相似的
    //1，类的创建public class 类名{} 2，结构体的创建 public struct class
    //3，成员属性的的创建public void（返回值） 命名{get，set}
    //4,索引器的创建public void this[参数]{get{},set{}}与成员属性创建有点像





    //this的三种用法：
    //1，this(),代表本类对象
    //2，构造函数后：this(),引用构造函数
    //3，索引器中的用法public void this[参数]{get{},set{}} ，this是固定的




    #region 索引器
    //知识点1，索引器的概念：让对象可以像数组一样通过索引来访问对象内其中的元素，使程序看起来更直观，更容易编写

    //知识点2，索引器语法
    //访问修饰符（public） 返回值（int） this[参数类型，参数名]
    /*    {
            内部的写法和规则与成员属性相同
            get{}
            set{}
    }
    */ 

    class Student {

        private String name;
        private int[] arr;
     public string this[int index]
        {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        
        }


    }


    #endregion




    class Program
    {

     
        static void Main(string[] args)
        {
            //索引器的调用，像数组一样
            Student stu = new Student();

            stu[1] = "dd";
            Console.WriteLine(stu[1]);

        //索引器主要作用时：比较适合于类中有数组变量时，调用访问时比较方便
        //这里不知为什么有bug不成功，以后可以演示，
        //索引器不是非必须的，但是可以需要读取这样的代码所以也是需要学的

           


        }
    }
}
