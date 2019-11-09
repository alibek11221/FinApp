CREATE PROCEDURE [dbo].[spUsers_GetById]
	@Id nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON
	SELECT FirstName, LastName, EmailAddress
	FROM [dbo].[Users]
	WHERE Id = @Id;
END
