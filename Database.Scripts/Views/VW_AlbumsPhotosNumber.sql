CREATE VIEW dbo.VW_AlbumsPhotosNumber
AS
SELECT 
	AlbumId,
	COUNT(Id) Number
FROM
	dbo.PhotoInAlbum
GROUP BY
	AlbumId