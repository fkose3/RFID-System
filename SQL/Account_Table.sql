CREATE TABLE Account
(
	id int identity(1,1) PRIMARY KEY,
	acc varchar(21) ,
	pwd varchar(100) ,
	name varchar(35),
	surname varchar(35)
)