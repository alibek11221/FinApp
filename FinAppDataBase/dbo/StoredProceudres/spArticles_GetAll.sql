CREATE PROCEDURE [dbo].[spArticles_GetAll]
	@UserId NVARCHAR(256)
AS
BEGIN
	SET NOCOUNT ON
	SELECT ArticleName
	FROM [dbo].[Articles]
END