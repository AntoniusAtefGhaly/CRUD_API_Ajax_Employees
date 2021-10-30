using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.VM
{
    public class EmployeeVM
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiringDate { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
