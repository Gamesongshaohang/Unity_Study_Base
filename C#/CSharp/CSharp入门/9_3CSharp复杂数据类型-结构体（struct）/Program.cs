using System;

namespace _9_3CSharp复杂数据类型_结构体_struct_
{
    class Program
    {

        #region 结构体
        //C#特有的数据类型，java是没有的
        //自定义的变量类型，类似枚举可以自己定义
        //在结构体中可以声明各种方法（包括构造方法）和变量

        //总：是数据和函数的集合
        //作用：用来表现关系的数据集合，会发现与类很像，比如表现学生，与class有点像后面讲区别


        #region 基本语法：
        //1,一般写在namespace语句块中，关键字struct
        //2,在结构体中的变量不能初始化，变量类型可以是任意类型包括结构体，但是不能是自己否则相当与死循环
        //3，在结构体中的方法一般不用static修饰（并不是不能）
        //4,结构体中的函数可以不用直接使用声明的变量
         struct Student {
            //变量
            public int age;
            struct stu { }


            #region 结构体的构造函数（可选）
            //1,没有返回值,不能写返回类型，包括void也不能写
            //2，函数名与结构体名相等
            //3，必须有参数，不能与默认构造函数一样
            //4，如果声明了构造函数，必须对结构体内所有变量初始化（强制性的）


            //与java一样this关键字：
            public Student(int age, string sex)
            {
                this.age = 10;
                this.age = age;
                age = 10;
                sex = "";
                ;
            }
            #endregion



            //函数
            public void add() {
                Console.WriteLine("打印",age);

            
            }
        
        
        }

        #endregion 



        #endregion
        static void Main(string[] args)
        {
            #region 结构体的使用
            //语法 结构体类型 变量名；变量名.变量/方法
            //推荐：像类一样可以实例化 Student stu = new Student();
            Student stu1;
            Student stu = new Student();
            stu1.age=10;
            stu1.add();
            Student stu2 = new Student(10,"10");
            stu2.add();


            #endregion

            //访问修饰符，不同与java的是不写，默认是private
            //public 公共的可以被外部访问
            //private 私有的 只能内部使用
        }
    }
}
