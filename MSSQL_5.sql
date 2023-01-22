declare @firstDate datetime
declare @date1 datetime
declare @price decimal
declare @cumulativePrice decimal
set @cumulativePrice = 0
declare cur insensitive cursor for
	select convert(date, ModifiedDate), sum(OrderQty * UnitPrice) 
		from Sales.SalesOrderDetail 
		group by convert(date, ModifiedDate) 
		order by convert(date, ModifiedDate)
open cur
	fetch next from cur into @date1, @price
	set @firstDate = @date1
	while(@@FETCH_STATUS <> -1)
	begin	
		set @cumulativePrice = @cumulativePrice + @price
		fetch next from cur into @date1, @price
		print(convert(varchar(20), @firstDate) + '-' + convert(varchar(20), @date1) + ': ' + convert(varchar(10), @cumulativePrice))
	end
close cur
deallocate cur