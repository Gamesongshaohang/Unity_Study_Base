


--第一种，一个table就是一个类（属性方法在table里声明）
person={
   --属性性别
   sex="男",
   --名字
   name ="ssh",
   --成员方法
   up=function(t)
print("up",t.sex)
end,

}

--第2种声明方式(声明表过后，在表外申明表有的变量和方法)
--添加属性
person.name1="ssh2"
--添加方法
person.speak=function()
end
function person.speak1()
end

person.up(person)
person:up()
--lua，table类里的属性方法更像java中的静态方法.
--在类中调用自己的属性的做法
--1，表名.属性/方法   2,   up=function(t)  print("up",t.sex) end，并且up(person)也就是传入的参数为本类（有点麻烦不建议）
--3，使用self(推荐)，self+:  的形式, ;调用会把自己（本类）作为一个参数传进来。即使方法
function person:up1()  --因为使用：  所有第一个参数是自己(隐式)，那么此时self所带表的就是本类。
	                
	--self：关键字表示默认传入的第一个参数
	
	print("up1",self.sex)
	
end
person:up1()

--总结最推荐使用  ：声明方法，：调用方法，self作为第一个参数


--重要：面试考点
