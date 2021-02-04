use WFA3DotNet

create proc sp_UpdateEmp
@empid int,
@empname varchar(20),
@esal float,
@deptid int
as
begin
update EmployeeTab set Empname=@empname,Salary=@esal,DeptNo=@deptId where Empid=@empid
end
select * from EmployeeTab
execute sp_UpdateEmp 14,'Span',567.56,11
select * from PastEmpTy

alter proc sp_Details
@empid int

as
begin
--select empname=@empname,Salary=@esal,Deptno=@deptid  from EmployeeTab where empid=@empid 
--select * from EmployeeTab where empid=@empid;
select e1.empid,e1.empname,e1.salary,e1.DeptNo,d1.deptname from EmployeeTab e1 join DeptTab d1
on e1.deptno=d1.deptid
where empid=@empid
end

exec sp_Details 9

alter proc sp_InsertEmployee
@empname varchar(20),
@esal float,
@deptid int
 as
begin
insert into EmployeeTab(empname,salary,deptNo)
values(@empname,@esal,@deptid)
End

execute sp_InsertEmployee'Pratusha',245.78,11
select * from EmployeeTab

create proc sp_DeleteEmployee
@empid int
as
begin
delete from employeetab where empid=@empid
end

execute sp_DeleteEmployee 13