                              --lua中级篇参数
--1，参数的简化(了解)
--字符串还有table
function setName(str)
	print(str)
end
setName("liu")
setName"liu"   --如果“实参”是字符串，则圆括号可以简化


--2,可变参数 ...相当于java那些类似，...是个关键字表示多个参数
   --Lua的内置函数 arg来代替{...},本质是把可变参数封装为一个表。#arg表示参数格式有
--函数访问可变参数的2种{...}或者arg
function mul(...)
	for i,v in pairs({...}) do
		print(v)
	end
end
function mul1(...)
	for i,v in pairs(arg) do
		print(v)
	end
end

function mul2(...)
	local num
	print(select(1,...) )
	for i=1,select('#',...) do  ---select('#',...)固定写法：表示可变参数的个数，select不可与#arg同时出现
	num=select(i,...)   --select(i,...)返回从索引数值到可变参数的所有内容。例如：下标1到最后，就是输出所有值
	--	print(num) 
	end
end

mul(1,2,3,4)
mul1(1,2,1,nil)
mul2(1,2,1,nil)

--一般而言nil是输出不了的，但是提供了select关键字解决

