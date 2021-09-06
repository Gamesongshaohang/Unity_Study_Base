using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{



    #region 什么是协变逆变
    //协变：和谐的变化，自然的变化
    //历史替换原则  父类可以装子类
    //所以子类变父类 ，比如 string 变成object 感受上是和谐

    //逆变：
    //逆常规的变化
    //历史替换原则 子类不可以装父类 父类变为子类比如：object变为string
    //感受上是不和谐的

    //协变与逆变是用来修饰泛型的
    //协变：out
    //逆变：in
    //1，用在泛型中修饰泛型字母的
    //2,只能用于泛型接口或者泛型委托


    #region 作用
    //作用1，重要
    //返回值和参数
    //out修饰过额泛型字母只能作为返回值，不能为参数
    //in修饰过的泛型，只能作为参数
 
        public delegate T deOut1<T>();
        public delegate T deOut<out T>();//用了out修饰协变，泛型字母只能作为返回值类型


        public delegate T deIn1<T>();
        public delegate void deIn<in T>(T t);//用了int修饰逆变，泛型字母只能作为参数



    

    class Father { }

    class Son : Father { }



    //作用2，结合历史替换原则理解，这里目前用的少，不过面试问偏门的可能问到。也可以看看，较为复杂
    #endregion


    #endregion
    class Program
    {
        static void Main(string[] args)
        {
           
            //结合历史替换原则理解例子

            //协变 父类被子类替换（符合里氏替换原则），子类以父类来存储来表现
            deOut1<Son> outSon1 = () => {
                return new Son();
            };

            deOut<Son> outSon = () => {
                return new Son();
            };

            //  deOut1<Father> OutFa = outSon1;  //用父类委托容器装子类，发现即使是Son是其子类仍然无法装。但是如果加上out
            //修饰泛型，它会自动判断2个类型是否符合里氏替换原则父子关系，如果有可以赋值

            deOut<Father> outFa = outSon;
            Father f = outFa();//这里最后也一样outSon返回的是子类对象用Father类来装



            //逆变 子类泛型委托装载父类泛型委托
            deIn<Father> inFa = (f) => { };

            deIn<Son> inSon = inFa;//子类泛型委托装载父类泛型委托
            inSon(new Son());






        }
    }
}
