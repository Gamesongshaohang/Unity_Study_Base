using System;






//C#学习第一天(与java非常类型)

//   1，注释：//，/**/，  文档注释（一般用于类前）///
/*2，命名规范：驼峰命名法（变量，字段等）：首字母小写，后面单词首字母大写
           ：定义方法，类接口，首字母大写

3，数据类型
     值类型：int float double char byte boolean  枚举
   引用类型：DateTime（时间）,string，类，所有类都是

4，类型转换
     -值类型：小到大自动，大到小强制转
     -引用类型：有继承关系可以转换
5，转换成字符串Tostring()

6,数组定义（格式）
只能这样 int[] arr = { }
          int[] arr ={ 10}
不能像java这样int arr[] = { }

7，namespace：命名空间，这与java区别，java导入的import,包名.类名
                                       C#导入是using 命名空间
--控制台输出（写）语句：Console.WriteLine("")
         输入（读）语句：Console.ReadLine()


8，程序代码之间的相互调用：API的相互调用，Api：系统或者自定义的代码
API：应用程序接口，是预先定义加的代码逻辑。用来提供给应用程序和开发人员，无需访问源码或者理解内部工作机制的细节（只知道怎么使用即可，具有实现无需理解）。*/
namespace CSharp入门1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
