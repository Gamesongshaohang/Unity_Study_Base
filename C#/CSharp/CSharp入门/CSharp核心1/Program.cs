using System;

namespace CSharp核心1
{


    /// <summary>
    ///  c#的面向对象，与java一样，只有部分不同，关键字，语法有些许不同
    /// </summary>
    /// 

    //注意点：在结构体与clss也一样在自己内部声明实例化产生自己类型例如：Person内里，写Person p=new Person(),不要实例化
    //会死循环，堆内存溢出，像单例模式用到了必须声明只实例化一次


    //类对象，类声明出来的对象，类的实例对象
    //对象的引用（地址）：栈中，对象：堆中
    //栈存放快，但空间小，堆：空间大，获取的慢



    #region 成员修饰符
 /*   与java类似一共有3个,最大的不同是，默认不写c#是private
  *   private
  *   public
  *   protect
  *   
  *   
*/
    #endregion


    class Person {
        public String name;
        public int age;
        //构造函数与几乎java一摸一样,与java不同的是，类中调用其构造函数时，也是默认不写则是默认创建一个无参的构造函数
        //java的写法时this(),this(参数)这样 ：java是写在方法体类且一定要在首行
        //C#的写法方法名后：this(),this(10)  例子： public Person(int age,String name): this()
        public Person()
        {
            this.name = name;
        }
        public Person(String name) :this()
        {
            this.name = name; 
        }

        public Person(int age,String name): this(name)

        {
            this.age = age;            
        }
        public void add()
        
        {
           
        
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            //成员变量:类上定义的变量
            //成员变量的初始值
            //当实例化对象后，对象内的变量默认自己初始化
            //数字类型为0，bool位false，引用类型为null,有一个关键子：default（数据类型），可以看其默认值，作用不大



         
            //与java一样，成员加了修饰符，外部类调用有对应的权限
            //析构函数：了解，对应有自动垃圾回收机制的GC,几乎不可能用到
            //概念：手动管理内存，做一些内存回收处理

         

        }
    }
}
