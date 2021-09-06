using System;

namespace CSharp核心Object常用方法
{


    class Person {

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            
            return "ddddddddddddd";


        }
    }
    #region Object

    #region Object知识点1,静态方法
    //Equals (跟java类似)，判断2个对象是否相等   可以重写，例如：string的Equals,重：交给左侧（第一个参数的Equals方法（比较的规则））
    //不同于java的是java都是类型.equals(类型)这样
    //C#  Equals(类型，类型)，其实也差不多，只是写法不同，c#的参考的Equals为第一个参数，而java则是参考调用它那个

    //ReferenceEquals：专门用于比较引用类型的，值类型都会返回false
    #endregion

    #region 普通方法
    //GetType（）：作用获取对象运行时的类型，反射会用到，这里先了解


    //普通方法MemberwishClone()  MemberwishClone修饰符是protect(不能为外部类使用)
    //作用：获取对象的浅拷贝对象（浅拷贝和深拷贝可以去看看）
    //该新对象的引用和老对象的引用是同一个（一体的）

    class Test {
        public int i = 1;
        public Test2 t2 = new Test2();

        // MemberwishClone修饰符是protect(不能为外部类使用),所以这里提供一public方法提供给外部使用

        public Test Clone() {


            return MemberwiseClone() as Test;  //相当于Test调用MemberwiseClone的返回值供其他类使用
        }
    }

    class Test2 {
        public int i = 2;

    }

    #endregion

    #region 虚方法
    //Equals  public virtual bool Equals(Object? obj)  可以重写该方法，使用override
    //微软对于值类型的基类 System.ValueType重写了该方法用于比较值相等而不是引用 （地址）


    //虚方法：GetHashCode: 哈希码与java一样，

    //虚方法ToString
    //返回当前对象代表的字符窜，非常常用。也经常重写
    //当我们打印时，默认就是打印对象的Tostring,但是都是没有重写的，自带的。可以选择打印的Tostring是什么




    #endregion

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //演示Equals
            Console.WriteLine(Object.Equals(1,1));
            Person p1 = new Person();
            Person p2 = new Person();
            Person p3 = p1;
            Console.WriteLine(Object.Equals(p1,p2));
            Console.WriteLine(Object.Equals(p1, p3));


            //演示ReferenceEquals
            Console.WriteLine(Object.ReferenceEquals(1, 1));
            Console.WriteLine(Object.ReferenceEquals(p1, p3));
            Console.WriteLine(Object.ReferenceEquals(p1, p3));


            //演示MemberwiseClone
            Console.WriteLine("-------------------演示MemberwiseClone---------------------");
            Test t1 = new Test();
            Test t2 = t1.Clone();
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine("-------------------没有改变前---------------------");
            Console.WriteLine("原来对象");
            Console.WriteLine(t1.i);
            Console.WriteLine(t1.t2.i); //访问t1中的t2对的i
            Console.WriteLine("克隆对象");
            Console.WriteLine(t2.i);
            Console.WriteLine(t2.t2.i); //访问t1中的t2对的i

            Console.WriteLine("-------------------改变克隆体信息后的变化区别---------------------");

            t2.i = 20;     //改变的是值类型
            t2.t2.i = 21;  //改变的是Test2对象类型，也就引用类型

            Console.WriteLine("原来对象");
            Console.WriteLine(t1.i);
            Console.WriteLine(t1.t2.i); //访问t1中的t2对的i
            Console.WriteLine("克隆对象");
            Console.WriteLine(t2.i);
            Console.WriteLine(t2.t2.i); //访问t1中的t2对的i

            //结论：浅拷贝的对象与原对象，新老对象的引用类型是同一个，改变则变化。而值类型不受改变，新对象的值类型改变不会影响老对象

            string str = "sss";
            string str2 = "sss1";

            Equals(str,str2);

        }
    }
}
