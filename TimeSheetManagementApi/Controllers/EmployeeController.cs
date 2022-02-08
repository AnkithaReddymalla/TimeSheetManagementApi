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
    public class EmployeeController : ControllerBase
    {
        private EmployeeServices _employeeServices;
        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost("AddTimeSheet")]
        public IActionResult AddTimeSheet([FromBody] TimeSheet timeSheet)
        {
            _employeeServices.AddTimeSheet(timeSheet);
            return Ok("TimeSheet Added successfully!!");
        }

        [HttpDelete("DeleteTimeSheet")]
        public IActionResult DeleteTimeSheet(int TimeSheetID)
        {
            _employeeServices.DeleteTimeSheet(TimeSheetID);
            return Ok("TimeSheet Deleted successfully!!");
        }
        [HttpGet("UpdateTimeSheet")]
        public TimeSheet UpdateTimeSheet(int TimeSheetID)
        {
            return _employeeServices.UpdateTimeSheet(TimeSheetID);

        }

        [HttpPut("UpdateTimeSheet")]
        public IActionResult UpdateTimeSheet([FromBody] TimeSheet timeSheet)
        {
            _employeeServices.UpdateTimeSheet(timeSheet);
            return Ok("TimeSheet Updated successfully!!");
        }
    }
}
