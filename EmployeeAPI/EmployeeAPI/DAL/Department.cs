using EmployeeAPI.Data;
using EmployeeAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.DAL
{
    public static class DepartmentDAL
    {
        //get all employee
        public static List<Department> GetAll()
        {
            using (var db = new DBContext())
            {
                return db.Departments.ToList();
            }
        }
        //get Department by id
        public static Department Get(int id)
        {
            using (var db = new DBContext())
            {
                return db.Departments.FirstOrDefault(e => e.Id == id);
            }
        }
        //add Department
        public static bool Add(Department Department)
        {
            using (var db = new DBContext())
            {
                try
                {
                    db.Departments.Add(Department);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //update Department
        public static bool Update(int id, Department editDepartment)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var Department = db.Departments.FirstOrDefault(e => e.Id == id);
                    if (Department == null)
                        return false;

                    Department.Name = editDepartment.Name;
                    db.Departments.Update(Department);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Delete Department
        public static bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var Department = db.Departments.FirstOrDefault(e => e.Id == id);
                if (Department == null)
                    return false;
                try
                {
                    db.Departments.Remove(Department);
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