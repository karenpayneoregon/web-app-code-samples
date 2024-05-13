--- 
SELECT cust.CustomerIdentifier,
       cust.CompanyName,
       cust.ContactId,
       cd.PhoneNumber,
       c.FirstName,
       c.LastName,
       c.ContactTypeIdentifier
FROM dbo.Customers AS cust
    INNER JOIN dbo.Contacts AS c
        ON c.ContactId = cust.ContactId
    INNER JOIN dbo.ContactDevices AS cd
        ON cd.ContactId = c.ContactId
WHERE cust.CustomerIdentifier = 1 AND cd.PhoneTypeIdentifier = 3;



