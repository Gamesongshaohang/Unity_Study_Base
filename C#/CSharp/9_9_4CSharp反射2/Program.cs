using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _9_9_4CSharp反射2
{

    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "123";
        public Test() { }
        public Test(int j) { this.j = j; }
        public Test(int i, string str) : this(i) //调用前面的构造函数
        {
            this.str = str;
        }
        public void Speak()
        {
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Activatior
            //我们之前讲的时候，想要实例化对象是先获取其构造方法在调用。很麻烦，代码还多还不好理解。
            //Activatior类：用于快速简单的实例化对象
            //Activatior.CreateInstance(),传入的参数为类的总的反射信息对象，返回值为Object
            //创建Test类的反射对象
            Type testType = typeof(Test);
            //实例化对象，通过传入反射总对象
            Object obj = Activator.CreateInstance(testType);
            Test test = obj as Test;
            Console.WriteLine(test.j);

            //实例化有参构造方法，CreateInstance（）第一个参数为类反射对象，后面的为实参数
            Object obj1 = Activator.CreateInstance(testType, 10);
            Test test1 = obj1 as Test;
            Console.WriteLine(test1.j);



            #endregion
            #region Assembly


            //Assembly：程序集类
            //主要用来加载其他程序集，加载后才能通过Type使用其他程序集的信息
            //比如其他程序集的dll文件（库文件）
            //简单把库文件看成一种代码仓库，它给使用者一些可以直接使用的变量函数和类

            //三种加载程序集的函数
            //Assembly.Load(“程序集名”)，用于加载同一文件夹下的其他程序集

            //加载不同文件下程序集
            //Assembly.LoadFrom("全路径")
            //Assembly.LoadFile("相对路径")
            //@：作用：取消转义字符
            Assembly assembly = Assembly.LoadFrom(@"E:\CSharp\CSharp进阶被反射访问的程序集dll\bin\Debug\netcoreapp3.1\CSharp进阶被反射访问的程序集dll.dll");

            //Assembly程序集类:GetType()：获取指定程序集中的所有信息
            Type[] type = assembly.GetTypes();
            //因为使用的其他程序集很可能不是自己写的，所有打印一下看一下有什么
            for (int i = 0; i < type.Length; i++)
            {
                Console.WriteLine(type[i]);
            }

            //反射最大的作用：自己的程序内实例化别人程序集内（使用别人的程序集）的代码使用

            //获取具体的程序集中的类对象,这时候获取到就是类的反射对象，接下来就跟之前学的一样，使用变量，方法等
            Type class1 = assembly.GetType("CSharp进阶被反射访问的程序集dll.Class1");

            MemberInfo[] meInfo = class1.GetMembers();

            for (int i = 0; i < meInfo.Length; i++)
            {
                Console.WriteLine(meInfo[i]);
            }

            Object obj3 = Activator.CreateInstance(class1); //创建实例

            #endregion

            #region 类库工程的创建
            //.dll文件的创建。新建项目时可以选择，然后点击内库文件生成

            #endregion


            #region 总结
            //反射：在程序运行时，通过反射可以得到其他程序集或者自己的程序集代码的各种信息
            //类、函数、变量、对象等等，实例化，执行他们、操作他们

            //关键类
            //Type
            //Assembly
            //Activator
            //为了之后学习Unity引擎的基本工作原理做铺垫，Unity引起的基本工作机制，就是建立在反射的基础上

            #endregion
            Console.ReadKey();
        }
    }
}
