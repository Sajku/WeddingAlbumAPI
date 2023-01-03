CREATE VIEW dbo.VW_FavAlbumsInEvent
AS
SELECT
	ufa.UserId,
	a.Id as AlbumId,
	a.Name as Title,
	p.Base64 as MainPhotoBase64,
	a.EventId
FROM 
	dbo.UserFavouriteAlbum ufa
JOIN
	dbo.Album a ON ufa.AlbumId = a.Id
JOIN
	dbo.Photo p ON a.MainPhotoId = p.Id