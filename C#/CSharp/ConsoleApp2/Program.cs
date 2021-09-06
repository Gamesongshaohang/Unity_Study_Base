using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            foreach (int i in linkedList)
                Console.WriteLine(i);

            Stack st = new Stack();

           

            //压栈（添加），push()      栈跟队列都是只能一个一个放一个一个取出
            st.Push(linkedList);



            //弹栈（取）  ,Pop()：会移除
            //Peek();只是取值不移除
            //Object v = st.Pop();
            //Console.WriteLine(v);




        }
    }
}
