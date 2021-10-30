using EmployeeAPI.DAL;
using EmployeeAPI.Data.Entities;
using EmployeeAPI.VM;
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
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeVM> Get()
        {
            return EmployeeDAL.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeVM Get(int id)
        {
            return EmployeeDAL.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool add([FromBody] EmployeeAddVM employee)
        {
return            EmployeeDAL.Add(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public bool update(int id, [FromBody] Employee employee)
        {
            return EmployeeDAL.Update(id,employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return EmployeeDAL.Delete(id);
        }
    }
}