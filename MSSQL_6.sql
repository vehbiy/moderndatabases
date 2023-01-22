SELECT * FROM [HumanResources].[Employee]

SELECT * FROM [Person].[Person]
SELECT * FROM [Person].[BusinessEntity]

set statistics time on
set statistics profile off
SELECT * FROM Person.Person where FirstName like '%Alice%'
SELECT * FROM Person.Person where FirstName like '%Alice%' and LastName like '%dffd%'
SELECT FirstName, LastName FROM Person.Person where FirstName like '%Alice%'

SELECT * FROM Person.Person p
	right join Person.BusinessEntity be on p.BusinessEntityID = be.BusinessEntityID

SELECT * FROM Person.Person 
	where BusinessEntityID not in (SELECT BusinessEntityID FROM Person.BusinessEntity)

SELECT * FROM Person.Person 
	where BusinessEntityID in (SELECT BusinessEntityID FROM Person.BusinessEntity)

SELECT * FROM Person.BusinessEntity
	where BusinessEntityID not in (SELECT BusinessEntityID FROM Person.Person)

sp_help '[Person].[Person]'
sp_help '[Person].[BusinessEntity]'
sp_help '[HumanResources].[Employee]'

SELECT * FROM [Sales].[SalesPerson]
SELECT * FROM [HumanResources].[Employee]

SELECT sc.name + '.' + st.name FROM sys.tables st
	join sys.schemas sc on st.schema_id = sc.schema_id
	--where st.Name like '%territo%'
	order by st.name

SELECT * FROM sys.tables as st

SELECT * FROM sys.schemas

sp_helptext 'sys.tables'
SELECT * FROM sysobjects

create proc Test
as
	SELECT * FROM person.person
go

sp_helptext Test
sp_help 'Person.Person'


SELECT 
    t.NAME AS TableName,
    i.name as indexName,
    sum(p.rows) as RowCounts,
    sum(a.total_pages) as TotalPages, 
    sum(a.used_pages) as UsedPages, 
    sum(a.data_pages) as DataPages,
    (sum(a.total_pages) * 8) / 1024 as TotalSpaceMB, 
    (sum(a.used_pages) * 8) / 1024 as UsedSpaceMB, 
    (sum(a.data_pages) * 8) / 1024 as DataSpaceMB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
WHERE 
    t.NAME NOT LIKE 'dt%' AND
    i.OBJECT_ID > 255 AND   
    i.index_id <= 1
GROUP BY 
    t.NAME, i.object_id, i.index_id, i.name 
ORDER BY 
    DataSpaceMB desc


alter proc UpdatePersonAndBusinessEntity
	@BusinessEntityID int,
	@FirstName varchar(100),
	@LastName varchar(100)
as
	begin tran
	update Person.Person 
		set FirstName = @FirstName,
			LastName = @LastName
		where BusinessEntityID = @BusinessEntityID

	if(@@ROWCOUNT = 0)
	begin
		rollback
		return
	end
	update Person.BusinessEntity set ModifiedDate = getdate()
		where BusinessEntityID = 16104
	if(@@ROWCOUNT = 0)
	begin
		rollback
		return
	end

	commit
go

select newid()


-- Lock sample should be executed in two seperate windows
begin tran
update Person.Person 
	set FirstName = 'gdsdsds',
		LastName = 'dssddsdsds'
	where BusinessEntityID = 16104

rollback

SELECT * FROM Person.Person (nolock) where BusinessEntityID = 16104
-- Lock sample
