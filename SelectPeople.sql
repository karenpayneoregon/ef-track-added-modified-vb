SELECT p.Id ,
       p.FirstName ,
       p.LastName ,
       p.BirthDate FROM dbo.Person AS p WHERE p.FirstName IS NULL OR p.LastName IS NULL
