using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetManagement.BAL.Services;
using TimeSheetManagement.Entity.Models;

namespace TimeSheetManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private AdminServices _adminServices;
        public AdminController(AdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        #region Employee

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _adminServices.GetEmployees();
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _adminServices.AddEmployee(employee);
            return Ok("Employee created successfully!!");
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmpID)
        {
            _adminServices.DeleteEmployee(EmpID);
            return Ok("Movie deleted successfully!!");
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _adminServices.UpdateEmployee(employee);
            return Ok("Employee updated successfully!!");
        }
        #endregion

       
        #region Project

        [HttpGet("GetProjects")]
        public IEnumerable<Project> GetProjects()
        {
            return _adminServices.GetProjects();
        }
        [HttpPost("AddProject")]
        public IActionResult AddProject([FromBody] Project project)
        {
            _adminServices.AddProject(project);
            return Ok("Project created successfully!!");
        }
        [HttpDelete("DeleteProject")]
        public IActionResult DeleteProject(int ProjectID)
        {
            _adminServices.DeleteProject(ProjectID);
            return Ok("Project deleted successfully!!");
        }
        [HttpPut("UpdateProject")]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            _adminServices.UpdateProject(project);
            return Ok("Project updated successfully!!");
        }
        [HttpGet("GetProjectByID")]
        public Project GetProjectByID(int ProjectID)
        {
            return _adminServices.GetProjectByID(ProjectID);

        }
        #endregion
    }
}
