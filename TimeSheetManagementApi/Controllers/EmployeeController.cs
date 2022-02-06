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

        [HttpPost("AddTimeSheeet")]
        public void AddTimeSheeet([FromBody] TimeSheet timeSheet)
        {
            _employeeServices.AddTimeSheeet(timeSheet);
        }

        [HttpDelete("DeleteTimeSheet")]
        public void DeleteTimeSheet(int TimeSheetID)
        {
            _employeeServices.DeleteTimeSheet(TimeSheetID);
        }

        [HttpPut("UpdateTimeSheet")]
        public void UpdateTimeSheet([FromBody] TimeSheet timeSheet)
        {
            _employeeServices.UpdateTimeSheet(timeSheet);
        }
    }
}
