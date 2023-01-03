CREATE VIEW dbo.VW_PhotoDetails
AS
SELECT
	p.Id,
	p.Base64,
	p.Description,
	p.Date,
	CONCAT(u.Name, ' ', u.LastName) as AuthorName
FROM
	dbo.Photo p 
LEFT JOIN
	dbo.[User] u on p.UserId = u.Id