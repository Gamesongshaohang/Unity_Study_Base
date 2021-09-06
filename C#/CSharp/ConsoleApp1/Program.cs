using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            AbsTarget GZH = new Target();//目标：公众号
            GZH.Add(new ZhanSan());
            GZH.Add(new LiShi());
            GZH.NoticeAll();


            List<int> l = new List<int>();
            Console.WriteLine(l.Capacity);
            l.Add(1);
            Console.WriteLine(l.Capacity);
            l.Add(1);
            l.Add(1);
            l.Add(1);
            l.Add(1);
            Console.WriteLine(l.Capacity);




            #region 观察者模式
            //观察者模式：定义了一种一对多的关系，可以让多个对象同时监听一个对象
            //当这个对象发生变化时，通知所有观察者对象，观察者模式支持广播通信。发布订阅模式
            //被观察者会向所有的注册过的观察者发出通知
            //解决了当一个对象的改变需要同时改变多个其他对象”的问题


            //大概实现就是
            //抽象目标：主要抽象目标者把所有观察者对象的引用保存在一个列表，并提供增加和删除操作，以及通知观察抽象方法
            //具体目标：主要实现通知所有观察者的具体实现，把观察者列表遍历然后全部调用其的响应方法
            //抽象观察者：抽象的响应的方法
            //具体观察者：实现响应的具体实现



            //例如：一个公众号，多个用户
            //目标与观察者之间的依赖性是很低的，
            //例如：微信公众号：目标  观察者：不同的用户，用户可以随时取消订阅

            #endregion
            #region 通过一个功能来理解观察者模式
            //需求：微信公众号，用户订阅

            //目标：公众号
            //观察者者：用户
            //因为面向抽象接口编程所以又分了，抽象和具体的目标与观察者



            #endregion
        }
    }


    /// <summary>
    /// 抽象目标：微信公众号
    /// 主要：提供了用于保存和删除观察者对象的聚集类
    /// </summary>
    abstract class AbsTarget {

        public List<User> observers = new List<User>();

        //增加观察者的方法，也就是增加用户的方法
        public void Add(User observer) {
            observers.Add(observer);
        }

        //删除观察者的方法
        public void Delete(User observer)
        {
            observers.Remove(observer);
        }

        //提供通知所有观察者的方法
        public abstract void NoticeAll();

    }

    /// <summary>
    /// 具体目标：
    /// </summary>
    class Target : AbsTarget
    {
        public override void NoticeAll()
        {
            
            Console.WriteLine("通知了所有用户");
            foreach (User obs in observers) {
                obs.response();
            };
        }
    }

    /// <summary>
    /// 抽象观察者：
    /// </summary>
    abstract class User {

        public abstract void response();
    }


    /// <summary>
    /// 具体观察者：
    /// </summary>
    class ZhanSan : User
    {
        public override void response()
        {
            Console.WriteLine("张三得到消息");
        }
    }
    class LiShi : User
    {
        public override void response()
        {
            Console.WriteLine("李氏得到消息");
        }
    }
    
}
