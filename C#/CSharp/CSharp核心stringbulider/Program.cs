using System;
using System.Text;

namespace CSharp核心stringbulider
{
    class Program
    {

        #region stringbuilder
        //主要作用：解决了字符串频繁修改和拼接时不停的创建新的字符串浪费内存空间的问题，提高性能
        //而且StringBuilder可以放其他类型的数据
        //所属命名空间：System.text


        #endregion
        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder("songshao");
            StringBuilder sb1 = new StringBuilder("songshao",100); //第2个参数指定最大容量
            Console.WriteLine("Hello World!");

            #region 容量
            //Stringbulider有一个容量，默认不指定为16，每次超过会自动扩容为原来的2倍。只有超过才扩容才创建，所有还是比string性能高很多

            //获得容量  属性：Capacity
            Console.WriteLine(sb.Capacity);
            #endregion

            #region 增删改查
            //1，增Append与AppendFormat(格式化增加)
            sb.Append("renren");
            sb.Append(1);
            Console.WriteLine(sb);
            sb.AppendFormat("{0},{1}",1,"ddd");
            Console.WriteLine(sb);

            //插入 insert()指定位置插入
            sb.Insert(0, "nihao ");
            Console.WriteLine(sb);
            //替换 Replace
            sb.Replace("song", "你好");
            Console.WriteLine(sb);

            //查
            Console.WriteLine(sb[1]);
            //改
            sb[1] = 'k';
            Console.WriteLine(sb[1]);

            //删Remove
            sb.Remove(0,10);
            Console.WriteLine(sb);


     
            //清空Clear()
            sb.Clear();
            Console.WriteLine(sb);

           
            #endregion
        }
    }
}
