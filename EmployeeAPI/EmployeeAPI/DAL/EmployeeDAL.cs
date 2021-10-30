using EmployeeAPI.Data;
using EmployeeAPI.Data.Entities;
using EmployeeAPI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DAL
{
    public static class EmployeeDAL
    {
        //get all employee
        public static List<EmployeeVM> GetAll()
        {
            using (var db = new DBContext())
            {
                var employeesVM= db.Employees.ToList();
                List<EmployeeVM> employees=new List<EmployeeVM>();
                foreach(var e in employeesVM)
                {
                    e.Department = db.Departments.FirstOrDefault(d=>d.Id==e.DepartmentId);
                    employees.Add(
                        new EmployeeVM{
                        Id=e.Id,
                        Name=e.Name,
                        Title=e.Title,
                        BirthDate=e.BirthDate,
                        Department=e.Department.Name,
                        HiringDate=e.HiringDate
                    }
                        );
                }
                return employees;
            }
        }
        //get employee by id
        public static EmployeeVM Get(int id)
        {
            using (var db = new DBContext())
            {
                var e= db.Employees.FirstOrDefault(e=>e.Id==id);
                e.Department = db.Departments.FirstOrDefault(d => d.Id == e.DepartmentId);

                return new EmployeeVM
                {
                    Id = e.Id,
                    Name = e.Name,
                    Title = e.Title,
                    BirthDate = e.BirthDate,
                    Department = e.Department.Name,
                    HiringDate = e.HiringDate,
                    DepartmentId=e.DepartmentId
                };

            }
        }
        //add employee
        public static bool Add(EmployeeAddVM employee)
        {
            using (var db = new DBContext())
            {
               

                try
                {
                    var department=db.Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
                    if (department == null)
                        return false;

                    Employee emp = new Employee
                    {
                        BirthDate = employee.BirthDate,
                        DepartmentId = employee.DepartmentId,
                        HiringDate = employee.HiringDate,
                        Name = employee.Name,
                        Title = employee.Title
                    };

                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //update employee
        public static bool Update(int id, Employee editEmployee)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var employee = db.Employees.FirstOrDefault(e => e.Id == id);
                    if (employee == null)
                        return false;

                    employee.BirthDate = editEmployee.BirthDate;
                    employee.Name = editEmployee.Name;
                    employee.DepartmentId = editEmployee.DepartmentId;
                    employee.HiringDate = editEmployee.HiringDate;
                    employee.Title = editEmployee.Title;
                    db.Employees.Update(employee);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Delete employee
        public static bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var employee = db.Employees.FirstOrDefault(e=>e.Id==id);
                if (employee == null)
                    return false;
                try
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}