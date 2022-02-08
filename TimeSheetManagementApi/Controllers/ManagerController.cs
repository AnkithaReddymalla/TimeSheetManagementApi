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
    public class ManagerController : ControllerBase
    {
        private ManagerServices _managerServices;
        public ManagerController(ManagerServices managerServices)
        {
            _managerServices = managerServices;
        }
        [HttpGet("AllocateProject")]
        public Employee AllocateProject(int EmpID)
        {
            return _managerServices.AllocateProject(EmpID);

        }

        [HttpPut("AllocateProject")]
        public IActionResult AllocateProject([FromBody] Employee employee)
        {
            _managerServices.AllocateProject(employee);
            return Ok("Project Allocated successfully!!");
        }
        [HttpGet("ChangeEmpPsw")]
        public Employee ChangeEmpPsw(int EmpID)
        {
            return _managerServices.ChangeEmpPsw(EmpID);

        }

        [HttpPut("ChangeEmpPsw")]
        public IActionResult ChangeEmpPsw([FromBody] Employee employee)
        {
            _managerServices.ChangeEmpPsw(employee);
            return Ok("Password Changed successfully!!");
        }

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees(int MgrID)
        {
            return _managerServices.GetEmployees(MgrID);
        }

        [HttpGet("GetTimeSheetByID")]
        public TimeSheet GetTimeSheetByID(int EmpID)
        {
            return _managerServices.GetTimeSheetByID(EmpID);
        }
        [HttpGet("TimeSheetRelease")]
        public TimeSheet TimeSheetRelease(int TimeSheetID)
        {
            return _managerServices.TimeSheetRelease(TimeSheetID);

        }

        [HttpPut("TimeSheetRelease")]
        public IActionResult TimeSheetRelease([FromBody] TimeSheet timeSheet)
        {
            _managerServices.TimeSheetRelease(timeSheet);
             return Ok("TimeSheet Released successfully!!");
        }
    }
}
