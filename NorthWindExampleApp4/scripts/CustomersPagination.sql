

    DECLARE @StartPositon AS INT = 10;
    DECLARE @EndPosition AS INT = 15;

    SELECT c.CustomerIdentifier,
           c.City,
           c.CompanyName,
           c.ContactId,
           c.ContactTypeIdentifier,
           c.CountryIdentifier,
           c.ModifiedDate,
           c.Phone,
           c.PostalCode,
           c.Street,
           c0.[Name] AS Country,
	       c2.ContactTitle,
           c1.FullName
    FROM dbo.Customers AS c
        LEFT OUTER JOIN dbo.Countries AS c0
            ON c.CountryIdentifier = c0.CountryIdentifier
        LEFT OUTER JOIN dbo.Contacts AS c1
            ON c.ContactId = c1.ContactId
        LEFT OUTER JOIN dbo.ContactType AS c2
            ON c1.ContactTypeIdentifier = c2.ContactTypeIdentifier
    ORDER BY c.CustomerIdentifier OFFSET @StartPositon * 1 - 1 ROWS FETCH NEXT @EndPosition ROWS ONLY;

    
    SELECT  Paged.RowNum, Paged.CustomerIdentifier, Paged.CompanyName,  Paged.ContactId,
            Paged.Street, Paged.City, Paged.PostalCode, Paged.CountryIdentifier,  Paged.Phone,
            Paged.ContactTypeIdentifier,  Paged.ModifiedDate
    FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY CompanyName) AS RowNum, *
              FROM      dbo.Customers
            ) AS Paged
    WHERE   RowNum >= @StartPositon
        AND RowNum < @EndPosition  
    ORDER BY RowNum

