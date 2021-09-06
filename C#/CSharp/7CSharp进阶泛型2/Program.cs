using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace 泛型2
{


    #region 泛型的限定条件

    //where关键字：后面接限制，只有使用了泛型的类，方法，结构等后面才可以使用where关键字
    //1,where T：U 例如：where Q : Person  ，指定具体的限制类型，泛型类型必须是Person或者其子类

    //2,where T ：struct 类型必须是值类型，像int,struct.z
    //3,where T：class   类型必须是引用类型 类型参数必须是引用类型，包括任何类、接口、委托或数组类型
    //4,where T：<base class name>	类型参数要派生自某个基类
    //5, T：<接口名称> 类型参数必须是指定的接口或实现指定的接口。可以指定多个接口约束

    //6,,where T：new()where T：new()	类型参数要有一个public无参构造函数（注意点：而且抽象函数不行）
    //例子：






    // 泛型约束的组合使用  逗号隔开
    class Person4<T> where T: class,new()
    {

    }

    //多个泛型都拥有约束的格式,不用逗号直接后面接着写where即可



    class Person5<T,Q> where T : class, new()  where Q: struct
    {

    }


    #endregion

    class Person
    {

    }
    class Person3
    {

        public Person3(string s) { }
    }
    class Person2<T> where T : new() { }


    class student : Person { }
    interface Person1 { }
    class MYGeneric2<T> where T : Person { }
    class MYGeneric3<T> where T : Person1 { }

    class MYGeneric<T> where T : Person
    {

        public void show<Q>() where Q : Person { }

    }













    class Program
    {

        #region 泛型委托
        public delegate void Mydelegate(int i);//普通委托
        public delegate T Mydelegate1<T>(T n); //泛型委托,使用了泛型委托，那么方法参数必须为T类型


        public static void show1() { }
        public static string show2(string s)
        {
            return default(string);
        }
        public static int show3(int s)
        {

            return default(int);
        }


        //泛型方法
        public static T show4<T>(T n)
        {
            return default(T);
        }

        #endregion
        static void Main(string[] args)
        {


            Mydelegate1<string> md1 = new Mydelegate1<string>(show2);
            Mydelegate1<int> md2 = new Mydelegate1<int>(show3);

            Mydelegate1<int> md3 = new Mydelegate1<int>(show4);
            Mydelegate1<string> md4 = new Mydelegate1<string>(show4);//泛型方法搭配泛型委托


            #region 泛型限定例子
            MYGeneric<Person> my = new MYGeneric<Person>();
            MYGeneric<Person> my1 = new MYGeneric<Person>();
            my1.show<Person>();

            // Person2<Person3> p = new Person2<Person3>();,因为使用了泛型限制了new,Person3的无惨构造被有参构造顶掉所以是错误的
            #endregion


        }
    }
}
