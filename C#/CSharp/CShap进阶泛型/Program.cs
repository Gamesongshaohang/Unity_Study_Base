using System;

namespace CShap进阶泛型
{


    class Fanxing<T> {
        public T value;
        public T find<Q>()
        {

            return default(T);  //default2种用法，1在case中，2作为所有类型的的默认值
        }

        internal void find<T1>(T1 v)
        {
            throw new NotImplementedException();
        }
    }



    //普通类中的泛型方法
    class Fanxing1
    {
        public void find<Q>(Q value)
        {


            Console.WriteLine(value);
        }
        public void find1<Q>()
        { }
    }
    
    interface IFanxing<T> { }



    class Fanxing2: Fanxing<int>,IFanxing<int>{}//继承时要声明泛型类型
    class Program
    {
        static void Main(string[] args)
        {
            #region 泛型
            //虽然java也有泛型，但是c#的泛型更大作用，java泛型再运行时就不是泛型了。
            //泛型作用
            //1，泛型相当于类型占位符   （可以作为一种数据类型的占位符，然后调用时再具体写是什么类型）

            //2,泛型实现了类型参数化，达到了代码重用的目的。像Fanxing中的T value，可以在调用变量申明为任意类型，
            //例：int和string,相当于在类中用public T value;一句代码声明却实现多种变量声明的的作用。代码重用
            //通过类型参数化来实现一份代码上操作多种类型


            //定义类或者方法时使用替代符代替变量类型
            //当真正使用时再具体指定类型

            #region 泛型分类
            //1，泛型类和泛型接口
            //基本语法：
            //class 类名<泛型占位符字母> 泛型占位符字母;任意字母，最好是大写字母
            //interface 接口名<泛型占位符字母>

            //2，泛型方法
            //函数名<泛型占位符字母>(参数列表)

            //注意：泛型占位符字母可以有多个，逗号隔开

            #endregion

            #region 泛型方法
            //1,普通方法的泛型


            #endregion

            #region 泛型的使用什么时候用
            //1,不同类型对象但是相同的逻辑处理时
            //2,使用泛型可言一定程度避免装箱拆箱（Object）,指定为其他类型，指定集合Collectios下的集合都指定



            //注意：当不确定泛型类型时获取其默认值，例如int为0，string为null，可以使用defalut(T)来获取泛型默认值
          
            #endregion


            #endregion



            Fanxing<int> f=new Fanxing<int>();
            f.find<string>("sssssss");

        }
    }
}
