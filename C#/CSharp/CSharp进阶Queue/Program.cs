using System;
using System.Collections;

namespace CSharp进阶Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //因为与java的几乎一样，初略的过
            //Queue：先进先出
            //本质也是Object数组，所以也存在装箱与拆箱

            Queue queue = new Queue();

            //增Enqueue
            queue.Enqueue("1");
            queue.Enqueue(new Program());
            queue.Enqueue(0.2f);

            //取 Dequeue（会移除）
            object v = queue.Dequeue();
            Console.WriteLine(v);

            //查 Peek()(只查不移除)，与栈中的peek一样
            //Contains 判断是否存在

            //改，也是没有改，不能使用queue[]这种格式，不能改


            //遍历与stack一摸一样


        }
    }
}
