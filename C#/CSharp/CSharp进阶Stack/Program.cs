using System;
using System.Collections;

namespace CSharp进阶Stack
{
    class Program
    {
       





    

        static void Main(string[] args)
        {

            #region Stack
            //概念：Stack(先进后出)，本质也是以恶搞Object数组，只是封装好了存储规则
            //先存入的数据却是最后取出，可以想象为单通道

            Stack st = new Stack();

            //压栈（添加），push()      栈跟队列都是只能一个一个放一个一个取出
            st.Push("1");
            st.Push("2");
            st.Push("3");
            st.Push(7);

            //弹栈（取）  ,Pop()：会移除
            //Peek();只是取值不移除
            Object v = st.Pop();
            Console.WriteLine(v);

            //栈无法查看指定位置索引的元素
            //只能查看上面的的元素/Peek()，Contains：是否有这个元素

            //改，不能改只能clear（）清空


            //遍历方法
            //1，foreach
            //2 object[] ToArray();把栈元素复制到Object数组中


            foreach (Object i in st)
                Console.WriteLine(i);       //数据取出都是最后存入的符合先进后出

            Object[] obj = st.ToArray();




            //因为也是Object[]数组跟ArrayList一样也存在装箱拆箱

            #endregion
        }
    }
}
