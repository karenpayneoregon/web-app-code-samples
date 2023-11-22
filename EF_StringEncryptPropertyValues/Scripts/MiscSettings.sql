SELECT m.Id,
       m.Name,
       m.TheEnumId,
       t.TypeName
FROM dbo.MiscSettings AS m
    INNER JOIN dbo.TheEnum AS t
        ON m.Id = t.Id;