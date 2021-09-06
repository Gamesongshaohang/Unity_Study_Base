--pairs  可以适用于键值对和其他的类型table，字符串的只能用这个
--ipairs  用于数组类型的table


str={"1","2","3"}
for i,v in ipairs(str) do
print(i,v)	
	
end

str1={a="das",b="dsad"}--#测不出键值对类型的table
--print(#str1)


--获取表中最大的数据
Array={10,20,5,3,6,7,8,9,100}

function max1(shu)
	 MaxNumber = nil
	
	--检查传进来的是否为表
	if(type(shu)) ~= "table" then
		print("传入的不是表")
	
   end

	for i,v in pairs(shu)	do
		if(MaxNumber==nil) then
			MaxNumber=v
			--print(v)
		end
		
		if(v>MaxNumber)  then
			MaxNumber=v
			--print(v)
			
		end
		
		
	end
	return MaxNumber
end
print("as")
print(max1(Array))

