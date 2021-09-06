using System;
using System.Collections;
using System.Collections.Generic;

namespace _8CSharp进阶泛型集合
{
    class Program
    {
        static void Main(string[] args)
        {

            //我们之前学习的ArrayList hashtable stack queue本质都是Object[]数组，存在拆箱装箱，学习了泛型
            //接下来的几乎都是与上面的差不多，是他们的泛型形式，本质改为泛型[]


            //List,ArrayList的泛型形式，本质是一个可变类型的泛型数组
            //为什么要弄这玩意呢？在java中的arraylist几乎所有集合是可以加泛型的，但是c#不同规定了上述的4种为object不能加泛型，所以加多几种集合类型

            List<int> list = new List<int>();

            //方法与arraylsit几乎一模一样这里就不具体讲了
        }
    }
}
