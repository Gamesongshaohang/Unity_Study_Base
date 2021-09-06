

print("-------------------元表的概念----------------------")
--元表（子表字（自己认为的概念））
--任何表变量都可以作为另一个表变量的元表
--任何表变量都可有自己的元表（爸爸的感觉）
--元表作用：当对子表进行一些特定操作的时候会执行元表的内容

print("--------------------设置元表-----------------------")

yuanbiao1={}
zibiao1={}
--设置元表方法一：关键字setmetatable（参数1，参数2） 参数1子表，参数2元表
setmetatable(zibiao1,yuanbiao1)



print("--------------------特定操作一，__tostring(注意元表的方法都是双下划线__)-----------------------")
--特定操作一，__tostring:作用相当于重写子表差不多
--当子表被当做字符串输出时会默认调用这个元表中的tostring方法
yuanbiao2={
    __tostring=function (t)
     --如何访问子表的属性
    return t.name
    end
}
zibiao2={
    name="元表访问子表"

}
setmetatable(zibiao2,yuanbiao2)
print(zibiao2)




print("--------------------特定操作二，__call-----------------------")
 --__call:当子表被当做一个函数来使用时，会默认调用元表中的call方法
yuanbiao3={
    __tostring=function (t)
     --如何访问子表的属性
    return t.name
    end
,--注意这里，元表是张表，任何属性，方法后要逗号
  __call=function (a,b)
      print(a)--这里发现a打印出来并不是1而是子表的元表访问子表2
              --可以发现此时的a是zibiao本身，把自己作为第一个参数，那么
              --也就执行了tostring
      print(b)--第2个参数才是我们传的参数，传参注意的是默认第一个参数是调用者自己
      print("当子表作为一个函数来使用时调用call方法")
  end
}
zibiao3={
    name="元表访问子表2"

}
setmetatable(zibiao3,yuanbiao3)
zibiao3(1)





print("--------------------特定操作三，运算符重载-----------------------")
yuanbiao4={
    --相当于运算符重载，当子表使用运算符+时会调用__add方法
    __add = function (t1,t2 )
    return t1.age+t2.age
    end,
    --运算符==，<=,>=有注意点   ，当子表使用==时会调用__eq
    __eq =function (t1,t2)
        return true
    end
}
zibiao4={age=1}
mytable={age=2}
setmetatable(zibiao4,yuanbiao4)
setmetatable(mytable,yuanbiao4)
print(mytable+zibiao4)--发现进行__add方法后，元表可以+

--表不能进行运算符的操作，print(mytable1+mytable})
--在元表中则可以进行，有很多方法这里以__add为例，其他类似

--如果要使用条件运算符来比较2个对象table
--这2个对象的元表一定要一致才能准确调用方法
--前提2个对象的元表要一致才能
print(zibiao4==mytable)


print("--------------------特定操作四，__index(最重要),__newIndex-----------------------")
--__index作用： 当子表中找不到一个属性时，会到元表中__index中指定的表(可以指定任意一张表)去找索引（属性）   


yuanbiao5deyuanbiao={age=20}
yuanbiao5deyuanbiao.__index=yuanbiao5deyuanbiao

ba={--age=10
}
yuanbiao5={
  --age=10,
 -- __index = ba,
 -- __index=yuanbiao5,注意：当__index指定自己表的时候，要写在表外面

}
yuanbiao5.__index=yuanbiao5  --可以在表外定义，表内定义
--yuanbiao5.__index={age=15}

zibiao5={}
setmetatable(zibiao5,yuanbiao5)
print(zibiao5.age) --当在子表中找不到该属性，去元表的__index中指定的的ba表中找到了age=10

setmetatable(yuanbiao5,yuanbiao5deyuanbiao)--元表的嵌套

print(yuanbiao5.age)
print(zibiao5.age)--先去元表yuanbiao5__index找，指向了yuanbiao5，yuanbiao5也没有就往其yuanbiao5deyuanbiao上找
                  --当__index指定的表没有找到时，会去找其元表的__index

print("rawget",rawget(zibiao5,"age"))


--__newIndex:当赋值时，如果赋值的是一个不存在的索引，那么会把这个值赋值到__newIndex
--所指的表中，不会修改自己的表0
xin={}
yuanbiao6={}
yuanbiao6.__newindex=xin
zibiao6={}
setmetatable(zibiao6,yuanbiao6)
zibiao6.age=10--如果没有元表没有__newIndex指定的表，那么对于自己表中没有的属性赋值时，
              --会修改自己的表，添加上age=10,相当于zibiao6={age=10}
print("zibiao6.age   "..tostring(zibiao6.age)) --nil
print("xin.age:"..xin.age)     --age=10



--getmetatable:获取子表的元表
-- mytable = {}                          -- 普通表
-- mymetatable = {}                      -- 元表
-- setmetatable(mytable,mymetatable)     -- 把 mymetatable 设为 mytable 的元表
-- 以上代码也可以直接写成一行：

-- mytable = setmetatable({},{})

--rawget(),不管元表中的__index,只在自己的表中找属性
--rawset(),不管元表的__newindex,都会设置自己改变自己的表