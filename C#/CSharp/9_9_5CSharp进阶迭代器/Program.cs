using System;
using System.Collections;

namespace _9_9_5CSharp进阶迭代器
{

    #region 什么是迭代器
    //iterator,又称为光标
    //是程序设计的软件设计模式
    //迭代器模式：提供一个方法，顺序的访问一个聚合对象中的各个元素，但又不暴露其内部的标识

    //表现效果上看：
    //是可以在容器对象（数组链表等）上遍历访问的接口
    //设计人员无需关心容器对象的内存分配的实现细节

    //--------------
    //可以使用foreach遍历的类，都是实现了迭代器的


    //让自定义类可以使用foreach遍历



    #endregion
    #region 标准迭代器的实现方法
    //关键接口：IEnumerator,IEnumerable
    //命名空间：using System.Collections
    //继承2接口并实现重写其中的方法
    #endregion
    #region 使用yield return 语法糖实现迭代器
    //yield return:C#提供的语法糖
    //语法糖:作用将复杂逻辑简单化，增加程序可读性

    //关键接口IEnumerable
    //通过foreach遍历的自定义类实现接口中GetIEnumerator即可

    class Custom :IEnumerable{
        private int[] list;

        public Custom()
        {

            list = new int[] { 1, 3, 5, 10 };
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++) {
                //yield关键字配合迭代器使用
               
                // yield return的本质就是我们上面写的IEnumerator方法由系统生成。
                yield return list[i];
            }

            //我们之前讲标准写法时知道，对象一直调用moveNext（），并返回对应current属性。
            //其实 yield return


            //其实写下面4句代码与上面for循环一样
            /* yield return list[0];
             yield return list[1];
             yield return list[2];
             yield return list[3];*/
        }
    }


    #endregion
    #region 使用yield return 语法糖泛型类实现迭代器
   //其实跟普通类一样写法

    class Custom1<T> : IEnumerable
    {
        private T[] list;

        public Custom1()
        {

          
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                //yield关键字配合迭代器使用

                // yield return的本质就是我们上面写的IEnumerator方法由系统生成。
                yield return list[i];
            }

            //我们之前讲标准写法时知道，对象一直调用moveNext（），并返回对应current属性。
            //其实 yield return


            //其实写下面4句代码与上面for循环一样
            /* yield return list[0];
             yield return list[1];
             yield return list[2];
             yield return list[3];*/
        }
    }


    #endregion
    class CustonList :IEnumerable, IEnumerator
    {

        private int[] list;
        private int position = -1;//定义光标初始位置,学过java都知道设置-1光标为，最开始元素的前一个
        public CustonList() {

            list = new int[] { 1, 3, 5, 10 };
        }

        #region IEnumerable接口的方法
        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("----------");
            Reset();  //为什么在这里设置 Reset();GetEnumerator方法时使用foreach就会调用一次，那么如果不使用 Reset()重置光标
                      //第2次使用foreach光标还在上一次哪个位置，说明2次的对象是同一个。
            return this;//因为本类实现了IEnumerator接口，也重写了里面的方法，其实也可以另外写一个类，但是那样将会十分麻烦
        }

        #endregion

        #region IEnumerator接口的方法


        //属性Current
        public object Current {
            get {

                return list[position];
            }
        
        }
        public bool MoveNext()
        {
            //每次调用MoveNext自++
            position++;


            return position <= list.Length-1;//不超过数组范围时为true
        }

        public void Reset() //重置光标位置
        {
            position = -1;
        }
        #endregion
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustonList list = new CustonList();

            //提供一个方法，顺序的访问一个聚合对象中的各个元素，但又不暴露list数组

            //foreach原理：
            //1，会调用in关键字后对象的中的GetEnumerator方法获取IEnumerator对象。所有其实既不继承IEnumerable无所谓，方便实现方法而已

            //2，获得IEnumerator对象后，会一直执行其中的MoveNext方法，只要MoveNext返回true，则获取属性Current
            //然后把current属性赋值给item，直达MoveNext返回false那么退出
            

            foreach (int item in list) {
                Console.WriteLine(item);
            
            }
            foreach (int item in list)
            {
                Console.WriteLine(item);

            }
        }
    }
}
