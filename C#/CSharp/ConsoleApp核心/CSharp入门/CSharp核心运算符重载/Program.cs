using System;

namespace CSharp核心运算符重载
{
    //作用：可以让结构体和类进行运算符运算（其实跟java中的比较器那里有点像，本身类是无法比较的，可以定义比较规则后就可了）
    //让结构体或者对象间或者与其他类型数据进行运算
    //语法 public static 返回值（任意的）   operator 运算符(参数1，参数2)


    class Point {            

        public int x;
        public int y;

        public static Point operator +(Point p1 ,Point p2) {

            Point p = new Point();
            p.x = p1.x + p1.x;
            p.y = p1.y + p1.y;
            return p;

        }
        public static Point operator +(int p1, Point p2)
        {

            return null;

        }
        public static Point operator ++(Point p1)
        {

            return null;

        }


        //注意：1，一定是个静态方法
        //2，参数其中一个必须为该类类型
        //3，参数的数量是看运算符决定的有的一个有的2个
        //3，条件运算符成对出现（例如：>,<）
        //4，不能使用ref,out（记住就行）
        //还有一些不能重载的运算符，这些自己用到时查找

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Point p1 = new Point();
            p1.x = 10;p1.y = 15;
            Point p2 = new Point();
            p2.x = 10;p2.y = 15;
            Point p = p1 + p2;           //按以前是思路，对象是不能进行运算的，但是这里进行运算符重载，重新定义了运算的规则
            Console.WriteLine(p.x+" "+p.y);

        }
    }
}
