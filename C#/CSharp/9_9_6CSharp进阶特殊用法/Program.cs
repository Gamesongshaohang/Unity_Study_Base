using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_9_93CSharp进阶
{
    class Test
    {
        private string name;
        private int money;
        private int score;
        public Test(string name)
        {
            this.name = name;
        }
        public int age
        {
            get;
            set;

        }
        public string sex
        {
            get;
            set;

        }
        public int Money
        {

            get
            {
                return this.money;

            }
            set
            {
                this.money = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }
    }

    class Program
    {


        static void Main(string[] args)
        {

            #region C#的特殊用法1
            #region 知识点1--var隐式类型
            //var：在js中就学过，用于声明变量的。无需显示指明变量具体类型，
            //注意点：1，不能作为类成员，只用于临时变量声明，写在函数中。也不能作为函数参数
            //var声明的变量必须初始化（本来就没声明类型靠的就是具体的值来判断变量类型）

            //可以用在你确定返回的变量类型是装载
            var a = 5;

            #endregion
            #region  知识点2--设置对象初始值
            //其实就是可以在实例化对象时后面加一括号，括号里对变量或者属性初始化。我感觉用在忘记在构造函数里初始化了，然后临时增加比较方便
           
            Test t = new Test("ssh") { age = 10, Money = 20, Score = 20 };

            Console.WriteLine(t.age);
            Console.WriteLine(t.Money);





            #endregion
            #region 设置集合的初始值
            //与上面的设置对象初始值一样的原理

            //例子：
            List<int> list = new List<int>() { 1,2,2,4};//相当于省略了list.add(1)list.add(2)
            #endregion
            #region 这里补充一个前面没学好的小知识点
            //1,快捷键crtl+R可以快速给变量 添加属性，get与set。
            //2，属性不一定要与变量搭配，例如： public string sex {get;set;}
            //这样就是作用一开始没有初始值，而且只进行赋值与获取不进行其他逻辑代码处理。
            #endregion
            #region 知识点3--匿名类型
            //var 变量声明自定义的匿名类型（而且只能放变量）
            //可以理解为没有类型的类，可以理解为临时定义的类。其实作用不大
            var h = new
            {
                a = 15,
                s = "abc"
            };


            #endregion
            #region 知识点4--可空类型
            //值类型是不能为空的，例如：int,bool这些
            //1,语法：申明时在值类型后+?，那么值类型可以赋值为空

            //int a = null;
            int ? aa= null;  //加了？后，int类型就不是普通的int32结构体而是个特殊的可空结构体


            //可空类型的一些方法
            int bb = 1;
            //2,判断是否为空HasValue
            if (aa.HasValue)  //只有可空结构体才有这个字段
            {
                Console.WriteLine("aa的值"+aa);
            }

            //3，安全获取可变类型的值
            //返回值如果没有返回其默认值
            Console.WriteLine(aa.GetValueOrDefault());
            //返回值如果没有返回指定的默认值
            Console.WriteLine(aa.GetValueOrDefault(100));

            //我们知道数据库中是有NULL值的，例如下面的一张表，年龄（int类型）是可以为空的，代表目前不知道此人年龄，那么当我们在C#代码向数据库插入数据时，就会需要一个可空的int类型。
            //用来解决数据库与C#代码数据类型不一致的问题。


            //还有一个小知识点：相当于语法糖
            //配合引用类型
            Object o = null;
            Console.WriteLine(o.ToString()); //因为o是null,打印是报错的我们通过要先判断是否为null

            //如果配合？
            Console.WriteLine(o?.ToString());//那么就不会报错，只会没有值而已

            #endregion
            #region 内插字符串

            //@:使转义字符失效
            //$:可以解析字符串中的{}，中的变量。
            //与format中的{0}，有点像不过format的占位符赋值作为参数，而他可以在外边就赋值了。而且他要在字符串前加$符号
            string name = "送首行";
            int money = 1000;

            Console.WriteLine(string.Format("你{0}啊Hello{1}", "好", "world"));

            Console.WriteLine($"碧海啊{name}有钱{money}");


            #endregion
            #region 空合并操作符
            //有点像3目运算符
            //空合并操作符：？？
            //左边为null返回右边，否则返回左边

            int? cc = null;

            int dd = cc ?? 1000;  //cc为null,那么dd赋值为1000
            #endregion

            #region 单句逻辑时大括号可以省略

            //2，像属性和方法这种如果只有一句代码的可以使用=>的形式
            //例如：public int add(int x,int y)=>x+y;
            //例如：public void add(int x)=>console.write(x);

            #endregion


            #endregion

            Console.ReadKey();
        }
    }
}
