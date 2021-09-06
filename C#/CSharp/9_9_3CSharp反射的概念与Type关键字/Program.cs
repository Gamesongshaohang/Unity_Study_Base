using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _9_9_3CSharp反射的概念与Type关键字
{
    #region 什么是程序集
    //上次讲过：作用是将源语言程序翻译为目标语言程序
    //程序集：由编译器编译得到的,得到的这个东西就叫程序集。程序集还可以被进一步编译执行
    //在Windows系统中，它一般后缀为.dll（库文件）或者.exe可执行文件格式

    //说白点：
    //程序集就是我们所写的代码的集合，我们写的所有代码
    //最终都会被编译器翻译为一个程序供别人使用
    #endregion
    #region 元数据
    //元数据：用于描述数据的数据
    //这个概念不仅用于程序，其他领域也一样

    //程序中的类、方法、变量、等就是程序中的元数据
    //有关程序以及类型的数据被称为元数据，保存在程序集中
    #endregion
    #region 反射的概念
    //程序正在运行时，可以查看其他程序集或者自身的元数据
    //一个运行程序查看本身或者其他程序的元数据的行为就叫反射

    //程序运行时，通过反射可以得到自己或者其他程序集的代码的各种信息
    //类，函数、变量、对象等，实例化他们，执行操作他们
    #endregion
    #region 反射的作用
    //因为反射可以在程序编译后，是编译后获得的信息。所以它提高程序的拓展性和灵活性。
    //1，程序运行时得到的所有元数据，包括元数据的特效
    //2,程序运行时，实例化对象，操作对象
    //3，程序运行时创建对象，用这些对象执行任务


    //例子：别人开发的第3方程序，你没有别人的源代码，而别人只会在.dll(程序集文件)中提供了接口给你使用
    //这样别人保护了自己的代码，你又使用到了。
    //其实就是引用与反射   引用是设计前就知道了。而反射是运行时才知道的
    //开闭原则：开闭原则规定“软件中的对象（类，模块，函数等等）应该对于扩展是开放的，但是对于修改是封闭的”，
    //反射是运行时才得到的，就符合这样原则。可以访问但不能修改。
    #endregion
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



            #region Type
            //Type(元数据)类的信息类，可以理解为类的反射信息都封装到里面
            //是反射功能的基础，是访问元数据的主要方式
            //使用Type的成员获取有关类型生命的信息
            //有关类型的成员（比如：构造函数，方法，字段，属性和类的事件）

            //获取Type的3种方式
            //1,Object中的GetType()方法,返回值为Type对象
            //通过对象.GetType()获取其数据类型的Type
            int a = 10;
            Type type = a.GetType();
            Console.WriteLine(type);

            //2,通过typeof（）关键字，参数：类名 也可以得到Type对象
            Type type1 = typeof(int);
            Console.WriteLine(type1);

            //Type.GetType.通过类的名字，类名必须加上命名空间
            Type type2 = Type.GetType("System.Int32");
            Console.WriteLine(type2);

            //每一种数据类型的Type元数据都只有一份，一种类型一份。创建多个，地址指向同一份
            //例如这里：int类型的type在内存中只有一份,int也是一个类
            #endregion

            #region 得到类的程序集的信息
            //通过Type得到类型所在程序集的信息，不怎么用到
            Console.WriteLine(type.Assembly);
            #endregion


            //现在暂时例子获取自身程序集的元数据
            //一般反射不会用于获取自己的程序集的元数据.
            //不同的程序集是不能new的
            #region 获取类中的所有成员
            //命名空间：using System.Reflectction

            //首先获取Type
            Type t = typeof(Test);
            //1,得到所有公共成员
            //Type类的方法GetMembers（），获取所有公共成员。返回值是MemerInfo[]
            MemberInfo[] infos = t.GetMembers();



            #endregion
            #region 获取类的公共构造函数并调用
            //1,获取公共全部构造函数
            //Type类的方法GetConstructors（），返回值ConstructorInfo[]
            ConstructorInfo[] c = t.GetConstructors();

            //获取具体的一个构造方法并执行

            //GetConstructor(Type[] types),接收的参数是Type数组
            //type数组的元素就是构造函数参数的顺序，因为Type类型存储的是type,所以存储的是参数的type
            Type[] types1 = new Type[0]; //因为这里是无参构造，所以为空即可
            ConstructorInfo con = t.GetConstructor(types1);

            //执行构造方法invoke(object[] parameters),接收的是Object[]数组，返回类型也是Object
            //之前java就学过，私有化构造方法就相当于不能实例化。其实执行构造方式就是实例化对象
            Object obj = con.Invoke(null);
            Test t1 = obj as Test;
            Console.WriteLine(t1.j);


            //这里要注意的就是GetConstructor接收的参数类型与Invoke接收的参数类型2个的类型要匹配
            Type[] types2 = new Type[] { typeof(int) }; //获取的是单个参数的构造方法
            ConstructorInfo con1 = t.GetConstructor(types2);
            Object obj1 = con1.Invoke(new object[] { 10 });
            Test t2 = obj1 as Test;
            Console.WriteLine(t2.j);
            Console.WriteLine(t2.str);

            //总结就是GetConstructor获取构造方法
            //Invoke通过获取的对应的构造方法进行实例化






            #endregion

            #region 获取类的公共成员变量
            //获取到的是成员变量的反射信息可以理解为引用
            //Type的GetFields()返回值FieldInfo[]类型，得到所有成员变量
            FieldInfo[] f = t.GetFields();


            //得到指定名称的公共成员变量
            FieldInfo f1 = t.GetField("j");  //传入的参数是字段名称
            Console.WriteLine(f1);


            //通过反射获取和设置对象的值，上面只是获取引用
            Test tt = new Test();      //反射一般用于获取其他程序集，这里只是用这里当个例子  
            tt.j = 100;
            tt.str = "132";
            //如果是得或设置其他程序集的变量，甚至连对象都不用实例化。只是在同一程序集中显得鸡肋

            //通过反射获取对象的变量的值，变量反射信息对象的引用.GetValue(对象名);
            Console.WriteLine(f1.GetValue(tt));
            f1.SetValue(tt, 101);
            Console.WriteLine(f1.GetValue(tt));

            #endregion
            #region 通过反射获取公共成员方法并执行
            //通过Type类中的GetMethod方法得到类中的方法

            //创建string类的总反射信息
            Type strType = typeof(string);

            MethodInfo[] mInfo = strType.GetMethods();


            //获取具体的某一个方法，但是方法有重载与构造方法一样
            //public MethodInfo GetMethod(string name, Type[] types);参数1：具体的哪一个方法，参数2：如果有重载指定其参数类型

            //获取的是string类中的SubString（int i,int j）方法的反射信息
            MethodInfo MeInfo = strType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            //调用执行该方法
            //构造方法执行相当于实例化对象
            //反射中调用方法不需创建对象，但是要指出哪一个对象
            //方法反射对象.Invoke(参数1，参赛2) 1：是那个对象要执行这个成员方法，2：方法的具体实参
            string str1 = "nihaoaaa";

            object on = MeInfo.Invoke(str1, new object[] { 1, 5 }); //与构造函数调用一样与GetMethod类型对应
            Console.WriteLine(on);



            //对应静态方法的调用
            //因为静态方法与类生命周期一致，可以类名的调用
            //反射调用也需要指明对象，但是静态不用只要填入null即可
            //例如： MeInfo.Invoke(null,new object[]{ 1,5});



            #endregion
            #region 其他
            //得枚举：
            //得事件得接口得属性等都是大同小异，可以通过发f12查看Type类也可以去查api

            #endregion
            Console.ReadKey();
        }
    }
}
