USE B_DB14_2018;
GO

ALTER VIEW AllEmployees
AS
SELECT emp.Emp_Id, emp.FName, emp.LName, dep.Dept_Name, emp.Zip, zip.City, man.Manager
FROM
    EX62_Employee AS emp
    JOIN EX62_Manager AS man
        ON emp.Dep_Id = man.Dep_Id
    JOIN EX62_ZipCity AS zip
        ON emp.Zip = zip.Zip
    JOIN EX62_Department AS dep
        ON emp.Dep_Id = dep.Dep_Id
GO
