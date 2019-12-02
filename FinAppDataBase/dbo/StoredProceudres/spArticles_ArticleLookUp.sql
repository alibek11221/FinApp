CREATE PROCEDURE [dbo].[spArticles_ArticleLookUp]
	@ArticleName NVARCHAR(128),
	@Out INT OUTPUT
AS
BEGIN
IF 
    (SELECT COUNT(*) FROM Articles WHERE LOWER(ArticleName) = LOWER(@ArticleName)) > 0
    BEGIN
        SET @Out = 1
    END
ELSE
    BEGIN
        SET @Out = 0
    END
END
