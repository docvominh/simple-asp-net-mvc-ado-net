
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<MinhPD>
-- Create date: <2016-10/14>
-- Description:	<Get list user base on input condition>
-- =============================================
CREATE PROCEDURE uspGetListUser
	
	--Input parameter
	@userId VARCHAR,
    @userName VARCHAR,
    @email VARCHAR,
	@active BIT
AS
BEGIN

	DECLARE @localVariable VARCHAR
	SET @localVariable = 'some value'

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		U.UserId		AS UserId,
		U.UserName		AS Username,
		U.Email			AS Email,
		U.LastLogin		AS LastLogin,
		U.Active		AS Active
	FROM 
		Users U
	WHERE
		(@userId IS NOT NULL OR U.UserID LIKE @userId)
		OR (@userName IS NOT NULL OR U.Username LIKE @userName)
		OR (@email IS NOT NULL OR U.Email LIKE @email)
		OR (@active IS NOT NULL OR U.Active LIKE @active)
				
END
GO


EXEC uspGetListUser 'minhpd', '', '', ''