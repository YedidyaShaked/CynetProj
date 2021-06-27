# CynetProj

The app runs with an SqlServer database
Change the connection in the appsettings.json file to match your database info.
In the terminal run 'dotnet ef database update'.
Add some employees to the employee table.
Run the app and find the 'Swagger UI' at https://localhost:5001/swagger/.

You can add employees using this code:

insert into Employees values('Yedidya Shaked','ddshaked1@gmail.com',0);
insert into Employees values('Moshe Cohen','moshec@gmail.com',0);
insert into Employees values('nelly','nelly@gmail.com',0);
insert into Employees values('Shimon Bell','shimonb@gmail.com',0);
insert into Employees values('Avi Tate','avit@gmail.com',0);
insert into Employees values('Yoni Shaked','yonisak@gmail.com',0);

Thanks :)
