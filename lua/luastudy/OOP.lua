--面向对象模拟

--定义表相当于类
Person={}

--定义“字段”
Person.Name="男"
Person.Sex="nv"

--定义方法
function Person.Speak()
print("da")

end


function Person.showinfo()
	
	print(Person.Name)
	print(Person.Speak())
end

a=showinfo()



--self相当于java中的this关键字，本类对象
--完善类的定义1，属性及方法的定义使用self,2调用方法使用：，不是.号。
