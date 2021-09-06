--函数嵌套
function f1()
	function f2()
		
		print("f2")
	end
	return f2()
end


--面试的考点：闭包

function f3(x)
	--改变了传入参数x的生命周期
	--本来x=10传入后生命周期就结束了，但是现在被内部函数使用
	--
	return function(y) --匿名函数
	    return x+y
	end
	
end

f4=f3(10)
print(f4(10))

