using System;

namespace CSharp基础1
{

    enum E_MonsterType { 
      
       Normal,//0
       Boss,//1
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 基本数据类型总结
            /*
             无符号变量(0-正数)：byte（1个字节，0-255） ushort uint ulong
             有符号变量：（负数到正数）sbyte short int  long
             浮点：float double decimal
             特殊:bool char string
*/
            #endregion

            #region  复杂数据类型概述    
            //枚举：整形常量的集合 ，可以自定义
            //数组：任意变量类型顺序存储的数据
            //结构体：任意变量的数据集合 可以自定义

            #endregion

            #region 枚举
            //关键字:整形，常量，集合
            //是存储整型常量的集合。
            //主要用于：状态，类型等

            #region 声明枚举
            //关键字enum，语法：enum 变量（名字） {
            //枚举项1， //默认位0
            // 枚举项2， }

            //2,第一个值默认以0开头，以此类推,若我让第一个默认位1，则会改变
            //注意：枚举项若没赋值会在其上以个枚举项的基础上自加1
            //3，枚举要在namespace中声明（常用），class语句块中，struct语句块中，不能在方法内使用

            /* enum E_status { 
              status1,
              status2,
              }
*/

            #endregion


            #region 声明枚举变量
            //语法：枚举类型 变量名=默认值（枚举类型.枚举项）
            E_MonsterType e_Type = E_MonsterType.Boss;

            //调用枚举：枚举类型.枚举项:E_MonsterType.Boss

            if (e_Type == E_MonsterType.Normal)
            {
                Console.WriteLine("是正常类型");
            }
            else
            {
                Console.WriteLine("是大boss类型");
            }

            //枚举与switch常常一起使用
            //在vs中，只要在switch（）输入枚举的变量名再按回车自动补全代码
            switch (e_Type)
            {
                case E_MonsterType.Normal:
                    break;
                case E_MonsterType.Boss:
                    break;
                default:
                    break;
            }
            #region 枚举的类型转换(了解就行很少用到)
            //1，枚举与int互转

            //1.1枚举强制转int
            int i_e =(int) e_Type;
            //1.2,int转成枚举




            //2，枚举与string互转
            string str = e_Type.ToString();

            //把字符串转成枚举
            e_Type = (E_MonsterType)Enum.Parse(typeof(E_MonsterType),"Boss");

            #endregion


            //c#的二维数组与java有一点不同
            //java int[][] a,c# int[,] a,
            //c#的int[][] a,交错数组，不常用到，可以自己看看




            #endregion
        }
    }
}
          #endregion