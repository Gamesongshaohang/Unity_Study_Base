using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{


    #region lambad表达式
    //lambad表达式：匿名函数的简写
    //除了匿名函数写法不同外一模一样
    //都是配合委托事件配合使用
    #endregion
    #region lambad表达式语法
    //匿名函数
    //delegate(参数列表){};

    //lambad表达式语法
    //（参数列表）=>{//函数体};


    class Test
    {     //1,无惨无返回值
        Action a = () => { };
        //有参
        Action<int> b = (int value) =>
        { };

        //3,可以省略掉参数类型，参数类型与委托或者事件容器一样
        Action<int> b1 = (value) =>
        { };

        //有返回值
        Func<string> c = () => { return "ssh"; };

        //调用
        public void Show()
        {
            a();
            b(1);
            b1(2);
            c();
        }

        //其他传参使用上和匿名函数一样
        //缺点也和匿名函数一样

    }
    #endregion

    #region 闭包
    //发生在匿名函数中，闭包主要用在访问外层函数定义的变量上。
    //内层函数可以引用包含在他外层的函数的变量,即使外层函数执行完，变量应该被释放。但是此时会被改变生命周期

    //注意：该变量提供的值并非变量创建时的值，而是在父函数内的最终值

    //使用闭包减少工作量

    class BiBag
    {


        public event Action action;

        public void Wai()
        {

            int value = 10;

            //这里行成了闭包，value为临时变量，当wai执行完，value应该被释放才对，
            //但是被内部方法使用该变量,使value的生命周期改变，只有当action清空时，value才会被释放。
            action = () => {
                Console.WriteLine(value);
            };
            int o = 1000;
            if (o >= 1000)
            {

                action += () => {
                    Console.WriteLine(o);
                };
            }

            //注意：该变量提供的值并非变量创建时的值，而是在父函数内的最终值
            for (int i = 0; i < 10; i++)
            {


                //
                action += () => {
                    Console.WriteLine("i的值" + i);//这里的i打印会是i最终的值全是10而不是0-9,什么时候会使用到i呢，当使用到i时，wai函数for循环早已结束，此时i传入的i是i的值是10时不满足的条件时的值
                                                 //内函数获取的是父函数Wai中for循环的i这个临时变量的最终值

                    //闭包陷阱:将匿名函数引用的变量用一个临时变量保存下来，然后在匿名函数中使用临时变量
                    //要想输出1-10，可以在for循环定义变量index接收i，再打印index即可。因为index创建了9个，不同于i



                };



            }



        }


        public void show()
        {

            action();
        }



    }


    #endregion





    class Program
    {
        static void Main(string[] args)
        {
            BiBag b = new BiBag();
            b.Wai();
            b.show();
            Console.ReadKey();
            //
        }
    }
}
