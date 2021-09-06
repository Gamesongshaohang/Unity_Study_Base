using System;

namespace _9CSharp基础3
{

  
     class Program
    {
        public  static void add() { }
        private static void add1() { }
       void ChangeArray1() { }
        static void ChangeArray(int[] arr) {

            arr = new int[]{1,2,3};
            
        }
        static void ChangeArray1(ref int[] arr)
        {

            arr = new int[] { 1, 2, 3 };

        }
        static void ChangeArray2(int[] arr)
        {
            arr[0] = 1;

        }
        static void Changenum(int num)
        {

            num = 1;

        }
        static void Changenum1(ref int num)
        {

            num = 1;

        }

        static void Main(string[] args)
        {




            #region 函数
            //c#比java多出一个结构体struct
            //函数也可以写在结构体中共，class中
            //格式：static 返回类型 函数名（参数）{}

            #region ref与out的使用
            //作用：解决在函数颞部改变外部传入的内容，里面改变了，外面也改变
            //



            //来个例子
            int num = 10;
            int[] arr2 = { 10,20,30};
            
            ChangeArray(arr2);
            ChangeArray2(arr2);
            Changenum(num);
            Console.WriteLine("传入arr2,改变arr2[0]"+arr2[0]);
            Console.WriteLine(num);
            Console.WriteLine(arr2[2]);

            Changenum1(ref num);
            ChangeArray1(ref arr2);
            Console.WriteLine(num);
            Console.WriteLine(arr2[2]);
            //发现，改变的arr[0],里面改变了，外面也改变了。因为数组是引用类型，
            //改变了arr[0]改变了在堆内存中的数据

            //发现改变num,与数组arr[]，是没有改变的，首先num是值类型，数据在栈中，而在函数上的num，局部变量
            //相当于又在栈中再创建了一个变量num。而数组[]座位引用类型为什么也改变不了呢？
            //因为再函数上又new int[],相当于新建一个变量指向新的地址，与原来没有关系

            //使用方法：在参数前，使用ref关键字修饰
            //加了ref关键字参数的函数被调用该函数时参数前也要加ref
            //out与ref几乎是一摸一样的


            //out与ref区别？
            //ref传入的变量必须初始化，out不用，
            //out传入的变量必须内部赋值，ref不用

            //也就是ref在前面就给变量赋了值，后面也改可不改
            //而out在前面可以不赋值，后面必须赋值，也就是一个必须在前面赋值一个必须在后面赋值
            





            #endregion



            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}
