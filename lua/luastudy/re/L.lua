tab1={1,3,2,10,6}


table.insert(tab1,1)




if #tab1>1 then
	for i=1,#tab1-1 do
		for j=1,#tab1-1 do
			if tab1[j]-tab1[i]>5  then
				
				print(tab1[j])
			end
			
			
			
			
		end
		
		
		
	end
	
	
	
end