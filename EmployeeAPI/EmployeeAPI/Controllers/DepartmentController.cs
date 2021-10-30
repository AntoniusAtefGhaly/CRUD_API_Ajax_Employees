using EmployeeAPI.DAL;
using EmployeeAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return DepartmentDAL.GetAll();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return DepartmentDAL.Get(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public bool add([FromBody] Department Department)
        {
return            DepartmentDAL.Add(Department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public bool update(int id, [FromBody] Department Department)
        {
            return DepartmentDAL.Update(id,Department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return DepartmentDAL.Delete(id);
        }
    }
}