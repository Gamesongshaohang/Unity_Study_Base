--函数尾调用：不占用“堆栈”空间，*最重要的作用：所有不会出现栈溢出，起到优化存储空间的作用
--stack overflow(堆栈溢出)
--格式：一个函数调用另外一个函数的最后一个动作
--eg: function f(x)
	--  return g(x)  end


--当需要进行大量内存空间的时候，可以用到尾调用
function recufun(num)
	if(num>0) then
		--print(num)
		return recufun(num-1) ---尾调用：最后一句return 函数
		--return recufun(num-1)+1 ---但当+1是就不是尾调用，那么会出现stack overflow(堆栈溢出)
	
	else
	return "end"
	end
end

res=recufun(100000)
print(res)


function  a1()
	return 100,200
	
end

function b1()
	return  a1()
end

function c1()
	return (a1())
end

res1,res2=b1()
res3,res4=c1()
print(res1,res2)
print(res3,res4)  --尾调用的最后方法（a1()）,加括号强制其只返回一个参数
