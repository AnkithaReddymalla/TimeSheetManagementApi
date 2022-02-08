using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetEmployeeByID")]
        public Employee GetEmployeeByID(int EmpID)
        {
            return _adminServices.GetEmployeeByID(EmpID);

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
            return Ok("Employee deleted successfully!!");
        }
        [HttpGet("UpdateEmployee")]
        public Employee UpdateEmployee(int EmpID)
        {
            return _adminServices.UpdateEmployee(EmpID);

        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _adminServices.UpdateEmployee(employee);
            return Ok("Employee updated successfully!!");
        }
        [HttpGet("AssignManager")]
        public Employee AssignManager(int EmpID)
        {
            return _adminServices.AssignManager(EmpID);

        }

        [HttpPut("AssignManager")]
        public IActionResult AssignManager([FromBody] Employee employee)
        {
            _adminServices.AssignManager(employee);
            return Ok("Manager Assigned successfully!!");
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
        [HttpGet("UpdateProject")]
        public Project UpdateProject(int ProjectID)
        {
            return _adminServices.UpdateProject(ProjectID);

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
