--1,if语句

--1.1if()  then  end   

if true then
	print("单分支语句")
end

--1.2 多分支语句

local num1=100
local num2=200
   if num1>num2 then
	print("")
   elseif num1<num2 then 
	print("多分支语句")
	else
	print("")
end


--2,循环控制
--while(条件)  do  end
i=1
while   i<=4  do
print(i)
i=i+1
end
--repeat  until(条件)，先循环再判断，而且是只有为true才会停止
j =1 

repeat
print("先循环再判断"..tostring(j))
until (true)

--3，*for循环  for i=1,10 do     print(i) end

--3,for循环类型：
--3.1   -泛型for循环  pairs 一般用于键值对的遍历
--3.2   -数值循环 一般用于数组类型的遍历 ipairs,(中间序号不能中断，遇到nil会停止)一
--

maArray={1,2,3}
for k in ipairs(maArray) do
	print(k)
end
maArray2={n1="asd",n2="da",n3="da"}

for k,v in pairs(maArray2) do
	print(k,v)
end

--一般用pairs即可，lua中没有continue,只有break(终止循环)
for i=1,100 do
	print(i)
	if(i>3) then
		break    --跳出循环
	end
end

--迭代器类型
--io.lines,pairs,ipairs,string.gmatch