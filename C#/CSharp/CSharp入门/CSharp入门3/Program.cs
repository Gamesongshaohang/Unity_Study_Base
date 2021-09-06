using System;
using System.Collections;

namespace CSharp入门3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //  #region然后按tab键，生成代码块，可以缩放
            #region 代码段
            string s = "dd";
            Random r = new Random();
            //Random的next方法
            Console.WriteLine(r.Next(1,10));
            #endregion


            #region 字符串
            //1，跟java一样，不可改变，只会再创建在堆中
            //连接符，重载了+,+=(隐式调用了tostring()),所以+，把其变为字符串再连接
            string s1 = "song";
            int i = 10;
            s1 += i;//s1=s1+i;
            Console.WriteLine(s1);

            /*
                        3，字符串常用方法：
                                  index(string,index)：返回字符在字符串中第一次的位置，index为从第几位开始查找,找不到返回-1
                                  Replace(oldstr,newstr)：替换
                                  Trim()去掉字符串首尾空格，也可以指定参数去掉(char)字符，相应的还有TrimStart（）y与TrimEnd()，去开头结尾的字符
                                  Substring(index,length),截取子串
                                  Remove(index,length)
            */
            string s2 = "songsong";
            int a=s2.IndexOf('s', 1);
            Console.WriteLine(a);

            string s3 = "           songshaohang    ";
            Console.WriteLine("字符串：" + s3);
            Console.WriteLine("Trim()去掉空格 "+s3.Trim());

           
            Console.WriteLine("Trim('song')去掉指定字符(char)" + s2.Trim('s'));
            Console.WriteLine("Trim('song')去掉指定字符(char)" + s3.Trim('s'));//这里发现去除不了，应该是本身有空格的原因
            //发现前面如果有空格是Trim('s'）是去除不了的，必须先去掉开头空格，再去除其他
            string s6 = s3.Trim();
           
            Console.WriteLine("Trim('song')去掉指定字符(char)" + s6);
            Console.WriteLine("Trim('song')去掉指定字符(char)" + s6.Trim('h'));
            Console.WriteLine("Trim()去开头空格" + s3.TrimStart());
            Console.WriteLine("Trim()去结尾空格" + s3.TrimEnd());

            Console.WriteLine("SubString子串" +s3.Substring(0));
            Console.WriteLine("SubString子串" + s3.Substring(0,8));

            string s4 = "song1  ddd";
            Console.WriteLine("去掉字符串中间的空格"+s4);
            string s5 = s4.Trim(' ');
            Console.WriteLine("去掉字符串中间的空格" + s5);
            Console.WriteLine("去掉字符串中间的空格" + s4.Replace(" ","$"));
            Console.WriteLine("去掉字符串中间的空格" + s4.Trim('$'));

           string str= s4.Remove(3, 1);

            Console.WriteLine(str);
            string str2= s4;
            Console.WriteLine("---------------");
            int ind= s4.IndexOf(" ");
       
            
           string st= s4.Remove(ind, 1);

            int count = 0;
            int leng = s4.Length-1;


            ArrayList ay = new ArrayList();
            for (int in1 = 0; in1 < 10; in1 ++){
                a = s4.IndexOf(" ", a);
             
                if (a >-1){
                    count++;
                    ay.Add(a);
          
                    Console.WriteLine("材质"+a+st);
                }
              
            }
          
            ay.Add(10);
            ay.Add(10);
            foreach (int ays in ay)
            {
                s4.Remove(ays, 1);
                Console.WriteLine(ays);
            }
            /*
                       while (true)

                        {

                            int index = s4.IndexOf(" ", count); //从第一个字符开始找，一直找到最后

                            Console.WriteLine("---------------"+index);
                            str2 = s4.Remove(index, 1);
                            Console.WriteLine("---------------" + str2);
                            count++;
                            index = s4.IndexOf(" ", count+1);

                            if (count== leng-1) {
                                Console.WriteLine("跳出循环");
                                break;
                            };

                        };*/



            Console.WriteLine("---------------" +st);

            #endregion




        }
    }
}
