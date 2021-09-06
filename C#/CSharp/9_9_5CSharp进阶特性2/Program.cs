using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _9_9_5CSharp进阶特性2
{

    #region 特性是什么
    //说白话：
    //特性本质是类
    //我们可以利用特性类为元数据添加额外信息
    //它可以说放置任意声明中
    //之后可以通过反射来获取这些额外的信息
    #endregion

    #region 自定义特性
    //继承特性基类 Attribute

    //特性名字一般为功能+Attribute  Attribute:在调用时会被省略
    class MyCustomAttribute : Attribute
    {
        public string info;
        public MyCustomAttribute(string info)
        {
            this.info = info;
        }

    }
    #endregion
    #region 特性的使用
    //基本语法
    //[特性名（参数列表）]  本质上就是调用特性类的构造方法
    //书写的位置？
    //类，函数，变量的上一行，表示为它们添加特性信息



    [MyCustom("这是为类添加特性")]            //特性名：省略了Attribute
    class Test
    {

        [MyCustom("这是为变量添加特性")]
        public int value;

        [MyCustom("这是为方法添加特性")]
        public void show([MyCustom("这是为参数添加特性")] int value) { }


    }


    #endregion



    #region 限制自定义特性的使用范围
    //通过为特性类 加特性（系统特性） 限制其使用范围
    //参数1（AttributeTargets），指定特性类能够使用在哪些地方，可以使用|则可以多选
    //参数2.（AllowMultiple），是否一个位置可以添加一个以上的特性
    //参数3（Inherited），说白了，就是继承或者特性类中被重写后的类和方法是否也拥有该特性
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = true, Inherited = true)]





    public class MyCustom2Attribute : Attribute { }
    #endregion
    #region 知识点5系统自带的特性 -- 过时特性
    //过时特性
    //Obsolte
    //用于提示用户，使用的方法等成员已经过时，建议使用新方法
    //一般加在函前的特性
    class Test2
    {
        [Obsolete("OldFun已经过时", false)]    //参数1.，提示内容，参数2，true:使用该方法报错  false:警告
        public void OldFun() { }             //当别人使用这个时会提示
        public void NewFun() { }



    }
    #endregion
    #region 系统自带的特性 -- 调用者信息的特性（了解）
    //[CallerFilePath]
    //告诉你哪一行调用了

    class person : Attribute
    {
        //打印a,b,c那么会打印1，那个文件调用了CallerFilePath特性
        //哪一行调用了CallerMemberName
        //哪一个函数调用了CallerLineNumber

        //一般用于查找错位，也可以用于trycatch中，很少用到
        public void show([CallerFilePath] string a = "", [CallerMemberName] string b = "", [CallerLineNumber] int s = 0) { }
    }

    #endregion

    #region 知识点7 系统自带特性--条件编译特性
    //Conditional
    //与预处理define配合使用
    //命名空间：using System.Diagnostics;
    //主要可以用在一些调试代码上
    //有时想执行有时却不想执行的代码

    //什么意思呢？在主类中创建方法show
    //发现加了Conditional，方法不能执行

    //方法加了Conditional特性，参数：为define定义的符号。如果没有预处理指令#define定义了这个符号
    //那么方法不会被编译就更不会被执行

    #endregion

    #region 知识点8 系统自带的特性--外部dll包函数特性
    //DllImport

    //用来标记非C#(.Net)的函数，表明该函数在一个外部的dll中定义
    //一般用来调用c或者c++中的dll写好的方法




    #endregion
    class Program
    {
        [Conditional("KEYi")]
        static void show()
        {
            Console.WriteLine("-------------");
        }
        static void Main(string[] args)
        {
            show();

            #region 特性的使用
            Type t = typeof(Test);
            FieldInfo ff = t.GetField("value");//获取变量的反射
            //判断是否使用（添加了某个特性）Type类中方法IsDefined(Type attributeType, bool inherit),参数1：传入特性类的Type,参数2：bool，是否找其父类是否具有特性。如果是属性和事件不用填此参数
            if (t.IsDefined(typeof(MyCustomAttribute), false))
                Console.WriteLine("Test类添加了MyCustomAttribute特性");

            //IsDefined不会去找类中的成员有没有使用特性，如果想判断单独再判断

            //GetCustomAttributes，通过反射对象，可以获取特性信息
            Object[] arr = t.GetCustomAttributes(true);//这个参数与上面的一样，是否判断继承链（是否找父类）
            Object[] arr1 = ff.GetCustomAttributes(true);//这个参数与上面的一样，是否判断继承链（是否找父类）

            for (int i = 0; i < arr.Length; i++)
            {
                //回忆：as：转换类型  is:判断类型


                //调用特性内的方法或者成员变量
                //把Object转为MyCustomAttribute
                MyCustomAttribute my = arr[i] as MyCustomAttribute;
                Console.WriteLine("-----------------");
                Console.WriteLine(my.info);
            }

            #endregion
            Console.ReadKey();
        }
    }
}
