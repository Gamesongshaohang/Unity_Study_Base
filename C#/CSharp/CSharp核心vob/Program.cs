using System;

namespace CSharp核心vob
{
    #region 多态
    //字面的意思就是“多种状态
    //让继承同一父类的子类们在执行相同方法时的不同表示（状态），例如都是父类的引用（父类的类型），各自的子类对象且执行的方法一样，但是内容不同
    //解决问题是让同一对象有唯一特征

    class Father {

        public void eat() {
            Console.WriteLine("爸爸的吃饭方式");
        
        }
    }
    class Son : Father {
        public void eat()
        {
            Console.WriteLine("儿子的吃饭方式");

        }
    }
    class Father1
    {
        string name;
       public Father1(string name) {
            this.name = name;
        }
        public virtual void eat()
        {
            Console.WriteLine("爸爸的吃饭方式");

        }
    }
    class Son1 : Father1
    {

      public  Son1(String name):base(name){  //base与this用法，当调用构造函数时写在构造函数后
                                             //当想使用普通方法字段时写在方法内
        
        }
        public override void eat()
        {
            base.eat();
            Console.WriteLine("儿子的吃饭方式");
        }

    }

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //之前的里氏替换原则，父类类型存储子类对象。目的是方便对对象的存储和管理
            Father f = new Son();
            f.eat();
            Son s = f as Son;//当我们想要使用子类的特有方法时需要转型,这破环了面向对象的原则
                             //我们即想使用里氏替换又想让一个对象有唯一特征
            s.eat();

            //这时就出现了多态
            //编译时堕胎，方法的重载，了解就行


            //重点
            //运行时多套（vob（不是关键术语只是为了方便记忆，）抽象函数、接口）
            //v:关键字：virtual(虚函数)
            //o:关键字：override(重写) 与virtual搭配的写
            //b:关键字：base(代表父类)

            Father1 f1 = new Son1("宋");
            f1.eat();


        }
    }
}
