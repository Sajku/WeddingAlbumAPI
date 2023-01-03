CREATE VIEW dbo.VW_PhotoComments
AS
select com.Id as CommentId, 
CONCAT(u.Name, ' ', u.LastName) as AuthorName,
com.Date, 
com.Content, 
com.LikesCount,
com.PhotoId from dbo.Comment com 
left join dbo.[User] u on com.UserId = u.Id