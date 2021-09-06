
//定义字符
#define IOS
#define Androinds
#define PC
#define UNITY

//取消字符让其失效
#undef UNITY




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_9_1CSharp进阶预处理器指令
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 什么是编译器
            //编译器是一种翻译程序
            //作用是将源语言程序翻译为目标语言程序

            //源语言程序：某种程序设计语言写成的，比如：C、C#、java得语言写成的程序
            //目标语言程序：2进制数标示的伪机器代码写的程序
            #endregion

            #region 什么是预处理器指令
            //预处理器指令 指导编译器在实际编译开始之前对信息进行预处理。重：在编译前
            //预处理指令：#开头
            //预处理器指令不是语句，所以它们不是；结束.
            //目前我们经常用到的折叠代码块就是预处理器指令
            #endregion


            #region 常见的预处理器指令
            //1，
            //#define:定义一个字符，类似一盒没有值的变量
            //#undef：取消定义的符合，让其失效
            //2个写在脚本文件最前面（最前面）
            //一般配合#if指令使用或配合特性

            //#if
            //#elif
            //#else
            //#endif
            //和if语句规则一样，一般配合#define定义的字符一起使用
            //而且可以使用逻辑或与逻辑与&& ||

#if IOS         //如果发现有定义IOS这个字符那么其包含的代码块会被编译器编译  注意是发生在编译之前（是否需要被翻译（编译））
            Console.WriteLine("操作系统是IOS");
#elif PC
          Console.WriteLine("操作系统是IOS");
      else
       Console.WriteLine("操作系统是其他");
#endif


            //3,
            //#warning：告诉编译器报警告
            //#error：告诉编译器报错误
            //还是配合#if使用
            //作用：满足什么条件时告诉提示别人错误

            //如果是Androinds，那么可以通过#warning 或者#error来提示这样不对
            //#error报错，甚至可以程序不能编译
            
#if Androinds
            Console.WriteLine("报警告还是报错误");
            #warning 报警告，这个平台不对
#endif





            //作用是什么呢？
            //unity是跨平台，经常用与判断unity版本或者平台
            //假设这块代码是#defineIOS平台的代码，不同平台执行的代码逻辑可能不同，所有可以利用这个来当不同平台编译不同的代码








            #endregion

        }
    }
}
