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

        [HttpPut("AllocateProject")]
        public void AllocateProject([FromBody] Employee employee)
        {
            _managerServices.AllocateProject(employee);
        }

        [HttpPut("ChangeEmpPsw")]
        public void ChangeEmpPsw([FromBody] Employee employee)
        {
            _managerServices.ChangeEmpPsw(employee);
        }

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees(int MgrID)
        {
            return _managerServices.GetEmployees(MgrID);
        }

        [HttpGet(" GetTimeSheetByID")]
        public TimeSheet GetTimeSheetByID(int EmpID)
        {
            return _managerServices.GetTimeSheetByID(EmpID);
        }

        [HttpPut("TimeSheetRelease")]
        public void TimeSheetRelease([FromBody] TimeSheet timeSheet)
        {
            _managerServices.TimeSheetRelease(timeSheet);
        }
    }
}
