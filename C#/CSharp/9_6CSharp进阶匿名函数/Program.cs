using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication20
{

    #region 匿名函数
    //匿名函数就是没有名字的函数
    //c#的匿名函数必须配合委托和事件
    //其实java也一样不能脱离父类（没记错的话）

    #region 匿名函数的语法
    //delegate(参数列表){};   分号不能省略


    class Test
    {
        //无参无返回值
        //匿名函数对应的系统委托或自定义委托事件
        Action myDelegate = delegate () { };  //匿名函数必须有容器，

        //无参有返回值
        Func<string> myDelegate1 = delegate () {
            return "ssh";
        };

        //有参无返回值
        Action<int> myDelegate2 = delegate (int a) { };  //匿名函数必须有容器，

        //调用匿名函数
        public void test()
        {
            myDelegate();
            myDelegate1();
            myDelegate2(10);

            //匿名函数主要作用
            //1,作为函数参数传递
            D(myDelegate);
            D(delegate () { });
            //2,作为返回值
        }




        //1,作为函数参数传递
        public void D(Action fun) { }
        //2,作为返回值
        public Action D1()
        {
            return delegate () { };
        }
    }


}

#region 匿名函数的缺点
//天机到委托事件也就是添加进容器后，因为是没有名字的，无法单独移除。只能全部移除才能删掉
#endregion

#endregion

#endregion



class Program
{
    static void Main(string[] args)
    {
    }
}

