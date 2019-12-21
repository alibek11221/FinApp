CREATE PROCEDURE [dbo].[spArticles_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	SELECT ArticleName, Id
	FROM [dbo].[Articles]
END