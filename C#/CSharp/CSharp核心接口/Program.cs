using System;

namespace CSharp核心接口
{
    #region 多态之接口
    //与java几乎一样
    //关键字：interface
    //接口：行为的抽象规范

    //注意：
    //1,不能声明成员变量（属性）
    //2,z只包含：方法，属性，索引器和事件
    //3，成员不能实现（所有的成员都只能时抽象的）
    //4，成员可以不写修饰符（默认为public）,不能私有
    //5,不能继承类，像java一样可以继承接口，类可以实现多个接口，因为接口的成员都是抽象的所以类继承后必须全部实现


    //接口，命名规范：一般前面加I



    //什么时候用接口呢？
    //接口是行为规范，是必须实现的。他不是父类，可以认位是大家共有的特征，而且是必须实现

    //c#的接口还有一个小知识点（了解）
    //显示实现接口
    //当实现多个接口并且里面的方法重名时使用显示实现接口）

    interface IAct {

        void fly();
    }

    interface ISuperAct {
        void fly();
    }


    class Person1 : IAct, ISuperAct {
        public void fly() { }   //其实2个接口的fly是不同的，这样其实是违背了面向对象

       void IAct.fly() { } //当2个方法名一样时可以使用接口.方法名的形式
        void ISuperAct.fly() { }


    }


    interface IFly{

       public abstract void Fly();  //这里其实应该跟java差不多，隐式的public abstract不需要写

        void Fly1();



        String Name {//成员属性

            set;
            get;
        }

        int this[int index] {  //索引器

            set;
            get;
        }
    }


    class Person : IFly
    {

      public string name;
        public int this[int index] {

            get
            {
              
                return 0;
            }

            set { }
        
        }

        public string Name          //成员属性一般起名为对应的变量的首字母大写
        { //成员属性可以使用
            get
            {

                return name;
            }

            set
            {
               name = value;
                //value为传入的值

            }
        }

        public virtual void Fly()  //加上虚函数后面可以重写
        {
            Console.WriteLine("ddd");
        }

        public void Fly1() {
            Console.WriteLine("ddddddd");
        }
    }

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            IFly f = new Person();
            f.Name = "sshsssss";
            Console.WriteLine(f.Name);
            f.Fly();
            f.Fly1();


            Person1 p = new Person1();
        }
    }
}
