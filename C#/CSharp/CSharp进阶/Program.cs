using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {





        static void Main(string[] args)
        {

            ArrayList al = new ArrayList();
            al.Add("123");
            al.Add("a");
            al.Add("b");
            al.Add(3);

            #region ArrayList
            //概述：C#封装好的类，本质时Object类型的数组（存储任意类型）
            //最重要的方法就是增删改查


            #region ArrayList属性
            //1，Capacity:容量（可以存储的数量上限）,之前StringBuilder也有容量属性且默认创建大小为16
            //ArrayList不写默认为0,当添加了元素第一次为4，然后下一次为原来的2倍。跟java的ArrayList有点类似

            Console.WriteLine("ArrayList的容量" + al.Capacity);
            //2，Count:包含元素数量   
            Console.WriteLine("ArrayList的个数" + al.Count);

            //3，获取ArrayList元素的方法，像数组一样即可。而java中则需要使用get等方法
            Console.WriteLine("ArrayList的容量" + al[2]);

            //不常见的属性
            /*
                       IsFixedSize:表示 ArrayList 是否具有固定大小。
                       IsReadOnly:表示 ArrayList 是否只读。
                       IsSynchronized:表示访问 ArrayList 是否同步（线程安全）多线程
                       SyncRoot:获取一个对象用于同步访问 ArrayList。
              */
            Console.WriteLine(al.IsFixedSize);
            Console.WriteLine(al.IsReadOnly);
            Console.WriteLine(al.IsSynchronized);
            #endregion
            #region ArrayList常用方法
            //全是虚方法可以重新



            //改：像数组一样计科 al[0]="10";
            //添加

            //1，Add():在末尾添加元素(任意类型)
            al.Add(0.1F);
            //2,AddRange(ICollection c):添加范围增加，把一个集合的元素增加到该集合中,ICollection接口下的子类对象都可以
            ICollection ic = new ArrayList();
            al.AddRange(ic);
            //3,insert():在指定位置插入元素
            al.Insert(0, 1.0);
            //4,insertRange():在指定位置插入集合（ICollection）
            al.Insert(0, ic);

            //删除

            //5,Remove():从ArrayList删除指定的对象（传入的是一个值）,删除的是找到的第一个
            Console.WriteLine("Remove（） " + al[3]);
            al.Remove("a");
            Console.WriteLine(al[3]);
            //6,RemoveAt():删除指定索引处的元素
            Console.WriteLine("RemoveAt（） " + al[2]);
            al.RemoveAt(2);
            Console.WriteLine(al[2]);
            //7,RemoveRange():删除某个范围内的元素  参数：下标，参数：数量
            al.RemoveRange(1, 1);
            //8,Clear():清除全部

            //9,Contains();判断某个元素是否存在集合中
            Console.WriteLine(al.Contains("b"));

            //查询

            //10,IndexOf():参数：值元素，返回该元素在集合中第一次出现的位置（索引）
            Console.WriteLine(al.IndexOf(0.1f));

            //11.GetRanger(int index,int count):获得子集合，获得集合的部分元素并组成一个新的集合
            ArrayList al2 = al.GetRange(0, 3);
            Console.WriteLine(al2[2]);


            //12,Reverse()反序，逆转集合中的顺序
            ArrayList al3 = new ArrayList();
            al3.Add(1);
            al3.Add(2);
            Console.WriteLine("反序");
            Console.WriteLine(al3[0]);
            al3.Reverse();
            Console.WriteLine(al3[0]);

            //13,SetRange();把某个集合的元素复制到当前集合的某个位置上（不是集合作为一个元素）

            ArrayList al4 = new ArrayList();
            al4.Add(1);
            al4.Add("bbb");
            al4.Add("al4");
            al4.Add("bbb");
            al.SetRange(0, al4);//把al4集合的全部元素复制到al的0索引处

            Console.WriteLine("遍历集合");

            for (int i = al.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(al[i]);

            }
            //14,Sort():排序，默认是自然排序，可以重新
            //al.Sort();//暂时不知为什么不行要查查
            Console.WriteLine("遍历排序后的集合");
            for (int i = al.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(al[i]);

            }

            //15,TrimToSize():设置容量为与集合的实际格式一致，了解

            #endregion


            #endregion

            Console.ReadLine();


            //装箱：Object转为值类型   引用转为值类型   堆到栈
            //拆箱：int-> Object    
            //ArrayList本质是Object类型的数组
            //所有使用ArrayList存储时其实就是再装箱，当取出来使用时就是拆箱
            //我们之前就学过装箱拆箱带来性能上的消耗，虽然方便，后面会学习其他的数据集合容器

            al[0] = 1; //装箱  Objcect->int

            int i1 = (int)al[0];//拆箱






        }
    }
}
