print("--------------------面向对象---------------------")
print("--------------------封装---------------------")

--lua面向对象 类，都是基于table来实现
--lua中所有复杂类型都是table来表现的

Object={}
--添加属性
Object.id=1
function Object:test()
    print(self.id)
    
end




--:,自动调用函数的对象作为第一个参数传入的写法，这里时Object
--实现一个new方法，（模拟java 类 引用= new 类（）），最后返回的是一个对象
--所有我们这也一样，通过new方法返回一个对象
function Object:new()
    --使用默认参数推荐使用self,self代表的是传入的第一个参数

    --表对象（变量）就是对象，
    local obj={}
--设置元表，slef
--setmetatable(obj,Object)
setmetatable(obj,self)
--Object.__index=self
self.__index=self  --尽量写在外面，写在里面容易出错

    return obj
end
--通过new()返回表对象obj，相当于java中的实例对象
local myobj = Object:new()
print(myobj.id)
myobj:test()--开始调用方法设置方法都有：，因为可以使用self
--myobj.test()--为什么这样调用不了self,因为：相当于myobj.test(myobj)，没有传参，方法中出现self时你访问不到

--现在的myobj跟java中实例类似，
myobj.id=10  --改变的只是实例的对象，并不是Object，相当于在空表中在申明一个属性
             --相当于java中实例化对象，改变的属性是你实例化对象的属性


myobj:test()--：谁调用，参数就是谁，现在参数是myobj是实例化对象，方法中的self对应的就是myobj而不是Object



print("lua的封装的可以大致一下")
--1,建立表Object（）相当于类
--2,表中中属性，方法等
--3,提供表（类）的new方法，new方法中定义一个表，这个表就是谁实例化提供出去的对象
--4,new方法中,设置元表为Object，最好设置__index等方法。然后可以new方法中可以定义访问类中的方法
--和属性等














