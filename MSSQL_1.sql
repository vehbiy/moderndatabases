create table City
(
	Code int primary key,
	Name varchar(100)
)

create table Person
(
	Id int primary key identity(1, 1),
	Name varchar(100),
	Surname varchar(200),
	Email varchar(100) not null unique,
	CityId int not null foreign key references City(Code),
	InsertTime datetime not null default (getdate())
)

select * from City
select * from Person

insert into City(Code, Name) values (34, 'Istanbul')
insert into City(Code, Name) values (6, 'Ankara')
---------------------------------------------------------------------------------------------
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


SELECT * FROM sys.dm_db_missing_index_details
SELECT * FROM  sys.dm_db_missing_index_groups
SELECT * FROM sys.dm_db_missing_index_group_stats

set statistics time on
set statistics profile off

select *
from person.person
where firstname like '%Crystal%'
go

SELECT * FROM Person.Person where rowguid = 'B1F04EEF-133F-406D-BCA5-33857AEE0606'

select top 10 *
from person.person
order by BusinessEntityId desc
go


SELECT * FROM [Person].[Address] where AddressLine1 like '%scenic%'

SELECT p.FirstName + ' ' + p.LastName, pa.AddressLine1 + ' ' + pa.AddressLine2 as addr FROM Person.Person p
	join Person.BusinessEntityAddress bea on p.BusinessEntityID = bea.BusinessEntityID
	join Person.Address pa on bea.AddressID = pa.AddressID
	where pa.AddressLine1 + ' ' + pa.AddressLine2 is not null

SELECT * FROM Person.Person p
	full join Person.BusinessEntityAddress bea on p.BusinessEntityID = bea.BusinessEntityID
	full join Person.Address pa on bea.AddressID = pa.AddressID
	--where pa.AddressLine1 + ' ' + pa.AddressLine2 is not null


SELECT * FROM Person.Person p
	full join Person.BusinessEntityAddress bea on p.BusinessEntityID = bea.BusinessEntityID

SELECT * FROM Person.Person where BusinessEntityID not in (SELECT BusinessEntityID FROM Person.BusinessEntityAddress)
SELECT * FROM Person.BusinessEntityAddress where BusinessEntityID not in (SELECT BusinessEntityID FROM Person.Person)


SELECT * FROM Person.Person where BusinessEntityID not in (SELECT BusinessEntityID FROM Person.BusinessEntityAddress)

select * from Person.Person p
	left join Person.BusinessEntityAddress be on p.BusinessEntityID = be.BusinessEntityID
	where be.AddressID is null