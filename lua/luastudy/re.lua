


--require:执行其他脚本（相当于执行了其他lua先）。获取其方法，变量
local test1=require("test")
print("test的a"..a)
print("test的b")
print(test1.a)

----如果时require加载执行的脚本，加载后不会再次执行
--require 后的return    在其他表中使用return可以再次使用
--return相当于返回值，可以是表方法，属性等，然后可以再次调用


--package.loaded["脚本名"],返回该脚本是否被执行或者加载过
print(package.loaded["test"])
package.loaded["test"]=nil   --脚本卸载，local test1=require("test")不在起作用
test1.eat()
print(a)

--大G表（重点）
--――G表是一个总表，将我们声明的所有全局变量都存储在其中
--  _G是关键字,require过的全局也一样加进 

local v=110
b=100
c=1110

for k,v in pairs(_G) do
    print(k,v)
end