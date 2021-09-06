using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9_9CSharp进阶多线程
{


    #region 线程与进程
    //因为在java中也学过，概念就稍微
    //进程：系统进行资源分配和调度的基本单位
    //进程互不干扰独立


    //什么是线程
    //操作系统中能运行调度的最小单位
    //被包含在进程中，是进程中实际运作单位。一进程可以并发多个线程
    //可以简单的理解为:我们制作的是进程，但是代码实际是在进程下的线程中执行的
    #endregion




    class Program
    {

        static void Main(string[] args)
        {


            #region C#多线程语法
            //线程类 Thread
            //命名空间：using System.Threading;
            //1，声明一个新的线程
            //线程要执行的代码 需要封装到一个函数中，像java的run方法

            //public Thread(ThreadStart start);构造方法，接收一个ThreadStart类型
            //ThreadStart是一个委托，接收的函数是无参无返回值的
            //新线程要执行的代码被封装到一个函数中
            Thread thread = new Thread(run);

            //2,启动线程
            thread.Start();

            //3,设置为后台线程
            //后台线程：默认新创建的线程都为前台线程。前台线程结束时，整个程序就结束了，即使后台线程还在运行。
            //这就有个问题：主线程为前台线程，一般我们都是当主线程结束了程序就结束才对。但是如果我们新建的
            //线程默认也为前台线程，主函数结束了但是其还是没有结束，导致整个应用程序无法停止了。

            //所以我们可以设置其为后台线程，受主线程影响。主线程关闭他也关闭
            //这里我们是
            thread.IsBackground = true;


            //关闭释放线程
            //1,代码执行完,不用关
            //2，死循环的情况
            //2.1设置bool标示,结束循环，跟java一样
            //2.2Abort():在某些C#（.Net）版本是无法停止 会报错
            thread.Abort();
            thread = null;


            //线程休眠Sleep  传入的是毫秒数1s=1000ms
            //其实c#中很多方法像java一样，但是unity前台程序代码为主暂时用不到那么多
            //像A*寻路这些可能用到，线程池什么的。
            Console.ReadKey();      //检测玩家输入，输入为主线程结束  
            #endregion

            #region 线程之间的共享数据
            //多个线程的内存共享
            //所以注意：多线程同时操作同一片内存区域是会可能出问题。跟java一样，操作共享数据时
            //需要通过加锁避免问题，具体可以看会java那块

            //C#中的加锁:lock(引用类型对象){代码块}
            //跟java一样，代码块中放入共享的代码块。与java的sychronized类似

            #endregion

            #region 多线程对于游戏的意义
            //可以用多线程专门处理一些耗时的逻辑
            //例如：寻路，网络通信等
            //：例子：寻路比较复杂，可以让主线程执行简单的逻辑，让新开的线程处理复杂的逻辑
            //因为是共享内存空间，当新开线程处理完，主线程再拿来用可以获得更顺畅的
            #endregion
        }


        static void run()
        {
            while (true)
                Console.WriteLine("新开的线程");
        }
    }
}
