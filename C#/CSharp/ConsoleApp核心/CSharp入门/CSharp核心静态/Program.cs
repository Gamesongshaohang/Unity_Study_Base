using System;

namespace CSharp核心静态
{
  
    class Program
    {
        #region 静态
        //跟java有一点不同，static与public位置可以互换

        public static void  add(){}
        static public void ass() {}

        //可以修饰
        #endregion
        //回忆
        //1，方法创建public static add(){}
        //2,类的创建 class Person{}
        //3，结构体的创建 struct p{}
        //4, 索引器的创建 public void this[]{get{};set{}}
        //5,成员属性的创建 public String Name{get{};set{}]

        //重要：静态与类（程序）共存，声明周期长，其实与java一样，只有类一加载就会分配内存给静态。而实例化同样是为了分配内存
        //唯一性（独立内存），全局性（点调用）
        //注意；与java一样静态成员不能使用成员变量，反之可以，其实就是生命周期的问题




        //C#与java的异同点：const关键字，在c#中可以使用const关键字来定义常量，const定义常量可以类名点调用，这是java做不到的


        //知识点：常量与静态变量的区别
        //1，都可以类名点调用

        //不同
        //const必须要初始化先，
        //const只能修饰变量，static可以修饰很多（几何所有）
        //const写在访问修饰符后，static没有
        
     


        static void Main(string[] args)
        {

        
          //  Person.b;
            const int a = 10;

            //const必须要先初始化，
            //const int b;
            Console.WriteLine(person.a);
            Console.WriteLine(person.b);
        }
    }

    public class person
    {
        public const int a = 10;
        public static int b = 10;
    }
}
