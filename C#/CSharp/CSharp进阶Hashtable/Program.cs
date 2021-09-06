using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {

        static void Main(string[] args)
        {
            #region  hashtable(哈希表)
            //概述：键值对，跟java的hashtable类似，可以通过key(键)来访问集合中的元素，本质也是Object[].所以装箱拆箱

            #region  Hashtable的属性
            //1,Count(键值对的 数量)


            Hashtable ht = new Hashtable();
            ht.Add("student", 2);
            ht.Add("person", 10);

            Console.WriteLine(ht["student"]);
            Console.WriteLine(ht["person"]);





            //2，Keys,获取hashtable集合中的所有key，返回值为ICollection
            ICollection keys = ht.Keys;
            foreach (string i in keys)
            {
                Console.WriteLine(i);
            };



            //3，Values,获取hashtable集合中的所有value，返回值为ICollection
            ICollection values = ht.Values; ;
            foreach (int i in values)         //暂时没用泛型只能靠自己主观判断类型
            {
                Console.WriteLine(i);
            };

            //不常用的IsFixedSize	获取一个值，表示 Hashtable 是否具有固定大小。
            //IsReadOnly	获取一个值，表示 Hashtable 是否只读。
            #endregion

            #region hashtable方法
            //1，通过key获取对应的值，hashtable也可以通过集[key]获取对应的值
            Console.WriteLine(ht["student"]);
            Console.WriteLine(ht["person"]);


            //2,Add方法，添加键值对
            ht.Add(1, null);
            // ht.Add(null, 2);  key不能为null

            //3,Clear.从 Hashtable 中移除所有的元素。

            //4, ContainsKey(),判断是否包含指定的key
            Console.WriteLine(ht.ContainsKey(1));

            //5, ContainsValue(),判断是否包含指定的value
            Console.WriteLine(ht.ContainsKey(null));

            //6,Remove()通过key删除对应的键值对
            ht.Remove(1);


            //改
            ht["student"] = "sss";

            //最大的特点就是：通过键key来查询修改删除等





            //总结：using System.Collections;下的集合本质都是Object[]，存储获取时存在装修和拆箱


            #endregion



            #endregion

            Console.ReadLine();
        }
    }
}
