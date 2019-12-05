CREATE PROCEDURE [dbo].[spArticles_GetAll]
AS
BEGIN
	SET NOCOUNT ON
	SELECT ArticleName
	FROM [dbo].[Articles]
END