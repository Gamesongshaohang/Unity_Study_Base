using System;

namespace _8CSharp基础2
{       /// <summary>
     ///值类型与引用类型
      /// </summary>
    class Program
    {

        static void Main(string[] args)
        {


            #region 值类型与引用类型的区别
            //引用类型：string 数组 类
            //值类型：其他，结构体

            int a = 10;
            int b = a;
            int[] arr = new int[10];
            arr[1] = 10;
            int[] arr2 = arr;
            Console.WriteLine("a,b:"+a+","+b);
            Console.WriteLine("arr[1],arr2[1]"+arr[1]+" "+arr2[1]);


            b = 20;
            arr2[1] = 20;
            Console.WriteLine("修改后的");
            Console.WriteLine("a,b:" + a + "," + b);
            Console.WriteLine("arr[1],arr2[1]" + arr[1] + " " + arr2[1]);

            //会发现，值类型在互相类型时拷贝了给对方，他变我不变，
            //而引用类型则是让2则指向同一个值（引用类型可以说是地址），他变我也变
            //arr与arr2,在栈 中存储的地址指向堆中的同一块地址，当改变其他一个时，改的是地址指向的实体
            //当另外一个指向同一位置的变量访问的就是改变过后的

            //为什么会出现这样区别？
            //原因：2则存储的内存区域不同，那么就出现区别
            //值类型：栈空间（系统分配，自动回收，小而快）
            //引用类型：堆空间（收动申请和释放，大而慢一点）


           // string虽然是引用类型，但是他是特殊的，具体参数java的string

        






            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}
