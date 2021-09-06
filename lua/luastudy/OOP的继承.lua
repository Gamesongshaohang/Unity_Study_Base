print("-----------------继承-------------------")
--继承子类继承父类
--假设把Object作为基类
--写一个的方法（提供一个子类来继承父类）



--继承
--子继承父类（享有其属性方法）







Object={}             --父（基）类
--添加属性
Object.id=1
function Object:test()   
    print(self.id)
    
end


--实例化
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


function Object:Speak()
	print("------------------------------------------")
	end



--创建子类方法
function Object:subClass(className)  --提供subClass方法，用于创建一个类继承Object
                      
--这里为什么用_G表，因为我们创建子类是提供一个类名，
--而在_G表中可以使用这个类名创建一个表

   _G[className]={} --大G表中的数据都是全局的，直接调用

   --设置继承的规则，设置元表
   local obj= _G[className]
   setmetatable(obj,self) --self谁调用那么它自己作为第一个参数
   self.__index=self  --设置__index,指向self表,当子表找不到属性，回去元表找


   
  
end 

        Object:subClass("Person")--这么写的话相当于在_G表中创建了一个叫Person的表
      local p1=Person:new() --子类创建对象
print(Person)
print(Person.id)  --查看id属性，发现查到id
                  --那么说明是其子类，调用subClass方法，是创建了一个className的表，且这个表找到了Objectd的属性

print(p1.id)




Object:Speak()
p1:Speak()
function p1:Speak()
	print("================")
end
p1:Speak()
--总结：
--步骤1，设父类，
--步骤2，父类提供一方法用于创建子类
            --2.1，使用传进来的classname在_G表中创建表
            --2.2，设置元表，让子类表与父类关联





