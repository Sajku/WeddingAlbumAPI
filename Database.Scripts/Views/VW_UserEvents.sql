CREATE VIEW dbo.VW_UserEvents
AS
SELECT 
	e.Id,
	e.Name,
	e.Date,
	uie.IsAdmin,
	uie.IsOwner,
	uie.UserId
FROM
    dbo.Event e 
LEFT JOIN
    dbo.UserInEvent uie ON e.Id = uie.EventId
	