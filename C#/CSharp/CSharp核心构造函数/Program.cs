using System;

namespace CSharp核心构造函数
{

    #region 构造函数
    //注意点1：子类实例化时默认自动调用父类得无参构造，所以当无参构造被顶掉会报错，找不到
    //当父类拥有有参构造函数，且没有无参构造函数时，会被顶掉有参顶掉无参
    //父类必须把无参构造显示得写出来

    //注意2：想要不用无参构造怎么把，base关键字与java得super类型
    //语法：base    构造函数public ZI():base(i){}
    //this          public ZI():this(i){}  分别对应java得super与this不同得是java中写在构造函数内得第一行代码，c#写在函数上

    class Father {


        private string name;
        public Father() {
            Console.WriteLine("父类得无参构造函数");
        }
        public Father(string name):this(){
            this.name = name;
            Console.WriteLine("父类有参构造调用得无参构造函数并初始化name"+name);
          


        }
    
    }
    class Zi : Father {

       
        public Zi(String name) : base(name) {  //与java得super(i)

            Console.WriteLine("子类构造函数"+name);
        
        } 
    
    
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {

            Zi z = new Zi("song");
            Console.WriteLine("Hello World!");
        }
    }
}
