using System;

namespace CSharp核心成员属性
{
    //其实就是java的get与set方法，但是语法不同
    //java的写法：public string GetName(){}
    //C#的写法    public string Name{get{},set{}} ,java的是普通方法，而c#这个是特有的,成员属性只能对成员变量进行set与get,不能对局部变量

    //c#的get与set是关键字，
    //1,成员属性的基本语法
    /*  
     public string Name{   --有点像方法但是名字后不带括号，参数也不写在这


      get{
      //有get方法说明这个属性可以获取内容，写了set说明可以设置内容
       get代码块内必须要返回值
        return name;
      }

      set{
    //关键字：value：用于表示外部传入的值
    
       name=value;
    
       }

     }
     */

    class Person {
        #region 成员属性
        private string name;
        private String money;
        private int age;
        private bool sex;

        public string Name
        {

          
              get {
                
                Console.WriteLine(name);
                return name;
            
            }
           // protected set { }
            set {
                name = value;
            }
          
        }





        #endregion


    }



    class Program
    {
        static void Main(string[] args)
        {
            #region 成员属性的使用
            Person p = new Person();
            p.Name = "1111"; //相当于执行了set方法，“1111”=value,value再赋值给了name
            Console.WriteLine(p.Name);//相当于执行了成员属性的get方法

            //成员属性保护了成员变量，为成员属性获取赋值前加入逻辑处理（可以加密处理保护了成员属性），


            //解决了3P（public private protect）的局限性，get和set前可以加访问修饰符
            //例如给get或者set加上private就能让成员变量只能获取或者只能设置
            //知识点3：成员属性可以设置只有set或者get，很多时候只提供get，这与上面添加修饰符功能差不多，保护作用
            //注意：
/*
                 1，默认不加，使用属性声明的访问权限，属性是什么，get和set就是什么
                 2，不能get与set2个访问修饰权限都低于属性访问权限。属性为public,set与get只能设置其中一个修饰符，这是规则
                 3，加的访问修饰符要低于属性的访问修饰符
 
 
 
 */           //知识点6，自动属性：感觉没什么作用，只是不要声明成员变量，而且可读性差了点，可以去看看。



            #endregion
        }
    }
}
