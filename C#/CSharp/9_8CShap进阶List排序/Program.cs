using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Person1
    {
        public int age;
        public Person1(int age)
        {

            this.age = age;
        }
    }

    class Person : IComparable<Person>
    {

        public int age;
        public Person(int age)
        {

            this.age = age;
        }

        public int CompareTo(Person other)  //集合中的前一个元素调用CompareTo与后一个进行比较
        {

            if (this.age > other.age)
                return 1;      //正数，则比较大，相等为0

            else if (this.age == other.age)
                return 0;
            else
                return -1;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {

            #region List集合排序
            List<int> itemList = new List<int>();
            itemList.Add(3);
            itemList.Add(2);
            itemList.Add(1);
            itemList.Add(4);


            foreach (int i in itemList)
                Console.WriteLine("排序前：" + i);

            //Sort()：方法用于排序，List与ArrayList都具有。默认的像int，这些是自然排序
            itemList.Sort();

            Console.WriteLine("----------------------------------------------");
            foreach (int i in itemList)
                Console.WriteLine("排序后：" + i);
            #endregion

            #region 自定义排序
            //对于List中存储的是自定义的对象类型，使用Sort是不行的。或者是想要自定义排序规则
            //自定义类没有继承IComparable/,本身不具备比较性，不能使用Sort。
            List<Person> itemList1 = new List<Person>();
            itemList1.Add(new Person(10));
            itemList1.Add(new Person(12));
            itemList1.Add(new Person(5));
            itemList1.Add(new Person(10));

            Console.WriteLine("------------------自定义排序----------------------------");
            //自定义排序，与java类似，继承接口，重写排序方法
            //继承IComparable,重写
            foreach (Person i in itemList1)
                Console.WriteLine("排序前：" + i.age);


            itemList1.Sort();
            Console.WriteLine("------------------自定义排序后----------------------------");


            //继承IComparable,重写
            foreach (Person i in itemList1)
                Console.WriteLine("排序前：" + i.age);
            #endregion

            #region 更为简单的排序：使用委托的方式
            //其实这种方式跟java的第2中2方式类似，可以理解为比较器的概念。通过传入比较器让集合中的元素按照其中的规则就行排序
            //不同的是在java中也是需要继承接口的而在c#其实也有就是方法继承IComparer可以让其变为比较器，但是这里我们不同这个
            //使用Sort（Comparison<T> comparison）接收委托的一种方法，传入一个与委托规则一样的方法即可
            List<Person1> itemList2 = new List<Person1>();
            itemList2.Add(new Person1(12));
            itemList2.Add(new Person1(12));
            itemList2.Add(new Person1(10));
            itemList2.Add(new Person1(14));

            Console.WriteLine("----------------------------------------------");
            foreach (Person1 i in itemList2)
                Console.WriteLine("排序前：" + i.age);



            itemList2.Sort(SortItem);

            Console.WriteLine("----------------------------------------------");
            foreach (Person1 i in itemList2)
                Console.WriteLine("排序后：" + i.age);

            Console.ReadKey();
            #endregion
        }

        public static int SortItem(Person1 a, Person1 b)
        {
            if (a.age > b.age)
                return 1;      //正数，则比较大，相等为0

            else if (a.age == b.age)
                return 0;
            else
                return -1;

        }


    }
}
