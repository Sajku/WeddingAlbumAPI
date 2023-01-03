CREATE VIEW dbo.VW_EventAlbums
AS
SELECT
	a.UserId,
	a.Id as AlbumId,
	a.Name as Title,
	p.Base64 as MainPhotoBase64,
	a.EventId,
	a.IsPrivate
FROM
	dbo.Album a
JOIN
	dbo.Photo p ON a.MainPhotoId = p.Id