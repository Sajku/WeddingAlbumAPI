CREATE VIEW dbo.VW_AlbumsPhotos
AS
SELECT
	pia.AlbumId,
	p.Id,
	p.Base64
FROM
	dbo.PhotoInAlbum pia
JOIN
	dbo.Photo p ON pia.PhotoId = p.Id