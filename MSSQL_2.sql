begin tran
update Person.Person set FirstName = 'Test' where BusinessEntityID = 2383
rollback