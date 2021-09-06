using System;
using System.Collections.Generic;

namespace _9_2CSharp进阶LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //本质是泛型双向链表


            LinkedList<int> linkedList = new LinkedList<int>();

            //链表对象需要掌握2个类
            //链表本身：包含增删改查等方法  2，链表结点：LinkedListNode:包含了上一个结点，下一个结点，还有当前结点的value等数据



            //增
            //1.往链表头部增加元素
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(5);

            //1.往链表尾部增加元素
            linkedList.AddLast(10);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(5);

            //在某个结点后添加结点
            //方法先获取该结点对象（first,last或者具体的都行），再往他后面添加
            LinkedListNode<int> linkedListfirstNode1 = linkedList.First;


            //方法AddAfter()  参数1，结点 参数2，插入的元素
            linkedList.AddAfter(linkedListfirstNode1,100);



            //方法AddAfter()  参数1，结点 参数2，插入的元素
            linkedList.AddBefore(linkedListfirstNode1,101);



            //删
            //1,移除头结点
            linkedList.RemoveFirst();

            //2,移除尾结点
            linkedList.RemoveLast();

            //3，移除指定结点  参数：为具体元素的值
            linkedList.Remove(5);
            //4，clear（） 清空

            //查
            //1,头结点
             LinkedListNode<int> linkedListfirstNode= linkedList.First;

            //尾结点
            LinkedListNode<int> linkedListendNode = linkedList.Last;
            Console.WriteLine(linkedListendNode);
            Console.WriteLine(linkedListendNode.Value);

            //找到指定结点
            LinkedListNode<int> Node = linkedList.Find(3);
            //是否存在 constains




            //改，方法：结点的value重新赋值
            //先获取结点对象获取其的value重新赋值就改了

            Node.Value = 10;




            //遍历

            //1,foreach()
            foreach (int i in linkedList) //foreach很特殊按道理因为要获取结点然后再获取value才行，但是foreach直接帮我们把value获取到了
                Console.WriteLine(i);


            //2，从头到尾遍历
            LinkedListNode<int> linkedListfirstNode2 = linkedList.First;
            while (linkedListfirstNode2 != null)
            {
                linkedListfirstNode2 = linkedListfirstNode2.Next;//另头结点等于下一个，这种方法来遍历


            }

            //3，从尾到头遍历
            LinkedListNode<int> linkedListendNode2 = linkedList.Last;
            {
                linkedListendNode2 = linkedListendNode2.Previous;//另头结点等于上一个结点，这种方法来遍历


            }
        }
    }
}
