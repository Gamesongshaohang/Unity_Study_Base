using System;

namespace CSharp核心抽象类与抽象方法
{

    //几乎与java一摸一样，不能实例化，抽象类不能私有，抽象方法没有方法体。关键字：abstrct
    //区别，C#重写父类方法时，override关键字要加上




    //虚函数搭配重写与抽象方法搭配重写的区别

    //1，虚函数有方法体，抽象方法没有
    //2，虚函数时可选的，子类继承时可以选择不重写，而抽象方法不行
    //3，抽象方法只能写在抽象类中，虚函数随意





    public abstract class Father {

        public abstract void Add();

        public virtual void show() { }
    
    
    }
    public  class Son:Father
    {

  

        public override void Add()
        {
            Console.WriteLine();
        }
        public override void show() { }
    }



    class Program
    {


        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
