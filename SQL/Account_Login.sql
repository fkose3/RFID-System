Alter PROCEDURE Account_Login
	@nRet tinyint output,
	@acc varchar(21),
	@pwd varchar(100)
as 
	DECLARE @Count int
	
	SELECT @Count=COUNT(*) FROM Account where acc=@acc AND pwd=@pwd 
	
	IF @Count < 1
		BEGIN
			SET @nRet = 3
		END
	ELSE
		BEGIN
			SELECT @Count=COUNT(*) FROM Account where acc=@acc AND pwd=@pwd AND Authorty=255
		
			IF @Count > 0
				BEGIN
					Set @nRet = 2
				END
			ELSE
				BEGIN
					SET @nRet = 1
				END
		END
Go