using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SortedList
            //SortedList:（数组+哈希表）存储形式也是键值对，可以通过索引和键key来访问元素  特殊的时：可以通过键也可以通过索引
            //当通过索引来访问元素时，它是一个数组ArrayList
            //当通过key来访问时，它一个哈希表

            //属性与hashList没什么区别

            //重点在方法
            #region SortedList
            SortedList sl = new SortedList();

            //增
            //1,Add：方法,
            sl.Add(3, "2");
            sl.Add(1, "ggg");
            sl.Add(2, "洛洛洛呀");
            sl.Add(10, "11111111111111111111");
            //ContainsKey()  ContainsValue()是否包含指定的键和值

            //SortedList中的元素会自动排序，默认按key的自然排序



            //删
            //Clear()清除
            //2，Remove():删除元素通过key
            //RemoveAt():删除元素通过下标

            //1，获取值

            //1.1key获取
            //通过key获取
            Console.WriteLine(sl[2]);              //发现：sortedlist要像数组一样使用时sl[]，传进的只能是key,下标没作用
            Console.WriteLine(sl[10]);

            //1.2索引获取
            //GetByIndex(int index) 根据索引获取值
            Console.WriteLine(sl.GetByIndex(0));

            //1.3获取集合的全部值
            //1，属性values  返回值类型ICollection
            //2,GetValueList() 返回值类型ICollection
            ICollection sl2 = sl.Values;
            IList il = sl.GetValueList();
            foreach (string i in sl2)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();

            foreach (string i in il)
            {
                Console.Write(i + ", ");
            }



            //获取key  GetKey通过下标获取key
            Console.WriteLine(sl.GetKey(0));

            //1.3获取集合的全部key
            //1，属性keys  返回值类型ICollection
            //2,GetValueList() 返回值类型ICollection
            ICollection sl3 = sl.Keys;
            IList il2 = sl.GetKeyList();
            foreach (int i in sl3)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();

            foreach (Int32 i in il2)
            {
                Console.Write(i + ", ");
            }

            //查
            //IndexOfKey()   根据key或者value返回索引
            //IndexOfValue()



            #endregion




            #endregion


            Console.ReadLine();

        }
    }
}
