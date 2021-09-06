using System;

namespace CSharp核心string
{
    class Program
    {
        static void Main(string[] args)
        {




            //重点：string是一经赋值不能更改，所以像remove,insert这些方法，都不能该变原有的字符串而是返回一个新的
            #region string
            //本质：char[]数组
            string str1 = "songshaohang";
            Console.WriteLine(str1[10]);

            //转为字符数组
            char[] cArr = str1.ToCharArray();
            Console.WriteLine(cArr[10]);



            //1,字符串拼接 ，1：+ 2：fromat(格式化之前讲过){n}:占位符
            Console.WriteLine("字符串拼接，格式化format");
            Console.WriteLine(string.Format("Hello{0}Worl{1}d",10,"LOL"));

            //2,查找字符的位置 
            //IndexOf:从前往后找到的第一个字符的位置，找不到返回-1
            //LaatIndexOf  从后往前找字符的位置
            Console.WriteLine("查找字符的位置");
            int a = str1.IndexOf("s");
            int a1 = str1.LastIndexOf("s");
            Console.WriteLine(a+a1);

            //3,移除指定位置的字符
            //Remove,
            //string是特殊的，本来的字符串并没有改变，是会产生一个新的返回给它
            Console.WriteLine(str1.Remove(0,5));


            //4,替换字符串
            String str3 = str1.Replace("song", "ddd");
            Console.WriteLine(str1);
            Console.WriteLine(str3);

            //5,大小写转换
            //ToLower与ToUpper


            //6，Substring返回字符串指定索引位置的字符串
            Console.WriteLine(str1.Substring(0, 5));

            //Trim():去字符串前后的空格

            //字符串切割spilt()（重要）


            //Join：把字符串数组所有元素连接起来并可以指定分隔符
            string[] sArr = { "1", "4", "gggg" }; //字符串数组
            string sArr1 = string.Join("_", sArr);
            Console.WriteLine(sArr1);

            //spit与Join相反，把字符串转为数组,传入一个字符，字符串根据这个字符作为分隔符分成n个字符串，并且存储入字符串数组中
            //split()首先是一个分隔符，它会把字符串按照split(‘ 字符’)里的字符把字符串分割成数组，然后存给一个数组对象。
            // 输出数组对象经常使用foreach或者for循环。

            string[] sArr2 = { };
            string s6 = "songshaohang";
            sArr2 = s6.Split('s');
            foreach (string i in sArr2)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(i);
            }


            //下面这些可以了解就好

            // //insert:往字符串中插入,并返回新的字符串
            Console.WriteLine(str1.Insert(0, "renren"));


            //IsNullOrEmpty：判断指定字符串为空或者null
            Console.WriteLine(string.IsNullOrEmpty(str1));


            //CompareTo():
            
            Console.WriteLine(str1.CompareTo(str3));
            Console.WriteLine(string.Compare(str1,str3));


            #endregion
        }
    }
}
