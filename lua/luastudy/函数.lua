--1,定义函数（方法）,无定义返回类型，可以任意类型，任意数量。参数可以为不定义参数类型
--函数也可以作为参数
function fun(num1)
	print(num1)
end
fun(100)

--1.1函数赋值给变量

fun1=fun(1000)--变量fun1得到函数的引用

--因为函数参数没有类型，这是弱点



--2，函数与变量，在函数中定义的局部变量不能再函数外使用
function fun2()
	local num=10
end
function fun3()
	print(num)
end
fun3()

--函数也可以作为参数

function fun4()
	print("fun4")
end
function fun5(f)
	f()
	print("fun5")
end

fun5(fun4)