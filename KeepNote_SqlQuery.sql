use ado_demos

create table Keep_Note(
	ID int identity primary key,
	Title varchar(10),
	Description varchar(50),
	Date date
)

--drop table Keep_Note
select * from Keep_Note