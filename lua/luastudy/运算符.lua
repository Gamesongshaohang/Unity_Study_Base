--lua没有自加与自减

--nil只能与自身相等

--1,逻辑运算符，flase,nil为假，其他为true
--and,or,not

num1=1
num2=2
num3=3

print(num1>num2 and num < num3)

--特殊的 a and b ==a?b:a
--       a or  b ==a?a:b
--       not a 



--2,多重赋值
num4,num5,num6=1,2,3
print(num4,num5..num6)



--3,局部变量（local）与全局变量

if true then   --then end相当于java中的{}
	local num=7 --在代码块中定义的局部变量其他地方不能访问
end
print("num7:",num7)


--do end 就是一个语句块

do 
local num8=8
end
print("空的",num8)
--nil可做释放资源