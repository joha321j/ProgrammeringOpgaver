USE B_DB14_2018
GO

CREATE VIEW Administration
AS
SELECT emp.FName, emp.LName, emp.Zip, zip.City
FROM EX62_Employee AS emp
    JOIN EX62_ZipCity AS zip
        ON emp.Zip = zip.Zip
WHERE emp.Dep_id = 1
GO
