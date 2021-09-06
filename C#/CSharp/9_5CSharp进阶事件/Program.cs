using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{

    //事件、匿名函数和Lambad表达式都是在委托放入基础上学的，
    //委托本质是类，是一个存储函数的容器

    //事件可以说与委托一模一样，只是事件更为安全



    #region 事件
    #region 什么是事件
    //事件是基于委托存在的
    //事件是委托的安全包裹
    //让委托更具安全性
    //事件是一种特殊的变量类型


    #region 事件的使用
    //申明语法：
    //访问修饰符 event 委托类型 事件名。

    //事件的使用：
    //1，事件是作为成员存在于类中
    //2，委托怎么使用，事件就怎么使用（2则类似）

    //事件与委托的区别？
    //1,事件不能在所在类外部  赋值（=）
    //2,事件不能在类外部      调用
    //注意：事件只能作为成员存在于类、接口和结构体中
    class Test
    {
        //声明系统的委托Action（无惨无返回值），变量myDelegate:函数容器
        public Action myDelegate;
        //事件成员变量，用于存储函数    
        public event Action myEvent;          //这里要注意了，不是说必须先声明委托变量才能声明事件变量，只是用于演示下面的例子，只要委托被创建出来，事件就能使用委托类型

        public Test()
        {
            //委托的赋值与事件的赋值与调用
            myDelegate = new Action(TestFun);
            myDelegate = TestFun;      //之前讲过2种方式是一样的
            myDelegate += myDelegate;
            myDelegate -= myDelegate;
            myDelegate();
            myDelegate.Invoke();
            myDelegate = null;

            myEvent = new Action(TestFun);
            myEvent = TestFun;
            myEvent += myEvent;
            myEvent -= myEvent;
            myEvent();
            myEvent.Invoke();
            myEvent = null;

        }



        public void TestFun() { }

    }


    #endregion




    #endregion



    #endregion


    class Program
    {
        public static void Test() { }
        static void Main(string[] args)
        {
            #region 事件与委托不同点演示
            Test t = new Test();

            //1,事件不能在外部类中赋值=,委托随意
            t.myDelegate = Test;
            t.myDelegate = null;
            //t.myEvent = Test;  在外部类赋值报错
            //t.myEvent = null

            //虽然不能赋值，但是可以+=，-=,可以添加和移除函数操作
            t.myEvent += Test;
            t.myEvent -= Test;

            //事件不能在类外部调用但是委托可以
            t.myDelegate();
            t.myDelegate.Invoke();

            //t.myEvent();  不能在类外部调用,只能通过类封装提供的方法调用
            // t.myEvent.Invoke();
            #endregion

            #region 为什么有事件
            //1,防止外部随意置空赋值委托
            //2,防止外部随意调用委托
            //3,事件相当于对委托进行一次封装，让其更安全

            #endregion

        }
    }
}
