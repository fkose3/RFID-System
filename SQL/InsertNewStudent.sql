CREATE PROCEDURE NewStudent
@nRet tinyint output,
@name varchar(50),
@surn varchar(50),
@number int ,
@adress varchar(250),
@tel1 varchar(10),
@tel2 varchar(10),
@bday varchar(20),
@card_num varchar(150)
AS
	DECLARE @num int 
	
	select @num = COUNT(*) fROM Student where number = @number
	
	IF @num > 0
		BEGIN
			SET @nRet = 1
			RETURN 
		END	
	ELSE
		BEGIN
			select @num = COUNT(*) FROM Student where card_number = @card_num
			
			IF @num > 0
			   BEGIN 
					SET @nRet = 2
					RETURN
			   END
		END
	
	
	INSERT INTO Student (student_name,student_surn,number,adres,tel1,tel2,birthday,savedate,card_number) 
				VALUES  (@name,@surn,@number,@adress,@tel1,@tel2,@bday,GETDATE(),@card_num)
				
	Set @nRet = 3
	return
go