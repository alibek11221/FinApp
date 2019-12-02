CREATE PROCEDURE [dbo].[spArticles_AddAritcle]
	@ArticleName NVARCHAR(128)
AS
BEGIN
	INSERT INTO [dbo].[Articles](ArticleName)
	values (@ArticleName)
END
