SELECT 
	username AS Name, fullname AS Name
FROM
	[Blog].[dbo].[Users]
ORDER BY fullname DESC, UserName ASC
--========================================
--========================================
SELECT 
	*
FROM
	[Blog].[dbo].[Users]
WHERE	
	id IN(SELECT	
		AuthorID
		FROM
	[Blog].[dbo].[Posts])
--========================================
--========================================
SELECT 
	[Blog].[Dbo].[Users].Username, [Blog].[Dbo].[Posts].Title
FROM	
	[Blog].[Dbo].[Users]
		JOIN
	[Blog].[Dbo].[Posts] ON [Blog].[Dbo].[Users].id = [Blog].[dbo].[Posts].AuthorID
--========================================
--========================================	
	SELECT
	UserName, FullName
FROM
	[Blog].[dbo].[Users]
WHERE
	id IN(SELECT
			AuthorId
		FROM
			[Blog].[dbo].[Posts]
		WHERE
			id = 4);
--========================================
--========================================	
SELECT MAX(AuthorId) as MAX_Value from [Blog].[dbo].[Posts]
SELECT SUM(Id) as Sum_Ids from [Blog].[dbo].[Tags]
--========================================
--========================================
USE Blog;
GO
SELECT Id, AuthorId, Date 
FROM Blog.dbo.Posts
WHERE AuthorId >= 9 
ORDER BY Id ASC;
GO
--========================================
--========================================
