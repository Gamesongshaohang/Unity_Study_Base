--字符串



--1,特殊多行字符串
str=[[
dasdsad
dasdsa
dsadsa
dsadsa
一般网页开发
]]
print(str)

--2,字符串的连接 ..
str="123"
print(str..str)

--3,字符串转换
print("2.2"+"30")  --把数字型字符串自动转为数值类型
print("2.2"+10)    --把数字型字符串自动转为数值类型

--4,#获取字符串长度
str="abc"
str1="你好啊"  --一个汉字长度是2
print(#str)
print(#str1)


--，5字符串与其他类型的转换
--toNumber,tostring

strNum1="888"
num2=666

--tonumber("数值")把字符串转为number类型
num1=tonumber(strNum1)
print(type(num1))

--tostring()把数值转为字符串
strNum2=tostring(num2)
print(type(strNum2))

--不过lua有自动转换，但是有的时候还是会使用到number或者string类型

--例子，必须使用tostring的场合1
numtab={1,2,3}
---print("da"..numtab)   会报错系统自动table转为字符串,但是表不能自动转为字符串，这时可以用到tostring

print("字符串连接表"..tostring(numtab))   --这时tostring可以输出表的地址

--场合2
num=nil                 --nil也是不能自动转换为字符串的，必须使用tostring
print("num="..tostring(num))


